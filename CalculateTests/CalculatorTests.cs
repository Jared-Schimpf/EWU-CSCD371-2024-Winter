using Calculate;

namespace CalculateTests;
public class CalculatorTests
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 0, 2)]
    [InlineData(-10, 2, -8)]
    public void Add_Returns_Expected(int arg1, int arg2, double expected){
            Assert.Equal(expected,Calculator.Add(arg1, arg2));
    }

    [Theory]
    [InlineData(1, 2, -1)]
    [InlineData(0, -2, 2)]
    [InlineData(-10, 2, -12)]
    public void Subtract_Returns_Expected(int arg1, int arg2, double expected){
            Assert.Equal(expected,Calculator.Subtract(arg1, arg2));
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(2, 0, 0)]
    [InlineData(-10, 2, -20)]
    public void Multiply_Returns_Expected(int arg1, int arg2, double expected){
            Assert.Equal(expected,Calculator.Multiply(arg1, arg2));
    }

    [Theory]
    [InlineData(1, 2, 0.5)]
    [InlineData(0, 2, 0)] //we never handled divide by zero lol
    [InlineData(-10, 2, -5)]
    public void Divide_Returns_Expected(int arg1, int arg2, int expected){
            Assert.Equal(expected,Calculator.Divide(arg1, arg2));
    }

    [Theory]
    [InlineData(42, '+', 5, 42+5)]
    [InlineData(-42, '+', -5, -42+-5)]
    [InlineData(-42, '+', 0, -42)]
    [InlineData(42, '*', 5, 42*5)]
    [InlineData(-42, '*', -5, -42*-5)]
    [InlineData(-42, '*', 0, 0)]
    public void TryCalculate_Returns_Expected(int arg1, char anOperator, int arg2, double expected) //according to the class example these tests are sufficient
    {
        Assert.True(Calculator.TryCalculate($"{arg1} {anOperator} {arg2}", out double? result));
        Assert.Equal(expected, result);
    }

    [Fact] //I'm writing an additional test to test when Trycalculate is given an expression it can't parse
    public void TryCalculate_NonsenseExpression_Returns_Expected(){
        Assert.False(Calculator.TryCalculate("Luigi", out double? result));
        Assert.Null(result);
    }

    [Fact] //I'm writing an additional test to test when Trycalculate is given an expression it can't parse
    public void TryCalculate_BadOperator_Returns_Expected(){
        Assert.False(Calculator.TryCalculate("1 ^ 2", out double? result));
        Assert.Null(result);
    }
    
    [Fact]
    public void TryCalculate_BadArg_Returns_Expected(){
        Assert.False(Calculator.TryCalculate("cat / 2", out double? result));
        Assert.Null(result);
    }






}
