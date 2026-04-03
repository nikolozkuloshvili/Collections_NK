using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericQueue_Enqueue : Operation
{
    [Benchmark]
    public void Enqueue()
    {
        MyGenericQueue<int> queue = new MyGenericQueue<int>();
        for (int i = 0; i < Operations; i++) queue.Enqueue(i);
    }
}
