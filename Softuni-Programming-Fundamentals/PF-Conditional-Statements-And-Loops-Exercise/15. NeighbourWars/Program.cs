using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.NeighbourWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());
            int peshoCurrentHealth = 100;
            int goshoCurrentHealth = 100;
            int round = 0;

            for (int i = 1; ; i++)
            {
                if (goshoCurrentHealth <= 0 || peshoCurrentHealth <= 0)
                {
                    break;
                }
                
                if (i % 2 == 1)
                {
                    goshoCurrentHealth -= peshoDamage;
                    round++;
                    if (goshoCurrentHealth <= 0)
                    {
                        break;
                    }
                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoCurrentHealth} health.");
                }
                if(i % 2 == 0)
                {
                    peshoCurrentHealth -= goshoDamage;
                    round++;
                    if (peshoCurrentHealth <= 0)
                    {
                        break;
                    }
                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoCurrentHealth} health.");
                }
                if (i % 3 == 0)
                {
                    peshoCurrentHealth += 10;
                    goshoCurrentHealth += 10;
                }
            }
            if (goshoCurrentHealth > peshoCurrentHealth)
            {
                Console.WriteLine($"Gosho won in {round}th round.");
            }
            else
            {
                Console.WriteLine($"Pesho won in {round}th round.");
            }
        }
    }
}
