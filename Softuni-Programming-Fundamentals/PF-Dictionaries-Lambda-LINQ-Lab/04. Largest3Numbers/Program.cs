using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .OrderByDescending((x => x)).Take(3)
                .ToList()
                .ToList();
            
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
