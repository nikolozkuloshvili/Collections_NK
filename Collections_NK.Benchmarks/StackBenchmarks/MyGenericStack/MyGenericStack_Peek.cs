using BenchmarkDotNet.Attributes;
using Collections_NK.MyGenericCollection;

namespace Collections_NK.Benchmarks;

public class MyGenericStack_Peek : Operation
{
    [Benchmark]
    public void Peek()
    {
        MyGenericStack<int> stack = new MyGenericStack<int>();
        for (int i = 0; i < Operations; i++) stack.Push(i);
        for (int j = 0; j < Operations; j++) stack.Peek();
    }
}
