namespace Logger.Tests;

using Xunit;

public class EmployeeTests{
    [Fact]
    public void Employee_Init()
    {
        Employee employee = new(new FullName ("Jane", "Doe"));

        Assert.Equal("Jane Doe", employee.Name);
    }

    [Fact]
    public void Employee_Equals_SameValue()
    {
        Employee employee = new(new FullName ("Jane", "Doe"));
        Employee employee2 = new(new FullName ("Jane", "Doe"));

        Assert.True(employee2 == employee);
        Assert.False(employee2 != employee);
    }

    [Fact]
    public void Employee_Equals_DifferentValue()
    {
        Employee employee = new(new FullName ("Jane", "Doe"));
        Employee employee2 = new(new FullName ("John", "Doe"));

        Assert.False(employee2 == employee);
        Assert.True(employee2 != employee);
    }
}