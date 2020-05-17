using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Durak.UI
{
    public partial class TablePanel : Panel
    {
        public TablePanel()
        {
            InitializeComponent();
        }

        public void AddCard(CardPictureBox card)
        {
            Controls.Add(card);
        }

        public void AddCards(List<CardPictureBox> cards)
        {
            foreach(CardPictureBox c in cards)
            {
                Controls.Add(c);
            }
        }

        public int CountCards()
        {
            return Controls.Count;
        }
    }
}
