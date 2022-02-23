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
        List<Card> userCards = new List<Card>();
        List<Card> dealerCards = new List<Card>();
        List<Card> discardPile = new List<Card>();
        private bool finishedPlayingGame = false;
        private int userTotal;
        private int dealerTotal;
        private bool dealerStands = false;
        private bool userStands = false;

        public void PlayingGame()
        {
            if (discardPile.Count > 0)
            {
                discardPile.RemoveRange(0, discardPile.Count - 1);
            }
            deckOfCards.CreateDeck(gameplayDeck);
            deckOfCards.GetDeck(gameplayDeck);
            gameplayDeck = gameplayDeck.OrderBy(i => Guid.NewGuid()).ToList();


            while (!finishedPlayingGame)
            {
                DealCards();
            }
            return;
        }

        public void DealCards()
        {
            if (gameplayDeck.Count < 9)
            {
                PlayingGame();
            }
            userTotal = 0;
            dealerTotal = 0;
            userCards.Add(gameplayDeck[0]);
            dealerCards.Add(gameplayDeck[1]);
            userCards.Add(gameplayDeck[2]);
            dealerCards.Add(gameplayDeck[3]);
            gameplayDeck.RemoveRange(0, 4);
            dealerStands = false;
            userStands = false;

            Console.WriteLine(" ------------------");
            Console.WriteLine(" Your current hand:");
            Console.WriteLine(" ------------------");
            foreach (Card cards in userCards)
            {
                Console.WriteLine($" {cards.Value} of {cards.Suit}");
            }
            if (userCards[0].Value == "Ace" && userCards[1].Value == "Ace")
            {
                userCards[0].Worth = 1;
                userCards[1].Worth = 11;
            }
            if (userCards[0].Value == "Ace" && userCards[1].Value != "Ace" || userCards[0].Value != "Ace" && userCards[1].Value == "Ace")
            {
                foreach (Card card in userCards)
                {
                    if (card.Value == "Ace")
                    {
                        card.Worth = 11;
                        foreach (Card otherCard in userCards)
                        {
                            if (otherCard.Worth == 10)
                            {
                                Console.WriteLine();
                                Console.WriteLine(" *********");
                                Console.WriteLine(" BLAKJACK!");
                                Console.WriteLine(" *********");
                                Console.WriteLine();
                                Console.WriteLine(" 21 on the deal! You win!");
                                Console.WriteLine();
                                FinalizeHand();

                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine(" ------------------");
            Console.WriteLine(" The dealer's hand:");
            Console.WriteLine(" ------------------");
            foreach (Card card in dealerCards)
            {
                Console.WriteLine($" {card.Value} of {card.Suit}");
            }
            if (dealerCards[0].Value == "Ace" && dealerCards[1].Value == "Ace")
            {
                dealerCards[0].Worth = 1;
                dealerCards[1].Worth = 11;
            }
            if (dealerCards[0].Value == "Ace" && dealerCards[1].Value != "Ace" || dealerCards[0].Value != "Ace" && dealerCards[1].Value == "Ace")
            {
                foreach (Card card in dealerCards)
                {
                    if (card.Value == "Ace")
                    {
                        card.Worth = 11;
                    }
                }
            }
            foreach (Card card in dealerCards)
            {
                dealerTotal += card.Worth;
            }
            if (dealerTotal >= 17)
            {
                dealerStands = true;
            }
            InGame();
        }

        public void DealAdditionalUser()
        {
            Console.Clear();
            userCards.Add(gameplayDeck[0]);
            gameplayDeck.RemoveRange(0, 1);
            Console.WriteLine($" Your new card: |{userCards[userCards.Count - 1].Value} of {userCards[userCards.Count - 1].Suit}|");
            userTotal = 0;
            Console.WriteLine();
            Console.WriteLine(" Your hand now consists of:");
            Console.WriteLine(" --------------------------");
            foreach (Card card in userCards)
            {
                Console.WriteLine($" {card.Value} of {card.Suit}");
            }
            if (userCards[userCards.Count - 1].Value == "Ace")
            {
                userCards[userCards.Count - 1].Worth = 11;
            }
            foreach (Card cards in userCards)
            {
                userTotal += cards.Worth;
            }
            foreach (Card card in userCards)
            {
                if (userTotal > 21 && card.Value == "Ace" && card.Worth != 1)
                {
                    card.Worth = 1;
                    userTotal = 0;
                    foreach (Card cards in userCards)
                    {
                        userTotal += cards.Worth;
                    }
                }
            }
            if (userTotal == 21)
            {
                Console.WriteLine();
                Console.WriteLine(" *************");
                Console.WriteLine(" *You hit 21!*");
                Console.WriteLine(" *************");
                userStands = true;
                if (dealerStands == false)
                {
                    DealAdditionalDealer();
                }
                InGame();
            }
            if (userTotal > 21)
            {
                Console.WriteLine();
                Console.WriteLine(" Dang it, you bust!");
                FinalizeHand();
            }
            if (dealerStands == false)
            {
                DealAdditionalDealer();
            }
            InGame();
        }

        public void DealAdditionalDealer()
        {
            dealerTotal = 0;
            foreach (Card cards in dealerCards)
            {
                dealerTotal += cards.Worth;
            }
            if (dealerTotal <= 16)
            {
                dealerCards.Add(gameplayDeck[0]);
                gameplayDeck.RemoveRange(0, 1);
                Console.WriteLine();
                Console.WriteLine(" ----------------------------------------------------------");
                Console.WriteLine(" The dealer took another card and the dealer's hand is now:");
                Console.WriteLine(" ----------------------------------------------------------");
                Console.WriteLine();
                foreach (Card card in dealerCards)
                {
                    Console.WriteLine($" {card.Value} of {card.Suit}");
                }
                dealerTotal = 0;
                if (dealerCards[dealerCards.Count - 1].Value == "Ace")
                {
                    dealerCards[dealerCards.Count - 1].Worth = 11;
                }
                foreach (Card cards in dealerCards)
                {
                    dealerTotal += cards.Worth;
                }
                foreach (Card card in dealerCards)
                {
                    if (dealerTotal > 21 && card.Value == "Ace" && card.Worth != 1)
                    {
                        card.Worth = 1;
                        dealerTotal = 0;
                        foreach (Card cards in userCards)
                        {
                            dealerTotal += cards.Worth;
                        }
                    }
                }
                if (dealerTotal >= 17 && dealerTotal <= 21)
                {
                    dealerStands = true;
                }
                if (dealerTotal > 21)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Dealer busts!");
                    FinalizeHand();
                }
                InGame();
            }
            InGame();
        }

        public void InGame()
        {
            userTotal = 0;
            dealerTotal = 0;
            Console.WriteLine();
            foreach (Card card in dealerCards)
            {
                dealerTotal += card.Worth;
            }
            foreach (Card card in userCards)
            {
                userTotal += card.Worth;
            }
            if (userStands == true && dealerTotal <= 16)
            {
                DealAdditionalDealer();
            }
            if (dealerStands == true && userStands == true)
            {
                FinalizeHand();
            }
            if (userTotal < 21 && userStands == false)
            {
                if (dealerStands == true)
                {
                    if (userTotal > dealerTotal)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" ********");
                        Console.WriteLine(" You win!");
                        Console.WriteLine(" ********");
                        FinalizeHand();
                    }
                    DealerStands();
                    Console.WriteLine();
                }
                Console.WriteLine(" What do you want to do, Hit(1) or Stand(2)?");
            }
            int userInput = int.Parse(Console.ReadLine());

            if (userInput == 1)
            {
                DealAdditionalUser();
            }
            if (userInput == 2)
            {
                userStands = true;

                if (dealerStands == false)
                {
                    Console.Clear();
                    DealAdditionalDealer();
                    Console.WriteLine();
                }
                if (dealerStands == true)
                {
                    FinalizeHand();
                }
            }
        }

        public void FinalizeHand()
        {
            userTotal = 0;
            dealerTotal = 0;
            Console.WriteLine();
            Console.WriteLine(" ===========================");
            Console.WriteLine(" Final results for that hand");
            Console.WriteLine(" ===========================");
            Console.WriteLine();
            Console.WriteLine(" Your hand");
            Console.WriteLine(" ---------");
            foreach (Card card in userCards)
            {
                userTotal += card.Worth;
                Console.WriteLine($" {card.Value} of {card.Suit}");
                Console.WriteLine();
                discardPile.Add(card);
            }
            Console.WriteLine($" Total: {userTotal}");
            Console.WriteLine(" ___________________");
            Console.WriteLine();
            Console.WriteLine(" Dealer hand");
            Console.WriteLine(" -----------");
            foreach (Card card in dealerCards)
            {
                dealerTotal += card.Worth;
                Console.WriteLine($" {card.Value} of {card.Suit}");
                Console.WriteLine();
                discardPile.Add(card);
            }
            Console.WriteLine($" Total: {dealerTotal}");
            Console.WriteLine(" ___________________");
            Console.WriteLine();
            if (userTotal > dealerTotal && userTotal <= 21 || userTotal < 21 && dealerTotal > 21)
            {
                Console.WriteLine(" ********************");
                Console.WriteLine(" Congrats on the win!");
                Console.WriteLine(" ********************");
                Console.WriteLine();
            }
            if (dealerTotal > userTotal && dealerTotal <= 21 || userTotal > 21 && dealerTotal <= 21)
            {
                Console.WriteLine(" =============================================");
                Console.WriteLine(" Dealer won this one... Better luck next hand!");
                Console.WriteLine(" =============================================");
                Console.WriteLine();
            }
            if (dealerTotal == userTotal && dealerTotal <= 21 && userTotal <= 21)
            {
                Console.WriteLine(" =====================");
                Console.WriteLine(" That hand was a push!");
                Console.WriteLine(" =====================");
                Console.WriteLine();
            }
            userCards.RemoveRange(0, userCards.Count);
            dealerCards.RemoveRange(0, dealerCards.Count);
            Console.WriteLine(" Deal again? Yes(1) or No(2)");
            int dealAgain = int.Parse(Console.ReadLine());
            if (dealAgain == 1)
            {
                Console.Clear();
                Console.WriteLine(" ============================");
                Console.WriteLine(" Next hand, place your wager!");
                Console.WriteLine(" ============================");
                Console.WriteLine();
                DealCards();
            }
            else
            {
                FinishGame();
            }
        }

        public void DealerStands()
        {
            Console.WriteLine();
            Console.WriteLine($" The dealer stands with:");
            Console.WriteLine(" ------------------------");
            dealerStands = true;
            foreach (Card card in dealerCards)
            {
                Console.WriteLine($" {card.Value} of {card.Suit}");
            }
        }

        public void FinishGame()
        {
            Console.Clear();
            Console.WriteLine(" Great game!");
            Console.WriteLine();
            Console.WriteLine();
            finishedPlayingGame = true;
            PlayingGame();
        }

        //public void UserAce()
        //{
        //    Console.WriteLine("Please choose the value of your Ace (enter \"1\" or \"11\").");
        //    if (gameplayDeck[i].Value == "Ace")
        //    {
        //        userInput = int.Parse(Console.ReadLine());
        //        gameplayDeck[i].Worth = deckOfCards.AceWorth + userInput;
        //    }
        //    else
        //    {
        //        userInput = int.Parse(Console.ReadLine());
        //        gameplayDeck[i + 2].Worth = deckOfCards.AceWorth + userInput;
        //    }
        //}

    }
}

//if (userCards[0].Value == "Ace" && userCards[1].Worth != 10 || userCards[1].Value == "Ace" && userCards[0].Worth != 10)
//{
//    Console.WriteLine("Please choose the value of your Ace (enter \"1\" or \"11\").");
//    if (userCards[0].Value == "Ace")
//    {
//        userInput = int.Parse(Console.ReadLine());
//        userCards[0].Worth = userCards[0].Worth + userInput;
//        Console.Clear();
//        Console.WriteLine($"Your cards: {userCards[0].Value} of {userCards[0].Suit} and {userCards[1].Value} of {userCards[1].Suit}");
//        Console.WriteLine();
//    }
//Console.WriteLine();
//Console.WriteLine("Please choose the value of your Ace (enter \"1\" or \"11\").");
//userInput = int.Parse(Console.ReadLine());
//card.Worth = card.Worth + userInput;
//Console.Clear();
//else
//{
//    Console.WriteLine();
//    Console.WriteLine(" ------------------");
//    Console.WriteLine(" Your current hand:");
//    Console.WriteLine(" ------------------");
//    foreach (Card card in userCards)
//    {
//        userTotal += card.Worth;
//        Console.WriteLine($" {card.Value} of {card.Suit}");
//    }
//    InGame();