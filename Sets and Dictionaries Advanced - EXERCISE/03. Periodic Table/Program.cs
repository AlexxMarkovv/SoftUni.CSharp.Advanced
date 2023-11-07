namespace _03._Periodic_Table
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                elements.UnionWith(elArray);
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}