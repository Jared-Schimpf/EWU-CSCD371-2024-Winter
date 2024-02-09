namespace Logger;
public record class PersonRecord(int Ssn)
{
    public PersonRecord(int ssn, int age) : this(ssn)
    {
        Age=age;
    }

    public int Age { get; set; }
};

public record struct Coordinate(int X, int Y);



// It does matter if the thing is a reference type or value type 
// when considering whether to compare things by reference or value

// If it looks like a duck and quacks like a duck, it's a duck