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
}