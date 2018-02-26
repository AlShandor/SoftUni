using System;
using System.Collections.Generic;

namespace _08.HandsOfCards
{
    class HandsOfCards
    {
        static void Main()
        {
            Dictionary<string, HashSet<string>> playersDeck = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "JOKER")
                {
                    break;
                }

                PutCurrentHandToPlayerDeck(input, playersDeck);
            }

            PrintPlayersScore(playersDeck);
        }

        private static void PrintPlayersScore(Dictionary<string, HashSet<string>> playersDeck)
        {
            Dictionary<char, int> cardsPower = new Dictionary<char, int>
            {
                ['1'] = 1,
                ['2'] = 2,
                ['3'] = 3,
                ['4'] = 4,
                ['5'] = 5,
                ['6'] = 6,
                ['7'] = 7,
                ['8'] = 8,
                ['9'] = 9,
                ['J'] = 11,
                ['Q'] = 12,
                ['K'] = 13,
                ['A'] = 14,
            };
            Dictionary<char, int> cardsType = new Dictionary<char, int>
            {
                ['S'] = 4,
                ['H'] = 3,
                ['D'] = 2,
                ['C'] = 1,
            };
            
            foreach (var playerHand in playersDeck)
            {
                int totalPlayerScore = 0;
                foreach (var card in playerHand.Value)
                {
                    if (card.Length == 2)
                    {
                        char currentCardPower = card[0];
                        char currentCardType = card[1];
                        totalPlayerScore += (cardsPower[currentCardPower] * cardsType[currentCardType]);
                    } else if (card.Length == 3)
                    {
                        char currentCardType = card[2];
                        totalPlayerScore += (10 * cardsType[currentCardType]);
                    }
                }

                Console.WriteLine($"{playerHand.Key}: {totalPlayerScore}");
            }
        }

        private static void PutCurrentHandToPlayerDeck(string input, Dictionary<string, HashSet<string>> playersDeck)
        {
            string[] tokens = input.Split(':');
            string player = tokens[0];
            string[] cardsInHand = tokens[1].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (!playersDeck.ContainsKey(player))
            {
                HashSet<string> currentHand = new HashSet<string>();
                foreach (var card in cardsInHand)
                {
                    currentHand.Add(card);
                }
                playersDeck.Add(player, currentHand);
            }

            foreach (var card in cardsInHand)
            {
                playersDeck[player].Add(card);
            }
        }
    }
}
