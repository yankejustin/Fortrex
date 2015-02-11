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
    public partial class frmGameWindow : Form
    {
        public frmGameWindow()
        {
            InitializeComponent();

            this.VisibleChanged += frmGameWindow_VisibleChanged;
        }

        void frmGameWindow_VisibleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
