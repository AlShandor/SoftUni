using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//sum, min, max, and average
namespace _03.SumMinMaxAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            for (int i = 0; i < length; i++)
            {
                nums.Add(int.Parse(Console.ReadLine()));
            }
            int sum = nums.Sum();
            int min = nums.Min();
            int max = nums.Max();
            double average = nums.Average();
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Average = {average}");

        }
    }
}
