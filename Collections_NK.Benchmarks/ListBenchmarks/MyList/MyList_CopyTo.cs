using BenchmarkDotNet.Attributes;
using Collections_NK.MyCollection;

namespace Collections_NK.Benchmarks;

public class MyList_CopyTo : Operation
{
    [Benchmark]
    public void CopyTo()
    {
        MyList list = new MyList();
        for (int i = 0; i < Operations; i++) list.Add(i);
        object[] array = new object[Operations];
        list.CopyTo(array, 0);
    }
}
