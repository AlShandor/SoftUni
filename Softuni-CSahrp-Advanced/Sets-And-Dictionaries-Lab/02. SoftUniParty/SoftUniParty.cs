using System;
using System.Collections.Generic;

namespace _02.SoftUniParty
{
    class SoftUniParty
    {
        static void Main()
        {
            SortedSet<string> guestSet = new SortedSet<string>();

            while (true)
            {
                string reservations = Console.ReadLine();
                if (reservations == "PARTY")
                {
                    break;
                }

                guestSet.Add(reservations);

            }

            while (true)
            {
                string guestsAtParty = Console.ReadLine();
                if (guestsAtParty == "END")
                {
                    break;
                }

                guestSet.Remove(guestsAtParty);
            }

            Console.WriteLine(guestSet.Count);
            foreach (var guestNotAtParty in guestSet)
            {
                Console.WriteLine(guestNotAtParty);
            }
        }
    }
}
