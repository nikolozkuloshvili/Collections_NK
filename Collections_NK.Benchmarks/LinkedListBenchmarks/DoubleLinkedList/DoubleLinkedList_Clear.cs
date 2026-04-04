using BenchmarkDotNet.Attributes;
using Collections_NK.MyLinkedLists.DoubleLinked;

namespace Collections_NK.Benchmarks;

public class  DoubleLinkedList_Clear : Operation
{
    [Benchmark]
    public void Clear()
    {
        var list = new DoubleLinkedList<int>();
        for (int i = 0; i < Operations; i++) list.AddLast(i);
        list.Clear();
    }
}
