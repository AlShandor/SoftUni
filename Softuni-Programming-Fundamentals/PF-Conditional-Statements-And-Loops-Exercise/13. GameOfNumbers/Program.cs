using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicalNumber = int.Parse(Console.ReadLine());
            string lastCombination = "";
            int combinations = 0;
            bool isEqualToMagicalNumber = false;

            for (int firstN = n; firstN <= m; firstN++)
            {
                for (int secondN = n; secondN <= m; secondN++)
                {
                    combinations++;
                    if (firstN + secondN == magicalNumber)
                    {
                        lastCombination = $"Number found! {firstN} + {secondN} = {magicalNumber}";
                        isEqualToMagicalNumber = true;
                    }
                }
            }
            if (isEqualToMagicalNumber)
            {
                Console.WriteLine(lastCombination);
            }
            else
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicalNumber}");
            }
        }
    }
}
