namespace Calculate;

//program and it's properties are static in the github's completed example
public static class Program{//changed to static to match github example

    //Define two init-only setter properties, WriteLine and ReadLine, that contain delegates for writing a line of text and reading a line of text respectively
    //Set the default behavior for the WriteLine and ReadLine properties to invoke System.Console versions of the methods and add an empty default constructor
    public static Action<string?> WriteLine {set; get;} = Console.WriteLine;//changed to static to match github example
    public static Func<string?> ReadLine{set;  get;} = Console.ReadLine;//changed to static to match github example
    
    //properties changed to match the completed example on github.
    //This means they are no longer init only but I agree with (what I assume was) the teacher's judgement that they didn't need to be in the first place


    //instructions ask to instantiate Calculator class but it is static in the example
    public static void Main(){
        
       //Program program = new();
        WriteLine("Enter a 2 operand equation:  (x + y, etc)");
        string input = ReadLine() ?? "";

        //Calculator calculator = new();
        if(Calculator.TryCalculate(input, out double? result) ){
            WriteLine($"Result: {result}");
            return;
        }
        WriteLine("Bad Input");

    }

}