using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PopulationCounter
{
    class PopulationCounter
    {
        static void Main()
        {
            Dictionary<string, Country> countryStats = new Dictionary<string, Country>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "report")
                {
                    break;
                }

                CollectCountryInfo(input, countryStats);
            }

            PrintCountryPopulation(countryStats);
        }

        private static void PrintCountryPopulation(Dictionary<string, Country> countryStats)
        {
            foreach (var country in countryStats.OrderByDescending(c => c.Value.TotalPopulation))
            {
                Console.WriteLine($"{country.Value.Name} (total population: {country.Value.TotalPopulation})");
                foreach (var city in country.Value.PopulationByCity.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }

        private static void CollectCountryInfo(string input, Dictionary<string, Country> countryStats)
        {
            string[] tokens = input.Split('|');
            string city = tokens[0];
            string country = tokens[1];
            long population = long.Parse(tokens[2]);
            

            if (!countryStats.ContainsKey(country))
            {
                Country currentCountry = new Country();
                currentCountry.Name = country;
                currentCountry.TotalPopulation = population;
                currentCountry.PopulationByCity.Add(city, population);

                countryStats.Add(country, currentCountry);
            }
            else
            {
                if (!countryStats[country].PopulationByCity.ContainsKey(city))
                {
                    countryStats[country].PopulationByCity[city] = 0;
                }

                countryStats[country].PopulationByCity[city] += population;
                countryStats[country].TotalPopulation += population;
            }
        }

        class Country
        {
            public string Name { get; set; }
            public long TotalPopulation { get; set; }
            public Dictionary<string, long> PopulationByCity = new Dictionary<string, long>();
        }
    }
}
