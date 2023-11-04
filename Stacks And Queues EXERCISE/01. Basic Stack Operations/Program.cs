namespace _01._Basic_Stack_Operations
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

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < numsInfo[0]; i++)
            {
                stack.Push(listOfIntegers[i]);
            }

            for (int i = 0; i < numsInfo[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                if (stack.Contains(numsInfo[2]))
                {
                    Console.WriteLine("true");
                }
                else if (!stack.Contains(numsInfo[2]))
                {
                    int smallestNum = stack.Min();
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