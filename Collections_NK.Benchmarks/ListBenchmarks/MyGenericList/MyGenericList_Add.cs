using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericList_Add : Operation
{
    [Benchmark]
    public void Add()
    {
        MyGenericList<int> list = new();
        for (int i = 0; i < Operations; i++) list.Add(i);
    }
}
