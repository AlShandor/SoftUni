using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numsList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int[] bombAndPower = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int bomb = bombAndPower[0];
            int power = bombAndPower[1];

            for (int index = 0; index < numsList.Count; index++)
            {
                if (numsList[index] == bomb)
                {
                    if (index - power < 0 && index + power > numsList.Count - 1)
                    {
                        numsList.Clear();
                    }
                    else if (index - power < 0)
                    {
                        numsList.RemoveRange(0, power + 1 + index);
                    }
                    else if (index + power > numsList.Count - 1)
                    {
                        numsList.RemoveRange(index - power, power + 1 +((numsList.Count - 1) - index));
                    }
                    else
                    {
                        numsList.RemoveRange(index - power, power * 2 + 1);
                    }
                    index = -1;
                }
            }
            
            Console.WriteLine(numsList.Sum());
        }
    }
}
