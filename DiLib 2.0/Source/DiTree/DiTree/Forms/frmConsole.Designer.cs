namespace DiTree
{
    partial class frmConsole
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
            this.components = new System.ComponentModel.Container();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.contextMenuConsole = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.Window;
            this.txtConsole.ContextMenuStrip = this.contextMenuConsole;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(0, 0);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(657, 363);
            this.txtConsole.TabIndex = 0;
            // 
            // contextMenuConsole
            // 
            this.contextMenuConsole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyConsoleToolStripMenuItem,
            this.clearConsoleToolStripMenuItem});
            this.contextMenuConsole.Name = "contextMenuConsoleClear";
            this.contextMenuConsole.Size = new System.Drawing.Size(103, 48);
            this.contextMenuConsole.Text = "Clear";
            // 
            // copyConsoleToolStripMenuItem
            // 
            this.copyConsoleToolStripMenuItem.Name = "copyConsoleToolStripMenuItem";
            this.copyConsoleToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyConsoleToolStripMenuItem.Text = "Copy";
            this.copyConsoleToolStripMenuItem.Click += new System.EventHandler(this.copyConsoleToolStripMenuItem_Click);
            // 
            // clearConsoleToolStripMenuItem
            // 
            this.clearConsoleToolStripMenuItem.Name = "clearConsoleToolStripMenuItem";
            this.clearConsoleToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.clearConsoleToolStripMenuItem.Text = "Clear";
            this.clearConsoleToolStripMenuItem.Click += new System.EventHandler(this.clearConsoleToolStripMenuItem_Click);
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 363);
            this.Controls.Add(this.txtConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "frmConsole";
            this.ShowInTaskbar = false;
            this.Text = "Console Output";
            this.contextMenuConsole.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.ContextMenuStrip contextMenuConsole;
        private System.Windows.Forms.ToolStripMenuItem clearConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyConsoleToolStripMenuItem;
    }
}