using System.Collections;
using Collections_NK.MyEnumerators;

namespace Collections_NK.MyCollection;

public abstract class MyCollection : ICollection
{
    protected object?[] _items = new object[1];

    public int Count { get; protected set; } = 0;

    public virtual void CopyTo(Array array, int index)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be non-negative.");
        if (array.Length - index < Count)
            throw new ArgumentException("The number of elements in the collection is greater than the available space from index to the end of the array.");

        for (int i = 0; i < Count; i++)
        {
            array.SetValue(_items[i], index + i);
        }
    }

    public void Clear()
    {
        _items = new object?[1]; Count = 0;
    }

    public void ExpandSizeBy2IfNeeded()
    {
        if (Count >= _items.Length)
            Array.Resize(ref _items, _items.Length * 2);
    }

    public virtual IEnumerator GetEnumerator() => new Enumerator(_items, Count);

    bool ICollection.IsSynchronized { get; } = false;
    object ICollection.SyncRoot { get; } = new object();
}
