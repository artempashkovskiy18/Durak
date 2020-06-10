using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace Durak.UI
{
    public partial class TablePanel : Panel
    {
        public TablePanel()
        {
            InitializeComponent();
        }

        public bool isAdded;
        public List<CardPictureBox> addedCards = new List<CardPictureBox>();

        public void AddCard(CardPictureBox card)
        {
            Controls.Add(card);
            card.Size = new Size(Height * card.Image.Width / card.Image.Height, Height);
            card.Location = new Point(card.Width * (addedCards.Count), 0);
            card.SizeMode = PictureBoxSizeMode.Zoom;
            addedCards.Add(card);
        }

        public void AddCards(List<CardPictureBox> cards)
        {
            foreach(CardPictureBox c in cards)
            {
                AddCard(c);
            }
        }

        public int CountCards()
        {
            return addedCards.Count;
        }

        public CardPictureBox LastAddedCard()
        {
            return addedCards[addedCards.Count - 1];
        }

        public void RemoveCard(CardPictureBox card)
        {
            Controls.Remove(card);
            addedCards.Remove(card);
        }

        public void RemoveCards(List<CardPictureBox> cards)
        {
            foreach (CardPictureBox c in cards)
            {
                RemoveCard(c);
            }
        }
    }
}
