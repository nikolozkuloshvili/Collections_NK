using Collections_NK.MyEnumerators;

namespace Collections_NK.MyGenericCollection;

public class MyGenericQueue<T> : MyGenericCollection<T>
{
    public void Enqueue(T item)
    {
        if (item == null)
            throw new ArgumentException("Added item was null");

        ExpandSizeBy2IfNeeded();

        _items[Count] = item;
        Count++;
    }

    public T Dequeue()
    {
        if (Count == 0)
            throw new ArgumentException("The Queue is empty");

        T firstItem = Peek();

        for (int i = 1; i < Count; i++)
        {
            _items[i - 1] = _items[i];
        }

        Count--;
        return firstItem;
    }

    public T Peek()
    {
        if (Count == 0)
            throw new ArgumentException("The Queue is empty");

        return _items[0];
    }
}
