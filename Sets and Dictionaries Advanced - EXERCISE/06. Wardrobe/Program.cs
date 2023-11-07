namespace _06._Wardrobe
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] details = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = details[0];

                string[] clothes = details[1]
                    .Split(",",StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    AddingCLothes(wardrobe, color, clothes);
                }
                else
                {
                    AddingCLothes(wardrobe, color, clothes);
                }
            }

            string[] searchedCloth = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorr = searchedCloth[0];
            string clothh = searchedCloth[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var item2 in item.Value)
                {
                    if (item.Key == colorr && item2.Key == clothh)
                    {
                        Console.WriteLine($"* {item2.Key} - {item2.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item2.Key} - {item2.Value}");
                    }
                }
            }
        }

        static void AddingCLothes(Dictionary<string, Dictionary<string, int>> wardrobe,
            string color, string[] clothes)
        {
            foreach (var item in clothes)
            {
                if (!wardrobe[color].ContainsKey(item))
                {
                    wardrobe[color].Add(item, 1);
                }
                else
                {
                    wardrobe[color][item]++;
                }
            }
        }
    }
}