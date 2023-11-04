namespace _2._Basic_Queue_Operations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numsInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] listOfIntegers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbersInQueue = new Queue<int>();
            for (int i = 0; i < numsInfo[0]; i++)
            {
                numbersInQueue.Enqueue(listOfIntegers[i]);
            }

            for (int i = 0; i < numsInfo[1]; i++)
            {
                numbersInQueue.Dequeue();
            }

            if (numbersInQueue.Count > 0)
            {
                if (numbersInQueue.Contains(numsInfo[2]))
                {
                    Console.WriteLine("true");
                }
                else if (!numbersInQueue.Contains(numsInfo[2]))
                {
                    int smallestNum = numbersInQueue.Min();
                    Console.WriteLine(smallestNum);
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}