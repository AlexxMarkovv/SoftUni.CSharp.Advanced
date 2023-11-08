namespace _2._Sum_Matrix_Columns
{
    using System;
    using System.Linq;
    using System.Data;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            for (int i = 0; i < cols; i++)
            {
                int sum = 0;
                for (int j = 0; j < rows; j++)
                {
                    sum += matrix[j,i];
                }
                Console.WriteLine(sum);
            }
        }
    }
}