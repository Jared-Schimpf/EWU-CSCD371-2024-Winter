namespace Calculate;

//program and it's properties are static in the github's completed example
public class Program{

    //Define two init-only setter properties, WriteLine and ReadLine, that contain delegates for writing a line of text and reading a line of text respectively
    //Set the default behavior for the WriteLine and ReadLine properties to invoke System.Console versions of the methods and add an empty default constructor
    public Action<string?> WriteLine {init; get;} = Console.WriteLine;
    public Func<string?> ReadLine{ init; get;} = Console.ReadLine;

    //instructions ask to instantiate Calculator class but it is static in the example
    public static void Main(){
        
        Program program = new();
        program.WriteLine("Enter a 2 operand equation:  (x + y, etc)");
        string input = program.ReadLine() ?? "";

        Calculator calculator = new();
        if( calculator.TryCalculate(input, out double? result) ){
            program.WriteLine($"Result: {result}");
            return;
        }
        program.WriteLine("Bad Input");

    }

}