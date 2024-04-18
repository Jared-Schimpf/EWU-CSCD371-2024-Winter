using System;

namespace CanHazFunny;

public class Output : IOutput
{
    public void Print(String joke)
    {
        ArgumentNullException.ThrowIfNull(joke);

        Console.WriteLine(joke);
    }    

}