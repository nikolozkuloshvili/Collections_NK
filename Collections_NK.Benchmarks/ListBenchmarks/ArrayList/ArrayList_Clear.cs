using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class ArrayList_Clear : Operation
{
    [Benchmark]
    public void ArrList_Clear()
    {
        System.Collections.ArrayList list = new System.Collections.ArrayList();
        for (int i = 0; i < Operations; i++) list.Add(i);
        list.Clear();
    }
}
