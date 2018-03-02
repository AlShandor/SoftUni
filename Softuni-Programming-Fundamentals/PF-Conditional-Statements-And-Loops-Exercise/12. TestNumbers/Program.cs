using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int maxSumBoundry = int.Parse(Console.ReadLine());
            int currentresult = 0;
            int counter = 0;

            for (int a = n; a >= 1; a--)
            {
                for (int b = 1; b <= m; b++)
                {
                    counter++;
                    currentresult += 3 * (a * b);
                    if (currentresult >= maxSumBoundry)
                    {
                        break;
                    }
                }
                if (currentresult >= maxSumBoundry)
                {
                    break;
                }
            }
            Console.WriteLine($"{counter} combinations");
            if (currentresult < maxSumBoundry)
            {
                Console.WriteLine($"Sum: {currentresult}");
            }
            else
            {
                Console.WriteLine($"Sum: {currentresult} >= {maxSumBoundry}");
            }
        }
    }
}
