using BenchmarkDotNet.Attributes;
using Collections_NK.MyCollection;

namespace Collections_NK.Benchmarks;

public class MyQueue_Enqueue : Operation
{
    [Benchmark]
    public void Enqueue()
    {
        MyQueue queue = new MyQueue();
        for (int i = 0; i < Operations; i++) queue.Enqueue(i);
    }
}
