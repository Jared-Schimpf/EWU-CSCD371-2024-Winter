using Xunit;//xunit has no external documentation, why not use vscode's test library?

namespace Logger.Tests;

public class StorageTests{
    [Fact] //<- pretentious
    public void Add_Book(){
        Book book = new("The King In Yellow");

        Storage storage = new();

        storage.Add(book);

        Assert.True(storage.Contains(book));
    }
    
    [Fact]
    public void Remove_Book(){
        Book book = new("The King In Yellow");

        Storage storage = new();

        storage.Add(book);

        storage.Remove(book);

        Assert.False(storage.Contains(book));
    }

    [Fact]
    public void Add_Student(){
        Student student = new("John", "Doe");

        Storage storage = new();

        storage.Add(student);

        Assert.True(storage.Contains(student));
    }
    
    [Fact]
    public void Remove_Student(){
        Student student = new("John", "Doe", "Saint");

        Storage storage = new();

        storage.Add(student);

        storage.Remove(student);

        Assert.False(storage.Contains(student));
    }

    [Fact]
    public void Add_Employee(){
        Employee employee = new("John", "Doe");

        Storage storage = new();

        storage.Add(employee);

        Assert.True(storage.Contains(employee));
    }
    
    [Fact]
    public void Remove_Employee(){
        Employee employee = new("John", "Doe", "Saint");

        Storage storage = new();

        storage.Add(employee);

        storage.Remove(employee);

        Assert.False(storage.Contains(employee));
    }

    [Fact]
    public void Remove_Nonexistent_NoChange(){
        Employee employee = new("John", "Doe", "Saint");
        Employee employee2 = new("Jim", "Beam");
        Storage storage = new();

        storage.Add(employee);

        storage.Remove(employee2);

        Assert.False(storage.Contains(employee2));
        Assert.True(storage.Contains(employee));
        
    }   

    [Fact]
    public void Get_Nonexistent_ReturnsNull(){
        Storage storage = new();
        
        Guid id = Guid.NewGuid();

        Assert.Null(storage.Get(id));

    } 
}