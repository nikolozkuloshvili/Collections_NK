using BenchmarkDotNet.Attributes;
using System.Collections;

namespace Collections_NK.Benchmarks;

public class Queue_Enqueue : Operation
{
    [Benchmark]
    public void Enqueue()
    {
        Queue queue = new Queue();
        for (int i = 0; i < Operations; i++) queue.Enqueue(i);
    }
}
