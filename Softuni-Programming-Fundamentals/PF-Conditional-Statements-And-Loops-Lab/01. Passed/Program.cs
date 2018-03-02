using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01.Passed
{
    class Program
    {
        static void Main(string[] args)
        {
            double mark = double.Parse(Console.ReadLine());

            if (mark >= 3)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
