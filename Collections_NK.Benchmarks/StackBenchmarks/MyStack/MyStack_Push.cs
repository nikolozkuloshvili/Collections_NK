using BenchmarkDotNet.Attributes;
using Collections_NK.MyCollection;

namespace Collections_NK.Benchmarks;

public class MyStack_Push : Operation
{
    [Benchmark]
    public void Push()
    {
        MyStack stack = new MyStack();
        for (int i = 0; i < Operations; i++) stack.Push(i);
    }
}
