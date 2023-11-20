int nameLength = int.Parse(Console.ReadLine());

List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Func<List<string>, Predicate<string>, List<string>> filter = (names, match) =>
{
    List<string> result = new List<string>();

    foreach (var name in names)
    {
        if (match(name))
        {
            result.Add(name);
        }
    }

    return result;
};

names = filter(names, name => name.Length <= nameLength);

Console.WriteLine(string.Join(Environment.NewLine, names));