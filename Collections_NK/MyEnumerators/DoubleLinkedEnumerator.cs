using Collections_NK.MyLinkedLists.DoubleLinked;
using System.Collections;

namespace Collections_NK.MyEnumerators;

public class DoubleLinkedListEnumerator<T> : IEnumerator<T>
{
    private DoubleLinkedNode<T>? _first;

    private DoubleLinkedNode<T>? _position;

    public DoubleLinkedListEnumerator(DoubleLinkedNode<T> node)
    {
        _first = node ?? throw new ArgumentNullException("List is Empty");
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

