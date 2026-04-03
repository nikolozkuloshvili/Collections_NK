using Collections_NK.MyGenericCollection;

namespace Collections_NK.UnitTests;

public class GenericEnumeratorTests
{
    [Fact]
    public void MyGenericListGenericEnumerator_Test()
    {
        MyGenericList<string> list = new MyGenericList<string>()
        {
                "Nika",
                "Nika2"
        };

        IEnumerator<string> enumerator = list.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika", enumerator.Current);

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika2", enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void MyGenericStackGenericEnumerator_Test()
    {
        MyGenericStack<string> stack = new MyGenericStack<string>();
        stack.Push("Nika");
        stack.Push("Nika2");

        IEnumerator<string> enumerator = stack.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika2", enumerator.Current);

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika", enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void MyGenericQueueGenericEnumerator_Test()
    {
        MyGenericQueue<string> queue = new MyGenericQueue<string>();
        queue.Enqueue("Nika");
        queue.Enqueue("Nika2");

        IEnumerator<string> enumerator = queue.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika", enumerator.Current);

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika2", enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}

