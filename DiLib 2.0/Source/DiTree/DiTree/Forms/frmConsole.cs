using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
    public partial class frmConsole : Form
    {
        public frmConsole()
        {
            InitializeComponent();
            txtConsole.Text = "";
        }

        public void addOutputText(string str, bool isDebug = false)
        {
            if (isDebug && DiGlobals.LogDebugInfo)
            {
                txtConsole.Text += str + "\r\n";
            }
            else if (!isDebug)
            {
                txtConsole.Text += str + "\r\n";
            }
        }

        private void copyConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtConsole.SelectedText != "")
            {
                Clipboard.SetText(txtConsole.SelectedText);
            }
        }

        private void clearConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }
    }
}
