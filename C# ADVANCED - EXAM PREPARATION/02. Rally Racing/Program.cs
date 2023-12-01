int size = int.Parse(Console.ReadLine());

string racingNumber = Console.ReadLine();

string[,] matrix = new string[size, size];

for (int row = 0; row < size; row++)
{
    string[] rows = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = rows[col];
    }
}

int passedKM = 0;
int carRow = 0;
int carCol = 0;

bool isReachedTheFinish = false;

string command;
while ((command = Console.ReadLine()) != "End")
{
    if (isReachedTheFinish)
    {
        continue;
    }

    bool isValidMove = false;

    isValidMove = CheckIfTheMoveIsValid(matrix, carRow, carCol, command, isValidMove);

    if (isValidMove)
    {
        switch (command)
        {
            case "left": carCol -= 1; break;
            case "right": carCol += 1; break;
            case "up": carRow -= 1; break;
            case "down": carRow += 1; break;
        }

        if (matrix[carRow, carCol] == ".")
        {
            passedKM += 10;
        }
        else if (matrix[carRow, carCol] == "T")
        {
            matrix[carRow, carCol] = ".";
            bool isTuunelClosed = false;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == "T")
                    {
                        matrix[row, col] = ".";
                        passedKM += 30;

                        carRow = row;
                        carCol = col;

                        isTuunelClosed = true;
                    }
                }

                if (isTuunelClosed)
                {
                    break;
                }
            }
        }
        else if (matrix[carRow, carCol] == "F")
        {
            passedKM += 10;

            matrix[carRow, carCol] = "C";

            isReachedTheFinish = true;
        }
    }
}

if (isReachedTheFinish)
{
    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
}
else
{
    matrix[carRow, carCol] = "C";
    Console.WriteLine($"Racing car {racingNumber} DNF.");
}

Console.WriteLine($"Distance covered {passedKM} km.");

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        Console.Write($"{matrix[row, col]}"); 
    }
    Console.WriteLine();
}

static bool CheckIfTheMoveIsValid(string[,] matrix, int carRow, int carCol, string command, bool isValid)
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
