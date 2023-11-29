Queue<int> coffeeQs = new Queue<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> milkQs = new Stack<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Dictionary<string, int> drinks = new Dictionary<string, int>()
{
    {"Cortado", 0 },
    {"Espresso", 0 },
    {"Capuccino", 0 },
    {"Americano", 0 },
    {"Latte", 0 }
};

string command;
while (true)
{
    int sum = coffeeQs.Peek() + milkQs.Peek();

    bool isDrinkMade = true;

    switch (sum)
    {
        case 50:
            drinks["Cortado"]++;
            break;
        case 75:
            drinks["Espresso"]++;
            break;
        case 100:
            drinks["Capuccino"]++;
            break;
        case 150:
            drinks["Americano"]++;
            break;
        case 200:
            drinks["Latte"]++;
            break;
        default:
            coffeeQs.Dequeue();
            milkQs.Push(milkQs.Pop() - 5);
            isDrinkMade = false;
            break;
    }

    if (isDrinkMade)
    {
        coffeeQs.Dequeue();
        milkQs.Pop();
    }

    if (coffeeQs.Count == 0 || milkQs.Count == 0)
    {
        break;
    }
}

if (!coffeeQs.Any() && !milkQs.Any())
{
    Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
    Console.WriteLine("Coffee left: none");
    Console.WriteLine("Milk left: none");
}
else
{
    Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");

    if (coffeeQs.Count == 0)
    {
        Console.WriteLine("Coffee left: none");
        Console.WriteLine($"Milk left: {string.Join(", ", milkQs)}");
    }
    else
    {
        Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQs)}");
        Console.WriteLine("Milk left: none");
    }
}

foreach (var drink in drinks
    .OrderBy(x => x.Value)
    .ThenByDescending(x => x.Key))
{
    if (drink.Value > 0)
    Console.WriteLine($"{drink.Key}: {drink.Value}");
}