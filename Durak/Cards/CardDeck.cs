using Durak.UI;
using Durak.Util;
using System;
using System.Collections.Generic;

namespace Durak
{
    public class CardDeck
    {

        private static readonly List<int> SUITS = new List<int> {
            Const.CardPictureBox.Suit.DIAMONDS,
            Const.CardPictureBox.Suit.CLUBS,
            Const.CardPictureBox.Suit.HEARTS,
            Const.CardPictureBox.Suit.SPADES
        };

        private static readonly List<int> SMALL_SET_FIGURES = new List<int> {
            Const.CardPictureBox.Figure.SIX,
            Const.CardPictureBox.Figure.SEVEN,
            Const.CardPictureBox.Figure.EIGHT,
            Const.CardPictureBox.Figure.NINE,
            Const.CardPictureBox.Figure.TEN,
            Const.CardPictureBox.Figure.JACK,
            Const.CardPictureBox.Figure.QUEEN,
            Const.CardPictureBox.Figure.KING,
            Const.CardPictureBox.Figure.ACE
        };

        private static readonly List<int> LARGE_SET_FIGURES = new List<int>
        { 
            Const.CardPictureBox.Figure.TWO,
            Const.CardPictureBox.Figure.THREE,
            Const.CardPictureBox.Figure.FOUR,
            Const.CardPictureBox.Figure.FIVE,
            Const.CardPictureBox.Figure.SIX,
            Const.CardPictureBox.Figure.SEVEN,
            Const.CardPictureBox.Figure.EIGHT,
            Const.CardPictureBox.Figure.NINE,
            Const.CardPictureBox.Figure.TEN,
            Const.CardPictureBox.Figure.JACK,
            Const.CardPictureBox.Figure.QUEEN,
            Const.CardPictureBox.Figure.KING,
            Const.CardPictureBox.Figure.ACE
        };

        private static readonly Random RANDOM = new Random();

        private List<CardPictureBox> cards;

        public CardPictureBox TrumpCard { get; private set; }

        private CardDeck(List<int> fugureSet)
        {
            cards = new List<CardPictureBox>();

            foreach (var i in fugureSet)
            {
                foreach (var j in SUITS)
                {
                    cards.Add(new CardPictureBox(i, j));
                }
            }

            Mix();

            TrumpCard = cards[cards.Count - 1];
        }

        private void Mix()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int rnd = RANDOM.Next(i);
                CardPictureBox temp = cards[rnd];
                cards[rnd] = cards[i];
                cards[i] = temp;
            }
        }

        public static CardDeck CreateSmallSet()
        {
            return new CardDeck(SMALL_SET_FIGURES);
        }

        public static CardDeck CreateLargeSet()
        {
            return new CardDeck(LARGE_SET_FIGURES);
        }

        public List<CardPictureBox> Deal(int amount)
        {
            amount = Math.Min(amount, cards.Count);
            List<CardPictureBox> dealCards = new List<CardPictureBox>();

            for (int i = 0; i < amount; i++)
            {
                dealCards.Add(cards[i]);
                cards.RemoveAt(i);
            }

            return dealCards;
        }

    }
}