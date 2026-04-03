using BenchmarkDotNet.Running;

namespace Collections_NK.Benchmarks;

public class ListTester
{
    public static void Runner()
    {
        int listChoice = InputHelper.GetValidChoice(
            "Choose list type:\n0 - ArrayList\n1 - GenericList\n2 - MyGenericList\n3 - MyList",
            0, 3);

        int opChoice = InputHelper.GetValidChoice(
            "Choose operation:\n0 - Add\n1 - Insert\n2 - Clear\n3 - Remove\n4 - RemoveAt\n5 - Contains\n6 - IndexOf\n7 - CopyTo",
            0, 7);

        Operation benchmark = listChoice switch
        {
            0 => opChoice switch
            {
                0 => new ArrayList_Add(),
                1 => new ArrayList_Insert(),
                2 => new ArrayList_Clear(),
                3 => new ArrayList_Remove(),
                4 => new ArrayList_RemoveAt(),
                5 => new ArrayList_Contains(),
                6 => new ArrayList_IndexOf(),
                7 => new ArrayList_CopyTo(),
                _ => throw new ArgumentException()
            },
            1 => opChoice switch
            {
                0 => new GenericList_Add(),
                1 => new GenericList_Insert(),
                2 => new GenericList_Clear(),
                3 => new GenericList_Remove(),
                4 => new GenericList_RemoveAt(),
                5 => new GenericList_Contains(),
                6 => new GenericList_IndexOf(),
                7 => new GenericList_CopyTo(),
                _ => throw new ArgumentException()
            },
            2 => opChoice switch
            {
                0 => new MyGenericList_Add(),
                1 => new MyGenericList_Insert(),
                2 => new MyGenericList_Clear(),
                3 => new MyGenericList_Remove(),
                4 => new MyGenericList_RemoveAt(),
                5 => new MyGenericList_Contains(),
                6 => new MyGenericList_IndexOf(),
                7 => new MyGenericList_CopyTo(),
                _ => throw new ArgumentException()
            },
            3 => opChoice switch
            {
                0 => new MyList_Add(),
                1 => new MyList_Insert(),
                2 => new MyList_Clear(),
                3 => new MyList_Remove(),
                4 => new MyList_RemoveAt(),
                5 => new MyList_Contains(),
                6 => new MyList_IndexOf(),
                7 => new MyList_CopyTo(),
                _ => throw new ArgumentException()
            },
            _ => throw new ArgumentException()
        };

        Console.WriteLine($"Running benchmark: {benchmark.GetType().Name}");
        BenchmarkRunner.Run(benchmark.GetType());
    }
}