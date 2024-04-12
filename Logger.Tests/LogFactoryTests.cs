using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    readonly LogFactory _factory = new LogFactory();

    [TestMethod]
    public void CreateLogger_ReturnsNullIfUnconfigured()
    {
        // Arrange

        // Act
        BaseLogger logger = _factory.CreateLogger(nameof(LogFactoryTests));

        // Assert
        Assert.IsNull(logger);
    }

    [TestMethod]
    public void CreateLogger_CreatesLoggerWhenConfigured()
    {
        // Arrange

        // Act
        _factory.configureFileLogger("path.txt");
        BaseLogger logger = _factory.CreateLogger(nameof(LogFactoryTests));

        // Assert
        Assert.IsNotNull(logger);
    }


}
 