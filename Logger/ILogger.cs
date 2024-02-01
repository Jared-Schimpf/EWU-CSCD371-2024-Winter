using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public interface ILogger
    {
        string ClassName { get; set; }
        abstract static ILogger Create(string className, string filePath);

        void Log(LogLevel logLevel, string message);
    }
}