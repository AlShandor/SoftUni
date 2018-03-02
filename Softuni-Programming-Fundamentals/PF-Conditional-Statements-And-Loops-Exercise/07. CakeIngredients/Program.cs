using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfIngredients = 0;
            while (true)
            {
                string ingredient = Console.ReadLine();
                if (ingredient == "Bake!")
                {
                    break;
                }
                Console.WriteLine($"Adding ingredient {ingredient}.");
                numOfIngredients++;
            }
            Console.WriteLine($"Preparing cake with {numOfIngredients} ingredients.");
        }
    }
}
