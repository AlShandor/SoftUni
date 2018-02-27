using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            bool[] primes = new bool[num + 1];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }
            
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (primes[i])
                {
                    for (int j = i * i; j < primes.Length; j+= i)
                    {
                        primes[j] = false;
                    }
                }
            }
            
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i] == true)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
