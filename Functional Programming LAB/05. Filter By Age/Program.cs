int n = int.Parse(Console.ReadLine());

List<Person> people = new List<Person>();

for (int i = 0; i < n; i++)
{
    string[] person = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries);

    people.Add(new Person(person[0], int.Parse(person[1])));
}

string filterType = Console.ReadLine();
int ageFilter = int.Parse(Console.ReadLine());
string formatType = Console.ReadLine();

Func<Person, bool> filter = GetFilter(filterType, ageFilter);

people = people.Where(filter).ToList();

Action<Person> printer = GetPrinter(formatType);

foreach (var person in people)
{
    printer(person);
}

Func<Person, bool> GetFilter(string filterType, int age)
{
    switch (filterType)
    {
        case "older": return person => person.Age >= ageFilter;
        case "younger": return person => person.Age < ageFilter;
        default:
            return null;
    }
}

Action<Person> typePrinting = GetPrinter(formatType);

Action<Person> GetPrinter(string formatType)
{
    switch (formatType)
    {
        case "name age": return p => Console.WriteLine($"{p.Name} - {p.Age}");
        case "name": return p => Console.WriteLine(p.Name);
        case "age": return p => Console.WriteLine(p.Age);
        default:
            return null;
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}