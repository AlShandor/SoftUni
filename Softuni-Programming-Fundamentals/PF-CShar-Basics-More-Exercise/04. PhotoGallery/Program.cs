using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//First line – the photo’s number – an integer in the range[0…9999]
// Second, third, fourth line – the day, month and year the photo was taken – integers forming valid dates in
//the range[01 / 01 / 1990…31 / 12 / 2020]
// Fifth, sixth line – the hours and minutes the photo was taken – integers in the range[0…23]
// Seventh line – the photo’s size in bytes – integer in the range[0…999000000]
// Eighth, ninth line – the photo’s resolution(width and height) in pixels – integers in the range[1…10000]
namespace _04.PhotoGallery
{
    class Program
    {
        static void Main(string[] args)
        {
            int photoNumber = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            double photoSize = double.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string orientation = "";
            string byteFormat = "";

            if (width > height)
            {
                orientation = "landscape";
            }
            else if (height > width)
            {
                orientation = "portrait";
            }
            else if (width == height)
            {
                orientation = "square";
            }

            if (photoSize >= 1000 && photoSize < 1000000)
            {
                photoSize /= 1000;
                byteFormat = "KB";
            }
            else if (photoSize < 1000)
            {
                byteFormat = "B";
            }
            else if (photoSize > 1000000)
            {
                photoSize = Math.Round((photoSize / 1000000.0), 1);
                byteFormat = "MB";
            }

            Console.WriteLine($"Name: DSC_{photoNumber:d4}.jpg");
            Console.WriteLine($"Date Taken: {day:d2}/{month:d2}/{year} {hours:d2}:{minutes:d2}");
            Console.WriteLine($"Size: {photoSize}{byteFormat}");
            Console.WriteLine($"Resolution: {width}x{height} ({orientation})");
        }
    }
}
