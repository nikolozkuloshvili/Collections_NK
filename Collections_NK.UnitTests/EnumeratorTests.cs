using Collections_NK.MyCollection;
using System.Collections;

namespace Collections_NK.UnitTests;

public class EnumeratorTests
{
    [Fact]
    public void MyListEnumerator_Test()
    {
        MyList list = new MyList()
        {
                "Nika",
                "Nika2"
        };

        IEnumerator enumerator = list.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika", enumerator.Current);

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika2", enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void MyStackEnumerator_Test()
    {
        MyStack stack = new MyStack();
        stack.Push("Nika");
        stack.Push("Nika2");

        IEnumerator enumerator = stack.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika2", enumerator.Current);

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika", enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void MyQueueEnumerator_Test()
    {
        MyQueue queue = new MyQueue();
        queue.Enqueue("Nika");
        queue.Enqueue("Nika2");

        IEnumerator enumerator = queue.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika", enumerator.Current);

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika2", enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}
