using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BeverageLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energyContent = int.Parse(Console.ReadLine());
            int sugarContent = int.Parse(Console.ReadLine());

            double energyPer100Ml = (volume / 100.0) * energyContent;
            double sugarPer100Ml = (volume / 100.0) * sugarContent;

            Console.WriteLine($"{volume}ml {name}:");
            Console.WriteLine($"{energyPer100Ml}kcal, {sugarPer100Ml}g sugars");
        }
    }
}
