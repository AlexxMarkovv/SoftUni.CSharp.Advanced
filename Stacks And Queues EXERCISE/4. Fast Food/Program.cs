namespace _4._Fast_Food
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int ordersQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);

            Console.WriteLine(ordersQueue.Max());

            while (ordersQueue.Count > 0)
            {
                int peekOrder = ordersQueue.Peek();
                if (ordersQuantity >= peekOrder)
                {
                    ordersQueue.Dequeue();
                    ordersQuantity -= peekOrder;
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}