using Xunit;
namespace GenericsHomework.Tests;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
public class NodeTests
{
    [Fact]
    public void Constructor_CorrectValue(){
        Node<int> node = new(1);

        Assert.AreEqual<int>(1, node.Data);
    }

    [Fact]
    public void ToString_Works(){
        Node<int> node = new(1);

        Assert.AreEqual("1", node.ToString());
    }

    [Fact]
    public void Next_InitsToSelf(){
        Node<int> node = new(1);
    
        Assert.AreEqual(node, node.Next);
    }

    [Fact]
    public void Append_CreatesNode(){
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        Assert.AreEqual<int>(3, node.Next.Data);
        Assert.AreEqual<int>(2, node.Next.Next.Data);
    }

    
    [Fact]
    public void Append_NodePointsToFirst(){
        Node<int> node = new(1);
        node.Append(2);
        Assert.AreEqual(node, node.Next.Next);
    }

    [Fact]
    public void Append_ThrowsOnDupe(){
        Node<int> node = new(1);
        Assert.ThrowsException<ArgumentException>(()=>node.Append(1));
    }

    [Fact]
    public void Clear_NodePointsToSelf(){
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        node.Clear();
        Assert.AreEqual(node,node.Next);
    }

    [Fact]
    public void Exists_FalseWhenDoesntExist(){
        Node<int> node = new(1);
        node.Append(2);

        Assert.IsFalse(node.Exists(3));
    }

    [Fact]
    public void Exists_TrueWhenExists(){
        Node<int> node = new(1);
        node.Append(2);

        Assert.IsTrue(node.Exists(2));
    }

    //null data value tests

    [Fact]
    public void Constructor_WorksWithNull(){
        Node<int?> node = new(null);

        Assert.IsNull(node.Data);
    }

    [Fact]
    public void ToString_WorksWithNull(){
        Node<int?> node = new(null);

        Assert.AreEqual("null", node.ToString());
    }

    [Fact]
    public void Append_CreatesNullNode(){
            Node<int?> node = new(1);
            node.Append(null);

            Assert.IsNull(node.Next.Data);
        }

    [Fact]
    public void Append_ThrowsOnNullDupe(){
        Node<int?> node = new(1);
        node.Append(null);
        Assert.ThrowsException<ArgumentException>(()=>node.Append(null));
    }

    [Fact]
    public void Exists_FalseWhenNoNullDupe(){
        Node<int?> node = new(1);
        node.Append(2);

        Assert.IsFalse(node.Exists(null));
    }

}