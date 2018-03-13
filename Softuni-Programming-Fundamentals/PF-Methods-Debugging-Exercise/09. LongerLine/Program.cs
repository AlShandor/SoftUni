using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstLineX1 = double.Parse(Console.ReadLine());
            double firstLineY1 = double.Parse(Console.ReadLine());
            double firstLineX2 = double.Parse(Console.ReadLine());
            double firstLineY2 = double.Parse(Console.ReadLine());

            double secondLineX1 = double.Parse(Console.ReadLine());
            double secondLineY1 = double.Parse(Console.ReadLine());
            double secondLineX2 = double.Parse(Console.ReadLine());
            double secondLineY2 = double.Parse(Console.ReadLine());

            double lengthFirstLine = GetLengthOfLine(firstLineX1, firstLineY1, firstLineX2, firstLineY2);
            double lengthSecondLine = GetLengthOfLine(secondLineX1, secondLineY1, secondLineX2, secondLineY2);
            
            if (lengthFirstLine >= lengthSecondLine)
            {
                double[] pointsStartingFromClosestToCenter = GetPointsStartingFromClosestToCenter(
                    firstLineX1, firstLineY1, firstLineX2, firstLineY2);

                Console.WriteLine("(" + String.Join(", ", pointsStartingFromClosestToCenter[0], pointsStartingFromClosestToCenter[1]) + ")" + 
                    "(" + String.Join(", ", pointsStartingFromClosestToCenter[2], pointsStartingFromClosestToCenter[3]) + ")");
            }
            else
            {
                double[] pointsStartingFromClosestToCenter = GetPointsStartingFromClosestToCenter(
                    secondLineX1, secondLineY1, secondLineX2, secondLineY2);

                Console.WriteLine("(" + String.Join(", ", pointsStartingFromClosestToCenter[0], pointsStartingFromClosestToCenter[1]) + ")" +
                    "(" + String.Join(", ", pointsStartingFromClosestToCenter[2], pointsStartingFromClosestToCenter[3]) + ")");
            }

        }

        static double GetLengthOfLine(double x1, double y1, double x2, double y2)
        {
            double lengthOfLine = Math.Sqrt((Math.Pow((x2 - x1), 2) + (Math.Pow((y2 - y1), 2))));
            return lengthOfLine;
        }

        static double[] GetPointsStartingFromClosestToCenter(double x1, double y1, double x2, double y2)
        {
            double pointFirst = Math.Abs(x1) + Math.Abs(y1);
            double pointSecond = Math.Abs(x2) + Math.Abs(y2);
            double[] pointClosest = new double[4];
            if (pointFirst <= pointSecond)
            {
                pointClosest[0] = x1;
                pointClosest[1] = y1;
                pointClosest[2] = x2;
                pointClosest[3] = y2;
                return pointClosest;
            }
            else
            {
                pointClosest[0] = x2;
                pointClosest[1] = y2;
                pointClosest[2] = x1;
                pointClosest[3] = y1;
                return pointClosest;
            }

        }
    }
}
