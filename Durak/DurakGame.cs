using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Durak.UI;

namespace Durak
{
    public class DurakGame
    {
        List<PlayerPanel> players;
        CardDeck deck;
        TablePanel table;

        public PlayerPanel ActivePlayer {get; set; }
        public PlayerPanel AttackingPlayer { get; set; }
        public PlayerPanel DefendingPlayer { get; set; }

        public DurakGame()
        {

        }

        public void Init(List<PlayerPanel> players, CardDeck deck, TablePanel table)
        {
            this.players = players;
            AttackingPlayer = players[0];
            ActivePlayer = players[0];
            DefendingPlayer = players[1];
            this.deck = deck;
            this.table = table;

            Start();
        }

        public PlayerPanel NextPlayer(PlayerPanel CurrentPlayer)
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
            if(ActiveCard.Card != null)
            {
                if (ActivePlayer == AttackingPlayer)
                {
                    AttackingPlayer.Attack();
                    ActivePlayer = DefendingPlayer;
                }
                else
                {
                    DefendingPlayer.Defend();
                    if (AttackingPlayer.hand.cards.Count == 0 && deck.cards.Count == 0)
                    {
                        if (DefendingPlayer.hand.cards.Count == 0)
                        {
                            // Draw
                        }
                        else
                        {
                            //Attacking player won
                        }
                    }
                    ActivePlayer = AttackingPlayer;
                }
            }
        }

        public void MakeTurn()
        {
            if (table.CountCards() < 12 )// || DefendingPlayer.isDefeated == false)
            {
                Move();
            }
            else
            {
                AttackingPlayer.hand.TakeCards();
                DefendingPlayer.hand.TakeCards();

                AttackingPlayer = DefendingPlayer;
                DefendingPlayer = NextPlayer(DefendingPlayer);
            }
        }
    }
}
