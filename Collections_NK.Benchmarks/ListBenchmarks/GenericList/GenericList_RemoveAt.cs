using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class GenericList_RemoveAt : Operation
{
    [Benchmark]
    public void RemoveAt()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < Operations; i++) list.Add(i);
        for (int j = 0; j < Operations; j++) list.RemoveAt(0);
    }
}
