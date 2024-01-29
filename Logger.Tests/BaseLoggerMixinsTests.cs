using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests;

[TestClass]
public class BaseLoggerMixinsTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Error_WithNullLogger_ThrowsException()
    {
        // Act
        BaseLoggerMixins.Error(null!, "");
    }

    [TestMethod]
    public void Error_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Error("Message {0}", 42.ToString());

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }

}

public class TestLogger(string className) : BaseLogger(className)
{
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();


    public override void Log(LogLevel logLevel, string message)
    {
        LoggedMessages.Add((logLevel, message));
    }
}
