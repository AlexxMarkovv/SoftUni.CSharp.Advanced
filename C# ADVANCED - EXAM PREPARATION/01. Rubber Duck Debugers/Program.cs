Queue<int> times = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> tasks = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Dictionary<string, int> ducks = new Dictionary<string, int>()
{
    {"Darth Vader Ducky", 0 },
    {"Thor Ducky", 0 },
    {"Big Blue Rubber Ducky", 0 },
    {"Small Yellow Rubber Ducky", 0}
};

while (times.Count > 0)
{
    int time = times.Peek();
    int task = tasks.Peek();
    int multiply = time * task;

    if (multiply >= 0 && multiply <= 60)
    {
        ducks["Darth Vader Ducky"]++;
        tasks.Pop();
        times.Dequeue();
    }
    else if (multiply >= 61 && multiply <= 120)
    {
        ducks["Thor Ducky"]++;
        tasks.Pop();
        times.Dequeue();
    }
    else if (multiply >= 121 && multiply <= 180)
    {
        ducks["Big Blue Rubber Ducky"]++;
        tasks.Pop();
        times.Dequeue();
    }
    else if (multiply >= 181 && multiply <= 240)
    {
        ducks["Small Yellow Rubber Ducky"]++;
        tasks.Pop();
        times.Dequeue();
    }
    else
    {
        tasks.Push(tasks.Pop() - 2);

        times.Enqueue(times.Dequeue());
    }
}

Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

foreach (var duck in ducks)
{
    Console.WriteLine($"{duck.Key}: {duck.Value}");
}