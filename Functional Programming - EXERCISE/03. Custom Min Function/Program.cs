HashSet<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .ToHashSet();

Func<HashSet<int>, int> minNum = numbers =>
{
    int min = int.MaxValue;

    foreach (var number in numbers)
    {
        if (number < min)
        {
            min = number;
        }
    }

    return min;
};

Console.WriteLine(minNum(numbers));
