using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CryptoMaster
{
    class Program
    {
        static void Main()
        {
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int numbersCount = numbers.Count;
            int longestSeq = 1;


            for (int currentStep = 1; currentStep < numbersCount - 1; currentStep++)
            {
                Queue<int> queue = new Queue<int>(numbers);
                
                for (int currentNumIndex = 1; currentNumIndex <= numbersCount; currentNumIndex++)
                {
                    Queue<int> tempQueue = new Queue<int>(queue);
                    int currentLongSeq = 1;
                    // check next number in sequence
                    for (int i = 2; i <= currentNumIndex; i++)
                    {
                        tempQueue.Enqueue(tempQueue.Dequeue());
                    }
                    int currentNum = tempQueue.Peek();
                    while (true)
                    {
                        bool isLongestStreakFound = false;
                        for (int i = 1; i <= currentStep; i++)
                        {
                            tempQueue.Enqueue(tempQueue.Dequeue());
                        }

                        int nextNum = tempQueue.Peek();
                        if (nextNum > currentNum)
                        {
                            currentLongSeq++;
                            currentNum = nextNum;
                            if (currentLongSeq > longestSeq)
                            {
                                longestSeq = currentLongSeq;
                            }
                        }
                        else
                        {
                            isLongestStreakFound = true;
                            break;
                        }

                        if (isLongestStreakFound)
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(longestSeq);
        }
    }
}
