using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class ArrayList_IndexOf : Operation
{
    [Benchmark]
    public void ArrList_IndexOf()
    {
        System.Collections.ArrayList list = new System.Collections.ArrayList();
        for (int i = 0; i < Operations; i++) list.Add(i);
        for (int j = 0; j < Operations; j++) list.IndexOf(j);
    }
}
