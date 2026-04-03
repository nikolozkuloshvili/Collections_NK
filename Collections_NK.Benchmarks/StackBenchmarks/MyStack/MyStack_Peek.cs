using BenchmarkDotNet.Attributes;
using Collections_NK.MyCollection;

namespace Collections_NK.Benchmarks;

public class MyStack_Peek : Operation
{
    [Benchmark]
    public void Peek()
    {
        MyStack stack = new MyStack();
        for (int i = 0; i < Operations; i++) stack.Push(i);
        for (int j = 0; j < Operations; j++) stack.Peek();
    }
}
