namespace _7._Hot_Potato
{
    using System;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split();
            int count = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(names);

            while (queue.Count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine("Removed " + queue.Dequeue());
            }

            Console.WriteLine("Last is " + queue.Dequeue());
        }
    }
}