using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*
 * main file 
 * 
 *
 * 
 */

namespace DiTree
{
    public partial class frmMDI : Form
    {
        
        public frmMDI()
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string[] args = Environment.GetCommandLineArgs();
            LoadFiles(args);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showNewDiFile();
        }


    }
}
