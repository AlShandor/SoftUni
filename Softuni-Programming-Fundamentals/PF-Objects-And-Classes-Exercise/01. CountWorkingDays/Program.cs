using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _01.CountWorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            var holidays = new []
            {
                "01 01",
                "03 03",
                "01 05",
                "06 05",
                "24 05",
                "06 09",
                "22 09",
                "01 11",
                "24 12",
                "25 12",
                "26 12"
            }
            .Select(a => DateTime.ParseExact(a, "dd MM", CultureInfo.InvariantCulture))
            .ToArray();

            DateTime date1 = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            int workingDaysCount = 0;
            for (DateTime currentDate = date1; currentDate <= date2; currentDate = currentDate.AddDays(1))
            {
                bool isWeekend = currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday;
                bool isHoliday = holidays.Any(d => d.Day == currentDate.Day && d.Month == currentDate.Month);
                bool isWorkingDay = !(isWeekend || isHoliday);
                if (isWorkingDay)
                {
                    workingDaysCount++;
                }
            }
            Console.WriteLine(workingDaysCount);
        }
    }
}
