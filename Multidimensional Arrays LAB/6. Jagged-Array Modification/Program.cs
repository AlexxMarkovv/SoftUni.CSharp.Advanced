namespace _6._Jagged_Array_Modification
{
    using System;
    using System.Linq;
    using System.Data;
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[rows][];

            for (int row = 0; row < jaggedArr.Length; row++)
            {
                jaggedArr[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmndArrgs = command.Split();
                int row = int.Parse(cmndArrgs[1]);
                int col = int.Parse(cmndArrgs[2]);
                int value = int.Parse(cmndArrgs[3]);

                if (row < 0 || col < 0 || row >= jaggedArr.Length
                    || col >= jaggedArr[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (cmndArrgs.First() == "Add")
                {
                    jaggedArr[row][col] += value;
                }
                else if (cmndArrgs.First() == "Subtract")
                {
                    jaggedArr[row][col] -= value;
                }
            }

            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write($"{jaggedArr[row][col]} ");
                }
                Console.WriteLine();
            }




            //Console.WriteLine("How many rows?");
            //int rows = int.Parse(Console.ReadLine());

            //int[][] jaggedArr = new int[rows][];

            //for (int row = 0; row < jaggedArr.Length; row++)
            //{
            //    Console.WriteLine("How many cols?");
            //    int cols = int.Parse(Console.ReadLine());

            //    jaggedArr[row] = new int[cols];

            //    for (int col = 0; col < cols; col++)
            //    {
            //        Console.Write($"jaggedArray[{row}][{col}]=");
            //        jaggedArr[row][col] = int.Parse(Console.ReadLine());
            //    }
            //    Console.WriteLine();
            //}

            //for (int row = 0; row < rows; row++)
            //{
            //    jaggedArr[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //}


            //for (int row = 0; row < jaggedArr.Length; row++)
            //{
            //    for (int col = 0; col < jaggedArr[row].Length; col++)
            //    {
            //        Console.Write($"{jaggedArr[row][col]} ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}