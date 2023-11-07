namespace _05._Count_Symbols
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> occurences = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (var item in text)
            {
                if (!occurences.ContainsKey(item))
                {
                    occurences.Add(item, 0);
                }
                occurences[item]++;
            }

            foreach (var item in occurences)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}