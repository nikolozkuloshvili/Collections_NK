using BenchmarkDotNet.Attributes;
using System.Collections;

namespace Collections_NK.Benchmarks;

public class Queue_Dequeue : Operation
{
    [Benchmark]
    public void Dequeue()
    {
        Queue queue = new Queue();
        for (int i = 0; i < Operations; i++) queue.Enqueue(i);
        for (int j = 0; j < Operations; j++) queue.Dequeue();
    }
}
