decimal[] prices = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(decimal.Parse)
    .ToArray();

Func<decimal, decimal> func = x => x * 1.20m;

foreach (var price in prices)
{
    Console.WriteLine($"{func(price):f2}");
}
