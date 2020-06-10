using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Durak.UI;
using System.Drawing;

namespace Durak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DurakGame Durak;
        List<PlayerPanel> players;
        TablePanel table;
        CardDeck deck;

        private void Button1_Click(object sender, EventArgs e)
        {
            table = new TablePanel();
            deck = new CardDeck();
            Durak = new DurakGame();

            deck.InitSmallSet(Durak);
            players = new List<PlayerPanel>() { new PlayerPanel("artem", table, deck), new PlayerPanel("nastya", table, deck) };
            Durak.Init(players, deck, table);

            players[0].Top = 12;
            players[0].Left = 415;
            players[0].Width = 370;
            players[0].Height = 100;
            players[0].BackColor = Color.White;
            Controls.Add(players[0]);

            players[1].Top = 224;
            players[1].Left = 415;
            players[1].Width = 370;
            players[1].Height = 100;
            players[1].BackColor = Color.White;
            Controls.Add(players[1]);

            table.Top = 118;
            table.Left = 415;
            table.Width = 370;
            table.Height = 100;
            table.BackColor = Color.White;
            Controls.Add(table);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(Durak.ActivePlayer == Durak.DefendingPlayer)
            {
                if (Durak.AttackingPlayer.hand.cards.Count == 0 && deck.cards.Count == 0)
                {
                    //Attacking player won
                }
                else
                {
                    Durak.AttackingPlayer.hand.TakeCards();
                    Durak.DefendingPlayer.hand.TakeCards(table.addedCards);
                }
            }
            else
            {
                Durak.AttackingPlayer.hand.TakeCards();
                Durak.DefendingPlayer.hand.TakeCards();

                Durak.AttackingPlayer = Durak.DefendingPlayer;
                Durak.DefendingPlayer = Durak.NextPlayer(Durak.DefendingPlayer);
            }
        }
    }
}
