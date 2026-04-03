using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

public class GenericStack_Peek : Operation
{
    [Benchmark]
    public void Peek()
    {
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < Operations; i++) stack.Push(i);
        for (int j = 0; j < Operations; j++) stack.Peek();
    }
}

