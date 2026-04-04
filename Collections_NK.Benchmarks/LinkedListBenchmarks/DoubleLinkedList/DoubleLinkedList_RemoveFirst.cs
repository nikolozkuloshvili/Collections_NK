using BenchmarkDotNet.Attributes;
using Collections_NK.MyLinkedLists.DoubleLinked;

namespace Collections_NK.Benchmarks;

public class DoubleLinkedList_RemoveFirst : Operation
{
    [Benchmark]
    public void RemoveFirst()
    {
        var list = new DoubleLinkedList<int>();
        for (int i = 0; i < Operations; i++) list.AddLast(i);
        list.RemoveFirst();
    }
}



