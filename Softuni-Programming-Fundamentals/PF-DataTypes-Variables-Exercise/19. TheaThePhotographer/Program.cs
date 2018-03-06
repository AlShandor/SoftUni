using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.TheaThePhotographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long totalPictures = long.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            double filterFactor = double.Parse(Console.ReadLine());
            long uploadTime = long.Parse(Console.ReadLine());

            int filteredPictures = (int)Math.Ceiling(totalPictures * filterFactor / 100.0);
            long totalFilterTime = filterTime * totalPictures;
            long totalUploadTime = filteredPictures * uploadTime;
            int totalTimeSeconds = (int)(totalFilterTime + totalUploadTime);

            int daysNeeded = totalTimeSeconds / 86400;
            int hoursNeeded = (totalTimeSeconds - (daysNeeded * 86400)) / 3600;
            int minutesNeeded = (totalTimeSeconds - (daysNeeded * 86400) - (hoursNeeded * 3600)) / 60;
            int secondsNeeded = totalTimeSeconds - (daysNeeded * 86400) - (hoursNeeded * 3600) - (minutesNeeded * 60);
            
            Console.WriteLine($"{daysNeeded}:{hoursNeeded:d2}:{minutesNeeded:d2}:{secondsNeeded:d2}");
        }
    }
}
