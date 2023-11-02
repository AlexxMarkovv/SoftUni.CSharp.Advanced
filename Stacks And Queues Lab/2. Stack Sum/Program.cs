namespace _2._Stack_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            foreach (var item in numbers)
            {
                stack.Push(item);
            }

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                string[] cmndArrgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmndType = cmndArrgs[0];

                if (cmndType == "add")
                {
                    int num1 = int.Parse(cmndArrgs[1]);
                    int num2 = int.Parse(cmndArrgs[2]);

                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if (cmndType == "remove")
                {
                    int count = int.Parse(cmndArrgs[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine("Sum: " + stack.Sum());
        }
    }
}