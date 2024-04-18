using System;

namespace CanHazFunny;

public class Jester(IOutput output, IGetJokes jokeService){

    private IOutput _output = output ?? throw new ArgumentNullException(nameof(output));
    private IGetJokes _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));


    public void TellJoke(){
        string joke = _jokeService.GetJoke();

        while(joke.Contains("Chuck Norris") || joke.Contains("Texas Ranger"))
        {
            joke = _jokeService.GetJoke();
        }

        _output.Print(joke);
    }
}