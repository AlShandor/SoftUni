using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            int area = width * heigth;
            double megapixels = area / 1000000.0;

            Console.WriteLine($"{width}x{heigth} => {Math.Round(megapixels, 1)}MP");
        }
    }
}
