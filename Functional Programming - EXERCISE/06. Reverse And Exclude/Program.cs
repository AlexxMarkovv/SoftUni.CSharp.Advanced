List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int divider = int.Parse(Console.ReadLine());

Func<List<int>, List<int>> reverseNumbers = numbers =>
{
    List<int> reversedList = new();

    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        reversedList.Add(numbers[i]);
    }

    return reversedList;
};

Func<List<int>, Predicate<int>, List<int>> excludesNums = (numbers, match) =>
{
    List<int> result = new();

    foreach (var number in numbers)
    {
        if (!match(number))
        {
            result.Add(number);
        }
    }

    return result;
};

numbers = excludesNums(numbers, number => number % divider == 0);
numbers = reverseNumbers(numbers);

Console.WriteLine(string.Join(" ", numbers));