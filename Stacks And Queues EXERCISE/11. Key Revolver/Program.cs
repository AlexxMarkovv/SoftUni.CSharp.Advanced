namespace _11._Key_Revolver
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> stackBullets = new Stack<int>(bullets);
            Queue<int> queueLocks = new Queue<int>(locks);
            int gunBarrel = gunBarrelSize;
            int bulletsShots = 0;

            while (stackBullets.Count > 0)
            {
                if (queueLocks.Count == 0)
                {
                    break;
                }
                
                int lockValue = queueLocks.Peek();
                if (lockValue >= stackBullets.Pop())
                {
                    queueLocks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bulletsShots++;
                gunBarrel--;
                if (gunBarrel == 0 && stackBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    gunBarrel = gunBarrelSize;
                }
            }

            if (!stackBullets.Any() && queueLocks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
            }
            else
            {
                double moneyEarned = intelligence - (bulletsShots * pricePerBullet * 1.0);
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}