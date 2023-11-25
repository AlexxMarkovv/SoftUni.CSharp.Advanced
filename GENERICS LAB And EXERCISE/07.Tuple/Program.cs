﻿namespace Tuple;

internal class Program
{
    static void Main(string[] args)
    {
        //CustomTuple<int, int> customTuple = new(1, 2);


        string[] personTokens = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string[] drinkTokens = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string[] numbersTokens = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        CustomTuple<string, string> nameAdress =
            new($"{personTokens[0]} {personTokens[1]}", personTokens[2]);

        CustomTuple<string, int> nameBeer = new(drinkTokens[0], int.Parse(drinkTokens[1]));

        CustomTuple<int, double> numbers =
            new(int.Parse(numbersTokens[0]), double.Parse(numbersTokens[1]));

        Console.WriteLine(nameAdress);
        Console.WriteLine(nameBeer);
        Console.WriteLine(numbers);
    }
}