using System;

namespace _01.HornetWings
{
    class Program
    {
        static void Main()
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            decimal distancePer1000Flaps = decimal.Parse(Console.ReadLine());
            int flipsBeforeRest = int.Parse(Console.ReadLine());

            decimal metersTravelled = (wingFlaps / 1000) * distancePer1000Flaps;

            decimal timeNoRest = wingFlaps / 100;
            decimal restTime = (wingFlaps / flipsBeforeRest) * 5;
            decimal totalTime = timeNoRest + restTime;

            Console.WriteLine($"{metersTravelled:f2} m.");
            Console.WriteLine($"{totalTime} s.");
        }
    }
}
