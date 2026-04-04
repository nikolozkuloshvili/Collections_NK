using BenchmarkDotNet.Attributes;
using System.Collections;


namespace Collections_NK.Benchmarks;

public class ArrayList_CopyTo : Operation
{
    [Benchmark]
    public void ArrList_CopyTo()
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < Operations; i++) list.Add(i);
        object[] array = new object[Operations];
        list.CopyTo(array, 0);
    }
}
