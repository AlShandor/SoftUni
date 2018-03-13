using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RectanglePosition
{
    class Program
    {
        class Rectangle
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public int Right
            {
                get
                {
                    return Left + Width;
                }
            }

            public int Bottom
            {
                get
                {
                    return Top + Height;
                }
            }
        }

        static void Main(string[] args)
        {
            Rectangle r1 = ReadRectangle();
            Rectangle r2 = ReadRectangle();

            if (isInside(r1, r2))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }

        private static bool isInside(Rectangle r1, Rectangle r2)
        {
            bool isInside = false;
            if (r1.Left >= r2.Left && r1.Right <= r2.Right &&
                r1.Top <= r2.Top && r1.Bottom <= r2.Bottom)
            {
                isInside = true;
            }
            return isInside;
        }

        private static Rectangle ReadRectangle()
        {
            int[] rectangleProps = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Rectangle rectangle = new Rectangle()
            {
                Left = rectangleProps[0],
                Top = rectangleProps[1],
                Width = rectangleProps[2],
                Height = rectangleProps[3]
            };
            return rectangle;
        }
    }
}
