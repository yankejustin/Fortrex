using System;
using System.Windows.Forms;
using System.Threading;

namespace prjFortrex.Client.GUI
{
    // Should get quite a bit of re-writing to make more consistent behavior

    // TODO: RE-WRITE SOME OF THE ANIMATION METHODS... SEE BELOW
    //       ADD A HORIZONTAL SCROLL BAR
    //       DYNAMICALLY ADD AN INVENTORYITEM

    /* Animation Method Problem */
    // Both animation methods rely on a "Thread.Sleep(int)" to
    //   make the animation better. Unfortunately, the speed of
    //   the animation will depend on the desired height...
    // The height should be a static speed, and should not rely
    //   on the desired height.

    public partial class CascadingInventoryBar : UserControl
    {
        #region Fields

        private bool Shrinking = false;
        private bool Growing = false;
        private bool Open = false;

        #endregion

        #region Constructors

        public CascadingInventoryBar()
        {
            InitializeComponent();
            this.TabStop = false;

            // Set the default position for the inventory bar.
            this.Dock = DockStyle.Bottom;
            // Set the default maximum size for the inventory bar.
            MaxBarHeight = 75;
        }

        #endregion

        #region Methods

        private void GrowBar()
        {
            try
            {
                // No reason to do the animation if the bar's height was greater-than or equal to
                // the maximum size. Only do the animation if these two conditions will not be met.
                if (!((this.Height > MaxBarHeight) || (this.Height == MaxBarHeight)))
                {
                    Growing = true;

                    for (int i = this.Height; (i < MaxBarHeight); i++)
                    {
                        if (!Growing || Shrinking)
                            return;

                        this.Invoke(new MethodInvoker(() => { this.Height = i; }));
                        Thread.Sleep(1);
                    }
                }
            }
            finally
            {
                Growing = false;
                Open = true;
            }
        }

        private void ShrinkBar()
        {
            try
            {
                // No reason to do the animation if the bar's height was less-than or equal to
                // the minimum size. Only do the animation if these two conditions will not be met.
                if (!((this.Height < MinBarHeight) || (this.Height == MinBarHeight)))
                {
                    Shrinking = true;

                    for (int i = this.Height; (i > MinBarHeight); i--)
                    {
                        if (!Shrinking || Growing)
                            return;

                        this.Invoke(new MethodInvoker(() => { this.Height = i; }));
                        Thread.Sleep(1);
                    }
                }
            }
            finally
            {
                Shrinking = false;
                Open = false;
            }
        }

        #endregion

        #region Events

        private void CascadingInventoryBar_MouseHover(object sender, EventArgs e)
        {
            if (Shrinking || !Growing && !Open)
            {
                Shrinking = false;

                new Thread(() => GrowBar()).Start();
            }
        }

        private void CascadingInventoryBar_MouseLeave(object sender, EventArgs e)
        {
            if (Growing)
            {
                Thread.Sleep(50);
            }

            if (Growing || (!Shrinking && Open))
            {
                Growing = false;

                new Thread(() => ShrinkBar()).Start();
            }
        }

        #endregion

        #region Properties

        public int MinBarHeight { get; set; }
        public int MaxBarHeight { get; set; }

        #endregion
    }
}