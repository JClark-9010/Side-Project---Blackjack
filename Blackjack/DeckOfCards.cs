using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blackjack
{
    class DeckOfCards
    {
        public void CreateDeck(List<Card> deckOfCards)
        {
            string[] suits = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    Card card = new Card(suit, value);
                    deckOfCards.Add(card);

                }
            }

            foreach (Card card in deckOfCards)
            {
                if (card.Value == "2" || card.Value == "3" || card.Value == "4" || card.Value == "5" || card.Value == "6" || card.Value == "7" || card.Value == "8" || card.Value == "9" || card.Value == "10")
                {
                    int worth = int.Parse(card.Value);
                    card.Worth = worth;
                }
                if (card.Value == "Jack" || card.Value == "Queen" || card.Value == "King")
                {
                    card.Worth = 10;
                }

                if (card.Value == "Ace")
                {
                    card.Worth = 0;
                }
            }
        }

        public List<Card> GetDeck(List<Card> deckOfCards)
        {
            return deckOfCards;
        }
        public void DisplayDeck(List<Card> deckOfCards)
        {
            foreach (Card card in deckOfCards)
            {
                if (card.Value == "Queen")
                {
                    Console.WriteLine($"    {card.Value} -  {card.Suit}");
                }
                else if (card.Value == "King" || card.Value == "Jack")
                {
                    Console.WriteLine($"    {card.Value}  -  {card.Suit}");
                }
                else if (card.Value == "Ace")
                {
                    Console.WriteLine($"    {card.Value}   -  {card.Suit}");
                }
                else if (card.Value == "10")
                {
                    Console.WriteLine($"    {card.Value}    -  {card.Suit}");
                }
                else
                {
                    Console.WriteLine($"    {card.Value}     -  {card.Suit}");
                }
            }
        }

        public void DisplayShuffledDeck(List<Card> deckOfCards)
        {
            deckOfCards = deckOfCards.OrderBy(i => Guid.NewGuid()).ToList();
            foreach (Card card in deckOfCards)
            {
                if (card.Value == "Queen")
                {
                    Console.WriteLine($"    {card.Value} -  {card.Suit}");
                }
                else if (card.Value == "King" || card.Value == "Jack")
                {
                    Console.WriteLine($"    {card.Value}  -  {card.Suit}");
                }
                else if (card.Value == "Ace")
                {
                    Console.WriteLine($"    {card.Value}   -  {card.Suit}");
                }
                else if (card.Value == "10")
                {
                    Console.WriteLine($"    {card.Value}    -  {card.Suit}");
                }
                else
                {
                    Console.WriteLine($"    {card.Value}     -  {card.Suit}");
                }
            }
        }
    }
}
