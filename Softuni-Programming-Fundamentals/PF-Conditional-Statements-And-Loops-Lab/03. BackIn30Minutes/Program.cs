using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;

            if (minutes > 59)
            {
                minutes = Math.Abs(60 - minutes);
                hours += 1;
            }

            if (hours > 23)
            {
                hours = Math.Abs(24 - hours);
            }

            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
