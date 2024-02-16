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
    public void CreateStudent()
    {
        TestThing thing = Factory<TestThing>.Create<ThingFactory>(
            new ThingFactory(), "data");
    }









}
