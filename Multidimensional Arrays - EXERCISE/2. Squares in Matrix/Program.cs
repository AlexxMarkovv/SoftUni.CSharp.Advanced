namespace _2._Squares_in_Matrix
{
    using System;
    using System.Linq;
    using System.Data;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] symbols = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            int squares = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col+1]
                        && matrix[row, col] == matrix[row+1,col]
                        && matrix[row, col] == matrix[row+1,col+1])
                    {
                        squares++;
                    }
                }
            }

            Console.WriteLine(squares);
        }
    }
}