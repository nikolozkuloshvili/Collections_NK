using BenchmarkDotNet.Attributes;
using Collections_NK.MyLinkedLists.DoubleLinked;
using Collections_NK.MyLinkedLists.SingleLinked;

namespace Collections_NK.Benchmarks;

public class SingleLinkedList_AddFirst : Operation
{
    [Benchmark]
    public void AddFirst()
    {
        var list = new SingleLinkedList<int>();
        for (int i = 0; i < Operations; i++) list.AddFirst(i);
    }
}
