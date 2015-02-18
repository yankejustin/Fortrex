﻿using System;
using System.Drawing;
using System.Windows.Forms;
using prjFortrex.GameEngine.Network;
using prjFortrex.GameEngine.GamePlay.Logic.Movement;

namespace prjFortrex.Client
{
    public partial class frmGameWindow : Form
    {
        #region Fields

        PlayerConnection player = new PlayerConnection();

        #endregion

        #region Constructors

        public frmGameWindow()
        {
            InitializeComponent();

            this.BackColor = Color.LightGray;
            // Set to double-buffer to stop flickering of the screen.
            this.DoubleBuffered = true;

            this.VisibleChanged += frmGameWindow_VisibleChanged;
            this.KeyDown += frmGameWindow_KeyDown;
            this.Paint += frmGameWindow_Paint;
        }

        #endregion

        #region Events

        void frmGameWindow_Paint(object sender, PaintEventArgs e)
        {
            // Update visuals.
            SuspendLayout();

            e.Graphics.DrawImage(player.EntityPicture, player.EntitySize);

            ResumeLayout(true);

            // Previously called "this.Invalidate();" here. Now called on the game window's KeyDown.
            // Calling "this.Invalidate();" here would eat up 15-20% of the CPU.
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

            // Don't raise OnPaint... HUGE performance hit. See "frmGameWindow_Paint" for more reasons.
            this.Invalidate();
        }

        private void frmGameWindow_VisibleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        #endregion
    }
}