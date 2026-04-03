using BenchmarkDotNet.Attributes;
using System.Collections;

namespace Collections_NK.Benchmarks;

public class Stack_Pop : Operation
{
    [Benchmark]
    public void Pop()
    {
        Stack stack = new Stack();
        for (int i = 0; i < Operations; i++) stack.Push(i);
        for (int j = 0; j < Operations; j++) stack.Pop();
    }
}
