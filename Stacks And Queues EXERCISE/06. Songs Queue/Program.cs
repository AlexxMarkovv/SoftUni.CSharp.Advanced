namespace _06._Songs_Queue
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");

            Queue<string> songsQueue = new Queue<string>(songs);

            string command = Console.ReadLine();
            while (true)
            {
                if (songsQueue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                if (command == "Play" && songsQueue.Count > 0)
                {
                    songsQueue.Dequeue();
                }
                else if (command == "Show" && songsQueue.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }

                if (command.StartsWith("Add"))
                {
                    string song = command.Substring(4);
                    if (!songsQueue.Contains(song))
                    {
                        songsQueue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}