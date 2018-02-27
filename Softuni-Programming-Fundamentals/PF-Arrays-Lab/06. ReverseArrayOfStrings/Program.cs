using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strArray = Console.ReadLine().Split(' ').ToArray();
            string[] reversedArray = new string[strArray.Length];

            int iReversedFirstHalf = strArray.Length;
            for(int iStr = 0; iStr < strArray.Length / 2; iStr++, iReversedFirstHalf--)
            {
                reversedArray[iStr] = strArray[iReversedFirstHalf - 1];
            }

            if (strArray.Length % 2 == 0)
            {
                int iReversedSecondHalf = (strArray.Length / 2) - 1;
                for (int iStr = (strArray.Length / 2); iStr < strArray.Length; iStr++, iReversedSecondHalf--)
                {
                    reversedArray[iStr] = strArray[iReversedSecondHalf];
                }

                Console.WriteLine(string.Join(" ", reversedArray));
            }
            else
            {
                int iReversedSecondHalf = (strArray.Length / 2);
                for (int iStr = (strArray.Length / 2); iStr < strArray.Length; iStr++, iReversedSecondHalf--)
                {
                    reversedArray[iStr] = strArray[iReversedSecondHalf];
                }

                Console.WriteLine(string.Join(" ", reversedArray));
            }
            
        }
    }
}
