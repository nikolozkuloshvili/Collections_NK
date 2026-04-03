using BenchmarkDotNet.Attributes;
using Collections_NK.MyCollection;

namespace Collections_NK.Benchmarks;

public class MyList_RemoveAt : Operation
{
    [Benchmark]
    public void RemoveAt()
    {
        MyList list = new MyList();
        for (int i = 0; i < Operations; i++) list.Add(i);
        for (int j = 0; j < Operations; j++) list.RemoveAt(0);
    }
}
