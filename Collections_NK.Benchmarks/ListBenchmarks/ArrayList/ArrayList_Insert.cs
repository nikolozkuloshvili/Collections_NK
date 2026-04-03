using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class ArrayList_Insert : Operation
{
    [Benchmark]
    public void ArrList_Insert()
    {
        System.Collections.ArrayList list = new System.Collections.ArrayList();
        for (int i = 0; i < Operations; i++) list.Insert(0, i);
    }
}
