using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericList_Contains : Operation
{
    [Benchmark]
    public void Contains()
    {
        MyGenericList<int> list = new();
        for (int i = 0; i < Operations; i++) list.Add(i);
        for (int j = 0; j < Operations; j++) list.Contains(j);
    }
}
