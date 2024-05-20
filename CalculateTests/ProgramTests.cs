using System.Text;
using Calculate;

namespace CalculateTests;

public class ProgramTests
{
    //Write a test that sets these properties at construction time and then invokes the properties and verifies the expected behavior occurs

    //the properties can no longer be changed at construction time due to Program being a static class
    [Fact]
    public void WriteLine_Set_Behavior()
    {
        StringBuilder outStream = new();
        //Program program = new(){
        Program.WriteLine = text => outStream.Append(text); //changed to match github example
        //};

        Program.WriteLine("test");
        Assert.Equal("test", outStream.ToString());
    }

    [Fact]
    public void ReadLine_Set_Behavior()
    {
        //Program program = new(){
        Program.ReadLine = () => "test"; //changed to match github example
        //};

        Assert.Equal("test", Program.ReadLine());
    }
}