using System;


public class Startup
{
    public static void Main()
    {
        string driver = Console.ReadLine();
        Ferrari ferrari = new Ferrari(driver);
        Console.WriteLine($"{ferrari.Model}/{ferrari.UseBrakes()}/{ferrari.UseGasPedal()}/{ferrari.Driver}");
    }
}

