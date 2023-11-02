namespace _8._Traffic_Jam
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsNum = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carsNum; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        carsPassed++;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}