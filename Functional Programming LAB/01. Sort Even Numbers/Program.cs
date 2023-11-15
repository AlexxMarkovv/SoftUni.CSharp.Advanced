int[] numbers = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .Where(x => x % 2 == 0)
    .OrderBy(x => x)
    .ToArray();

Console.WriteLine(string.Join(", ", numbers));
    

