using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericStack_Pop : Operation
{
    [Benchmark]
    public void Pop()
    {
        MyGenericStack<int> stack = new MyGenericStack<int>();
        for (int i = 0; i < Operations; i++) stack.Push(i);
        for (int j = 0; j < Operations; j++) stack.Pop();
    }
}
