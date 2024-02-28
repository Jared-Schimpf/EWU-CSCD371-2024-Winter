using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculate.Tests;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    [DataRow(42, 5, 47)]
    [DataRow(-42, -5, -47)]
    [DataRow(-42, 0, -42)]
    public void Add_TwoNumbers_Returns(int left, int right, int expected)
    {
        Assert.AreEqual(expected, Calculator.Add(left, right));
    }

    [TestMethod]
    [DataRow(42, 5, 37)]
    [DataRow(-42, -5, -37)]
    [DataRow(-42, 0, -42)]
    public void Subtract_TwoNumbers_Returns(int left, int right, int expected)
    {
        Assert.AreEqual(expected, Calculator.Subtract(left, right));
    }

    [TestMethod]
    [DataRow(42, 5, 42*5)]
    [DataRow(-42, -5, -42*-5)]
    [DataRow(-42, 0, 0)]
    public void Multiple_TwoNumbers_Returns(int left, int right, int expected)
    {
        Assert.AreEqual(expected, Calculator.Multiply(left, right));
    }


    [TestMethod]
    [DataRow(42, '+', 5, 42+5)]
    [DataRow(-42, '+', -5, -42+-5)]
    [DataRow(-42, '+', 0, -42)]
    [DataRow(42, '*', 5, 42*5)]
    [DataRow(-42, '*', -5, -42*-5)]
    [DataRow(-42, '*', 0, 0)]
    public void TryCalculate_TwoNumbers_Returns(int left, char mathOperator, int right, int expected)
    {
        Assert.IsTrue(Calculator.TryCalculate($"{left} {mathOperator} {right}", out double result));
        Assert.AreEqual(expected, result);
    }
}
