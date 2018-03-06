using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write program to enter an integer number of centuries and convert it to years, days, hours, minutes, seconds,
//milliseconds, microseconds, nanoseconds.

//    1 centuries = 100 years = 36524 days = 876576 hours = 52594560 minutes =
//3155673600 seconds = 3155673600000 milliseconds = 3155673600000000
//microseconds = 3155673600000000000 nanoseconds

//Assume that a year has 365.2422 days at average
namespace _10.CenturiesToSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            long minutes = (long)hours * 60;
            long seconds = (long)minutes * 60;
            BigInteger milliseconds = (BigInteger)seconds * 1000;
            BigInteger microseconds = (BigInteger)milliseconds * 1000;
            BigInteger nanoseconds = (BigInteger)(microseconds * 1000);
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours =" +
                $" {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = " +
                $"{microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}
