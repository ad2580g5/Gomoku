using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Gomoku : Form   
    {
        private Game game = new Game();
        public Gomoku()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Gomoku_MouseDown(object sender, MouseEventArgs e)
        {
           
                piece piece = game.PlaceAPiece(e.X, e.Y);
                if (piece != null)
                {
                    this.Controls.Add(piece);
                }
                //Check Win?
                if(game.Winner == PieceType.BLACK)
            {
                MessageBox.Show("BLACK win.");
            }
                else if(game.Winner == PieceType.WHITE)
            {
                MessageBox.Show("White win.");
            }
           
        }

        private void Gomoku_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

    }
}
