using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.IntersectionOfCircles
{
    class Program
    {
        class Circle
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Radius { get; set; }
        }
        static void Main(string[] args)
        {
            double[] c1Stats = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] c2Stats = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Circle circle1 = new Circle()
            {
                X = c1Stats[0],
                Y = c1Stats[1],
                Radius = c1Stats[2]
            };
            Circle circle2 = new Circle()
            {
                X = c2Stats[0],
                Y = c2Stats[1],
                Radius = c2Stats[2]
            };
            if (Intersect(circle1, circle2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }

        private static bool Intersect(Circle circle1, Circle circle2)
        {
            double distance = Math.Sqrt(Math.Pow((circle2.X - circle1.X), 2) + Math.Pow((circle2.Y - circle1.Y), 2));
            bool intersect = false;
            if (distance <= circle1.Radius + circle2.Radius)
            {
                intersect = true;
            }
            return intersect;
        }
    }
}
