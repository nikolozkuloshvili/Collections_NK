namespace Collections_NK.MyCollection;

public class MyQueue : MyCollection
{
    public void Enqueue(object? item)
    {
        if (item == null)
            throw new ArgumentException("Added item was null");

        ExpandSizeBy2IfNeeded();

        _items[Count] = item;
        Count++;
    }

    public object? Dequeue()
    {
        if (Count == 0)
            throw new ArgumentException("The Queue is empty");

        object? firstItem = Peek();

        for (int i = 1; i < Count; i++)
        {
            _items[i - 1] = _items[i];
        }

        Count--;
        return firstItem;
    }

    public object? Peek()
    {
        if (Count == 0)
            throw new ArgumentException("The Queue is empty");

        return _items[0];
    }
}