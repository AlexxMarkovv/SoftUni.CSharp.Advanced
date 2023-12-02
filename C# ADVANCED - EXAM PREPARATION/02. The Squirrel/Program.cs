int size = int.Parse(Console.ReadLine());

string[] commands = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

char[,] matrix = new char[size, size];

int currentRow = 0;
int currentCol = 0;

for (int row = 0; row < size; row++)
{
    string rows = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = rows[col];

        if (matrix[row, col] == 's')
        {
            currentRow = row;
            currentCol = col;
        }
    }
}

int hazelnuts = 0;

for(int i = 0; i < commands.Length; i++)
{
    int oldRow = currentRow;
    int oldCol = currentCol;

    if (commands[i] == "up")
    {
        currentRow--;
    }
    else if (commands[i] == "down")
    {
        currentRow++;
    }
    else if (commands[i] == "left")
    {
        currentCol--;
    }
    else
    {
        currentCol++;
    }

    if (currentRow < 0 || currentRow >= size || currentCol < 0 || currentCol >= size)
    {
        Console.WriteLine("The squirrel is out of the field.");
        Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
        matrix[oldRow, oldCol] = '*';
        return;
    }
    else if (matrix[currentRow, currentCol] == 't')
    {
        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
        Console.WriteLine($"Hazelnuts collected: {hazelnuts}");
        matrix[oldRow, oldCol] = '*';
        return;
    }
    else if (matrix[currentRow, currentCol] == 'h')
    {
        matrix[currentRow, currentCol] = '*';
        hazelnuts++;
    }
    else
    {
        matrix[currentRow, currentCol] = 's';
    }
}

if (hazelnuts == 3)
{
    Console.WriteLine($"Good job! You have collected all hazelnuts!");
}
else
{
    Console.WriteLine("There are more hazelnuts to collect.");
}

Console.WriteLine($"Hazelnuts collected: {hazelnuts}");