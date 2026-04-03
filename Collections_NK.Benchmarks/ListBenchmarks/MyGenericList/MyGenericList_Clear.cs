using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericList_Clear : Operation
{
    [Benchmark]
    public void Clear()
    {
        MyGenericList<int> list = new();
        for (int i = 0; i < Operations; i++) list.Add(i);
        list.Clear();
    }
}
