using BenchmarkDotNet.Attributes;
using Collections_NK.MyLinkedLists.DoubleLinked;

namespace Collections_NK.Benchmarks;

public class DoubleLinkedList_FindLast : Operation
{
    [Benchmark]
    public void FindLast()
    {
        var list = new DoubleLinkedList<int>();
        for (int i = 0; i < Operations; i++) list.AddLast(i);
        for (int i = 0; i < Operations; i++) list.FindLast(1);
    }
}


