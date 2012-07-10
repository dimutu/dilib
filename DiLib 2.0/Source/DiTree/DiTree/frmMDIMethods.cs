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

        private void openDiFile()
        {
            
        }

        private bool saveDiFile(bool a_bSaveAs)
        {
            if (this.ActiveMdiChild == null)
            {
                return false;
            }
            if ((this.ActiveMdiChild is frmDiFile) == false)
            {
                return false;
            }
            frmDiFile frm = (frmDiFile)this.ActiveMdiChild;

            //show the dialog if not already saved or save as selected
            if (saveFile.FileName == "" || a_bSaveAs)
            {
                if (saveFile.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return false;
                }
            }

            if (saveFile.FileName != "")
            {

                frm.SaveFile(saveFile.FileName);                
            }//end if file not blank
            return false;

        }

    }
}
