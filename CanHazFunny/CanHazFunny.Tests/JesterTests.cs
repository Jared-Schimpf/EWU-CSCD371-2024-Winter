using Xunit;
using Moq;
using System;
using System.IO;
namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public static void Jester_ThrowsOnNullOutput(){
        var fakeJokeService = new Mock<IGetJokes>();  
        Assert.Throws<ArgumentNullException>(() =>new Jester(null!, fakeJokeService.Object));
    }

    [Fact]
    public static void Jester_ThrowsOnNullJokeService(){
        var fakeOutput = new Mock<IOutput>();
        Assert.Throws<ArgumentNullException>(() =>new Jester(fakeOutput.Object, null!));
    }

    [Fact]
    public static void TellJoke_SkipsChuckNorris(){
        var fakeOutput = new Mock<IOutput>();
        var fakeJokeService = new Mock<IGetJokes>();
        fakeJokeService.SetupSequence(x => x.GetJoke()).Returns("Chuck Norris").Returns("Test joke" );
        
        Jester Arkham = new(fakeOutput.Object, fakeJokeService.Object);
        Arkham.TellJoke();

        fakeOutput.Verify(y => y.Print("Test joke"));
    }

    [Fact]
    public static void TellJoke_OutputsJokeToConsole(){
        var originalOut = Console.Out;
        var capture = new StringWriter();
        Console.SetOut(capture);

        var fakeJokeService = new Mock<IGetJokes>();
        fakeJokeService.Setup(x => x.GetJoke()).Returns("Test joke" );
        
        Jester Arkham = new(new Output(), fakeJokeService.Object);
        Arkham.TellJoke();

        capture.Flush();
        Console.SetOut(originalOut);

        string joke = capture.GetStringBuilder().ToString();
        Assert.Contains("Test joke", joke);
    }


}
