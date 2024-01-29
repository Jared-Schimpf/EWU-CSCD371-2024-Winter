using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTestsBase
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string FilePath { get; set; }
    public FileLogger Logger { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    
    [TestInitialize]
    public virtual void TestInitialize()
    {
        FilePath = Path.GetTempFileName();
        Logger = new FileLogger(nameof(FileLoggerTestsBase), FilePath);
    }

    [TestCleanup]
    public virtual void TestCleanup()
    {
        if (File.Exists(FilePath)) File.Delete(FilePath);
    }
}
