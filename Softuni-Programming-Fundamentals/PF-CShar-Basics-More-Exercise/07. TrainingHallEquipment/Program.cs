using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.TrainingHallEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfItems = int.Parse(Console.ReadLine());
            double totalsum = 0;

            while (numberOfItems > 0)
            {
                string itemName = Console.ReadLine();
                double itemPrice = double.Parse(Console.ReadLine());
                int itemCount = int.Parse(Console.ReadLine());
                totalsum += (itemPrice * itemCount);
                if (itemCount > 1)
                {
                    itemName += "s";
                }

                Console.WriteLine($"Adding {itemCount} {itemName} to cart.");
                numberOfItems--;
            }
            Console.WriteLine($"Subtotal: ${totalsum:f2}");

            if (budget >= totalsum)
            {
                Console.WriteLine($"Money left: ${(budget - totalsum):f2}");
            }
            else
            {
                Console.WriteLine($"Not enough. We need ${(totalsum - budget):f2} more.");
            }
        }
    }
}
