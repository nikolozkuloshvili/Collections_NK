using BenchmarkDotNet.Running;

namespace Collections_NK.Benchmarks;

public class CustomTester
{
    public static void Runner()
    {
        BenchmarkRunner.Run<TestClass>();
    }
}
