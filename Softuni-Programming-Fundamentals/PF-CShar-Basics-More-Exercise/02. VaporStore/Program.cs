using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//OutFall 4	                    $39.99
//CS: OG	                    $15.99
//Zplinter Zell                 $19.99
//Honored 2	                    $59.99
//RoverWatch	                $29.99
//RoverWatch Origins Edition	$39.99

namespace _02.VaporStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());

            string outFall4 = "OutFall 4";
            string cs = "CS: OG";
            string splinterCell = "Zplinter Zell";
            string honored = "Honored 2";
            string roverwatch = "RoverWatch";
            string roverwatchOE = "RoverWatch Origins Edition";

            double totalSpent = 0;


            while (true)
            {
                string game = Console.ReadLine();
                if (game == "Game Time")
                {
                    break;
                }
                if (game == outFall4)
                {
                    if (currentBalance < 39.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        currentBalance -= 39.99;
                        Console.WriteLine($"Bought {game}");
                        totalSpent += 39.99;
                    }
                }
                else if (game == cs)
                {
                    if (currentBalance < 15.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        currentBalance -= 15.99;
                        Console.WriteLine($"Bought {game}");
                        totalSpent += 15.99;
                    }
                }
                else if (game == splinterCell)
                {
                    if (currentBalance < 19.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        currentBalance -= 19.99;
                        Console.WriteLine($"Bought {game}");
                        totalSpent += 19.99;
                    }
                }
                else if (game == honored)
                {
                    if (currentBalance < 59.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        currentBalance -= 59.99;
                        Console.WriteLine($"Bought {game}");
                        totalSpent += 59.99;
                    }
                }
                else if (game == roverwatch)
                {
                    if (currentBalance < 29.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        currentBalance -= 29.99;
                        Console.WriteLine($"Bought {game}");
                        totalSpent += 29.99;
                    }
                }
                else if (game == roverwatchOE)
                {
                    if (currentBalance < 39.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        currentBalance -= 39.99;
                        Console.WriteLine($"Bought {game}");
                        totalSpent += 39.99;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
            }
            Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${currentBalance:f2}");
        }
    }
}
