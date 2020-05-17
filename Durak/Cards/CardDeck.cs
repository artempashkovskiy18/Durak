﻿using Durak.UI;
using Durak.Util;
using System;
using System.Collections.Generic;

namespace Durak
{
    public class CardDeck
    {

        private static readonly List<int> SUITS = new List<int> {
            Const.Card.Suit.DIAMONDS,
            Const.Card.Suit.CLUBS,
            Const.Card.Suit.HEARTS,
            Const.Card.Suit.SPADES
        };

        private static readonly List<int> SMALL_SET_FIGURES = new List<int> {
            Const.Card.Figure.SIX,
            Const.Card.Figure.SEVEN,
            Const.Card.Figure.EIGHT,
            Const.Card.Figure.NINE,
            Const.Card.Figure.TEN,
            Const.Card.Figure.JACK,
            Const.Card.Figure.QUEEN,
            Const.Card.Figure.KING,
            Const.Card.Figure.ACE
        };

        private static readonly List<int> LARGE_SET_FIGURES = new List<int>
        { 
            Const.Card.Figure.TWO,
            Const.Card.Figure.THREE,
            Const.Card.Figure.FOUR,
            Const.Card.Figure.FIVE,
            Const.Card.Figure.SIX,
            Const.Card.Figure.SEVEN,
            Const.Card.Figure.EIGHT,
            Const.Card.Figure.NINE,
            Const.Card.Figure.TEN,
            Const.Card.Figure.JACK,
            Const.Card.Figure.QUEEN,
            Const.Card.Figure.KING,
            Const.Card.Figure.ACE
        };

        private static readonly Random RANDOM = new Random();

        private List<CardPictureBox> cards;

        public CardPictureBox TrumpCard { get; private set; }

        private CardDeck(List<int> figureSet)
        {
            cards = new List<CardPictureBox>();

            foreach (var i in figureSet)
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