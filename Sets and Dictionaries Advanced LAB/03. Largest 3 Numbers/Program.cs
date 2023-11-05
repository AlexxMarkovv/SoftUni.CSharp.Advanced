namespace _03._Largest_3_Numbers
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            array = array.OrderByDescending(x => x)
                .Take(3).ToArray();

            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }   
        }
    }
}