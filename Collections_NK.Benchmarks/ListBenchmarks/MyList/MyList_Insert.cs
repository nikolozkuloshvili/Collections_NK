using BenchmarkDotNet.Attributes;
using Collections_NK.MyCollection;

namespace Collections_NK.Benchmarks;

public class MyList_Insert : Operation
{
    [Benchmark]
    public void Insert()
    {
        MyList list = new MyList();
        for (int i = 0; i < Operations; i++) list.Insert(0, i);
    }
}
