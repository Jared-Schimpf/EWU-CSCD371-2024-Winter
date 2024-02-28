namespace Calculate;

public static class Program
{
    public static Action<string?> WriteLine { get; set; } = Console.WriteLine;
    public static Func<string?> ReadLine { get; set; } = Console.ReadLine;

    public static void Main()
    {
        WriteLine("Enter a math expression (e.g. 1 + 1 = 2):");
        string? input = ReadLine();
        if (input is not null && Calculator.TryCalculate(input, out double result))
        {
            WriteLine($"Result: {result}");
        }
        else
        {
            WriteLine("Invalid input");
        }
    }
}
