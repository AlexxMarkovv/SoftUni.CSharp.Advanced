namespace _05._Fashion_Boutique
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes);
            int usedRacks = 1;
            int nextRack = rackCapacity;

            while (stack.Count > 0)
            {
                int currCloth = stack.Peek();
                if (rackCapacity >= currCloth)
                {
                    stack.Pop();
                    rackCapacity -= currCloth;
                }
                else
                {
                    rackCapacity = nextRack;
                    usedRacks++;
                }
            }
            Console.WriteLine(usedRacks);
        }
    }
}