string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string> printer = name => Console.WriteLine(name);

foreach (string name in names)
{
	printer(name);
}