using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double[] pointClosestToCenter = GetPointClosestToCenter(x1, y1, x2, y2);
            Console.WriteLine("(" + String.Join(", ", pointClosestToCenter) + ")");

        }

        static double[] GetPointClosestToCenter(double x1, double y1, double x2, double y2)
        {
            double pointFirst = Math.Abs(x1) + Math.Abs(y1);
            double pointSecond = Math.Abs(x2) + Math.Abs(y2);
            double[] pointClosest = new double[2];
            if (pointFirst <= pointSecond)
            {
                pointClosest[0] = x1;
                pointClosest[1] = y1;
                return pointClosest;
            }
            else
            {
                pointClosest[0] = x2;
                pointClosest[1] = y2;
                return pointClosest;
            }

        }
    }
}
