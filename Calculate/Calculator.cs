namespace Calculate;

public class Calculator
{

    /*
    Define a read-only property, MathematicalOperations, of type System.Collections.Generics.IReadOnlyDictionary<TKey,TValue> that:
    - Is initialized to a System.Collections.Generics.Dictionary<<TKey,TValue> instance that:
        - Uses char for the key corresponding to the operators +, -, *, and /.
        - Has values that correspond with the Add, Subtract, Multiple, and Divide methods.
    */
    public static IReadOnlyDictionary<char, Func<int, int, double>> MathOperations {get;} = new Dictionary<char, Func<int, int, double>>(){
        {'+', Add},
        {'-', Subtract},
        {'/', Divide},
        {'*', Multiply}
    };

    //Define static Add, Subtract, Multiple, and Divide methods that have two parameters and return a third parameter
    public static double Add(int arg1, int arg2) => arg1 + arg2;
    public static double Subtract(int arg1, int arg2) => arg1 - arg2;
    public static double Divide(int arg1, int arg2) => arg1 / arg2;
    public static double Multiply(int arg1, int arg2) => arg1 * arg2;
    

    /*
    Implement a TryCalculate method following "TryParse" pattern
    Valid calculation expressions include such strings as "3 + 4", "42 - 2", etc.
    If there is no whitespace around the operator, you can assume the calculation is invalid and return false. Similarly if the operands are not integers.
    Use string.Split(), pattern matching, logical and operators to parse the string in their entirety
    Index into the MathematicalOperations method using the operator parsed during pattern matching to find the corresponding implementation and invoke it
    */

    public bool TryCalculate(string expression, out double? result){
        if(expression.Split(' ') is [string arg1Text, string operation, string arg2Text]
            && int.TryParse(arg1Text, out int arg1)
            && int.TryParse(arg2Text, out int arg2))
        {
            result = MathOperations[operation[0]](arg1, arg2);
            return true;
        }
        result = null;
        return false;
    }

    
}
