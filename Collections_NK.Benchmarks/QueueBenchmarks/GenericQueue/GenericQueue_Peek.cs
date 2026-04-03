using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class GenericQueue_Peek : Operation
{
    [Benchmark]
    public void Peek()
    {
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i<Operations; i++) queue.Enqueue(i);
        for (int j = 0; j < Operations; j++) queue.Peek();
    }
}
