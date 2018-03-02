using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();

            string hallName = "";
            double totalPrice = 0;
            double discount = 0;

            if (groupSize > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
            else
            {
                if (groupSize > 0 && groupSize <= 50)
                {
                    hallName = "Small Hall";
                    totalPrice += 2500;
                }
                else if (groupSize > 50 && groupSize <= 100)
                {
                    hallName = "Terrace";
                    totalPrice += 5000;
                }
                else if (groupSize > 100 && groupSize <= 120)
                {
                    hallName = "Great Hall";
                    totalPrice += 7500;
                }

                if (package == "Normal")
                {
                    totalPrice += 500;
                    discount = 0.95;
                }
                else if (package == "Gold")
                {
                    totalPrice += 750;
                    discount = 0.9;
                }
                else if (package == "Platinum")
                {
                    totalPrice += 1000;
                    discount = 0.85;
                }

                Console.WriteLine($"We can offer you the {hallName}");
                Console.WriteLine($"The price per person is {((totalPrice * discount) / groupSize):f2}$");
            }
        }
    }
}
