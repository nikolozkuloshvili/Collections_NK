using Collections_NK.MyEnumerators;
using System.Collections;
using System.Runtime.Serialization;

namespace Collections_NK.MyLinkedLists.DoubleLinked;

public class DoubleLinkedList<T> : ICollection<T>, IReadOnlyCollection<T>, ICollection, IDeserializationCallback, ISerializable
{
    private DoubleLinkedNode<T>? _first;

    private DoubleLinkedNode<T>? _last;

    public int Count { get; private set; }

    public void AddFirst(DoubleLinkedNode<T> node)
    {
        if (IsEmpty())
        {
            Add_FirstNode_ToEmptyList(node);
        }
        else
        {
            AddBefore(_first!, node);
        }
    }

    public DoubleLinkedNode<T> AddFirst(T value)
    {
        var node = new DoubleLinkedNode<T>(value);
        AddFirst(node);
        return node;
    }

    public void AddLast(DoubleLinkedNode<T> node)
    {
        if (IsEmpty())
        {
            Add_FirstNode_ToEmptyList(node);
        }
        else
        {
            AddAfter(_last!, node);
        }
    }

    public DoubleLinkedNode<T>? AddLast(T value)
    {
        var node = new DoubleLinkedNode<T>(value);
        AddLast(node);
        return node;
    }

    public void AddAfter(DoubleLinkedNode<T> node, DoubleLinkedNode<T> newNode)
    {
        ValidateNode_BelongsTo_ThisList_And_IsNot_Null(node);
        ValidateNewNode_IsNot_Null_Or_AlreadyAdded(newNode);

        if (node == _last)
        {
            _last!.Next = newNode;
            newNode.Previous = _last;
            _last = newNode;
            newNode.List = this;
            Count++;
            return;
        }

        newNode.Previous = node;
        newNode.Next = node.Next;
        node.Next = newNode;

        newNode.List = this;
        Count++;
    }

    public DoubleLinkedNode<T>? AddAfter(DoubleLinkedNode<T> node, T value)
    {
        var newNode = new DoubleLinkedNode<T>(value);
        AddAfter(node, newNode);
        return newNode;
    }

    public void AddBefore(DoubleLinkedNode<T> node, DoubleLinkedNode<T> newNode)
    {
        ValidateNode_BelongsTo_ThisList_And_IsNot_Null(node);
        ValidateNewNode_IsNot_Null_Or_AlreadyAdded(newNode);

        if (node == _first)
        {
            newNode.Next = _first;
            _first.Previous = newNode;
            _first = newNode;
            newNode.List = this;
            Count++;
            return;
        }

        newNode.Previous = node.Previous;
        node.Previous!.Next = newNode;
        node.Previous = newNode;
        newNode.Next = node;

        newNode.List = this;
        Count++;
    }

    public DoubleLinkedNode<T> AddBefore(DoubleLinkedNode<T> node, T value)
    {
        var newNode = new DoubleLinkedNode<T>(value);
        AddBefore(node, newNode);
        return newNode;
    }

    public DoubleLinkedNode<T>? Find(T value)
    {
        if (IsEmpty())
            throw new ArgumentNullException("List is empty. Nothing left to search for.");

        ValidateValue_IsNot_Null(value);

        var start = _first;
        while (start != null)
        {
            if (EqualityComparer<T>.Default.Equals(start.Value, value))
            {
                return start;
            }

            start = start.Next;
        }

        return null;
    }

    public DoubleLinkedNode<T>? FindLast(T value)
    {
        if (IsEmpty())
            throw new ArgumentNullException("List is empty. Nothing left to search for.");

        ValidateValue_IsNot_Null(value);

        var node = _last;
        while (node != null)
        {
            if (EqualityComparer<T>.Default.Equals(node.Value, value))
            {
                return node;
            }
            node = node.Previous;
        }

        return null;
    }

    public void Remove(DoubleLinkedNode<T> node)
    {
        if (IsEmpty())
            throw new ArgumentNullException("List is already empty. Nothing left to be deleted.");

        ValidateNode_BelongsTo_ThisList_And_IsNot_Null(node);

        if (node == _first)
        {
            RemoveFirst(); return;
        }

        if (node == _last)
        {
            RemoveLast(); return;
        }

        var start = _first;
        while (start!.Next != node)
        {
            start = start.Next;
        }

        start!.Next = node.Next;
        node.Next!.Previous = start;

        node.List = null;
        Count--;
    }

    public bool Remove(T value)
    {
        if (IsEmpty())
            throw new ArgumentNullException("List is already empty. Nothing left to be deleted.");

        var node = Find(value);

        var num = Count;
        Remove(node!);

        if (num > Count)
            return true;

        return false;
    }

    public void RemoveFirst()
    {
        if (IsEmpty())
            throw new ArgumentNullException("List is already empty. Nothing left to be deleted.");

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
        if (IsEmpty())
            throw new ArgumentNullException("List is already empty. Nothing left to be deleted.");

        if (_first == _last)
        {
            Clear(); return;
        }

        _last!.List = null;
        _last!.Previous!.Next = null;
        _last = _last.Previous;
        Count--;
    }

    public void Clear()
    {
        var start = _first;
        while (start != null)
        {
            var next = start.Next;
            start.Next = null;
            start.List = null;
            start = next;
        }

        _first = null; _last = null; Count = 0;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index must be non-negative.");
        if (array.Length - arrayIndex < Count)
            throw new ArgumentException("The number of elements in the collection is greater than the available space from index to the end of the array.");

        var first = _first;
        for (int i = 0; i < Count && first != null; i++)
        {
            array.SetValue(first.Value, arrayIndex + i);
            first = first.Next;
        }
    }

    private bool IsEmpty() => _first == null;

    private void Add_FirstNode_ToEmptyList(DoubleLinkedNode<T> node)
    {
        ValidateNewNode_IsNot_Null_Or_AlreadyAdded(node);

        _first = node;
        _last = node;
        node.List = this;
        Count++;
    }

    private void ValidateNewNode_IsNot_Null_Or_AlreadyAdded(DoubleLinkedNode<T> node)
    {
        if (node == null)
            throw new ArgumentNullException("Node Can't be empty.");

        if (node!.List == this)
            throw new ArgumentException("Node already belongs to this list.");

        if (node.List != null)
            throw new ArgumentException("Node already belongs to other list.");
    }

    private bool ValidateNode_BelongsTo_ThisList_And_IsNot_Null(DoubleLinkedNode<T> node)
    {
        if (node == null)
            throw new ArgumentNullException("Node Can't be empty.");

        if (node!.List == this)
            return true;
        else
            throw new ArgumentException("Node is not in this list");
    }

    private void ValidateValue_IsNot_Null(T value)
    {
        if (value == null)
            throw new ArgumentNullException();
    }

    bool ICollection<T>.Contains(T item) => Find(item) != null;

    public IEnumerator<T> GetEnumerator() => new DoubleLinkedListEnumerator<T>(_first!);

    void ICollection.CopyTo(Array array, int index) => CopyTo((T[])array, index);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    void ICollection<T>.Add(T item) => AddLast(item);

    bool ICollection<T>.IsReadOnly => false;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => new();

    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => throw new NotImplementedException();

    void IDeserializationCallback.OnDeserialization(object? sender) => throw new NotImplementedException();
}