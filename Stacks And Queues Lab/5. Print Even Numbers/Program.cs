namespace _5._Print_Even_Numbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();
            foreach (var item in integers)
            {
                if (item % 2 == 0)
                {
                    queue.Enqueue(item);
                }
            }
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}