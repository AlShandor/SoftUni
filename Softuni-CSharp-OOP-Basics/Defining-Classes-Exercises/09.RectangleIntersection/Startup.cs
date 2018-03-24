
using System;
using System.Collections.Generic;

class Startup
{
    public static int numOfRectangles;
    public static int numOfIntersections;
    public static Dictionary<string, Rectangle> rectangles = new Dictionary<string, Rectangle>();

    static void Main()
    {

        string[] numOfRectAndNumOfIntersections = Console.ReadLine().Split();
        numOfRectangles = int.Parse(numOfRectAndNumOfIntersections[0]);
        numOfIntersections = int.Parse(numOfRectAndNumOfIntersections[1]);


        for (int i = 0; i < numOfRectangles; i++)
        {
            string[] rectangleInfo = Console.ReadLine().Split();
            Rectangle newRectangle = new Rectangle(rectangleInfo);
            if (!rectangles.ContainsKey(rectangleInfo[0]))
            {
                rectangles[newRectangle.Id] = newRectangle;
            }

        }

        for (int i = 0; i < numOfIntersections; i++)
        {
            string[] rectanglesToCompare = Console.ReadLine().Split();
            string firstR = rectanglesToCompare[0];
            string secondR = rectanglesToCompare[1];

            bool isIntersect = IsRectanglesIntersect(rectangles, firstR, secondR);

            if (isIntersect)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

    }

    private static bool IsRectanglesIntersect(Dictionary<string, Rectangle> rectangles, string firstR, string secondR)
    {
        bool isIntersect = false;
        var firstRec = rectangles[firstR];
        var secondRec = rectangles[secondR];


        // (X2' >= X1 && X1' <= X2) && (Y2' >= Y1 && Y1' <= Y2)
        if (((secondRec.X1 + secondRec.Width) >= firstRec.X1 && secondRec.X1 <= (firstRec.X1 + firstRec.Width) && (secondRec.Y2 >= (firstRec.Y2 - firstRec.Height) && (secondRec.Y2 - secondRec.Width) <= firstRec.Y2)))
        {
            isIntersect = true;
        }


        return isIntersect;
    }
}
