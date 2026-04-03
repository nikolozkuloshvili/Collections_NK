using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class ArrayList_RemoveAt : Operation
{
    [Benchmark]
    public void ArrList_RemoveAt()
    {
        System.Collections.ArrayList list = new System.Collections.ArrayList();
        for (int i = 0; i < Operations; i++) list.Add(i);
        for (int j = 0; j < Operations; j++) list.RemoveAt(0);
    }
}
