using Collections_NK.MyEnumerators;
using System.Collections;

namespace Collections_NK.MyCollection;

public class MyStack : MyCollection
{
    public void Push(object? item)
    {
        if (item == null)
            throw new ArgumentException("Added item was null");

        ExpandSizeBy2IfNeeded();

        _items[Count] = item;
        Count++;
    }

    public object? Pop()
    {
        if (Count == 0)
            throw new ArgumentException("The Stack is empty");

        object? item = Peek();

        Count--;

        return item;
    }

    public object? Peek()
    {
        if (Count == 0)
            throw new ArgumentException("The Stack is empty");

        return _items[Count - 1];
    }

    public override void CopyTo(Array array, int index)
    {
        if (array == null)
            throw new ArgumentNullException();
        if (index < 0)
            throw new ArgumentOutOfRangeException();
        if (array.Length - index < Count)
            throw new ArgumentOutOfRangeException();

        for (int i = 0; i < Count; i++)
        {
            array.SetValue(_items[Count - 1 - i], index + i);
        }
    }

    public override IEnumerator GetEnumerator() => new StackEnumerator(_items, Count);
}