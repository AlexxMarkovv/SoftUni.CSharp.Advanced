namespace _3._Simple_Calculator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            var stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++) 
            {
                stack.Push(input[i]);
            }

            int firstNum = 0;
            int result = 0;

            while (stack.Count > 0)
            {
                string firstSymbol = stack.Pop();
                if (firstSymbol != "+" && firstSymbol != "-")
                {
                    firstNum = int.Parse(firstSymbol);
                }
                else if(firstSymbol == "-")
                {
                    int secondNum = int.Parse(stack.Pop());
                    result = firstNum - secondNum;
                    firstNum = result;
                }
                else if (firstSymbol == "+")
                {
                    int secondNum = int.Parse(stack.Pop());
                    result = firstNum + secondNum;
                    firstNum = result;
                }
            }
            Console.WriteLine(result);
        }
    }
}