Queue<int> tools = new Queue<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> substances = new Stack<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

List<int> chalanges = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

while (tools.Count > 0 && substances.Count > 0 && chalanges.Count > 0)
{
    int sum = tools.Peek() * substances.Peek();

    if (chalanges.Contains(sum))
    {
        tools.Dequeue();
        substances.Pop();

        chalanges.Remove(sum);
    }
    else
    {
        tools.Enqueue(tools.Dequeue() + 1);

        int subst = substances.Peek() - 1;

        if (subst <= 0)
        {
            substances.Pop();
        }
        else
        {
            substances.Push(substances.Pop() - 1);
        }
    }
}

if (chalanges.Count > 0)
{
    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");

    if (tools.Any())
    {
        Console.WriteLine($"Tools: {string.Join(", ", tools)}");
    }
    else if (substances.Any())
    {
        Console.WriteLine($"Substances: {string.Join(", ", substances)}");
    }

    Console.WriteLine($"Challenges: {string.Join(", ", chalanges)}");
}
else
{
    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");

    if (tools.Any())
    {
        Console.WriteLine($"Tools: {string.Join(", ", tools)}");
    }
    else if (substances.Any())
    {
        Console.WriteLine($"Substances: {string.Join(", ", substances)}");
    }
}