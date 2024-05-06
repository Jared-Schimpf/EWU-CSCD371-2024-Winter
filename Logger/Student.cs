namespace Logger;

//implicit/explicit implementation of IEntity members defined in Person abstract class. see: Person.cs

public record class Student(FullName MyName) : Person(MyName)
{
    public Student(string First, string Last, string? Middle = "") : this(new FullName(First, Last, Middle)){}
}