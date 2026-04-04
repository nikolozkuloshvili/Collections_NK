using BenchmarkDotNet.Attributes;
using Collections_NK.MyLinkedLists.DoubleLinked;
using Collections_NK.MyLinkedLists.SingleLinked;

namespace Collections_NK.Benchmarks;

public class SingleLinkedList_FindLast : Operation
{
    [Benchmark]
    public void FindLast()
    {
        var list = new SingleLinkedList<int>();
        for (int i = 0; i < Operations; i++) list.AddLast(i);
        for (int i = 0; i < Operations; i++) list.FindLast(1);
    }
}

