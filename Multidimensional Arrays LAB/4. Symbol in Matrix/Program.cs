namespace _4._Symbol_in_Matrix
{
    using System;
    using System.Linq;
    using System.Data;
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n,n];

            for (int i = 0; i < n; i++)
            {
                string symbols = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = symbols[j];
                }
            }

            char symbolSearched = char.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == symbolSearched)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbolSearched} does not occur in the matrix");
        }
    }
}