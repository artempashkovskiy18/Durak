using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Durak.Player;

namespace Durak.UI
{
    public partial class PlayerPanel : Panel
    {
        public PlayerPanel()
        {
            InitializeComponent();
        }

        public PlayerPanel(string name, TablePanel table, CardDeck deck)
        {
            this.table = table;
            this.deck = deck;
            hand = new PlayerHand(deck);
            hand.TakeCards();
            isDefended = false;
            Name = name;
            DisplayCards();
        }

        public string Name;
        private CardDeck deck; 
        public PlayerHand hand; 
        private TablePanel table; 
        public bool isDefended; 

        public void DisplayCards()
        {
            for(int i = 0; i < hand.cards.Count; i++)
            {
                hand.cards[i].Size = new Size(Height * hand.cards[i].Image.Width / hand.cards[i].Image.Height, Height);
                hand.cards[i].Location = new Point(i * (Width - hand.cards[i].Width) / hand.cards.Count, 0);
                hand.cards[i].SizeMode = PictureBoxSizeMode.Zoom;
                Controls.Add(hand.cards[i]);
            }
        }

        public void Defend()
        {
            CardPictureBox attackingCard = table.LastAddedCard();
            if (ActiveCard.Card.Suit == attackingCard.Suit || ActiveCard.Card.Suit == deck.TrumpCard.Suit)
            {
                if (ActiveCard.Card.Figure > attackingCard.Figure)
                {
                    table.AddCard(hand.UseCard(ActiveCard.Card));
                    isDefended = true;
                }
            }

            if (ActiveCard.Card.Suit == deck.TrumpCard.Suit)
            {
                if (attackingCard.Suit != deck.TrumpCard.Suit)
                {
                    table.AddCard(hand.UseCard(ActiveCard.Card));
                    isDefended = true;
                }
                else
                {
                    if (ActiveCard.Card.Figure > attackingCard.Figure)
                    {
                        table.AddCard(hand.UseCard(ActiveCard.Card));
                        isDefended = true;
                    }
                }
            }
        }

        public void Attack()
        {
            if (table.CountCards() > 0)
            {
                foreach (var item in table.GetAllFigures())
                {
                
                    if (ActiveCard.Card.Figure == item)
                    {
                        table.AddCard(hand.UseCard(ActiveCard.Card));
                    }
                }
            }
            else
            {
                table.AddCard(hand.UseCard(ActiveCard.Card));
            }
        }

    }
}
