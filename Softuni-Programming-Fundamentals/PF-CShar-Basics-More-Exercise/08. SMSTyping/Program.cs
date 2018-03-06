using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.SMSTyping
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCharacters = int.Parse(Console.ReadLine());

            string[] message = new string[numberOfCharacters];

            for (int i = 0; i < numberOfCharacters; i++)
            {
                int characterInNumbers = int.Parse(Console.ReadLine());

                switch (characterInNumbers)
                {
                    case 2:
                        message[i] = "a";
                        break;
                    case 22:
                        message[i] = "b";
                        break;
                    case 222:
                        message[i] = "c";
                        break;
                    case 3:
                        message[i] = "d";
                        break;
                    case 33:
                        message[i] = "e";
                        break;
                    case 333:
                        message[i] = "f";
                        break;
                    case 4:
                        message[i] = "g";
                        break;
                    case 44:
                        message[i] = "h";
                        break;
                    case 444:
                        message[i] = "i";
                        break;
                    case 5:
                        message[i] = "j";
                        break;
                    case 55:
                        message[i] = "k";
                        break;
                    case 555:
                        message[i] = "l";
                        break;
                    case 6:
                        message[i] = "m";
                        break;
                    case 66:
                        message[i] = "n";
                        break;
                    case 666:
                        message[i] = "o";
                        break;
                    case 7:
                        message[i] = "p";
                        break;
                    case 77:
                        message[i] = "q";
                        break;
                    case 777:
                        message[i] = "r";
                        break;
                    case 7777:
                        message[i] = "s";
                        break;
                    case 8:
                        message[i] = "t";
                        break;
                    case 88:
                        message[i] = "u";
                        break;
                    case 888:
                        message[i] = "v";
                        break;
                    case 9:
                        message[i] = "w";
                        break;
                    case 99:
                        message[i] = "x";
                        break;
                    case 999:
                        message[i] = "y";
                        break;
                    case 9999:
                        message[i] = "z";
                        break;
                    case 0:
                        message[i] = " ";
                        break;
                    default:
                        break;
                }
            }
            foreach (var item in message)
            {
                Console.Write(item.ToString());
            }
        }
    }
}
