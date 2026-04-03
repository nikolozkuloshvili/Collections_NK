using Collections_NK.MyEnumerators;
using System.Collections;

namespace Collections_NK.MyGenericCollection;

public class MyGenericList<T> : MyGenericCollection<T>, IList<T>, IReadOnlyList<T>, IList
{
    public void Add(T item)
    {
        int index = Count;
        Insert(index, item);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException();

        ExpandSizeBy2IfNeeded();

        for (int i = Count; i > index; i--)
        {
            _items[i] = _items[i - 1];
        }

        _items[index] = item;
        Count++;
    }

    public bool Contains(T item) => IndexOf(item) >= 0;

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException();

        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        Count--;
        _items[Count] = default;
    }

    public int IndexOf(T item) => IndexOf(item, 0);

    public int IndexOf(T item, int startIndex)
    {
        if (startIndex < 0 || startIndex >= Count)
            throw new ArgumentOutOfRangeException();

        for (int i = startIndex; i < Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[i], item))
                return i;
        }

        return -1;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            _items[index] = value;
        }
    }

    int IList.Add(object? item)
    {
        int index = Count;
        Insert(index, (T)item);
        return index;
    }

    void IList.Insert(int index, object? item) => Insert(index, (T)item);

    void IList.Remove(object? value) => Remove((T)value);

    bool IList.Contains(object? item)
    {
        if (IndexOf((T)item) >= 0)
        {
            return true;
        }
        return false;
    }

    int IList.IndexOf(object? item) => IndexOf((T)item, 0);

    object? IList.this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            _items[index] = (T)value;
        }
    }

    bool IList.IsReadOnly { get; } = false;
    bool IList.IsFixedSize { get; } = false;
    bool ICollection<T>.IsReadOnly => false;
}
