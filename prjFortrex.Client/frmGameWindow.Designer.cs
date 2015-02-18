namespace prjFortrex.Client
{
    partial class frmGameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                player.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InventoryBar = new prjFortrex.Client.GUI.CascadingInventoryBar();
            this.SuspendLayout();
            // 
            // InventoryBar
            // 
            this.InventoryBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InventoryBar.BackColor = System.Drawing.Color.SaddleBrown;
            this.InventoryBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InventoryBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.InventoryBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InventoryBar.Location = new System.Drawing.Point(0, 414);
            this.InventoryBar.Name = "InventoryBar";
            this.InventoryBar.Size = new System.Drawing.Size(600, 30);
            this.InventoryBar.TabIndex = 0;
            this.InventoryBar.TabStop = false;
            // 
            // frmGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 444);
            this.Controls.Add(this.InventoryBar);
            this.Name = "frmGameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fortrex";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.CascadingInventoryBar InventoryBar;
    }
}