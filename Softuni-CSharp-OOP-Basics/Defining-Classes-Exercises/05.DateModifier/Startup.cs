using System;


class Startup
{
    static void Main()
    {
        DateTime startDate = DateTime.Parse(Console.ReadLine());
        DateTime endDate = DateTime.Parse(Console.ReadLine());
        DateModifier dateModifier = new DateModifier(startDate, endDate);
        Console.WriteLine(dateModifier.GetDifferenceBetweenDates());
    }
}
