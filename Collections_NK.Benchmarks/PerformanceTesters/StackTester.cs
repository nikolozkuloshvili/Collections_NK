using BenchmarkDotNet.Running;

namespace Collections_NK.Benchmarks;

public class StackTester
{
    public static void Runner()
    {
        int stackChoice = InputHelper.GetValidChoice(
            "Choose stack type:\n0 - Stack\n1 - GenericStack\n2 - MyStack\n3 - MyGenericStack",
            0, 3);

        int opChoice = InputHelper.GetValidChoice(
            "Choose operation:\n0 - Push\n1 - Pop\n2 - Peek",
            0, 2);

        Operation benchmark = stackChoice switch
        {
            0 => opChoice switch
            {
                0 => new Stack_Push(),
                1 => new Stack_Pop(),
                2 => new Stack_Peek(),
                _ => throw new ArgumentException()
            },
            1 => opChoice switch
            {
                0 => new GenericStack_Push(),
                1 => new GenericStack_Pop(),
                2 => new GenericStack_Peek(),
                _ => throw new ArgumentException()
            },
            2 => opChoice switch
            {
                0 => new MyStack_Push(),
                1 => new MyStack_Pop(),
                2 => new MyStack_Peek(),
                _ => throw new ArgumentException()
            },
            3 => opChoice switch
            {
                0 => new MyGenericStack_Push(),
                1 => new MyGenericStack_Pop(),
                2 => new MyGenericStack_Peek(),
                _ => throw new ArgumentException()
            },
            _ => throw new ArgumentException()
        };

        Console.WriteLine($"Running benchmark: {benchmark.GetType().Name}");
        BenchmarkRunner.Run(benchmark.GetType());
    }
}
