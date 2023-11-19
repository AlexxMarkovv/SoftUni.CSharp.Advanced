int[] bounds = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string command = Console.ReadLine();

Func<int, int, List<int>> generateRange = (start, end) =>
{
    List<int> range = new();

    for (int i = start; i <= end; i++)
    {
        range.Add(i);
    }

    return range;
};

Func<string, int, bool> evenOddMAtch = (command, number) =>
{
    if(command == "even")
    {
        return number % 2 == 0;
    }
    else
    {
        return number % 2 != 0;
    }
};

List<int> numbers = generateRange(bounds[0], bounds[1]);

foreach (var number in numbers)
{
    if (evenOddMAtch(command, number))
    {
        Console.Write($"{number} ");
    }
}