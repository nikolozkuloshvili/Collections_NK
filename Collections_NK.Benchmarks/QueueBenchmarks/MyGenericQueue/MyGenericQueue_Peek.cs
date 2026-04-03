using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericQueue_Peek : Operation
{
    [Benchmark]
    public void Peek()
    {
        MyGenericQueue<int> queue = new MyGenericQueue<int>();
        for (int i = 0; i < Operations; i++) queue.Enqueue(i);
        for (int j = 0; j < Operations; j++) queue.Peek();
    }
}
