namespace _3._Maximal_Sum
{
    using System;
    using System.Linq;
    using System.Data;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixData[0];
            int cols = matrixData[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowNums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowNums[col];
                }
            }

            int squareRows = 3;
            int squareCols = 3;

            int maxSum = int.MinValue;
            int maxRow  = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int currSum = 0;

                    if (row > matrix.GetLength(0) - squareRows
                        || col > matrix.GetLength(1) - squareCols)
                    {
                        continue;
                    }

                    for (int sqrRow = 0; sqrRow < squareRows; sqrRow++)
                    {
                        for (int sqrCol = 0; sqrCol < squareCols; sqrCol++)
                        {
                            currSum += matrix[row + sqrRow, col + sqrCol];
                        }
                    }

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{matrix[maxRow + i, maxCol + j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}