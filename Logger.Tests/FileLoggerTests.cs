using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests : FileLoggerTestsBase
{

   [TestMethod]
    public void Create_GivenClassNameAndGoodFileName_Success()
    {
        Assert.AreEqual(nameof(FileLoggerTestsBase), Logger.ClassName);
        Assert.AreEqual(FilePath, Logger.FilePath);
    }

    //[TestMethod]
    //public async Task Log_Message_FileAppended()
    //{
    //    Logger.Log
    //}

}
