using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfIntegers = 0;

            try
            {
                while (true)
                {
                    int num = int.Parse(Console.ReadLine());
                    numberOfIntegers++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(numberOfIntegers);
            }
        }
    }
}
