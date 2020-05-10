using System;
using System.Windows.Forms;

namespace Durak.UI
{
    public partial class CardPictureBox : PictureBox, IComparable<CardPictureBox>
    { 

        public int Suit { get; set; }
        public int Figure { get; set; }

        public CardPictureBox()
        {
            InitializeComponent();
        }

        public CardPictureBox(int suit, int figure)
        {
            InitializeComponent();
            Suit = suit;
            Figure = figure;
            this.Click += HandleClick;
        }

        private void HandleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(CardPictureBox other)
        {
            return Figure.CompareTo(other.Figure) == 0 ? Suit.CompareTo(other.Suit) : Figure.CompareTo(other.Figure);
        }

    }
}
