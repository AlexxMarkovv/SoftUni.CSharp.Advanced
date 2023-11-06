namespace _07._Parking_Lot
{
    using System;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> carNumbers = new HashSet<string>();

            while (input[0] != "END")
            {
                string cmndType = input[0];
                string carNum = input[1];

                if (cmndType == "IN")
                {
                    carNumbers.Add(carNum);
                }
                else if (cmndType == "OUT" && carNumbers.Contains(carNum))
                {
                    carNumbers.Remove(carNum);
                }

                input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (carNumbers.Count > 0)
            {
                foreach (string carNum in carNumbers)
                {
                    Console.WriteLine(carNum);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}