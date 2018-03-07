using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_SrabskoUnleashedV2
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Venue> Venues = new Dictionary<string, Venue>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                try
                {
                    string name = "";
                    if (!input.Split('@').First().EndsWith(" "))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        name = input.Split('@').First().Trim();
                    }
                    Singer newSinger = GetSinger(input, name);
                    string newVenueName = GetVenue(input);
                    if (!Venues.ContainsKey(newVenueName))
                    {
                        // Create new Venue and add to dict
                        Venue newVenue = new Venue();
                        newSinger.TotalMoney = newSinger.TicketPrice * newSinger.TicketCount;
                        newVenue.ListOfSingers.Add(newSinger);
                        Venues.Add(newVenueName, newVenue);
                    }
                    else
                    {
                        bool isNewSinger = true;
                        // If Singer is already in the list of the venue, increase total money of singer.
                        foreach (var singer in Venues[newVenueName].ListOfSingers)
                        {
                            if (singer.Name == newSinger.Name)
                            {
                                singer.TotalMoney += newSinger.TicketPrice * newSinger.TicketCount;
                                isNewSinger = false;
                            }
                        }
                        // If is new singer for the venues, add it to the list.
                        if (isNewSinger)
                        {
                            newSinger.TotalMoney = newSinger.TicketPrice * newSinger.TicketCount;
                            Venues[newVenueName].ListOfSingers.Add(newSinger);
                        }
                    }
                }
                catch
                {
                    input = Console.ReadLine();
                    continue;
                }
                input = Console.ReadLine();
            }
            PrintSIngersByVenues(Venues);
        }

        private static void PrintSIngersByVenues(Dictionary<string,Venue> Venues)
        {
            foreach (var venue in Venues)
            {
                Console.WriteLine(venue.Key);
                var orderedVenue = venue.Value.ListOfSingers.OrderByDescending(x => x.TotalMoney);
                foreach (var singer in orderedVenue)
                {
                    Console.WriteLine($"#  {singer.Name} -> {singer.TotalMoney}");
                }
            }
        }

        private static string GetVenue(string input)
        {
            string[] tokens = input.Split('@').Skip(1).First().Split(' ').Reverse().Skip(2).Reverse().ToArray();
            string newVenue = string.Join(" ", tokens);
            return newVenue;
        }

        private static Singer GetSinger(string input, string name)
        {
            int ticketPrice = int.Parse(input.Split(new char[] { '@', ' ' }).Reverse().First());
            int ticketCount = int.Parse(input.Split(new char[] { '@', ' ' }).Reverse().Skip(1).First());
            Singer newSinger = new Singer();
            newSinger.Name = name;
            newSinger.TicketPrice = ticketPrice;
            newSinger.TicketCount = ticketCount;
            return newSinger;
        }

        class Singer
        {
            public string Name { get; set; }
            public int TicketPrice { get; set; }
            public int TicketCount { get; set; }
            public long TotalMoney { get; set; }
        }

        class Venue
        {
            public List<Singer> ListOfSingers = new List<Singer>();
        }
    }
}
