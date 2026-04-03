using BenchmarkDotNet.Running;

namespace Collections_NK.Benchmarks;

public class QueueTester
{
    public static void Runner()
    {
        int queueChoice = InputHelper.GetValidChoice(
            "Choose queue type:\n0 - Queue\n1 - GenericQueue\n2 - MyQueue\n3 - MyGenericQueue",
            0, 3);

        int opChoice = InputHelper.GetValidChoice(
            "Choose operation:\n0 - Enqueue\n1 - Dequeue\n2 - Peek",
            0, 2);

        Operation benchmark = queueChoice switch
        {
            0 => opChoice switch
            {
                0 => new Queue_Enqueue(),
                1 => new Queue_Dequeue(),
                2 => new Queue_Peek(),
                _ => throw new ArgumentException()
            },
            1 => opChoice switch
            {
                0 => new GenericQueue_Dequeue(),
                1 => new GenericQueue_Dequeue(),
                2 => new GenericQueue_Peek(),
                _ => throw new ArgumentException()
            },
            2 => opChoice switch
            {
                0 => new MyQueue_Enqueue(),
                1 => new MyQueue_Dequeue(),
                2 => new MyQueue_Peek(),
                _ => throw new ArgumentException()
            },
            3 => opChoice switch
            {
                0 => new MyGenericQueue_Enqueue(),
                1 => new MyGenericQueue_Dequeue(),
                2 => new MyGenericQueue_Peek(),
                _ => throw new ArgumentException()
            },
            _ => throw new ArgumentException()
        };

        Console.WriteLine($"Running benchmark: {benchmark.GetType().Name}");
        BenchmarkRunner.Run(benchmark.GetType());
    }
}

