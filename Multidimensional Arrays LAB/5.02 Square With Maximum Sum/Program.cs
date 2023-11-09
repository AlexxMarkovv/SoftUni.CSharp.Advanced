namespace _5._Square_With_Maximum_Sum
{
    using System;
    using System.Linq;
    using System.Data;
    internal class Program
    {
        static void Main(string[] args)
        {
            int squareRows = 3;
            int squareCols = 3;

            int[,] matrix = ReadMatrixWithCommas();

            int maxSum = matrix[0,0];
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int currSum = 0;

                    if (row > matrix.GetLength(0) - squareRows ||
                        col > matrix.GetLength(1) - squareCols)
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


                    //currSum += matrix[row, col];
                    //currSum += matrix[row + 1, col];
                    //currSum += matrix[row, col + 1];
                    //currSum += matrix[row + 1, col + 1];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int i = 0; i < squareRows; i++)
            {
                for (int j = 0; j < squareCols; j++)
                {
                    Console.Write(matrix[maxRow + i, maxCol + j] + " ");
                }
                Console.WriteLine();
            }

            //Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            //Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");

            Console.WriteLine(maxSum);
        }

        public static int[,] ReadMatrixWithCommas()
        {
            int[] matrixData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = matrixData[0];
            int cols = matrixData[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowNums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowNums[col];
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}