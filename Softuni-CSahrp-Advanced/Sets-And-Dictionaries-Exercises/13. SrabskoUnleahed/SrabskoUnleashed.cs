using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _13.SrabskoUnleahed
{
    class SrabskoUnleashed
    {
        class Venue
        {
            public string Name { get; set; }
            public Dictionary<string, long> SingerEarnings = new Dictionary<string, long>();
        }

        static void Main()
        {
            Dictionary<string, Venue> venueEarnings = new Dictionary<string, Venue>();
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string pattern = @"(([A-za-z]+ )+)@(([A-za-z]+ )+)([0-9]+ )([0-9]+)";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(input))
                {
                    CollectVenueAndSingerInfo(input, regex, venueEarnings);
                }
                else
                {
                    continue;
                }
            }

            PrintVenueInfo(venueEarnings);
        }

        private static void PrintVenueInfo(Dictionary<string, Venue> venueEarnings)
        {
            foreach (var venue in venueEarnings)
            {
                Console.WriteLine(venue.Key);
                foreach (var singer in venue.Value.SingerEarnings.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }

        private static void CollectVenueAndSingerInfo(string input, Regex regex, Dictionary<string, Venue> venueEarnings)
        {
            var match = regex.Match(input);
            string singer = match.Groups[1].Value.Trim();
            string venueName = match.Groups[3].Value.Trim();
            int ticketsPrice = int.Parse(match.Groups[5].Value.Trim());
            int ticketsCount = int.Parse(match.Groups[6].Value.Trim());

            if (!venueEarnings.ContainsKey(venueName))
            {
                Venue currentVenue = new Venue();
                currentVenue.Name = venueName;
                if (!currentVenue.SingerEarnings.ContainsKey(singer))
                {
                    currentVenue.SingerEarnings[singer] = 0;
                }
                currentVenue.SingerEarnings[singer] += (ticketsCount * ticketsPrice);

                venueEarnings.Add(venueName, currentVenue);
            }
            else
            {
                if (!venueEarnings[venueName].SingerEarnings.ContainsKey(singer))
                {
                    venueEarnings[venueName].SingerEarnings[singer] = 0;
                }
                venueEarnings[venueName].SingerEarnings[singer] += (ticketsCount * ticketsPrice);
            }
        }
    }
}
