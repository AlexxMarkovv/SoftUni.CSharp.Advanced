Queue<int> textiles = new Queue<int> 
    (Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> medicaments = new Stack<int>
    (Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Dictionary<string, int> items = new Dictionary<string, int>()
{
    {"Patch", 0},
    {"Bandage", 0},
    {"MedKit", 0 },
};

while (true)
{
    int sum = textiles.Peek() + medicaments.Peek();
    int remainValue = 0;

    switch (sum)
    {
        case 30:
            items["Patch"]++;
            textiles.Dequeue();
            medicaments.Pop();
            break;
        case 40:
            items["Bandage"]++;
            textiles.Dequeue();
            medicaments.Pop();
            break;
        case 100:
            items["MedKit"]++;
            textiles.Dequeue();
            medicaments.Pop();
            break;

    }

    if (sum > 100)
    {
        remainValue = sum - 100;
        items["MedKit"]++;

        textiles.Dequeue();
        medicaments.Pop();

        //int nextValue = medicaments.Pop();
        medicaments.Push(medicaments.Pop() + remainValue);
    }
    else if (sum != 30 && sum != 40 && sum != 100)
    {
        textiles.Dequeue();
        medicaments.Push(medicaments.Pop() + 10);
    }

    if (textiles.Count == 0 || medicaments.Count == 0)
    {
        break;
    }
}

if (!textiles.Any() && !medicaments.Any())
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if (!textiles.Any())
{
    Console.WriteLine("Textiles are empty.");
}
else if (!medicaments.Any())
{
    Console.WriteLine("Medicaments are empty.");
}

foreach (var item in items.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    if (item.Value > 0)
    {
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}

if (medicaments.Any())
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}
else if (textiles.Any())
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}