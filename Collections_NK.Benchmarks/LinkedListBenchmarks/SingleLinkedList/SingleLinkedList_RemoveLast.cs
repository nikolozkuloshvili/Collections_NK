using BenchmarkDotNet.Attributes;
using Collections_NK.MyLinkedLists.SingleLinked;

namespace Collections_NK.Benchmarks;

public class SingleLinkedList_RemoveLast : Operation
{
    [Benchmark]
    public void RemoveLast()
    {
        var list = new SingleLinkedList<int>();
        for (int i = 0; i < Operations; i++) list.AddLast(i);
        list.RemoveLast();
    }
}


