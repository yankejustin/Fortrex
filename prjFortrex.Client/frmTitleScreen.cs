using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjFortrex.Client
{
    public partial class frmTitleScreen : Form
    {
        frmGameWindow gameWindow = new frmGameWindow();

        public frmTitleScreen()
        {
            InitializeComponent();
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                if (gameWindow == null)
                {
                    gameWindow = new frmGameWindow();
                }

                this.Hide();
                gameWindow.ShowDialog();
            }
            finally
            {
                this.Show();
            }
        }
    }
}
