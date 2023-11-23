namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new();

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                family.AddMember(new Person(name, age));
            }

            family.Members = family.Members.Where(m => m.Age > 30)
                .OrderBy(m => m.Name).ToList();

            foreach (var member in family.Members)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}