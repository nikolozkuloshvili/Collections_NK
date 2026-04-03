using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericStack_Push : Operation
{
    [Benchmark]
    public void Push()
    {
        MyGenericStack<int> stack = new MyGenericStack<int>();
        for (int i = 0; i < Operations; i++) stack.Push(i);
    }
}
