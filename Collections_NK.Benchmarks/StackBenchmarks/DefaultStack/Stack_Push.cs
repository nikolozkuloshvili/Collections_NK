using BenchmarkDotNet.Attributes;
using System.Collections;

namespace Collections_NK.Benchmarks;

public class Stack_Push : Operation
{
    [Benchmark]
    public void Push()
    {
        Stack stack = new Stack();
        for (int i = 0; i < Operations; i++) stack.Push(i);
    }
}
