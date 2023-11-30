using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Tiles_Master
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> greyTiles = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> areasAndTiles = new Dictionary<string, int>()
            {
                {"Floor", 0 },
                {"Sink", 0}, 
                {"Oven", 0},
                {"Countertop", 0 },
                {"Wall", 0 }
            };

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int tilesSum = whiteTiles.Pop() + greyTiles.Dequeue();

                    switch (tilesSum)
                    {
                        case 40: areasAndTiles["Sink"]++; break;
                        case 50: areasAndTiles["Oven"]++; break;
                        case 60: areasAndTiles["Countertop"]++; break;
                        case 70: areasAndTiles["Wall"]++; break;
                        default: areasAndTiles["Floor"]++; break;
                    }
                }
                else
                {
                    int whiteTile = whiteTiles.Pop() / 2;
                    whiteTiles.Push(whiteTile);

                    int greyTile = greyTiles.Dequeue();
                    greyTiles.Enqueue(greyTile);
                }
            }

            if (!whiteTiles.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.Write("White tiles left: ");
                Console.WriteLine(string.Join(", ", whiteTiles));
            }

            if (!greyTiles.Any())
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.Write("Grey tiles left: ");
                Console.WriteLine(string.Join(", ", greyTiles));
            }

            foreach (var area in areasAndTiles
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                if (area.Value > 0)
                Console.WriteLine($"{area.Key}: {area.Value}");
            }
        }

    }
}