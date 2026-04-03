using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class GenericList_CopyTo : Operation
{
    [Benchmark]
    public void CopyTo()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < Operations; i++) list.Add(i);
        int[] array = new int[Operations];
        list.CopyTo(array, 0);
    }
}