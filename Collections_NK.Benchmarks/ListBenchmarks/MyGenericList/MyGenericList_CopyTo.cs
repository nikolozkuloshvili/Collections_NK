using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericList_CopyTo : Operation
{
    [Benchmark]
    public void CopyTo()
    {
        MyGenericList<int> list = new();
        for (int i = 0; i < Operations; i++) list.Add(i);
        int[] array = new int[Operations];
        list.CopyTo(array, 0);
    }
}
