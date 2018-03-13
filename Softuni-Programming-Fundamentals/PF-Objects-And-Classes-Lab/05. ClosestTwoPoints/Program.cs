using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ClosestTwoPoints
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
            int numOfPoints = int.Parse(Console.ReadLine());
            var listOfPoints = new List<Point>();
            for (int i = 0; i < numOfPoints; i++)
            {
                int[] newPointCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var newPoint = new Point() { X = newPointCoordinates[0], Y = newPointCoordinates[1] };
                listOfPoints.Add(newPoint);
            }

            double closestDistance = double.MaxValue;
            Point[] closestPoints = new Point[2];
            for (int currentPoint = 0; currentPoint < listOfPoints.Count; currentPoint++)
            {
                for (int nextPoint = currentPoint + 1; nextPoint < listOfPoints.Count; nextPoint++)
                {
                    var currentDistance = CalcDistance(listOfPoints[currentPoint], listOfPoints[nextPoint]);
                    if (currentDistance < closestDistance)
                    {
                        closestDistance = currentDistance;
                        closestPoints[0] = listOfPoints[currentPoint];
                        closestPoints[1] = listOfPoints[nextPoint];
                    }
                }
            }

            Console.WriteLine($"{closestDistance:f3}");
            Console.WriteLine("(" + closestPoints[0].X + ", " + closestPoints[0].Y + ")");
            Console.WriteLine("(" + closestPoints[1].X + ", " + closestPoints[1].Y + ")");
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
