using BenchmarkDotNet.Running;

namespace Collections_NK.Benchmarks;

public class LinkedListTester
{
    public static void Runner()
    {
        int listChoice = InputHelper.GetValidChoice(
            "Choose list type:\n0 - SingleLinedList\n1 - DoubleLinkedList",
            0, 1);

        int opChoice = InputHelper.GetValidChoice(
            "Choose operation:\n0 - AddFirst\n1 - AddLast\n2 - RemoveFirst\n3 - RemoveLast\n4 - Remove\n5 - Find\n6 - FindLast\n7 - Clear",
            0, 7);

        Operation benchmark = listChoice switch
        {
            0 => opChoice switch
            {
                0 => new SingleLinkedList_AddFirst(),
                1 => new SingleLinkedList_AddLast(),
                2 => new SingleLinkedList_RemoveFirst(),
                3 => new SingleLinkedList_RemoveLast(),
                4 => new SingleLinkedList_Remove(),
                5 => new SingleLinkedList_Find(),
                6 => new SingleLinkedList_FindLast(),
                7 => new SingleLinkedList_Clear(),
                _ => throw new ArgumentException()
            },
            1 => opChoice switch
            {
                0 => new DoubleLinkedList_AddFirst(),
                1 => new DoubleLinkedList_AddLast(),
                2 => new DoubleLinkedList_RemoveFirst(),
                3 => new DoubleLinkedList_RemoveLast(),
                4 => new DoubleLinkedList_Remove(),
                5 => new DoubleLinkedList_Find(),
                6 => new DoubleLinkedList_FindLast(),
                7 => new DoubleLinkedList_Clear(),
                _ => throw new ArgumentException()
            },
            _ => throw new ArgumentException()
        };

        Console.WriteLine($"Running benchmark: {benchmark.GetType().Name}");
        BenchmarkRunner.Run(benchmark.GetType());
    }
}