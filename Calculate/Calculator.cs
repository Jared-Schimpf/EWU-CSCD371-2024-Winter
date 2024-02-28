namespace Calculate;

public class Calculator
{
    public static IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, double>>()
    {
        {'+', Add },
        {'-', Subtract },
        {'/', Divide },
        {'*', Multiply },
    };
    public static double Add(int left, int right) => left + right;
    public static double Subtract(int left, int right) => left - right;
    public static double Divide(int left, int right) => left / right;
    public static double Multiply(int left, int right) => left * right;

    public static bool TryCalculate(string expression, out double result)
    {
        if(expression.Split(' ') is [string leftText, string mathematicalOperation, string rightText ] 
            && int.TryParse(leftText, out int left) 
            && int.TryParse(rightText, out int right))
        {
            result = MathematicalOperations[mathematicalOperation[0]](left, right);
            return true;
        }
        else 
        {
            result = int.MaxValue;
            return false; 
        }
    }
}
