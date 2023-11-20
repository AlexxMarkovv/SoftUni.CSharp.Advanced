List<string> people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string command;
while ((command = Console.ReadLine()) != "Party!")
{
    string[] cmndArrgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string action = cmndArrgs[0];
    string filter = cmndArrgs[1];
    string value = cmndArrgs[2];

    if (action == "Remove")
    {
        people.RemoveAll(CheckingNames(filter, value));
    }
    else
    {
        List<string> peopleToDouble = people.FindAll(CheckingNames(filter, value));

        foreach (string person in peopleToDouble)
        {
            int index = people.FindIndex(p => p == person);

            people.Insert(index, person);
        }
    }
}

if (people.Any())
{
    Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}

static Predicate<string> CheckingNames(string filter, string value)
{
    switch (filter)
    {
        case "StartsWith": return n => n.StartsWith(value);
        case "EndsWith": return n => n.EndsWith(value);
        case "Length": return n => n.Length == int.Parse(value);
        default:
            return null;
    }
}
