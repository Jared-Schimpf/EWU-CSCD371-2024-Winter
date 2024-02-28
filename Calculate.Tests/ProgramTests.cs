namespace CalculateTests;

using System.Text;
using Calculate;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void Main()
    {
        StringBuilder output = new();
        string input = "1 + 1";
        Program.WriteLine = text => output.AppendLine(text);
        Program.ReadLine = () => input;
        Program.Main();
        Assert.AreEqual(
            "Enter a math expression (e.g. 1 + 1 = 2):" + Environment.NewLine 
            + "Result: 2" + Environment.NewLine, 
            output.ToString());
    }
}