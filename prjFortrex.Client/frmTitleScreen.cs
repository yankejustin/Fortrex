using System;
using System.Windows.Forms;

namespace prjFortrex.Client
{
    public partial class frmTitleScreen : Form
    {
        #region Fields

        frmGameWindow gameWindow = new frmGameWindow();

        #endregion

        #region Constructors

        public frmTitleScreen()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            DialogResult GameWindowResult = System.Windows.Forms.DialogResult.OK;
            try
            {
                // Make the game window again if it is null or was disposed.
                if (gameWindow == null || gameWindow.IsDisposed)
                {
                    gameWindow = new frmGameWindow();
                }

                // Hide the title screen from the user.
                this.Hide();
                // Show the game window form as a modal dialog box so it will stop the "finally" block
                //   from executing until the gamewindow has closed.
                GameWindowResult = gameWindow.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Unable to show the game window: " + ex.Message);
            }
            catch (Exception ex)
            {
                // There was a severe or unexpected issue with the game!
                MessageBox.Show("UNEXPECTED ERROR FROM THE GAME WINDOW::" + ex.Message, "CRITICAL ERROR");
                // Tell the finally block to kill the application due to the severe error. An error in the game should be handled internally,
                //   no error should reach here except for the possible "InvalidOperationException" from showing the game window.
                GameWindowResult = System.Windows.Forms.DialogResult.Abort;
            }
            finally
            {
                // After the gamewindow was closed, show the title screen unless the user wanted to exit the application entirely.
                // The game window's method of closing the whole application is to close itself, but returning a "DialogResult" of "DialogResult.Abort".
                if (GameWindowResult == System.Windows.Forms.DialogResult.Abort)
                {
                    // Kill the application.
                    Application.Exit();
                }
                else
                {
                    // If the user did not prompt to fully exit the application, just show the title screen once again.
                    this.Show();
                }
            }
        }

        #endregion
    }
}