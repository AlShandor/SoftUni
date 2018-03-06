using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BPMCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int beatsPerMinute = int.Parse(Console.ReadLine());
            double numberOfBeats = double.Parse(Console.ReadLine());

            double bar = Math.Round((numberOfBeats / 4.0), 1);

            int lengthInSeconds = (int)Math.Floor((numberOfBeats / beatsPerMinute) * 60);
            int minutes = 0;

            if (lengthInSeconds > 59)
            {
                minutes = lengthInSeconds / 60;
                lengthInSeconds %= 60;
            }

            Console.WriteLine($"{bar} bars - {minutes}m {lengthInSeconds}s");

        }
    }
}
