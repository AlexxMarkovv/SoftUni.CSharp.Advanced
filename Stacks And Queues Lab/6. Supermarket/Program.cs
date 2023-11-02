namespace _6._Supermarket
{
    using System;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var queue = new Queue<string>();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, queue));
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            if (input == "End")
            {
                Console.WriteLine($"{queue.Count} people remaining.");
            }
        }
    }
}