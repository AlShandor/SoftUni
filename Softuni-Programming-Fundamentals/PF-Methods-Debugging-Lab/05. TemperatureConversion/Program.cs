using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.TemperatureConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double temperature = double.Parse(Console.ReadLine());
            temperature = ConvertFahrenheitToCelsius(temperature);
            Console.WriteLine($"{temperature:f2}");
        }

        static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            fahrenheit = (fahrenheit - 32) * 5 / 9;
            return fahrenheit;
        }
    }
}
