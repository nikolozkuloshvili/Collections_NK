using BenchmarkDotNet.Attributes;
using Collections_NK.MyCollection;

namespace Collections_NK.Benchmarks;

public class MyList_Clear : Operation
{
    [Benchmark]
    public void Clear()
    {
        MyList list = new MyList();
        for (int i = 0; i < Operations; i++) list.Add(i);
        list.Clear();
    }
}
