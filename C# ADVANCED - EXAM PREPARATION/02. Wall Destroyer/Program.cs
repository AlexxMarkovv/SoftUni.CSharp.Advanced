using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace _02._Wall_Destroyer
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int vankoRow = 0;
            int vankoCol = 0;

            for (int row = 0; row < size; row++)
            {
                string rows = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rows[col];

                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            int countOfHoles = 1;
            int countOfRods = 0;
            bool isElectroCuted = false;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                matrix[vankoRow, vankoCol] = '*';

                bool isValidMove = false;
                isValidMove = CheckIfTheMoveIsValid(matrix, vankoRow, vankoCol, command, isValidMove);

                if (isValidMove && isElectroCuted == false)
                {
                    switch(command)
                    {
                        case "up":
                            char symbol = matrix[vankoRow - 1, vankoCol];
                            switch (symbol)
                            {
                                case '-':
                                    vankoRow--;
                                    countOfHoles++;   
                                    break;
                                case 'R':
                                    Console.WriteLine("Vanko hit a rod!");
                                    countOfRods++; 
                                    break;
                                case 'C':
                                    matrix[vankoRow - 1, vankoCol] = 'E';
                                    isElectroCuted = true;
                                    countOfHoles++;
                                    break;
                                case '*':
                                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow - 1}, {vankoCol}]!");
                                    vankoRow--;
                                    break;
                            }
                            break;

                        case "down":
                            char symbol2 = matrix[vankoRow + 1, vankoCol];
                            switch (symbol2)
                            {
                                case '-':
                                    vankoRow++;
                                    countOfHoles++;
                                    break;
                                case 'R':
                                    Console.WriteLine("Vanko hit a rod!");
                                    countOfRods++;
                                    break;
                                case 'C':
                                    matrix[vankoRow + 1, vankoCol] = 'E';
                                    isElectroCuted = true;
                                    countOfHoles++;
                                    break;
                                case '*':
                                    Console.WriteLine($"The wall is already destroyed at position" +
                                        $" [{vankoRow - 1}, {vankoCol}]!");
                                    vankoRow++;
                                    break;
                            }
                            break;

                        case "left":
                            char symbol3 = matrix[vankoRow, vankoCol - 1];
                            switch (symbol3)
                            {
                                case '-':
                                    vankoCol--;
                                    countOfHoles++;
                                    break;
                                case 'R':
                                    Console.WriteLine("Vanko hit a rod!");
                                    countOfRods++;
                                    break;
                                case 'C':
                                    matrix[vankoRow, vankoCol - 1] = 'E';
                                    isElectroCuted = true;
                                    countOfHoles++;
                                    break;
                                case '*':
                                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol - 1}]!");
                                    vankoCol--;
                                    break;
                            }
                            break;

                        case "right":
                            char symbol4 = matrix[vankoRow , vankoCol + 1];
                            switch (symbol4)
                            {
                                case '-':
                                    vankoCol++;
                                    countOfHoles++;
                                    break;
                                case 'R':
                                    Console.WriteLine("Vanko hit a rod!");
                                    countOfRods++;
                                    break;
                                case 'C':
                                    matrix[vankoRow, vankoCol + 1] = 'E';
                                    isElectroCuted = true;
                                    countOfHoles++;
                                    break;
                                case '*':
                                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow - 1}, {vankoCol}]!");
                                    vankoCol++;
                                    break;
                            }
                            break;

                    }
                }

                if (isElectroCuted)
                {
                    break;
                }

            }

            if (isElectroCuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
                matrix[vankoRow, vankoCol] = 'V';
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static bool CheckIfTheMoveIsValid(char[,] matrix,
            int carRow, int carCol, string command, bool isValid)
        {
            switch (command)
            {
                case "left":
                    if (carCol - 1 >= 0)
                    {
                        isValid = true;
                    }
                    break;
                case "right":
                    if (carCol + 1 < matrix.GetLength(0))
                    {
                        isValid = true;
                    }
                    break;
                case "up":
                    if (carRow - 1 >= 0)
                    {
                        isValid = true;
                    }
                    break;
                case "down":
                    if (carRow + 1 < matrix.GetLength(1))
                    {
                        isValid = true;
                    }
                    break;

            }

            return isValid;
        }
    }
}