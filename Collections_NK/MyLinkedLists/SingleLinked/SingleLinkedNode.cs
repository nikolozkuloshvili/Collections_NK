namespace Collections_NK.MyLinkedLists.SingleLinked;

public class SingleLinkedNode<T>
{
    public SingleLinkedNode<T>? Next;
    public SingleLinkedList<T>? List;

    public T Value { get; }

    public SingleLinkedNode(T value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }
    public override string? ToString() => Value?.ToString();
}