namespace _04._Product_Shop
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Dictionary<string, double>> shopsData 
                = new Dictionary<string, Dictionary<string, double>>();

            while (input[0] != "Revision")
            {
                string shopName = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shopsData.ContainsKey(shopName))
                {
                    shopsData.Add(shopName, new Dictionary<string, double>());
                }

                shopsData[shopName].Add(product, price);

                input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            shopsData = shopsData
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var shop in shopsData)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}