using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CalculateTriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseTriangle = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double triangleArea = CalculateTriangleArea(baseTriangle, height);
            Console.WriteLine(triangleArea);
        }

        static double CalculateTriangleArea(double baseTriangle, double height)
        {
            double triangleArea = (baseTriangle * height) / 2;
            return triangleArea;
        }
    }
}
