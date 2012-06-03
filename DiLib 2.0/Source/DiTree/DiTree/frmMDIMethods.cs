using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


/*
 * holds the common function use in the form
 * 
 */

namespace DiTree
{
    public partial class frmMDI : Form
    {
        /// <summary>
        /// Creates new instance of Di File form and display
        /// </summary>
        private void showNewDiFile()
        {
            frmDiFile frm = new frmDiFile();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
