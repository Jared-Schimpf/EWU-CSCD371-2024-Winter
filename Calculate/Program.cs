namespace Calculate;

public static class Program{

    //Define two init-only setter properties, WriteLine and ReadLine, that contain delegates for writing a line of text and reading a line of text respectively
    //Set the default behavior for the WriteLine and ReadLine properties to invoke System.Console versions of the methods and add an empty default constructor
    public static Action<string?> WriteLine {set; get;} = Console.WriteLine;
    public static Func<string?> ReadLine{set;  get;} = Console.ReadLine;

    public static void Main(){

        WriteLine("Enter a 2 operand equation:  (x + y, etc)");
        string input = ReadLine() ?? "";


        if(Calculator.TryCalculate(input, out double? result) ){
            WriteLine($"Result: {result}");
            return;
        }
        WriteLine("Bad Input");

    }

}