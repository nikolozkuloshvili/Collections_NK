using BenchmarkDotNet.Attributes;
using Collections_NK.MyLinkedLists.DoubleLinked;

namespace Collections_NK.Benchmarks;

public class DoubleLinkedList_Find : Operation
{
    [Benchmark]
    public void Find()
    {
        var list = new DoubleLinkedList<int>();
        for (int i = 0; i < Operations; i++) list.AddLast(i);
        for (int i = 0; i < Operations; i++) list.Find(19999);
    }
}
