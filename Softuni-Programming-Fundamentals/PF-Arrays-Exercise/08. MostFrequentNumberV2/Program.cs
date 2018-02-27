using System;
using System.Linq;

namespace DevApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int count = 1;
            int frequentNumber = array[0];
            int tempNumber = 0;
            for (int i = 0; i < (array.Length - 1); i++)
            {
                tempNumber = array[i];
                int tempCount = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (tempNumber == array[j])
                    {
                        tempCount++;
                    }
                }
                if (tempCount > count)
                {
                    frequentNumber = tempNumber;
                    count = tempCount;
                }
            }
            Console.WriteLine(frequentNumber);
        }
    }
}