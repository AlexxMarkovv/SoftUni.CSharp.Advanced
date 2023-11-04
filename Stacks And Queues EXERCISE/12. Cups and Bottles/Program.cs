namespace _12._Cups_and_Bottles
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsQueue = new(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Stack<int> bottlesStack = new(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int wastedWater = 0;

            while (cupsQueue.Any() && bottlesStack.Any())
            {
                int cupValue = cupsQueue.Peek();
                int bottleValue = bottlesStack.Peek();

                if (cupValue == bottleValue)
                {
                    cupsQueue.Dequeue();
                    bottlesStack.Pop();
                }
                else if (cupValue > bottleValue)
                {
                    for (int i = 0; i < bottlesStack.Count; i++)
                    {
                        if (cupValue > 0)
                        {
                            cupValue -= bottlesStack.Pop();
                        }
                        else if (cupValue < 0)
                        {
                            cupsQueue.Dequeue();
                            cupValue *= -1;
                            wastedWater += cupValue;
                        }
                    }
                    

                    //while (cupValue >= bottleValue && bottlesStack.Any())
                    //{
                    //    cupValue -= bottleValue;
                    //    if (cupValue <= 0)
                    //    {
                    //        cupsQueue.Dequeue();
                    //        wastedWater += bottleValue - cupValue;
                    //    }

                    //    bottlesStack.Pop();
                    //    if (bottlesStack.Any() && bottleValue > cupValue)
                    //    {
                    //        bottleValue = bottlesStack.Peek();
                    //    }
                    //}

                    //wastedWater += bottleValue - cupValue;
                    //if (bottlesStack.Any())
                    //{
                    //    bottlesStack.Pop();
                    //}

                    //if (cupsQueue.Any())
                    //{
                    //    cupsQueue.Dequeue();
                    //}

                    if (!bottlesStack.Any())
                    {
                        Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
                        Console.WriteLine($"Wasted litters of water: {wastedWater}");
                        return;
                    }
                }
                else if (bottleValue > cupValue)
                {
                    wastedWater += bottleValue - cupValue;
                    cupsQueue.Dequeue();
                    bottlesStack.Pop();
                }
            }

            if (bottlesStack.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}