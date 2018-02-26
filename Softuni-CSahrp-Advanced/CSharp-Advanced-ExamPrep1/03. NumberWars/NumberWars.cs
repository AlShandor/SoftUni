using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._NumberWars
{
    class NumberWars
    {
        class Card
        {
            public int Number { get; set; }
            public char Letter { get; set; }
        }

        static void Main()
        {
            string[] inputPlayer1 = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] inputPlayer2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<Card> deckPlayer1 = GetPlayerDeckFromInput(inputPlayer1);
            Queue<Card> deckPlayer2 = GetPlayerDeckFromInput(inputPlayer2);

            bool winPlayer1 = false;
            bool winPlayer2 = false;
            bool isDraw = false;
            int turn = 0;
            bool isGameOver = false;
            // play the game
            while (true)
            {
                turn++;
                Card drawnCardPlayer1 = deckPlayer1.Dequeue();
                Card drawnCardPlayer2 = deckPlayer2.Dequeue();

                // player1 wins hand
                if (drawnCardPlayer1.Number > drawnCardPlayer2.Number)
                {
                    deckPlayer1.Enqueue(drawnCardPlayer1);
                    deckPlayer1.Enqueue(drawnCardPlayer2);
                }
                // player2 wins hand
                else if (drawnCardPlayer2.Number > drawnCardPlayer1.Number)
                {
                    deckPlayer2.Enqueue(drawnCardPlayer2);
                    deckPlayer2.Enqueue(drawnCardPlayer1);
                }
                // if no winner 
                else
                {
                    List<Card> drawnCardsPlayer1 = new List<Card>();
                    List<Card> drawnCardsPlayer2 = new List<Card>();
                    // each player draw 3 more cards
                    
                    while (true)
                    {
                        // if player has no cards game over
                        if (deckPlayer1.Count == 0 || deckPlayer2.Count == 0)
                        {
                            if (deckPlayer1.Count == 0 && deckPlayer2.Count == 0)
                            {
                                isDraw = true;
                                isGameOver = true;
                                break;
                            }
                            if (deckPlayer1.Count == 0)
                            {
                                winPlayer2 = true;
                                isGameOver = true;
                                break;
                            }
                            if (deckPlayer2.Count == 0)
                            {
                                winPlayer1 = true;
                                isGameOver = true;
                                break;
                            }
                        }

                        // draw 3 more player1
                        for (int i = 0; i < 3; i++)
                        {
                            drawnCardsPlayer1.Add(deckPlayer1.Dequeue());
                        }

                        // draw 3 more player2
                        for (int i = 0; i < 3; i++)
                        {
                            drawnCardsPlayer2.Add(deckPlayer2.Dequeue());
                        }

                        int strengthHandPlayer1 = GetStrengthLast3Cards(drawnCardsPlayer1);
                        int strengthHandPlayer2 = GetStrengthLast3Cards(drawnCardsPlayer2);
                        if (strengthHandPlayer1 > strengthHandPlayer2)
                        {
                            drawnCardsPlayer1.AddRange(drawnCardsPlayer2);
                            drawnCardsPlayer1.Add(drawnCardPlayer1);
                            drawnCardsPlayer1.Add(drawnCardPlayer2);
                            foreach (var card in drawnCardsPlayer1.OrderByDescending(x => x.Number).ThenByDescending(x => x.Letter))
                            {
                                deckPlayer1.Enqueue(card);
                            }
                            break;
                        }
                        if (strengthHandPlayer2 > strengthHandPlayer1)
                        {
                            drawnCardsPlayer1.AddRange(drawnCardsPlayer2);
                            drawnCardsPlayer1.Add(drawnCardPlayer1);
                            drawnCardsPlayer1.Add(drawnCardPlayer2);
                            foreach (var card in drawnCardsPlayer1.OrderByDescending(x => x.Number).ThenByDescending(x => x.Letter))
                            {
                                deckPlayer2.Enqueue(card);
                            }
                            break;
                        }
                    }
                }

                if (isGameOver)
                {
                    break;
                }

                // if player has no cards game over
                if (deckPlayer1.Count == 0 || deckPlayer2.Count == 0)
                {
                    if (deckPlayer1.Count == 0 && deckPlayer2.Count == 0)
                    {
                        isDraw = true;
                        isGameOver = true;
                        break;
                    }
                    if (deckPlayer1.Count == 0)
                    {
                        winPlayer2 = true;
                        isGameOver = true;
                        break;
                    }
                    if (deckPlayer2.Count == 0)
                    {
                        winPlayer1 = true;
                        isGameOver = true;
                        break;
                    }
                }

                // end on turn 1000000
                if (turn == 1000000)
                {
                    // todo determine winner
                    if (deckPlayer1.Count > deckPlayer2.Count)
                    {
                        winPlayer1 = true;
                        break;
                    }
                    else if (deckPlayer2.Count > deckPlayer1.Count)
                    {
                        winPlayer2 = true;
                        break;
                    }
                }
            }

            PrintFinalResult(winPlayer1, winPlayer2, isDraw, turn);
        }

        private static void PrintFinalResult(bool winPlayer1, bool winPlayer2, bool isDraw, int turn)
        {
            if (isDraw)
            {
                Console.WriteLine($"Draw after {turn} turns");
            }
            else if(winPlayer1)
            {
                Console.WriteLine($"First player wins after {turn} turns");
            }
            else if (winPlayer2)
            {
                Console.WriteLine($"Second player wins after {turn} turns");
            }
        }

        private static int GetStrengthLast3Cards(List<Card> drawnCardsPlayer)
        {
            int strengthLast3Cards = 0;
            for (int currentCardIndex = drawnCardsPlayer.Count - 1; currentCardIndex >= drawnCardsPlayer.Count - 3; currentCardIndex--)
            {
                strengthLast3Cards += (int)drawnCardsPlayer[currentCardIndex].Letter;
            }

            return strengthLast3Cards;
        }

        private static Queue<Card> GetPlayerDeckFromInput(string[] inputPlayer)
        {
            Queue<Card> newQueue = new Queue<Card>();
            foreach (var cardString in inputPlayer)
            {
                Card newCard = new Card();
                newCard.Number = int.Parse(cardString.Remove(cardString.Length - 1));
                newCard.Letter = cardString[cardString.Length - 1];
                newQueue.Enqueue(newCard);
            }

            return newQueue;
        }
    }
}
