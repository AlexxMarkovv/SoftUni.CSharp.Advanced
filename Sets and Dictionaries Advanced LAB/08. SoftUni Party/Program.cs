namespace _08._SoftUni_Party
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string reservation = Console.ReadLine();
            while (reservation != "END")
            {
                if (reservation == "PARTY")
                {
                    string input2;
                    while ((input2 = Console.ReadLine()) != "END")
                    {
                        char symbol = input2.First();
                        if (char.IsDigit(symbol) && vip.Contains(input2))
                        {
                            vip.Remove(input2);
                            continue;
                        }
                        else if (regular.Contains(input2))
                        {
                            regular.Remove(input2);
                        }
                    }
                    break;
                }

                char symbol2 = reservation.First();
                if (char.IsDigit(symbol2))
                {
                    vip.Add(reservation);
                }
                else
                {
                    regular.Add(reservation);
                }

                reservation = Console.ReadLine();
            }

            int reservationsLeft = vip.Count + regular.Count;
            Console.WriteLine(reservationsLeft);

            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }

            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}