namespace _7._Pascal_Triangle
{
    using System;
    using System.Linq;
    using System.Data;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] pascalArr = new long[n][];
            pascalArr[0] = new long[1] { 1 };

            for (int row = 1; row < n; row++)
            {
                pascalArr[row] = new long[row + 1];

                for (int col = 0; col < pascalArr[row].Length; col++)
                {
                    if (pascalArr[row - 1].Length > col)
                    {
                        pascalArr[row][col] += pascalArr[row - 1][col];
                    }

                    if (col > 0)
                    {
                        pascalArr[row][col] += pascalArr[row - 1][col - 1];
                    }
                }
            }

            for (int i = 0; i < pascalArr.Length; i++)
            {
                for (int j = 0; j < pascalArr[i].Length; j++)
                {
                    Console.Write(pascalArr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}