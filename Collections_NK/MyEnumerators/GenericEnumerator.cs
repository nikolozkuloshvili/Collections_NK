using System.Collections;

namespace Collections_NK.MyEnumerators;

public class GenericEnumerator<T> : IEnumerator<T>
{
    private readonly T[] _items;
    protected readonly int _count;
    protected int _position;

    public GenericEnumerator(T[] items, int count)
    {
        _items = items ?? throw new ArgumentNullException();
        _count = count;
        Reset();
    }

    public T Current
    {
        get
        {
            if (_position < 0 || _position >= _count)
                throw new InvalidOperationException();
            return _items[_position]!;
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose() => Reset(); // ?

    public virtual bool MoveNext() => ++_position < _count;

    public virtual void Reset() => _position = -1;
}
