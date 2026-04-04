using BenchmarkDotNet.Attributes;
using System.Collections;

namespace Collections_NK.Benchmarks;

public class ArrayList_Clear : Operation
{
    [Benchmark]
    public void ArrList_Clear()
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < Operations; i++) list.Add(i);
        list.Clear();
    }
}
