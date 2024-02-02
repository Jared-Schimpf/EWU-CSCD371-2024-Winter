using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class SerializableLogger : ILogger, ISerializable
    {
        public string ClassName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static ILogger Create(string className, string filePath)
        {
            throw new NotImplementedException();
        }

        public string Deserialize(string input)
        {
            throw new NotImplementedException();
        }

        public void Log(LogLevel logLevel, string message)
        {
            throw new NotImplementedException();
        }

        public string Serialize(string input)
        {
            throw new NotImplementedException();
        }
    }
}