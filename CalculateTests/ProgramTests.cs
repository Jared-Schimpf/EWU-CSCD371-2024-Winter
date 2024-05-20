using System.Text;
using Calculate;

namespace CalculateTests;

public class ProgramTests
{
    //Write a test that sets these properties at construction time and then invokes the properties and verifies the expected behavior occurs
    [Fact]
    public void WriteLine_Set_Behavior()
    {
        StringBuilder outStream = new();
        Program program = new(){
            WriteLine = text => outStream.Append(text)
        };

        program.WriteLine("test");
        Assert.Equal("test", outStream.ToString());
    }

    [Fact]
    public void ReadLine_Set_Behavior()
    {
        Program program = new(){
            ReadLine = () => "test"
        };

        Assert.Equal("test", program.ReadLine());
    }
}