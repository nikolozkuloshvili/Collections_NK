using BenchmarkDotNet.Attributes;
using Collections_NK.MyLinkedLists.DoubleLinked;

namespace Collections_NK.Benchmarks;

public class DoubleLinkedList_RemoveLast : Operation
{
    [Benchmark]
    public void RemoveLast()
    {
        var list = new DoubleLinkedList<int>();
        for (int i = 0; i < Operations; i++) list.AddLast(i);
        list.RemoveLast();
    }
}



