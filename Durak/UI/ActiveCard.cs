using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Durak.UI
{
    public partial class ActiveCard : CardPictureBox
    {
        public ActiveCard()
        {
            InitializeComponent();
        }

        public static CardPictureBox Card;
    }
}
