namespace _10._Crossroads
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightTime = int.Parse(Console.ReadLine());
            int freeWindowTime = int.Parse(Console.ReadLine());

            int lightTime = greenLightTime;
            int freeTime = freeWindowTime;

            Queue<char> queue = new Queue<char>();
            int totalCarsPassed = 0;

            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "green")
                {
                    greenLightTime = lightTime;
                    freeWindowTime = freeTime;
                }
                else if (greenLightTime > 0)
                {
                    for (int i = 0; i < command.Length; i++)
                    {
                        queue.Enqueue(command[i]);
                    }

                    while (queue.Count > 0)
                    {
                        char lastChar = queue.Peek();
                        if (greenLightTime > 0)
                        {
                            queue.Dequeue();
                            greenLightTime--;
                        }
                        else if (freeWindowTime > 0)
                        {
                            queue.Dequeue();
                            freeWindowTime--;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{command} was hit at {lastChar}.");
                            return;
                        }
                    }

                    totalCarsPassed++;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");

        }
    }
}