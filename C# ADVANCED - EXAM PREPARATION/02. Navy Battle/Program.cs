int size = int.Parse(Console.ReadLine());

char[,] matrix = new char[size, size];

int subRow = 0;
int subCol = 0;

for (int row = 0; row < size; row++)
{
    string rows = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = rows[col];

        if (matrix[row,col] == 'S')
        {
            subRow = row;
            subCol = col;
        }
    }
}

int submarineDamage = 3;
int cruisersCount = 3;

string command = Console.ReadLine();
while (true)
{
    matrix[subRow, subCol] = '-';

    switch(command)
    {
        case "up": subRow--; break;
        case "down": subRow++; break;
        case "left": subCol--; break;
        case "right": subCol++; break;
    }

    if (matrix[subRow,subCol] == '*')
    {
        submarineDamage--;
        matrix[subRow, subCol] = '-';

        if (submarineDamage == 0)
        {
            break;
        }
    }
    else if (matrix[subRow, subCol] == 'C')
    {
        cruisersCount--;
        matrix[subRow, subCol] = '-';

        if (cruisersCount == 0)
        {
            break;
        }
    }

    command = Console.ReadLine();
}

matrix[subRow, subCol] = 'S';

if (cruisersCount == 0)
{
    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
}
else if (submarineDamage == 0)
{
    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{subRow}, {subCol}]!");
}

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        Console.Write(matrix[row,col]);
    }
    Console.WriteLine();
}
