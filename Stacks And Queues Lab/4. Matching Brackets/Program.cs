namespace _4._Matching_Brackets
{
    using System;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            var openingBracketIndeces = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBracketIndeces.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = openingBracketIndeces.Pop();
                    for (int j = startIndex; j <= i; j++)
                    {
                        Console.Write(expression[j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}