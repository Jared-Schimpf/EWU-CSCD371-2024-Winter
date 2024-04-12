using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void Log_AppendsToFile()
    {   
        LogFactory factory = new LogFactory();
        factory.configureFileLogger("test.txt");

        BaseLogger logger = factory.CreateLogger(nameof(FileLoggerTests));
        logger.Log(LogLevel.Information, "test");
        
        string fileContents = File.ReadAllText("test.txt");
        Assert.IsTrue(fileContents.Contains($"FileLoggerTests Information: test"));

        File.Delete("test.txt");
    }
}
