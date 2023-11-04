namespace _07._Truck_Tour
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();
            
            for (int i = 0; i < petrolPumps; i++)
            {
                int[] pumpInfo2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(pumpInfo2);
            }

            int petrol = 0;
            int startingIndex = 0;

            for (int i = 0; i < queue.Count; i++)
            {
                int[] pumpInfo = queue.Peek();
                petrol += pumpInfo[0];

                if (petrol >= pumpInfo[1])
                {
                    petrol -= pumpInfo[1];
                }
                else
                {
                    petrol = 0;
                    queue.Enqueue(queue.Dequeue());
                    startingIndex++;
                }
            }

            Console.WriteLine(startingIndex);
        }
    }
}