namespace _02._Sets_of_Elements
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            HashSet<int> uniqueNums = new HashSet<int>();

            int[] setsCounts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < setsCounts[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                set1.Add(number);
            }

            for (int i = 0; i < setsCounts[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                set2.Add(number);
            }

            //foreach (var item in set1)
            //{
            //    if (set2.Contains(item))
            //    {
            //        uniqueNums.Add(item);
            //    }
            //}

            uniqueNums = set1.Intersect(set2).ToHashSet();

            Console.WriteLine(string.Join(" ", uniqueNums));
        }
    }
}