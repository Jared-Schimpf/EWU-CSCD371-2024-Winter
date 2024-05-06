namespace Logger.Tests;

using Xunit;

public class FullNameTests{
    [Fact]
    public void FullName_FirstNull_ThrowsException(){
        Assert.Throws<ArgumentNullException>(()=> new FullName(null!, "l"));
    }

    [Fact]
    public void FullName_LastNull_ThrowsException(){
        Assert.Throws<ArgumentNullException>(()=> new FullName("f", null!));
    }

    [Fact]
    public void FullName_MiddleNull_NoException(){
        FullName name = new("f", "l", null!);
        Assert.True(true);
    }

    [Fact]
    public void FullName_ToString_Works(){
        FullName name = new("Mary", "Sue");
        Assert.Equal("Mary Sue", name.ToString());
    }

    [Fact]
    public void FullName_ToString_WorksWithMiddle(){
        FullName name = new("Mary", "Sue", "The Crusher");
        Assert.Equal("Mary The Crusher Sue", name.ToString());
    }


}