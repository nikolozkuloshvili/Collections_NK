using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class GenericList_Add : Operation
{
    [Benchmark]
    public void Add()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < Operations; i++) list.Add(i);
    }
}
