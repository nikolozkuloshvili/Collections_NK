using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class GenericList_Clear : Operation
{
    [Benchmark]
    public void Clear()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < Operations; i++) list.Add(i);
        list.Clear();
    }
}
