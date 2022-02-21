using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    class UserInterface
    {
        public void RunInterface()
        {
            Console.WriteLine("Welcome to Jason's Blackjack Table!");
            Console.WriteLine("***********************************");
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            bool finishedWithMenu = false;
            while (!finishedWithMenu)
            {
                Gameplay gameplay = new Gameplay();
                DeckOfCards cardDeck = new DeckOfCards();
                List<Card> menuDeck = new List<Card>();
                cardDeck.CreateDeck(menuDeck);
                cardDeck.GetDeck(menuDeck);
                Console.WriteLine();
                Console.WriteLine("1) I want to play Blackjack!");
                Console.WriteLine("2) I need to checkout the rules.");
                Console.WriteLine("3) I want to see the deck, make sure it's all there.");
                Console.WriteLine("4) Exit game.");

                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    finishedWithMenu = true;
                    Console.Clear();
                    Console.WriteLine("Alright, let's play!");
                    Console.WriteLine();
                    Console.WriteLine("Initial deal");
                    Console.WriteLine("============");
                    Console.WriteLine();
                    gameplay.PlayingGame();
                }
                if (userInput == 2)
                {
                    finishedWithMenu = false;
                }
                if (userInput == 3)
                {
                    finishedWithMenu = false;
                    Console.Clear();
                    cardDeck.DisplayDeck(menuDeck);
                    Console.WriteLine();
                    Console.WriteLine("There it is! Now what would you like to do?");
                    Console.WriteLine();
                    Console.WriteLine("**Okay, well now I want to see it shuffled!**  (Enter secret code \"5\")");
                }
                if (userInput == 4)
                {
                    finishedWithMenu = false;
                }
                if (userInput == 5)
                {
                    finishedWithMenu = false;
                    Console.Clear();
                    cardDeck.DisplayShuffledDeck(menuDeck);
                    Console.WriteLine();
                    Console.WriteLine("All shuffled! Now what would you like to do?");
                    Console.WriteLine();
                }
            }
        }

        public void InGameMenu()
        {
            Gameplay gameplay = new Gameplay();
            gameplay.PlayingGame();

            bool finishedWithGameMenu = false;

            while (!finishedWithGameMenu)
            {
                finishedWithGameMenu = false;
                Console.WriteLine();
                Console.WriteLine("Hit(1) or stay(2)?");
                Console.ReadLine();
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    finishedWithGameMenu = false;
                    Console.WriteLine();
                    gameplay.DealACard();
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
