namespace Collections_NK.MyEnumerators;

public class StackGenericEnumerator<T> : GenericEnumerator<T>
{
    public StackGenericEnumerator(T[] items, int count) : base(items, count)
    {
    }

    public override bool MoveNext() => --_position >= 0;

    public override void Reset() => _position = _count;
}
