using Xunit;

namespace Logger.Tests;

public class PersonTests{
    
    [Fact]
    public void Employee_InheritedGet(){
        Person person = new Employee(new FullName ("Jane", "Doe"));

        Assert.Equal("Jane Doe", person.Name);
    }

    [Fact]
    public void Student_InheritedGet(){
        Person person = new Student(new FullName ("Jane", "Doe"));

        Assert.Equal("Jane Doe", person.Name);
    }

}