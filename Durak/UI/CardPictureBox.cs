using System;
using System.Drawing;
using System.Windows.Forms;

namespace Durak.UI
{
    public partial class CardPictureBox : PictureBox, IComparable<CardPictureBox>
    { 

        public int Suit { get; set; }
        public int Figure { get; set; }

        public DurakGame durak;

        public CardPictureBox()
        {
            InitializeComponent();
        }

        public CardPictureBox(int suit, int figure, DurakGame d)
        {
            InitializeComponent();
            Suit = suit;
            Figure = figure;
            SetImage();
            Click += HandleClick;
            durak = d;
        }

        private void HandleClick(object sender, EventArgs e)
        {
            if (durak.ActivePlayer.hand.cards.Contains(this)) {
                ActiveCard.Card = this;
                durak.MakeTurn();
            }
        }

        public int CompareTo(CardPictureBox other)
        {
            return Figure.CompareTo(other.Figure) == 0 ? Suit.CompareTo(other.Suit) : Figure.CompareTo(other.Figure);
        }

        private void SetImage()
        {
            string way = @"Cards\";

            switch (Suit)
            {
                case 1:
                    way += "Diamonds ";
                    break;

                case 2:
                    way += "Clubs ";
                    break;

                case 3:
                    way += "Hearts ";
                    break;

                case 4:
                    way += "Spades ";
                    break;
            }

            switch (Figure)
            {
                case 1:
                    way += "two.png";
                    break;

                case 2:
                    way += "three.png";
                    break;

                case 3:
                    way += "four.png";
                    break;

                case 4:
                    way += "five.png";
                    break;

                case 5:
                    way += "six.png";
                    break;

                case 6:
                    way += "seven.png";
                    break;

                case 7:
                    way += "eight.png";
                    break;

                case 8:
                    way += "nine.png";
                    break;

                case 9:
                    way += "ten.png";
                    break;

                case 10:
                    way += "jack.png";
                    break;

                case 11:
                    way += "queen.png";
                    break;

                case 12:
                    way += "king.png";
                    break;

                case 13:
                    way += "ace.png";
                    break;
            }
            Image = Image.FromFile(way);
        }

    }
}
