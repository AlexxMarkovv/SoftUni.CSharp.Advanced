namespace GenericBoxOfString;

public class StartUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Box<int> box = new();

        for (int i = 0; i < n; i++)
        {
            int item = int.Parse(Console.ReadLine());

            box.Add(item);
        }

        int[] indeces = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        box.SwapElements(indeces[0], indeces[1]);

        Console.WriteLine(box);
    }
}