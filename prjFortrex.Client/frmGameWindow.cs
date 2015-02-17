using System;
using System.Drawing;
using System.Windows.Forms;
using prjFortrex.GameEngine.Network;
using prjFortrex.GameEngine.GamePlay.Logic.Movement;

namespace prjFortrex.Client
{
    public partial class frmGameWindow : Form
    {
        PlayerConnection player = new PlayerConnection();

        public frmGameWindow()
        {
            InitializeComponent();

            this.BackColor = Color.LightGray;
            this.DoubleBuffered = true;

            this.VisibleChanged += frmGameWindow_VisibleChanged;
            this.KeyDown += frmGameWindow_KeyDown;
            this.Paint += frmGameWindow_Paint;
        }

        void frmGameWindow_Paint(object sender, PaintEventArgs e)
        {
            // Update visuals.

            e.Graphics.DrawImage(player.EntityPicture, player.EntitySize);

            this.Invalidate();
        }

        void frmGameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    player.MoveEntity(Direction.Up);
                    break;
                case Keys.Down:
                    player.MoveEntity(Direction.Down);
                    break;
                case Keys.Left:
                    player.MoveEntity(Direction.Left);
                    break;
                case Keys.Right:
                    player.MoveEntity(Direction.Right);
                    break;
                default:
                    return;
            }

            this.RaisePaintEvent("OnPaint", new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
        }

        private void frmGameWindow_VisibleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}