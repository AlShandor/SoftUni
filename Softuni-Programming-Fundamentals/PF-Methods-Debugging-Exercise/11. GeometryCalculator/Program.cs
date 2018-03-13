using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that can calculate the area of four different geometry figures - triangle, square, rectangle and
//circle.
//On the first line you will get the figure type.Next you will get parameters for the chosen figure, each on a different
//line:
// Triangle - side and height
// Square - side
// Rectangle - width and height
// Circle - radius
namespace _11.GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            if (figureType == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double areaTriangle = GetTriangleArea(side, height);
                Console.WriteLine($"{areaTriangle:f2}");
            }
            else if (figureType == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double areaSquare = GetSquareArea(side);
                Console.WriteLine($"{areaSquare:f2}");
            }
            else if (figureType == "rectangle")
            {
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double areaRectangle = GetRectangleArea(width, height);
                Console.WriteLine($"{areaRectangle:f2}");
            }
            else if (figureType == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double areaCircle = GetCircleArea(radius);
                Console.WriteLine($"{areaCircle:f2}");
            }
        }

        private static double GetCircleArea(double radius)
        {
            double areaCircle = Math.PI * Math.Pow(radius, 2);
            return areaCircle;
        }

        private static double GetRectangleArea(double width, double height)
        {
            double areaRectangle = width * height;
            return areaRectangle;
        }

        private static double GetSquareArea(double side)
        {
            double areaSquare = side * side;
            return areaSquare;
        }

        private static double GetTriangleArea(double side, double height)
        {
            double areaTriangle = side * height / 2;
            return areaTriangle;
        }
    }
}
