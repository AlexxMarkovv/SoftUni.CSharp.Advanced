int[] sizes = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = sizes[0];
int cols = sizes[1];

char[,] matrix = new char[rows, cols];

int currRow = -1;
int currCol = -1;

int cheeseCount = 0;

for (int row = 0; row < rows; row++)
{
    string rowData = Console.ReadLine();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = rowData[col];

        if (matrix[row, col] == 'M')
        {
            currRow = row;
            currCol = col;
        }

        if (matrix[row, col] == 'C')
        {
            cheeseCount++;
        }
    }
}

string command = string.Empty;
while((command = Console.ReadLine()) != "danger")
{
    if (command == "up" && ValidateMove(matrix, currRow - 1, currCol))
    {
        if (matrix[currRow - 1, currCol] == '@')
        {
            continue;
        }

        matrix[currRow, currCol] = '*';
        currRow--;
    }
    else if (command == "down" && ValidateMove(matrix, currRow + 1, currCol))
    {
        if (matrix[currRow + 1, currCol] == '@')
        {
            continue;
        }

        matrix[currRow, currCol] = '*';
        currRow++;
    }
    else if (command == "right" && ValidateMove(matrix, currRow, currCol + 1))
    {
        if (matrix[currRow, currCol + 1] == '@')
        {
            continue;
        }

        matrix[currRow, currCol] = '*';
        currCol++;
    }
    else if (command == "left" && ValidateMove(matrix, currRow, currCol - 1))
    {
        if (matrix[currRow, currCol - 1] == '@')
        {
            continue;
        }

        matrix[currRow, currCol] = '*';
        currCol--;
    }
    else
    {
        Console.WriteLine("No more cheese for tonight!");
        break;
    }

    if (matrix[currRow, currCol] == 'C')
    {
        cheeseCount--;
        if (cheeseCount <= 0)
        {
            matrix[currRow, currCol] = 'M';
            Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
            break;
        }

        matrix[currRow, currCol] = '*';
    }
    else if (matrix[currRow, currCol] == 'T')
    {
        matrix[currRow, currCol] = 'M';
        Console.WriteLine("Mouse is trapped!");
        break;
    }
    else
    {
        matrix[currRow, currCol] = 'M';
    }
}

if (command == "danger")
{
    Console.WriteLine("Mouse will come back later!");
}


for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}


static bool ValidateMove(char[,] matrix, int row, int col)
{
    bool isMoveValid = row >= 0 && row < matrix.GetLength(0)
        && col >= 0 && col < matrix.GetLength(1);

    return isMoveValid;
}
