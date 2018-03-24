class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
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
}
