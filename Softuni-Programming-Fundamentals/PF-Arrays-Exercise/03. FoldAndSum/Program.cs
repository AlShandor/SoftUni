using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] firstHalf = GetFirstHalfOfArray(array);
            int[] half1 = GetFirstHalfOfArray(firstHalf).Reverse().ToArray();
            int[] half2 = GetSecondHalfOfArray(firstHalf);
            int[] sumFirstHalf = GetSumOfTwoHalves(half1, half2);

            int[] secondHalf = GetSecondHalfOfArray(array);
            int[] secondHalf1 = GetFirstHalfOfArray(secondHalf);
            int[] secondHalf2 = GetSecondHalfOfArray(secondHalf).Reverse().ToArray();
            int[] sumSecondHalf = GetSumOfTwoHalves(secondHalf1, secondHalf2);

            Console.WriteLine(string.Join(" ",sumFirstHalf) + " " + string.Join(" ",sumSecondHalf));
        }

        static int[] GetSumOfTwoHalves(int[] half1, int[] half2)
        {
            int[] sumFirstHalf = new int[half1.Length];
            for (int i = 0; i < sumFirstHalf.Length; i++)
            {
                sumFirstHalf[i] = half1[i] + half2[i];
            }

            return sumFirstHalf;
        }

        static int[] GetFirstHalfOfArray(int[] array)
        {
            int[] firstHalf = new int[array.Length / 2];
            for (int i = 0; i < firstHalf.Length; i++)
            {
                firstHalf[i] = array[i];
            }

            return firstHalf;
        }

        static int[] GetSecondHalfOfArray (int[] array)
        {
            int[] secondHalf = new int[array.Length / 2];
            int n = array.Length / 2;
            for (int i = 0; i < secondHalf.Length; i++)
            {
                secondHalf[i] = array[n];
                n++;
            }

            return secondHalf;
        }
    }
}
