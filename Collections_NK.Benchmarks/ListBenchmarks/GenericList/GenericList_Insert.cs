using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class GenericList_Insert : Operation
{
    [Benchmark]
    public void Insert()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < Operations; i++) list.Insert(0, i);
    }
}
