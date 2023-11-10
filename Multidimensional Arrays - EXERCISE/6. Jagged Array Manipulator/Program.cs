namespace _6._Jagged_Array_Manipulator
{
    using System;
    using System.Linq;
    using System.Data;
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArr = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArr[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                if (i > 0)
                {
                    double[] array = jaggedArr[i - 1];
                    int length1 = array.Length;
                    int length2 = jaggedArr[i].Length;

                    if (length1 == length2)
                    {
                        for (int j = 0; j < length1; j++)
                        {
                            jaggedArr[i - 1][j] *= 2;
                            jaggedArr[i][j] *= 2;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < length1; j++)
                        {
                            jaggedArr[i - 1][j] /= 2;
                        }

                        for (int j = 0; j < length2; j++)
                        {
                            jaggedArr[i][j] /= 2;
                        }
                    }
                }
            }

            string command;
            while ((command= Console.ReadLine()) != "End")
            {
                string[] cmndArrgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmndType = cmndArrgs[0];
                int row = int.Parse(cmndArrgs[1]);
                int col = int.Parse(cmndArrgs[2]);
                int value = int.Parse(cmndArrgs[3]);

                if (cmndType == "Add" && row >= 0 && row < jaggedArr.Length
                    && col >= 0 && col < jaggedArr[row].Length)
                {
                    jaggedArr[row][col] += value;
                }
                else if (cmndType == "Subtract" && row >= 0 && row < jaggedArr.Length
                    && col >= 0 && col < jaggedArr[row].Length)
                {
                    jaggedArr[row][col] -= value;
                }
            }

            foreach (double[] row in jaggedArr)
            {
                Console.Write($"{string.Join(" ", row)}");
                Console.WriteLine();
            }
        }
    }
}