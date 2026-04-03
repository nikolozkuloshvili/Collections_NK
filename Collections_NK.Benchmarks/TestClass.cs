using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser]
public class TestClass
{
    [Benchmark]
    public void TestMethod()
    {
        for (int i = 2; i < 1000; i += 2)
        {
        }

        for (int i = 999; i > 0; i -= 2)
        {
        }
    }
}
