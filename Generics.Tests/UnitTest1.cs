namespace Generics.Tests;
using static CompareResult;

public partial class UnitTest1
{
    [Fact]
    public void TestTwoFullNamesAreEqual()
    {
        FullName fullName1 = new("a", "b");
        FullName fullName2 = new("b", "c");

        // gt = 1, eq = 0, lt = -1

        //Assert.Equal(GreaterThan, fullName2.Compare(fullName1));
        //Assert.Equal(GreaterThan, Comparer.Compare(fullName1, fullName2));
    }

    [Fact]
    public void WL_Test() 
    {
        // Arrange
        string expectedGreeting = "Hello, World!";

        // Act
        string actualGreeting = Thing.GreetDelegate();

        // Assert
        Assert.Equal(expectedGreeting, actualGreeting);
    }

    [Fact]
    public void WL_TestTypes()
    {
        Assert.IsType<Func<string>>(Thing.GreetDelegate);

        Assert.IsType<string>(Thing.GreetDelegate());
    }
}

public static class Thing
{
    public static Func<string> GreetDelegate { get; set; } = () => "Hello, World!";
}