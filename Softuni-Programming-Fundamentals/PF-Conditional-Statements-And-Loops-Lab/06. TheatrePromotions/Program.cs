using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TheatrePromotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayType = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price;

            if (dayType == "Weekday" && (age >= 0 && age <= 18))
            {
                price = 12;
                Console.WriteLine($"{price}$");
            }
            else if (dayType == "Weekday" && (age > 18 && age <= 64))
            {
                price = 18;
                Console.WriteLine($"{price}$");
            }
            else if (dayType == "Weekday" && (age > 64 && age <= 122))
            {
                price = 12;
                Console.WriteLine($"{price}$");
            }
            else if (dayType == "Weekend" && (age >= 0 && age <= 18))
            {
                price = 15;
                Console.WriteLine($"{price}$");
            }
            else if (dayType == "Weekend" && (age > 18 && age <= 64))
            {
                price = 20;
                Console.WriteLine($"{price}$");
            }
            else if (dayType == "Weekend" && (age > 64 && age <= 122))
            {
                price = 15;
                Console.WriteLine($"{price}$");
            }
            else if (dayType == "Holiday" && (age >= 0 && age <= 18))
            {
                price = 5;
                Console.WriteLine($"{price}$");
            }
            else if (dayType == "Holiday" && (age > 18 && age <= 64))
            {
                price = 12;
                Console.WriteLine($"{price}$");
            }
            else if (dayType == "Holiday" && (age > 64 && age <= 122))
            {
                price = 10;
                Console.WriteLine($"{price}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
