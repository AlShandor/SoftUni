using System;

namespace _08.RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        private static long[] memo;

        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            memo = new long[num];

            Console.WriteLine(Fibonacci(num));
        } 

        static long Fibonacci(int num)
        {
            if (num <= 2)
            {
                return 1;
            }

            if (memo[num - 1] != 0)
            {
                return memo[num - 1];
            }
               
            return memo[num - 1] = Fibonacci(num - 1) + Fibonacci(num - 2);
        }
    }
}
