using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class GenericStack_Push : Operation
{
    [Benchmark]
    public void Push()
    {
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < Operations; i++) stack.Push(i);
    }
}

