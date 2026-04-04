using BenchmarkDotNet.Attributes;
using System.Collections;


namespace Collections_NK.Benchmarks;

public class ArrayList_Contains : Operation
{
    [Benchmark]
    public void ArrList_Contains()
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < Operations; i++) list.Add(i);
        for (int j = 0; j < Operations; j++) list.Contains(j);
    }
}
