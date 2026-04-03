using Collections_NK.MyLinkedLists.SingleLinked;
using System.Collections;

namespace Collections_NK.MyEnumerators;

public class SingleLinkedEnumerator<T> : IEnumerator<T>
{
    protected SingleLinkedNode<T>? _first;

    protected SingleLinkedNode<T>? _position;

    public SingleLinkedEnumerator(SingleLinkedNode<T> node)
    {
        _first = node ?? throw new ArgumentNullException();
        Reset();
    }

    public T Current
    {
        get
        {
            if (_position == null)
                throw new InvalidOperationException();
            return _position.Value;
        }
    }

    object IEnumerator.Current => Current!;

    public virtual bool MoveNext()
    {
        if (_position == null)
        {
            _position = _first;

        }
        else
        {
            _position = _position.Next;
        }

        return _position != null;
    }

    public virtual void Reset() => _position = null;

    public void Dispose() => Reset();
}
