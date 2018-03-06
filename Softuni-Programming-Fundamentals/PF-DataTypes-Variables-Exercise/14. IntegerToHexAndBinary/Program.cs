using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.IntegerToHexAndBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalVal = int.Parse(Console.ReadLine());
            string hex = Convert.ToString(decimalVal, 16);
            string binary = Convert.ToString(decimalVal, 2);

            Console.WriteLine(hex.ToUpper());
            Console.WriteLine(binary.ToUpper());
        }
    }
}
