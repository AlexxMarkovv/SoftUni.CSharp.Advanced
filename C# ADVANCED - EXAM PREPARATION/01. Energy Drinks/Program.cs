
int[] caffInts = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] drinksInts = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> caffeinMg = new();

foreach (var caff in caffInts)
{
    caffeinMg.Push(caff);
}

Queue<int> drinks = new Queue<int>();

foreach (var drink in drinksInts)
{
    drinks.Enqueue(drink);
}

int currentCaffein = 0;
int caffeinLimit = 300;

for (int i = caffeinMg.Count - 1; i >= 0; i--)
{
    for (int j = 0; j < drinks.Count; j++)
    {
        if (caffeinMg.Peek() * drinks.Peek() <= caffeinLimit)
        {
            currentCaffein += caffeinMg.Peek() * drinks.Peek();
            caffeinLimit -= caffeinMg.Peek() * drinks.Peek();

            caffeinMg.Pop();
            drinks.Dequeue();
        }
        else
        {
            currentCaffein -= 30;
            caffeinLimit += 30;

            if (currentCaffein < 0)
            {
                currentCaffein = 0;
            }

            int removedDrink = drinks.Dequeue();
            drinks.Enqueue(removedDrink);
            caffeinMg.Pop();
        }

        if (drinks.Count == 0 || caffeinMg.Count == 0)
        {
            break;
        }
    }

    if (drinks.Count == 0 || caffeinMg.Count == 0)
    {
        if (drinks.Count == 0)
        {
            Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            Console.WriteLine($"Stamat is going to sleep with {currentCaffein} mg caffeine.");
            return;
        }
        else
        {
            Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
            Console.WriteLine($"Stamat is going to sleep with {currentCaffein} mg caffeine.");
            return;
        }

    }
}

