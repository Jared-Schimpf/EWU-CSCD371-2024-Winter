using Microsoft.Extensions.DependencyInjection;

namespace DI;
public class Program
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // service is just a fancy list of ServiceDescriptors
        services.AddTransient<IWriter, ConsoleWriter>();
        services.AddSingleton<OutputService>();
        // this is shorthand for services.Add(new ServiceDescriptor(typeof(OutputService), new OutputService()));
        services.AddScoped<ICharacterProvider, CharacterProvider>();
    }

    public static void Main()
    {
        IServiceCollection services = new ServiceCollection();

        ConfigureServices(services);

        ServiceProvider serviceProvider = services.BuildServiceProvider();

        ICharacterProvider bar2 = serviceProvider.GetRequiredService<ICharacterProvider>();

        using (IServiceScope serviceScope = serviceProvider.CreateScope())
        {
            ICharacterProvider bar = serviceScope.ServiceProvider.GetRequiredService<ICharacterProvider>();
        }

        using (IServiceScope serviceScope = serviceProvider.CreateScope())
        {
            ICharacterProvider foo = serviceScope.ServiceProvider.GetRequiredService<ICharacterProvider>();
        }

        // GetRequiredService is a fancy way of saying "Get me the service or throw an exception"
        serviceProvider.GetRequiredService<OutputService>().WriteOutNextCharacter();

        // Same instance - 2
        // Different instance - the rest
    }

    public static void Main(IWriter writer)
    {
        writer.Write("Hello Inigo Montoya!");
    }
}

// POCO - Plain Old C# Object
// DTO - Data Transfer Object
// Service Class - A class that contains business logic
// Leaky Abstraction - An abstraction that doesn't hide the underlying implementation
// WAT: Google "destroy all software WAT" - Kevins version of Homethink aka Homelookup
// Rubber Duck Debugging - Explaining your code to a rubber duck
// Nerd Sniping - 

// If you cannot justify your reason for an interface, DELETE IT!

// Singleton - One instance for the entire application
// Scoped - One instance per scope
// Transient - Always create a new instance


public interface ICharacterProvider
{
    string GetCharacter();
}

public class CharacterProvider(IWriter writer) : ICharacterProvider
{
    private string[] CharacterNames { get; } = ["Inigo Montoya", "Fezzik", "Vizzini", "Buttercup", "Westley"];
    private int index = 0;
    public string GetCharacter()
    {
        try
        {
            return CharacterNames[index++];
        }
        catch (IndexOutOfRangeException)
        {

            writer.Write("No more characters!");
            return string.Empty;
        }
    }
}

public class OutputService(ICharacterProvider characterProvider, IWriter writer)
{
    public void WriteOutNextCharacter()
    {
        writer.Write(characterProvider.GetCharacter());
        writer.Write("thing");
    }
}

public interface IWriter
{
    void Write(string message);
}

public class ConsoleWriter : IWriter
{
    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}