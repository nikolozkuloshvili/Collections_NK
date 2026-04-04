using Collections_NK.MyLinkedLists.DoubleLinked;
using Collections_NK.MyLinkedLists.SingleLinked;
using System.Collections;

namespace Collections_NK.UnitTests;

public class DoubleLinkedListTests
{
    [Fact]
    public void SameNode_ShouldNotBe_Added_ToTwoLists()
    {
        var list1 = new DoubleLinkedList<int>();
        var list2 = new DoubleLinkedList<int>();
        var node = new DoubleLinkedNode<int>(1);

        list1.AddFirst(node);

        Assert.Throws<ArgumentException>(() => list2.AddFirst(node));
        Assert.Throws<ArgumentException>(() => list2.AddLast(node));
        Assert.Throws<ArgumentException>(() => list2.AddAfter(node, node));
        Assert.Throws<ArgumentException>(() => list2.AddBefore(node, node));
    }

    [Fact]
    public void SameNode_ShouldNotBe_Added_ToSameList()
    {
        var list = new DoubleLinkedList<int>();
        var node = new DoubleLinkedNode<int>(1);

        list.AddFirst(node);

        Assert.Throws<ArgumentException>(() => list.AddFirst(node));
        Assert.Throws<ArgumentException>(() => list.AddLast(node));
        Assert.Throws<ArgumentException>(() => list.AddAfter(node, node));
        Assert.Throws<ArgumentException>(() => list.AddBefore(node, node));
    }

    [Fact]
    public void SingleLinkedListEnumerator_Test()
    {
        var list = new SingleLinkedList<string>();
        list.AddLast("Nika");
        list.AddLast("Nika2");

        IEnumerator enumerator = list.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika", enumerator.Current);

        Assert.True(enumerator.MoveNext());
        Assert.Equal("Nika2", enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}