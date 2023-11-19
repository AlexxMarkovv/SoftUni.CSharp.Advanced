List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

Func<string, List<int>, List<int>> calculate = (command, numbers) =>
{
    List<int> result = new List<int>();

    foreach (int number in numbers)
    {
        switch (command)
        {
            case "add": result.Add(number + 1);
                break;
            case "multiply": result.Add(number * 2);
                break;
            case "subtract": result.Add(number - 1);
                break;
        }
    }
    return result;
};


Action<List<int>> printer = numbers => 
Console.WriteLine(string.Join(" ", numbers));

string command;
while ((command = Console.ReadLine()) != "end")
{
    switch (command)
    {
        case "print": printer(numbers); break;
        default: numbers = calculate(command, numbers); break;
    }
}