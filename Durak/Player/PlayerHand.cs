using Durak.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Durak.Player
{
    public class PlayerHand
    {

        private const int HAND_SIZE = 6;

        private List<CardPictureBox> cards;

        private CardDeck deck;

        public PlayerHand(CardDeck deck)
        {
            this.deck = deck;
        }

        public void TakeCards()
        {
            if (cards.Count < HAND_SIZE) {
                cards.AddRange(deck.Deal(HAND_SIZE - cards.Count));
                Sort();
            }
        }

        public void TakeCards(List<CardPictureBox> cards)
        {
            this.cards.AddRange(cards);
            Sort();
        }

        private void Sort()
        {
            cards.Sort();
        }

        public CardPictureBox UseCard(int index)
        {
            CardPictureBox card = cards[index];
            cards.RemoveAt(index);
            return card;
        }

    }
}
