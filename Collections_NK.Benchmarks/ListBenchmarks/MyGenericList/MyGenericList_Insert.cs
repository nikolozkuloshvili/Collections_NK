using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericList_Insert : Operation
{
    [Benchmark]
    public void Insert()
    {
        MyGenericList<int> list = new();
        for (int i = 0; i < Operations; i++) list.Insert(0, i);
    }
}
