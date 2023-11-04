namespace _09._Simple_Text_Editor
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();
            string text = "";

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string cmndType = command[0];

                if (cmndType == "1")
                {
                    stack.Push(text);
                    text += command[1];
                }
                else if (cmndType == "2")
                {
                    stack.Push(text);
                    int count = int.Parse(command[1]);
                    string reversed = new string(text.Reverse().ToArray());

                    reversed = reversed.Remove(0, count);
                    text = new string(reversed.Reverse().ToArray());
                }
                else if (cmndType == "3")
                {
                    int index = int.Parse(command[1]);

                    char ch = text[index - 1];
                    Console.WriteLine(ch);
                }
                else if (cmndType == "4")
                {
                    text = stack.Pop();
                }
            }
        }
    }
}