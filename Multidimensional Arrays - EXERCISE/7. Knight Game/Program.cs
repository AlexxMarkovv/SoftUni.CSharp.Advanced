namespace _7._Knight_Game
{
    using System;
    using System.Linq;
    using System.Data;
    using System.Numerics;

    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string chars = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            int knightsRemoved = 0;

            while (true)
            {
                int countMostAttack = 0;
                int rowMostAtacking = 0;
                int colMostAtacking = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attackedKnights = CountAttackedKnights(row, col, matrix);

                            if (attackedKnights > countMostAttack)
                            {
                                countMostAttack = attackedKnights;
                                rowMostAtacking = row;
                                colMostAtacking = col;
                            }
                        }
                    }
                }

                if (countMostAttack == 0)
                {
                    break;
                }
                else
                {
                    matrix[rowMostAtacking, colMostAtacking] = '0';
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        static int CountAttackedKnights(int row, int col, char[,] matrix)
        {
            int attackedKnights = 0;

            if (isCellValid(row - 1, col - 2, matrix))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isCellValid(row + 1, col - 2, matrix))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isCellValid(row - 1, col + 2, matrix))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isCellValid(row + 1, col + 2, matrix))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isCellValid(row - 2, col - 1, matrix))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isCellValid(row - 2, col + 1, matrix))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isCellValid(row + 2, col - 1, matrix))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (isCellValid(row + 2, col + 1, matrix))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }

        static bool isCellValid(int row, int col, char[,] matrix)
        {
            return
                row >= 0
              && row < matrix.Length
              && col >= 0
              && col < matrix.Length;
        }
    }
}