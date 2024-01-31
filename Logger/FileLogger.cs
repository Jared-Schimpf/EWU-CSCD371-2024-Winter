using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public class FileLogger : BaseLogger, ISerializable, IDisposable
{
    public FileLogger(string className, string filePath) : base(className)
    {
        FilePath = filePath;
        File = new FileInfo(filePath);
    }

    public string FilePath { get; }
    private FileInfo File { get; }

    public override void Log(LogLevel logLevel, string message)
    {
        using StreamWriter writer = File.AppendText();
        writer.WriteLine($"{DateTime.Now}, {ClassName}, {logLevel}, {message}");
    }
}
