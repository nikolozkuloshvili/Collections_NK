namespace Collections_NK.MyLinkedLists.DoubleLinked;

public class DoubleLinkedNode<T>
{
    public DoubleLinkedNode<T>? Next;

    public DoubleLinkedNode<T>? Previous;

    public DoubleLinkedList<T>? List;

    public T Value { get; }

    public DoubleLinkedNode(T value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }
    public override string? ToString() => Value?.ToString();
}