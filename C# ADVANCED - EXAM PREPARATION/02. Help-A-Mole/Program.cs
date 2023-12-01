using System;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int mouseRow = 0;
            int mouseCol = 0;

            int firstSpecialRow = -1;
            int firstSpecialCol = -1;
            int secondSpecialRow = -1;
            int secondSpecialCol = -1;

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                    }

                    if (matrix[row, col] == 'S')
                    {
                        if (firstSpecialRow >= 0)
                        {
                            secondSpecialRow = row;
                            secondSpecialCol = col;
                        }
                        else
                        {
                            firstSpecialRow = row;
                            firstSpecialCol = col;
                        }
                    }
                }
            }

            int points = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "up" && ValidateMove(size, mouseRow - 1, mouseCol))
                {
                    matrix[mouseRow, mouseCol] = '-';
                    mouseRow--;
                }
                else if (command == "down" && ValidateMove(size, mouseRow + 1, mouseCol))
                {
                    matrix[mouseRow, mouseCol] = '-';
                    mouseRow++;
                }
                else if (command == "left" && ValidateMove(size, mouseRow, mouseCol - 1))
                {
                    matrix[mouseRow, mouseCol] = '-';
                    mouseCol--;
                }
                else if (command == "right" && ValidateMove(size, mouseRow, mouseCol + 1))
                {
                    matrix[mouseRow, mouseCol] = '-';
                    mouseCol++;
                }

                if (char.IsDigit(matrix[mouseRow, mouseCol]))
                {
                    points += int.Parse(matrix[mouseRow, mouseCol].ToString());

                    if (points >= 25)
                    {
                        matrix[mouseRow, mouseCol] = 'M';
                        break;
                    }
                }
                else if (matrix[mouseRow, mouseCol] == 'S')
                {
                    if (mouseRow == firstSpecialRow && mouseCol == firstSpecialCol)
                    {
                        mouseRow = secondSpecialRow;
                        mouseCol = secondSpecialCol;
                        matrix[firstSpecialRow, firstSpecialCol] = '-';
                    }
                    else
                    {
                        mouseRow = firstSpecialRow;
                        mouseCol = firstSpecialCol;
                        matrix[secondSpecialRow, secondSpecialCol] = '-';
                    }

                    points -= 3;
                }
                matrix[mouseRow, mouseCol] = 'M';
            }

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool ValidateMove(int size, int row, int col)
        {
            if (row >= 0 && row < size && col >= 0 && col < size)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Don't try to escape the playing field!");
                return false;
            }
        }
    }
}
