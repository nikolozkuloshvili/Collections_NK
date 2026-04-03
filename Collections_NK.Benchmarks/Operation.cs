using BenchmarkDotNet.Attributes;

namespace Collections_NK.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser]
public class Operation
{
    [Params(20000)]
    public int Operations { get; set; }
}
