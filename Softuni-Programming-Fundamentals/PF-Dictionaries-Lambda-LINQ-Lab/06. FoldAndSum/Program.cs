using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numsList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int k = numsList.Length / 4;
            int[] row1Left = numsList.Take(k).Reverse().ToArray();
            int[] row1Right = numsList.Reverse().Take(k).ToArray();
            int[] row1 = row1Left.Concat(row1Right).ToArray();
            int[] row2 = numsList.Skip(k).Take(2 * k).ToArray();
            int[] resultArray = new int[row1.Length];
            for (int i = 0; i < row1.Length; i++)
            {
                resultArray[i] = row1[i] + row2[i];
            }

            Console.WriteLine(string.Join(" ", resultArray));
        }
    }
}
