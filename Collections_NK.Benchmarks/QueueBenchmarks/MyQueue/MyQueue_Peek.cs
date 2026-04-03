using BenchmarkDotNet.Attributes;
using Collections_NK.MyCollection;

namespace Collections_NK.Benchmarks;

public class MyQueue_Peek : Operation
{
    [Benchmark]
    public void Peek()
    {
        MyQueue queue = new MyQueue();
        for (int i = 0; i < Operations; i++) queue.Enqueue(i);
        for (int j = 0; j < Operations; j++) queue.Peek();
    }
}
