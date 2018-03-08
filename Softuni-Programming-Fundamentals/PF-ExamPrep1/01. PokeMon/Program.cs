using System;

namespace _01.PokeMon
{
    class Program
    {
        static void Main()
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int count = 0;
            int currentPokePower = pokePower;
            while (true)
            {
                currentPokePower -= distance;
                count++;
                bool isPossibleDivision = IsPossibleDivision(currentPokePower, exhaustionFactor);
                if (currentPokePower == pokePower * 0.5 && isPossibleDivision)
                {
                    currentPokePower /= exhaustionFactor;
                }
                if (currentPokePower < distance)
                {
                    break;
                }
            }
            Console.WriteLine(currentPokePower);
            Console.WriteLine(count);
        }

        private static bool IsPossibleDivision(int currentPokePower, int exhaustionFactor)
        {
            bool isPossibleDivision = true;
            try
            {
                int result = currentPokePower / exhaustionFactor;
            }
            catch
            {
                isPossibleDivision = false;
            }
            return isPossibleDivision;
        }
    }
}
