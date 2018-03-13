using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases =
            {
                "Excellent product",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            string[] events =
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            string[] authors =
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };
            string[] cities =
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            int numberofMessages = int.Parse(Console.ReadLine());
            Random random = new Random();
            for (int i = 0; i < numberofMessages; i++)
            {
                int phraseIndex = random.Next(phrases.Length);
                int eventsIndex = random.Next(events.Length);
                int authorsIndex = random.Next(authors.Length);
                int citiesIndex = random.Next(cities.Length);
                Console.WriteLine($"{phrases[phraseIndex]} {events[eventsIndex]} {authors[authorsIndex]} – {cities[citiesIndex]}");
            }
        }
    }
}
