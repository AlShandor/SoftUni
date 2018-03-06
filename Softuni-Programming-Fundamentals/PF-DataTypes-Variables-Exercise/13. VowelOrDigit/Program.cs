using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.VowelOrDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbol = Console.ReadLine();
            try
            {
                int integer = Convert.ToInt32(symbol);
                Console.WriteLine("digit");
            }
            catch (Exception)
            {
                switch (symbol)
                {
                    case "a":
                    case "e":
                    case "u":
                    case "o":
                    case "i":
                        Console.WriteLine("vowel");
                        break;
                    default:
                        Console.WriteLine("other");
                        break;
                }
            }

        }
    }
}
