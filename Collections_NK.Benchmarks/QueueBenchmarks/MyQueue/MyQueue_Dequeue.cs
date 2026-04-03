using BenchmarkDotNet.Attributes;
using Collections_NK.MyCollection;

namespace Collections_NK.Benchmarks;

public class MyQueue_Dequeue : Operation
{
    [Benchmark]
    public void Dequeue()
    {
        MyQueue queue = new MyQueue();
        for (int i = 0; i < Operations; i++) queue.Enqueue(i);
        for (int j = 0; j < Operations; j++) queue.Dequeue();
    }
}
