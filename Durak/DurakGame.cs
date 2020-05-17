using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Durak.UI;

namespace Durak.Player
{
    class DurakGame
    {
        List<PlayerPanel> players;
        PlayerPanel AttackingPlayer;
        PlayerPanel DefendingPlayer;
        CardDeck deck;
        TablePanel table;

        public DurakGame(List<PlayerPanel> players, CardDeck deck, TablePanel table)
        {
            this.players = players;
            AttackingPlayer = players[0];
            DefendingPlayer = players[1];
            this.deck = deck;
            this.table = table;
        }

        private PlayerPanel NextPlayer(PlayerPanel CurrentPlayer)
        {
            PlayerPanel UtilPlayer = new PlayerPanel();
            for(int i = 0; i < players.Count; i++)
            {
                if(players[i] == CurrentPlayer)
                {
                    if(i == players.Count - 1)
                    {
                        UtilPlayer = players[0];
                    }
                    else
                    {
                        UtilPlayer = players[i+1];
                    }
                }
            }
            return UtilPlayer;
        }

        private void Start()
        {
            foreach(PlayerPanel p in players)
            {
                p.hand.TakeCards(deck.Deal(6));
            }
        } 

        private void Move()
        {
            AttackingPlayer.Attack();
            DefendingPlayer.Defend();
        }

        public void PlayGame()
        {
            Start();
            while(table.CountCards() < 12 || DefendingPlayer.IsDefeated == false)
            {
                Move();
            }

            AttackingPlayer.hand.TakeCards();
            DefendingPlayer.hand.TakeCards();

            AttackingPlayer = DefendingPlayer;
            DefendingPlayer = NextPlayer(DefendingPlayer);
        }
    }
}
