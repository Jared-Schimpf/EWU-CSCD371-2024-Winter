using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public class FileLogger : BaseLogger, IDisposable, ILogger
{
    public FileLogger(string className, string filePath) : base(className)
    {
        FilePath = filePath;
        File = new FileInfo(filePath);
    }



    public string FilePath { get; }
    private FileInfo File { get; }
    string ILogger.ClassName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    void IDisposable.Dispose()
    {
        throw new NotImplementedException();
    }

    void Dispose()
    {

    }

    public override void Log(LogLevel logLevel, string message)
    {
        using StreamWriter writer = File.AppendText();
        writer.WriteLine($"{DateTime.Now}, {ClassName}, {logLevel}, {message}");
    }

    public static ILogger Create(string className, string filePath)
    {
        return new FileLogger(className, filePath);
    }
}
