using System;
using System.Collections.Generic;
using BlazorBJ.Client.Extensions;
using BlazorBJ.Client.Models.Enums;

namespace BlazorBJ.Client.Models
{
    public class CardDeck
    {
        protected Stack<Card> Cards { get; set; }

        public CardDeck()
        {
            var deck = GetDeck();
            ShuffleDeck(deck);
            Cards = MakeCardStack(deck);
        }

        private List<Card> GetDeck()
        {
            var cards = new List<Card>();

            foreach (var suit in (CardSuit[]) Enum.GetValues(typeof(CardSuit)))
            {
                foreach (var value in (CardValue[]) Enum.GetValues(typeof(CardValue)))
                {
                    var newCard = new Card()
                    {
                        Suit = suit,
                        Value = value,
                        ImageName = "card" + suit.GetDisplayName() + value.GetDisplayName()
                    };

                    cards.Add(newCard);
                }
            }

            return cards;
        }

        private void ShuffleDeck(List<Card> cards)
        {
            var rnd = new Random();

            for (int i = cards.Count - 1; i > 0; --i)
            {
                var k = rnd.Next(i + 1);

                var temp = cards[i];
                cards[i] = cards[k];
                cards[k] = temp;
            }
        }

        private Stack<Card> MakeCardStack(List<Card> cards)
        {
            var stack = new Stack<Card>();
            
            for (int i = 0; i < cards.Count; i++)
            {
                stack.Push(cards[i]);
            }

            return stack;
        }

        public int Count => Cards.Count;

        public void AddCard(Card card)
        {
            Cards.Push(card);
        }

        public Card DrawCard() => Cards.Pop();
    }
}