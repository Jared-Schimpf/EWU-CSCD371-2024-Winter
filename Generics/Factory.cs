namespace Generics;

public abstract class Factory<TResult>
{
    public static TResult Create<TFactory>(in TFactory factory, string text)
        where TFactory : Factory<TResult>
    {
        return factory.Create(text);
        
    }

    public abstract TResult Create(string text);
}


