
using System;

public class Program
{
    public static void Main()
    {
        double length = Double.Parse(Console.ReadLine());
        double width = Double.Parse(Console.ReadLine());
        double height = Double.Parse(Console.ReadLine());

        try
        {
            Box box = new Box(length, width, height);
            double boxSurfaceArea = box.GetSurfaceArea();
            double boxLateralSurface = box.GetLateralSurface();
            double boxVolume = box.GetVolume();

            Console.WriteLine($"Surface Area - {boxSurfaceArea:f2}");
            Console.WriteLine($"Lateral Surface Area - {boxLateralSurface:f2}");
            Console.WriteLine($"Volume - {boxVolume:f2}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}