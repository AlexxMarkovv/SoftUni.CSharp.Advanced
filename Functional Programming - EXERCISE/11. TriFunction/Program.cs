using System.Xml.Linq;

int charsSum = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Func<string, int, bool> checkingCharsSum =
    (name, sum) => name.Sum(ch => ch) >= charsSum;

Func<string[], int, Func<string, int, bool>, string> getFirstName =
    (names, charsSum, match) => names.FirstOrDefault(name => match(name, charsSum));

Console.WriteLine(getFirstName(names, charsSum, checkingCharsSum));

