using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a program to calculate rectangle’s perimeter, area and diagonal by given its width and height.
namespace _12.RectangleProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double width =  double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
           
            double rectanglePerimeter = 2 * (width + height);
            double rectangleArea = width * height;
            double rectangleDiagonal = Math.Sqrt((width * width + height * height));

            Console.WriteLine(rectanglePerimeter);
            Console.WriteLine(rectangleArea);
            Console.WriteLine(rectangleDiagonal);
        }
    }
}
