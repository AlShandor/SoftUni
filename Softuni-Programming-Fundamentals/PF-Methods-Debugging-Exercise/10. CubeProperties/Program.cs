using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that can calculate the length of the face diagonals, space diagonals, volume and surface area of a
//cube(http://www.mathopenref.com/cube.html) by a given side. On the first line you will get the side of the cube.
//On the second line is given the parameter (face, space, volume or area).
namespace _10.CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string property = Console.ReadLine();
            double returnedProperty = 0;
            if (property == "face")
            {
                returnedProperty = GetFaceDiagonalOfCube(side);
                Console.WriteLine($"{returnedProperty:f2}");
            }
            else if (property == "space")
            {
                returnedProperty = GetSpaceDiagonalOfCube(side);
                Console.WriteLine($"{returnedProperty:f2}");
            }
            else if (property == "volume")
            {
                returnedProperty = GetVolumeOfCube(side);
                Console.WriteLine($"{returnedProperty:f2}");
            }
            else if (property == "area")
            {
                returnedProperty = GetAreaOfCube(side);
                Console.WriteLine($"{returnedProperty:f2}");
            }

        }

        static double GetAreaOfCube(double side)
        {
            double area = 6 * Math.Pow(side, 2);
            return area;
        }

        static double GetVolumeOfCube(double side)
        {
            double volume = Math.Pow(side, 3);
            return volume;
        }

        static double GetSpaceDiagonalOfCube(double side)
        {
            double spaceDiagonal = Math.Sqrt(3 * Math.Pow(side, 2));
            return spaceDiagonal;
        }

        static double GetFaceDiagonalOfCube(double side)
        {
            double faceDiagonal = Math.Sqrt(2 * Math.Pow(side, 2));
            return faceDiagonal;
        }
    }
}
