using BenchmarkDotNet.Attributes;
using Collections_NK.MyLinkedLists.SingleLinked;

namespace Collections_NK.Benchmarks;

public class SingleLinkedList_Find : Operation
{
    [Benchmark]
    public void Find()
    {
        var list = new SingleLinkedList<int>();
        for (int i = 0; i < Operations; i++) list.AddLast(i);
        for (int i = 0; i < Operations; i++) list.Find(19999);
    }
}

