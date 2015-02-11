using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjFortrex.GameEngine;
using prjFortrex.GameEngine.Network;

namespace prjFortrex.Client
{
    public partial class frmGameWindow : Form
    {
        private Rectangle player = new Rectangle(0, 0, 20, 20);

        public frmGameWindow()
        {
            InitializeComponent();

            this.BackColor = Color.LightGray;

            this.VisibleChanged += frmGameWindow_VisibleChanged;
            this.Paint += frmGameWindow_Paint;
        }

        void frmGameWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Brown, player);
        }

        private void frmGameWindow_VisibleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
