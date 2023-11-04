namespace _3._Maximum_and_Minimum_Element
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int numOfQueries = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfQueries; i++)
            {
                int[] queries = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int typeOfQuery = queries[0];

                if (typeOfQuery == 1)
                {
                    stack.Push(queries[1]);
                }
                else if (typeOfQuery == 2 && stack.Count > 0)
                {
                    stack.Pop();
                }

                if (typeOfQuery == 3 && stack.Count > 0)
                {
                    int maxNum = stack.Max();
                    Console.WriteLine(maxNum);
                }
                else if (typeOfQuery == 4 && stack.Count > 0)
                {
                    int minNum = stack.Min();
                    Console.WriteLine(minNum);
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}