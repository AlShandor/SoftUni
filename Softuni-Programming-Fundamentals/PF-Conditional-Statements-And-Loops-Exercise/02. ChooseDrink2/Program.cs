using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ChooseDrink2
{
    class Program
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double water = 0.7;
            double coffee = 1.00;
            double beer = 1.7;
            double tea = 1.20;
            double totalPrice = 0;

            if (profession == "Athlete")
            {
                totalPrice = quantity * water;
            }
            else if (profession == "Businessman" || profession == "Businesswoman")
            {
                totalPrice = quantity * coffee;
            }
            else if (profession == "SoftUni Student")
            {
                totalPrice = quantity * beer;
            }
            else
            {
                totalPrice = quantity * tea;
            }

            Console.WriteLine($"The {profession} has to pay {totalPrice:f2}.");
        }
    }
}
