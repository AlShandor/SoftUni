using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.WinningTicket
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string validTicketPattern = @"";
            string winningTicketPattern = @"";
            string jackpotPattern = @"";

            var validTickets = Regex.Matches(input, validTicketPattern)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();
        }
    }
}
