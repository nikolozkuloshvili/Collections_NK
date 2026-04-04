using Collections_NK.MyEnumerators;
using System.Collections;
using System.Runtime.Serialization;

namespace Collections_NK.MyLinkedLists.SingleLinked;

public class SingleLinkedList<T> : ICollection<T>, IReadOnlyCollection<T>, ICollection, IDeserializationCallback, ISerializable
{
    private SingleLinkedNode<T>? _first;

    private SingleLinkedNode<T>? _last;

    public int Count { get; private set; }

    public void AddFirst(SingleLinkedNode<T> node)
    {
        Node_IsNotNull_Validater(node);

        if (_first == null)
        {
            _first = node;
            _last = node;
            node.List = this;
        }
        else
        {
            AddBefore(_first, node);
        }
    }

    public SingleLinkedNode<T> AddFirst(T value)
    {
        var node = new SingleLinkedNode<T>(value);
        AddFirst(node);
        return node;
    }

    public void AddLast(SingleLinkedNode<T> node)
    {
        ValidateNewNode_IsNot_InList(node);

        if (_first == null)
        {
            _first = node;
            _last = node;
            node.List = this;
        }
        else
        {
            AddAfter(_last!, node);
        }
    }

    public SingleLinkedNode<T>? AddLast(T value)
    {
        var node = new SingleLinkedNode<T>(value);
        AddLast(node);
        return node;
    }

    public void AddAfter(SingleLinkedNode<T> node, SingleLinkedNode<T> newNode)
    {
        if (node == newNode)
            throw new ArgumentException("Node already belongs to this list.");

        Node_IsNotNull_Validater(node);
        ValidateNewNode_IsNot_InList(newNode);

        if (node == _last)
        {
            _last!.Next = newNode;
            _last = newNode;
            newNode.List = this;
            Count++;
            return;
        }

        newNode.Next = node.Next;
        node.Next = newNode;

        newNode.List = this;
        Count++;
    }

    public SingleLinkedNode<T>? AddAfter(SingleLinkedNode<T> node, T value)
    {
        var newNode = new SingleLinkedNode<T>(value);
        AddAfter(node, newNode);
        return newNode;
    }

    public void AddBefore(SingleLinkedNode<T> node, SingleLinkedNode<T> newNode)
    {
        if (node == newNode)
            throw new ArgumentException("Node already belongs to this list.");

        Node_IsNotNull_Validater(node);
        ValidateNewNode_IsNot_InList(newNode);

        if (node == _first)
        {
            newNode.Next = _first;
            _first = newNode;
            newNode.List = this;
            Count++;
            return;
        }

        var current = _first;
        while (current != null && current.Next != node)
        {
            current = current.Next;
        }

        if (current == null)
            throw new ArgumentNullException("Node is not in this list");

        current.Next = newNode;
        newNode.Next = node;

        newNode.List = this;
        Count++;
    }

    public SingleLinkedNode<T> AddBefore(SingleLinkedNode<T> node, T value)
    {
        var newNode = new SingleLinkedNode<T>(value);
        AddBefore(node, newNode);
        return newNode;
    }

    public SingleLinkedNode<T>? Find(T value)
    {
        var node = _first;
        while (node != null)
        {
            if (EqualityComparer<T>.Default.Equals(node.Value, value))
            {
                return node;
            }
            node = node.Next;
        }

        return null;
    }

    public SingleLinkedNode<T>? FindLast(T value)
    {
        var node = _first;
        SingleLinkedNode<T>? lastFounded = null;
        while (node != null)
        {
            if (EqualityComparer<T>.Default.Equals(node.Value, value))
            {
                lastFounded = node;
            }
            node = node.Next;
        }

        return lastFounded;
    }

    public void Remove(SingleLinkedNode<T> node)
    {
        Node_IsNotNull_Validater(node);

        if (node == _first)
        {
            RemoveFirst(); return;
        }

        var start = _first;
        while (start != null && start.Next != node)
        {
            start = start.Next;
        }

        if (start == null)
            throw new ArgumentNullException("Node is not in this list");

        if (start.Next == _last)
        {
            RemoveLast(); return;
        }

        start.Next = node.Next;
        node.List = null;

        Count--;
    }

    public bool Remove(T value)
    {
        if (EqualityComparer<T>.Default.Equals(_first!.Value, value))
        {
            RemoveFirst(); return true;
        }

        var node = _first;
        while (node.Next != null)
        {
            if (EqualityComparer<T>.Default.Equals(node.Next.Value, value))
            {
                node.Next.List = null;
                node.Next = node.Next.Next;
                Count--;
                return true;
            }

            node = node.Next;
        }

        return false;
    }

    public void RemoveFirst()
    {
        If_ListEmpty_ThrowExecption();

        if (_first == _last)
        {
            Clear(); return;
        }

        _first!.List = null;
        _first = _first!.Next;

        Count--;
    }

    public void RemoveLast()
    {
        If_ListEmpty_ThrowExecption();

        if (_first == _last)
        {
            Clear(); return;
        }

        var node = _first;
        while (node != null && node.Next != _last)
        {
            node = node.Next;
        }

        _last!.List = null;
        node!.Next = null;
        _last = node;
        Count--;
    }

    public void Clear()
    {
        var current = _first;
        while (current != null)
        {
            var next = current.Next;
            current.Next = null;
            current.List = null;
            current = next;
        }

        _first = null; _last = null; Count = 0;
    }

    private void Node_IsNotNull_Validater(SingleLinkedNode<T> node)
    {
        if (node == null)
            throw new ArgumentNullException("Node Can't be empty.");
    }

    private void ValidateNewNode_IsNot_InList(SingleLinkedNode<T>? node)
    {
        Node_IsNotNull_Validater(node!);

        if (node!.List == this)
            throw new ArgumentException("Node already belongs to this list.");

        if (node.List != null)
            throw new ArgumentException("Node already belongs to other list.");
    }            


    private void If_ListEmpty_ThrowExecption()
    {
        if (_first == null)
            throw new ArgumentNullException("List is already empty, nothing left to remove.");
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index must be non-negative.");
        if (array.Length - arrayIndex < Count)
            throw new ArgumentException("The number of elements in the collection is greater than the available space from index to the end of the array.");

        var current = _first;
        for (int i = 0; i < Count && current != null; i++)
        {
            {
                array.SetValue(current.Value, arrayIndex + i);
            }

            current = current.Next;
        }
    }

    bool ICollection<T>.Contains(T item)
    {
        if (Find(item) != null) return true;

        else return false;
    }

    public IEnumerator<T> GetEnumerator() => new SingleLinkedEnumerator<T>(_first!);

    void ICollection.CopyTo(Array array, int index) => CopyTo((T[])array, index);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    void ICollection<T>.Add(T item) => AddLast(item);

    bool ICollection<T>.IsReadOnly => false;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => new();

    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => throw new NotImplementedException();

    void IDeserializationCallback.OnDeserialization(object? sender) => throw new NotImplementedException();
}

