namespace Calculate;

public static class ProgramBase
{
    public static Action<string?> WriteLine { get; } = Console.WriteLine;
    public static Func<string?> ReadLine { get; } = Console.ReadLine;
}