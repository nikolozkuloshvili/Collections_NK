using BenchmarkDotNet.Attributes;
using Collections_NK.MyCollection;

namespace Collections_NK.Benchmarks;

public class MyList_Add : Operation
{
    [Benchmark]
    public void Add()
    {
        MyList list = new MyList();
        for (int i = 0; i < Operations; i++) list.Add(i);
    }
}
