namespace _01._Count_Same_Values_in_Array
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> counts = new Dictionary<double, int>();

            double[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var item in input)
            {
                if (!counts.ContainsKey(item))
                {
                    counts.Add(item, 1);
                }
                else 
                {
                    counts[item]++;
                }
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}