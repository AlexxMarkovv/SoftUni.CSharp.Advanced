namespace _01._Unique_Usernames
{
    using System;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string username = Console.ReadLine();
                set.Add(username);
            }

            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}