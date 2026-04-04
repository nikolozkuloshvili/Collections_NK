using BenchmarkDotNet.Attributes;
using Collections_NK.MyLinkedLists.DoubleLinked;

namespace Collections_NK.Benchmarks;

public class DoubleLinkedList_Remove : Operation
{
    [Benchmark]
    public void Remove()
    {
        var list = new DoubleLinkedList<int>();
        for (int i = 0; i < Operations; i++) list.AddLast(i);
        for (int i = 0; i < Operations; i++) list.Remove(i);
    }
}



