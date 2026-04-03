using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericQueue_Dequeue : Operation
{
    [Benchmark]
    public void Dequeue()
    {
        MyGenericQueue<int> queue = new MyGenericQueue<int>();
        for (int i = 0; i < Operations; i++) queue.Enqueue(i);
        for (int j = 0; j < Operations; j++) queue.Dequeue();
    }
}
