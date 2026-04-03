using System.Collections;

namespace Collections_NK.MyEnumerators;

public class Enumerator : IEnumerator
{
    protected readonly object?[] _items;
    protected readonly int _count;
    protected int _position;

    public Enumerator(object?[] items, int count)
    {
        _items = items ?? throw new ArgumentNullException();
        _count = count;
        Reset();
    }

    public object? Current
    {
        get
        {
            if (_position < 0 || _position >= _count)
                throw new InvalidOperationException();
            return _items[_position];
        }
    }

    public virtual bool MoveNext() => ++_position < _count;

    public virtual void Reset() => _position = -1;
}