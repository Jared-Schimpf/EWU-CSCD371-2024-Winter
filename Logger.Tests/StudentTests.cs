namespace Logger.Tests;

using Xunit;

public class StudentTests{
    [Fact]
    public void Student_Init()
    {
        Student student = new(new FullName ("Jane", "Doe"));

        Assert.Equal("Jane Doe", student.Name);
    }

    [Fact]
    public void Student_Equals_SameValue()
    {
        Student student = new(new FullName ("Jane", "Doe"));
        Student student2 = new(new FullName ("Jane", "Doe"));

        Assert.True(student2 == student);
        Assert.False(student2 != student);
    }

    [Fact]
    public void Student_Equals_DifferentValue()
    {
        Student student = new(new FullName ("Jane", "Doe"));
        Student student2 = new(new FullName ("John", "Doe"));

        Assert.False(student2 == student);
        Assert.True(student2 != student);
    }
}