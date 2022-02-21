using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blackjack
{
    class Gameplay
    {
        DeckOfCards deckOfCards = new DeckOfCards();
        List<Card> gameplayDeck = new List<Card>();
        private int userInput;

        public void PlayingGame()
        {
            deckOfCards.CreateDeck(gameplayDeck);
            deckOfCards.GetDeck(gameplayDeck);
            gameplayDeck = gameplayDeck.OrderBy(i => Guid.NewGuid()).ToList();

            bool finishedPlayingGame = false;

            while (!finishedPlayingGame)
            {

                DealACard();
                break;
            }
        }

        public void DealACard()
        {
            for (int i = 0; i < gameplayDeck.Count; i++)
            {
                Console.WriteLine($"Your cards: {gameplayDeck[i].Value} of {gameplayDeck[i].Suit} and {gameplayDeck[i + 2].Value} of {gameplayDeck[i + 2].Suit}");
                Console.WriteLine();
                if (gameplayDeck[i].Value == "Ace" || gameplayDeck[i + 2].Value == "Ace")
                {
                    Console.WriteLine("Please choose the value of your Ace (enter \"1\" or \"11\").");
                    if (gameplayDeck[i].Value == "Ace")
                    {
                        userInput = int.Parse(Console.ReadLine());
                        gameplayDeck[i].Worth = deckOfCards.AceWorth + userInput;
                    }
                    else
                    {
                        userInput = int.Parse(Console.ReadLine());
                        gameplayDeck[i + 2].Worth = deckOfCards.AceWorth + userInput;
                    }
                }
                Console.WriteLine($"Your hand is currently worth {gameplayDeck[i].Worth + gameplayDeck[i + 2].Worth} (the {gameplayDeck[i].Value} of {gameplayDeck[i].Suit} = {gameplayDeck[i].Worth} and the {gameplayDeck[i + 2].Value} of {gameplayDeck[i + 2].Suit} = {gameplayDeck[i + 2].Worth})");
                int dealerHand = 2;
                Card[] dealerCards = new Card[dealerHand];
                dealerCards[0] = gameplayDeck[i + 1];
                dealerCards[1] = gameplayDeck[i + 3];

                InGame();
            }
        }

        public void InGame()
        {
            bool finishedWithGameMenu = false;

            while (!finishedWithGameMenu)
            {
                finishedWithGameMenu = false;
                Console.WriteLine();
                Console.WriteLine("What do you want to do, Hit(1) or Stay(2)?");
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    finishedWithGameMenu = false;
                    Console.WriteLine();
                    DealACard();
                    //InGameMenu();

                }
                if (userInput == 2)
                {
                    finishedWithGameMenu = false;
                }
            }
        }
    }
}
