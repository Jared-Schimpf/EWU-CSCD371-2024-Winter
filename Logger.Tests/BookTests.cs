namespace Logger.Tests;

using Xunit;

public class BookTests{
    [Fact]
    public void Book_Init()
    {
        Book book = new("Necronomicon");
        Assert.Equal("Necronomicon", book.Name);
    }

    [Fact]
    public void Book_Equals_SameValue()
    {
        Book book = new("Nyarlathotep");
        Book book2 = new("Nyarlathotep");

        Assert.True(book == book2);
        Assert.False(book != book2);
    }

    [Fact]
    public void Book_Equals_DifferentValue()
    {
        Book book = new("The Hound");
        Book book2 = new("The Dream-Quest of Unknown Kadath");

        Assert.False(book == book2);
        Assert.True(book != book2);
    }
}