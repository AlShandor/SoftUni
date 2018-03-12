using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CharacterStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int currentHealth = int.Parse(Console.ReadLine());
            int maxHealth = int.Parse(Console.ReadLine());
            int currentEnergy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            char pipe = '|';
            char dot = '.';

            Console.WriteLine($"Name: {name}");

            Console.Write("Health: ");
            Console.Write(pipe);
            Console.Write(new string(pipe, currentHealth));
            Console.Write(new string(dot, (maxHealth - currentHealth)));
            Console.WriteLine(pipe);

            Console.Write("Energy: ");
            Console.Write(pipe);
            Console.Write(new string(pipe, currentEnergy));
            Console.Write(new string(dot, (maxEnergy - currentEnergy)));
            Console.WriteLine(pipe);
        }
    }
}
