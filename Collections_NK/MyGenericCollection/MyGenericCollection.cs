using Collections_NK.MyGenericCollection;
using System.Collections;

namespace Collections_NK.MyEnumerators;

public abstract class MyGenericCollection<T> : IReadOnlyCollection<T>, ICollection
{
    protected T[] _items = new T[1];
    public int Count { get; protected set; } = 0;

    public virtual void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index must be non-negative.");
        if (array.Length - arrayIndex < Count)
            throw new ArgumentException("The number of elements in the collection is greater than the available space from index to the end of the array.");

        for (int i = 0; i < Count; i++)
        {
            array.SetValue(_items[i], arrayIndex + i);
        }
    }

    public void ExpandSizeBy2IfNeeded()
    {
        if (Count == _items.Length)
        {
            int newSize = _items.Length * 2;
            T[] newArray = new T[newSize];
            Array.Copy(_items, newArray, Count);
            _items = newArray;
        }
    }

    public void Clear()
    {
        _items = new T[1];
        Count = 0;
    }

    public virtual IEnumerator<T> GetEnumerator() => new GenericEnumerator<T>(_items, Count);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    void ICollection.CopyTo(Array array, int index) => CopyTo((T[])array, index);

    bool ICollection.IsSynchronized => false;
    object ICollection.SyncRoot => new();
}

