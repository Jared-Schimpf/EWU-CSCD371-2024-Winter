using Xunit;

namespace Logger.Tests;

public class LogFactoryTests : FileLoggerTestsBase
{
    [Fact]
    public void ConfigureFileLogger_GivenFilePath_ReturnsFileLoggerWithSetFilePath()
    {
        LogFactory logFactory = new();
        logFactory.ConfigureFileLogger(FilePath);
    }

    [Fact]
    public void PersonRecord()
    {
        PersonRecord personRecord = new(1);
        Coordinate coordinate = new(1,2);
        Assert.True(false, (new Person(2)).ToString());
        Assert.True(false, coordinate.ToString());
        
    }
}
