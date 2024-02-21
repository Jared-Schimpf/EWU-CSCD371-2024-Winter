namespace Generics.Tests;


public class FactoryTests
{
    [Fact]
    public void CreateBook()
    {
        TestThing book  = Factory<TestThing>.Create<ThingFactory>(
            new ThingFactory(), "data");
    }

    [Fact]
    public void NodeTest()
    {
        // Local Function Declaration
        void Validate(string? value) => ArgumentException.ThrowIfNullOrEmpty(value);

        Node<string> node = new("Hello");

        node.Action = Validate;

        // Anonymous Function Declaration and Assignment
        //node.Action = value =>
        //{
        //    //if (string.IsNullOrEmpty(value))
        //    //{
        //    //    throw new ArgumentException(nameof(value));
        //    //}
        //    ArgumentException.ThrowIfNullOrEmpty(value);
        //};
        
        node.Action = value => ArgumentException.ThrowIfNullOrEmpty(value);

        node.Value = null!;
    }



    [Fact]
    public void CreateStudent()
    {
        TestThing thing = Factory<TestThing>.Create<ThingFactory>(
            new ThingFactory(), "data");
    }









}
