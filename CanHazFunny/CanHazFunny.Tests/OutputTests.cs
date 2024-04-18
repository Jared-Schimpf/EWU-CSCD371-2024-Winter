using Xunit;
using System;
using System.IO;
namespace CanHazFunny.Tests;

public class outputTests
{
    [Fact]
    public static void Print_throwsOnNull(){
        Output output = new();
        Assert.Throws<ArgumentNullException>(() => output.Print(null!));
    }

    [Fact]
    public static void Print_WritesToConsole(){
        Output output = new();
        
        var originalOut = Console.Out;
        var capture = new StringWriter();
        Console.SetOut(capture);

        output.Print("Test joke");

        capture.Flush();
        Console.SetOut(originalOut);

        string joke = capture.GetStringBuilder().ToString();
        Assert.Contains("Test joke", joke);

    }

}