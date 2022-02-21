using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public int Worth { get; set; }
        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;

        }
    }
}
