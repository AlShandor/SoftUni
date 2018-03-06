using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//On the first line of input you will receive
//the char index you should start with and on the second line - the index of the last character you should print.
namespace _17.PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int indexBegin = int.Parse(Console.ReadLine());
            int indexFinish = int.Parse(Console.ReadLine());

            for (int i = indexBegin; i <= indexFinish; i++)
            {
                Console.Write((char)i + " ");
            }

        }
    }
}
