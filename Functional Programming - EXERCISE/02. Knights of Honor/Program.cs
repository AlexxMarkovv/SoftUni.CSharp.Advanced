string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string> printerWithTitle = name => Console.WriteLine($"Sir {name}");

foreach(string name in names)
{
    printerWithTitle(name);
}