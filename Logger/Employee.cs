namespace Logger;

//implicit/explicit implementation of IEntity members defined in Person abstract class. see: Person.cs
public record class Employee(FullName MyName) : Person(MyName)
{
    public Employee(string First, string Last, string? Middle = "") : this(new FullName(First, Last, Middle)){}

}