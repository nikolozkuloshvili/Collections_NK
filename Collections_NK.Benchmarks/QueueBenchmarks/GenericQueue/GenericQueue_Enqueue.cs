using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class GenericQueue_Enqueue : Operation
{
    [Benchmark]
    public void Enqueue()
    {
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < Operations; i++) queue.Enqueue(i);
    }
}
