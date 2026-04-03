namespace Collections_NK.MyEnumerators;

public class StackEnumerator : Enumerator
{
    public StackEnumerator(object?[] items, int count) : base(items, count)
    {
    }

    public override bool MoveNext() => --_position >= 0;

    public override void Reset() => _position = _count;
}
