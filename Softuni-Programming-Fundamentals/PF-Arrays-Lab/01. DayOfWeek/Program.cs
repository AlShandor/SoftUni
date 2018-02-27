using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] daysOfWeek =  
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            };
            if (num >= 1 && num <=7)
            {
                Console.WriteLine(daysOfWeek[num - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
            
            
        }
    }
}
