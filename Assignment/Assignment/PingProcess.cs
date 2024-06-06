using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput); 

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new("ping"); 

    public PingResult Run(string hostNameOrAddress)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder??=new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return new PingResult( process.ExitCode, stringBuilder?.ToString());
    }

    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        return RunAsync(hostNameOrAddress);
    }




    async public Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        
        void updateStdOutput(string? line) =>
            (stringBuilder??=new StringBuilder()).AppendLine(line);
        
        Task<PingResult> task = Task.Run(() =>
        {
            cancellationToken.ThrowIfCancellationRequested();
            Process process = RunProcessInternal(
                StartInfo, updateStdOutput, default, cancellationToken);
            return new PingResult(process.ExitCode, stringBuilder?.ToString());
        });
        
        return await task.WaitAsync(cancellationToken);
    }


    //this is the only item that wasn't already fully implemented in the solution.
    async public Task<PingResult> RunAsync(  
        params string[] hostNameOrAddresses)
    {
        //removed: StringBuilder? stringBuilder = null; //define INSIDE select, this also stops the outputs from being intermingled
        //changed: ParallelQuery<Task<int>>? all //we dont want just the exitcode with this stringbuilder impl


        ParallelQuery<Task<PingResult>>? all = hostNameOrAddresses.AsParallel().Select(async item =>
        {
            StringBuilder? stringBuilder = null;  //when created INSIDE the select statement we prevent multiple tasks from using the same stringbuilder in parallel
            StartInfo.Arguments = item;

            void updateStdOutput(string? line) => (stringBuilder??=new StringBuilder()).AppendLine(line);
            
            Task<PingResult> task = Task.Run(() =>
            {
                Process process = RunProcessInternal(
                    StartInfo, updateStdOutput, default, default);
                return new PingResult(process.ExitCode, stringBuilder?.ToString());
            });
            await task.WaitAsync(default(CancellationToken));
            return task.Result; //removed .ExitCode; //we want to return the whole result
        });

        PingResult[] results = await Task.WhenAll(all); //easier way of collecting the results of all tasks
       
        //removed: int total = all.Aggregate(0, (total, item) => total + item.Result); 
        int total = results.Sum(result => result.ExitCode);
        string combinedOutputs = string.Join(Environment.NewLine, results.Select(result => result.StdOutput)); //no longer have to use stringbuilder


        return new PingResult(total, combinedOutputs);
    }


    public Task<PingResult> RunLongRunningAsync( 
        string hostNameOrAddress, CancellationToken cancellationToken = default) //Essentially same as RunAsync except instead of using Task.run it uses Task factory
    {
       StringBuilder? stringBuilder = null;
        StartInfo.Arguments = hostNameOrAddress;
        void updateStdOutput(string? line) =>
            (stringBuilder??=new StringBuilder()).AppendLine(line);
        return Task.Factory.StartNew(() => 
        {
            cancellationToken.ThrowIfCancellationRequested();
            Process process = RunProcessInternal(
                StartInfo, updateStdOutput, default, cancellationToken);
            return new PingResult(process.ExitCode, stringBuilder?.ToString());
        }, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Current);
    }












    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        var process = new Process
        {
            StartInfo = UpdateProcessStartInfo(startInfo)
        };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorHandler;

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(obj =>
            {
                if (obj is Process p && !p.HasExited)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Win32Exception ex)
                    {
                        throw new InvalidOperationException($"Error cancelling process{Environment.NewLine}{ex}");
                    }
                }
            }, process);


            if (process.StartInfo.RedirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }
            if (process.StartInfo.RedirectStandardError)
            {
                process.BeginErrorReadLine();
            }

            if (process.HasExited)
            {
                return process;
            }
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'{Environment.NewLine}{e}");
        }
        finally
        {
            if (process.StartInfo.RedirectStandardError)
            {
                process.CancelErrorRead();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                process.CancelOutputRead();
            }
            process.OutputDataReceived -= OutputHandler;
            process.ErrorDataReceived -= ErrorHandler;

            if (!process.HasExited)
            {
                process.Kill();
            }

        }
        return process;

        void OutputHandler(object s, DataReceivedEventArgs e)
        {
            progressOutput?.Invoke(e.Data);
        }

        void ErrorHandler(object s, DataReceivedEventArgs e)
        {
            progressError?.Invoke(e.Data);
        }
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        return startInfo;
    }
}