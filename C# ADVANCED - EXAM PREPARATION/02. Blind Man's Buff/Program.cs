
using System.Numerics;

int[] sizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = sizes[0];
int cols = sizes[1];

char[,] matrix = new char[rows, cols];

int currRow = 0;
int currCol = 0;

for (int row = 0; row < rows; row++)
{
    char[] rowData = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = rowData[col];

        if (matrix[row, col] == 'B')
        {
            currRow = row;
            currCol = col;
        }
    }
}

int touchedOpponents = 0;
int movesMade = 0;

string command;
while ((command = Console.ReadLine()) != "Finish")
{
    if (touchedOpponents == 3)
    {
        continue;
    }

    int oldRow = currRow;
    int oldCol = currCol;

    switch (command)
    {
        case "up":
            if (ValidateMove(currRow - 1, currCol, matrix))
            {
                movesMade++;

                matrix[currRow, currCol] = '-';

                if (matrix[currRow - 1, currCol] == 'P')
                {
                    touchedOpponents++;
                }

                currRow--;
                matrix[currRow, currCol] = 'B';
            }
            break;
        case "down":
            if (ValidateMove(currRow + 1, currCol, matrix))
            {
                movesMade++;

                matrix[currRow, currCol] = '-';

                if (matrix[currRow + 1, currCol] == 'P')
                {
                    touchedOpponents++;
                }

                currRow++;
                matrix[currRow, currCol] = 'B';
            }
            break;
        case "left":
            if (ValidateMove(currRow, currCol - 1, matrix))
            {
                movesMade++;

                matrix[currRow, currCol] = '-';

                if (matrix[currRow, currCol - 1] == 'P')
                {
                    touchedOpponents++;
                }

                currCol--;
                matrix[currRow, currCol] = 'B';
            }
            break;
        case "right":
            if (ValidateMove(currRow, currCol + 1, matrix))
            {
                movesMade++;

                matrix[currRow, currCol] = '-';

                if (matrix[currRow, currCol + 1] == 'P')
                {
                    touchedOpponents++;
                }

                currCol++;
                matrix[currRow, currCol] = 'B';
            }
            break;
    }

    if (touchedOpponents == 3)
    {
        break;
    }
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");

static bool ValidateMove(int currRow, int currCol, char[,] matrix)
{
    bool isValid = currRow >= 0
        && currRow < matrix.GetLength(0)
        && currCol >= 0
        && currCol < matrix.GetLength(1)
        && matrix[currRow, currCol] != 'O';

    return isValid;
}

//for (int row = 0; row < rows; row++)
//{
//    for (int col = 0; col < cols; col++)
//    {
//        Console.Write(matrix[row, col] + " ");
//    }
//    Console.WriteLine();
//}