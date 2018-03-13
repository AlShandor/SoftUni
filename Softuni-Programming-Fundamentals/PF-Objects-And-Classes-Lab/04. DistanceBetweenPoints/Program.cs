using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DistanceBetweenPoints
{
    class Program
    {
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        static void Main(string[] args)
        {
            int[] p1Coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] p2Coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var p1 = new Point() { X = p1Coordinates[0], Y = p1Coordinates[1] };
            var p2 = new Point() { X = p2Coordinates[0], Y = p2Coordinates[1] };

            double distance = CalcDistance(p1, p2);
            Console.WriteLine($"{distance:f3}");
        }

        private static double CalcDistance(Point p1, Point p2)
        {
            double a = Math.Abs(p1.X - p2.X);
            double b = Math.Abs(p1.Y - p2.Y);
            double distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            return distance;
        }
    }
}
