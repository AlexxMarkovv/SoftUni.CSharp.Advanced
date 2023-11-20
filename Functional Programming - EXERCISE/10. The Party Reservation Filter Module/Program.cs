List<string> people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Dictionary<string, Predicate<string>> filters = new();

string command;
while ((command = Console.ReadLine()) != "Print")
{
    string[] cmndArrgs = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string cmndType = cmndArrgs[0];
    string filter = cmndArrgs[1];
    string value = cmndArrgs[2];

    if (cmndType == "Add filter")
    {
        if (!filters.ContainsKey(filter + value))
        {
            filters.Add(filter + value, GetPredicate(filter, value));
        }
    }
    else if (cmndType == "Remove filter")
    {
        filters.Remove(filter + value);
    }
}

foreach (var filter in filters)
{
    people.RemoveAll(filter.Value);
}

Console.WriteLine(string.Join(" ", people));

static Predicate<string> GetPredicate(string filterType, string filterParam)
{
    switch (filterType)
    {
        case "Starts with": return p => p.StartsWith(filterParam);
        case "Ends with": return p => p.EndsWith(filterParam);
        case "Length": return p => p.Length == int.Parse(filterParam);
        case "Contains": return p => p.Contains(filterParam);
        default:
            return null;
    }
}