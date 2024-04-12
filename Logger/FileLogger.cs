using System;
using System.IO;

namespace Logger;

public class FileLogger : BaseLogger
{
    private readonly string _filePath;

    public FileLogger(string filePath) => _filePath = filePath;

    public override void Log(LogLevel logLevel, string message)
    {   
        string dateTime = DateTime.Now.ToString("MM/dd/yyy hh:mm:ss tt");
        string log = $"{dateTime} {ClassName} {logLevel}: {message}";
        
         File.AppendAllText(_filePath, log);
    }
}

