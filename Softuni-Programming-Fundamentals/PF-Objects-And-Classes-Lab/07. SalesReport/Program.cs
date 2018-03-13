using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SalesReport
{
    class Program
    {

        class Sale
        {
            public string Town { get; set; }
            public string Product { get; set; }
            public decimal Price { get; set; }
            public decimal Quantity { get; set; }
        }
        static void Main()
        {
            var salesByCity = new SortedDictionary<string, decimal>();
            int numOfSales = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfSales; i++)
            {
                Sale newSale = ReadSale();
                if (!salesByCity.ContainsKey(newSale.Town))
                {
                    salesByCity[newSale.Town] = 0;
                }
                salesByCity[newSale.Town] += newSale.Price * newSale.Quantity;
            }
            foreach (var city in salesByCity)
            {
                Console.WriteLine($"{city.Key} -> {city.Value:f2}");
            }

        }

        private static Sale ReadSale()
        {
            string[] saleInfo = Console.ReadLine().Split(' ').ToArray();
            var newSale = new Sale()
            {
                Town = saleInfo[0],
                Product = saleInfo[1],
                Price = decimal.Parse(saleInfo[2]),
                Quantity = decimal.Parse(saleInfo[3])
            };
            return newSale;
        }
    }
}
