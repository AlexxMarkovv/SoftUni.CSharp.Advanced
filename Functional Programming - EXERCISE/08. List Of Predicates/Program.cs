int range = int.Parse(Console.ReadLine());

HashSet<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

List<Predicate<int>> predicates = new();

int[] numbers = Enumerable.Range(1, range).ToArray();

foreach(int divider in dividers)
{
    Predicate<int> check = n => n % divider == 0;

    predicates.Add(check);
}

foreach(var number in numbers)
{
    bool isDivisible = true;

    foreach (var match in predicates)
    {
        if (!match(number))
        {
            isDivisible = false;
            break;
        }
    }

    if (isDivisible)
    {
        Console.Write(number + " ");
    }
}