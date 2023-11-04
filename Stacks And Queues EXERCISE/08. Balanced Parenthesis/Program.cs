namespace _08._Balanced_Parenthesis
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<char> stack = new();

            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(expression[i]);
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}