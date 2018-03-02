using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//A hotel has three types of rooms: studio, double and master suite.The prices are different for the different months:
//May and October                       June and September        July, August and December
//Studio - 50 leva per night Studio - 60 leva per night Studio - 68 leva per night
//Double - 65 leva per night Double - 72 leva per night Double - 77 leva per night
//Suite - 75 leva per night Suite -   82 leva per night Suite -  89 leva per night

//They have also the following discounts:
// For studio and more than 7 nights in May and October: 5% discount
// For double and more than 14 nights in June and September: 10% discount
// For suite and more than 14 nights in July, August and December: 15% discount
// For studio and more than 7 nights in September and October: one night is free
namespace _04.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            string may = "May";
            string june = "June";
            string july = "July";
            string august = "August";
            string september = "September";
            string october = "October";
            string december = "December";
            
            double studioPrice = 0;
            double doubleRoomPrice = 0;
            double suitePrice = 0;
            int studioNightsCount = nightsCount;

            if (month == may || month == october)
            {
                studioPrice = 50;
                doubleRoomPrice = 65;
                suitePrice = 75;
            }
            else if (month == june || month == september)
            {
                studioPrice = 60;
                doubleRoomPrice = 72;
                suitePrice = 82;
            }
            else if (month == july || month == august || month == december)
            {
                studioPrice = 68;
                doubleRoomPrice = 77;
                suitePrice = 89;
            }

            if (month == may && nightsCount > 7)
            {
                studioPrice *= 0.95;
            }
            else if (month == october && nightsCount > 7)
            {
                studioPrice *= 0.95;
                studioNightsCount--;
            }
            else if (month == september && nightsCount > 7)
            {
                studioNightsCount--;
            }

            if ((month == june || month == september) && nightsCount > 14)
            {
                doubleRoomPrice *= 0.9;
            }

            if ((month == july || month == august || month == december) && nightsCount > 14)
            {
                suitePrice *= 0.85;
            }

            Console.WriteLine($"Studio: {(studioPrice * studioNightsCount):f2} lv.");
            Console.WriteLine($"Double: {(doubleRoomPrice * nightsCount):f2} lv.");
            Console.WriteLine($"Suite: {(suitePrice * nightsCount):f2} lv.");
        }
    }
}
