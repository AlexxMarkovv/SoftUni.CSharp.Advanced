namespace _4._Matrix_Shuffling
{
    using System;
    using System.Linq;
    using System.Data;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] matrixData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = matrixData[col];
                }
            }

            string command;
            while((command = Console.ReadLine()) != "END")
            {
                string[] cmndArrgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmndArrgs.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                
                int row1 = int.Parse(cmndArrgs[1]);
                int col1 = int.Parse(cmndArrgs[2]);
                int row2 = int.Parse(cmndArrgs[3]);
                int col2 = int.Parse(cmndArrgs[4]);

                if (cmndArrgs.First() != "swap" || cmndArrgs.Length != 5 
                    || row1 < 0 || col1 < 0 || row2 < 0 || col2 < 0 || 
                    row1 >= rows || col1 >= cols || row2 >= rows || col2 >= cols)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string element = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = element;

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            Console.Write($"{matrix[i,j]} ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}