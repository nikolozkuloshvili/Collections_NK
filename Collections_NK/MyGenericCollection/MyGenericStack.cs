using Collections_NK.MyEnumerators;

namespace Collections_NK.MyGenericCollection;

public class MyGenericStack<T> : MyGenericCollection<T>
{
    public void Push(T item)
    {
        if (item == null)
            throw new ArgumentException("Added item was null");

        ExpandSizeBy2IfNeeded();

        _items[Count] = item;
        Count++;
    }

    public T Pop()
    {
        if (Count == 0)
            throw new ArgumentException("The Stack is empty");

        T item = Peek();

        Count--;

        return item;
    }

    public T Peek()
    {
        if (Count == 0)
            throw new ArgumentException("The Stack is empty");

        return _items[Count - 1];
    }

    public override void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index must be non-negative.");
        if (array.Length - arrayIndex < Count)
            throw new ArgumentException("The number of elements in the collection is greater than the available space from index to the end of the array.");

        for (int i = 0; i < Count; i++)
        {
            array.SetValue(_items[Count - 1 - i], arrayIndex + i);
        }
    }

    public override IEnumerator<T> GetEnumerator() => new StackGenericEnumerator<T>(_items, Count);
}
