using System;

class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double GetSurfaceArea()
    {
        // 2lw + 2lh + 2wh
        double surfaceArea =
            (2 * length * height) + (2 * width * height) + (2 * length * width);
        return surfaceArea;
    }

    public double GetLateralSurface()
    {
        // 2lh + 2wh
        double lateralSurface = (2 * length * height) + (2 * width * height);
        return lateralSurface;
    }

    public double GetVolume()
    {
        double volume = height * length * width;
        return volume;
    }

    public double Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }

            length = value;
        }
    }

    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }

            width = value;
        }
    }

    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }

            height = value;
        }
    }
}
