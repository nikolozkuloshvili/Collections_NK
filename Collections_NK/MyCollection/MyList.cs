using System.Collections;

namespace Collections_NK.MyCollection;

public class MyList : MyCollection, IList
{
    public int Add(object? value)
    {
        int index = Count;
        Insert(index, value);
        return index;
    }

    public void Insert(int index, object? value)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException();

        ExpandSizeBy2IfNeeded();

        for (int i = Count; i > index; i--)
        {
            _items[i] = _items[i - 1];
        }

        _items[index] = value;
        Count++;
    }

    public void Remove(object? value)
    {
        int index = IndexOf(value);
        if (index >= 0)
        {
            RemoveAt(index);
        }
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
        _items[Count] = null;
    }

    public bool Contains(object? value) => IndexOf(value) >= 0;

    public int IndexOf(object? value) => IndexOf(value, 0);

    public int IndexOf(object? value, int startIndex)
    {
        if (startIndex < 0 || startIndex >= Count)
            throw new ArgumentOutOfRangeException();

        for (int i = startIndex; i < Count; i++)
        {
            if (_items[i] == value)
                return i;
        }

        return -1;
    }

    public object? this[int index]
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

    bool IList.IsFixedSize { get; } = false;
    bool IList.IsReadOnly { get; } = false;
}