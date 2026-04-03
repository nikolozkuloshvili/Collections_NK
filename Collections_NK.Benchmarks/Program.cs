namespace Collections_NK.Benchmarks;

internal class Program
{
    public class MainRunner
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Choose Collection type:");
                Console.WriteLine("0 - List");
                Console.WriteLine("1 - Queue");
                Console.WriteLine("2 - Stack");
                Console.WriteLine("3 - Your Custom Code Tester");
                Console.WriteLine("X - Exit");

                string? input = Console.ReadLine();
                if (string.Equals(input, "X", StringComparison.OrdinalIgnoreCase))
                    return;

                if (!int.TryParse(input, out int choice) || choice < 0 || choice > 3)
                {
                    Console.WriteLine("Invalid choice, try again.\n");
                    continue;
                }

                switch (choice)
                {
                    case 0: ListTester.Runner(); break;
                    case 1: QueueTester.Runner(); break;
                    case 2: StackTester.Runner(); break;
                    case 3: CustomTester.Runner(); break;
                }

                Console.WriteLine("\nBenchmark finished. Run another? (Y/N)");
                string? again = Console.ReadLine();
                if (!string.Equals(again, "Y", StringComparison.OrdinalIgnoreCase))
                    break;
            }
        }
    }
}
