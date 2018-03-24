
using System;

public class Rectangle
{
    private string id;
    private int x1;
    private int width;
    private int height;
    private int y2;

    public Rectangle(string[] rectangleInfo)
    {
        Id = rectangleInfo[0];
        Width = Math.Abs(int.Parse(rectangleInfo[1]));
        Height = Math.Abs(int.Parse(rectangleInfo[2]));
        X1 = int.Parse(rectangleInfo[3]);
        Y2 = int.Parse(rectangleInfo[4]);
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }


    public int Width
    {
        get { return width; }
        set { width = value; }
    }


    public int Y2
    {
        get { return y2; }
        set { y2 = value; }
    }


    public int X1
    {
        get { return x1; }
        set { x1 = value; }
    }
}
