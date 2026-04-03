namespace Collections_NK.Benchmarks;

public static class InputHelper
{
    public static int GetValidChoice(string prompt, int min, int max)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= min && choice <= max)
                return choice;

            Console.WriteLine("Invalid input, try again.\n");
        }
    }
}
