using BenchmarkDotNet.Attributes;
using System.Collections;

namespace Collections_NK.Benchmarks;

public class ArrayList_Add : Operation
{
    [Benchmark]
    public void ArrList_Add()
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < Operations; i++) list.Add(i);
    }
}
