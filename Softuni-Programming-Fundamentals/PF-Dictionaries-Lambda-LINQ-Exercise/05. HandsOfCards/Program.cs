using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> cards = new Dictionary<string, int>
            {
                ["2"] = 2,
                ["3"] = 3,
                ["4"] = 4,
                ["5"] = 5,
                ["6"] = 6,
                ["7"] = 7,
                ["8"] = 8,
                ["9"] = 9,
                ["10"] = 10,
                ["J"] = 11,
                ["Q"] = 12,
                ["K"] = 13,
                ["A"] = 14,
                ["S"] = 4,
                ["H"] = 3,
                ["D"] = 2,
                ["C"] = 1
            };

            Dictionary<string, List<string>> playersScore = new Dictionary<string, List<string>>();
            string[] playerAndCardsDrawn = Console.ReadLine()
                .Split(':')
                .ToArray();
            while (playerAndCardsDrawn[0] != "JOKER")
            {
                string personName = playerAndCardsDrawn[0];
                List<string> cardsDrawn = playerAndCardsDrawn[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (playersScore.ContainsKey(personName))
                {
                    playersScore[personName].AddRange(cardsDrawn);
                }
                else
                {
                    playersScore.Add(personName, cardsDrawn);
                }
                playerAndCardsDrawn = Console.ReadLine()
                    .Split(':')
                    .ToArray(); ;
            }

            
            foreach (var p in playersScore)
            {
                int playerResult = 0;
                var playerListOfCards = p.Value.Distinct().ToArray();
                for (int i = 0; i < playerListOfCards.Length; i++)
                {
                    string card = playerListOfCards[i];
                    string power = "";
                    string type = "";
                    if (card.Length == 3)
                    {
                        power = "10";
                        type = card[2].ToString();
                    }
                    else
                    {
                        power = card[0].ToString();
                        type = card[1].ToString();
                    }
                    playerResult += cards[power] * cards[type];
                }
                Console.WriteLine(p.Key + ": " + playerResult);
            }
        }
    }
}
