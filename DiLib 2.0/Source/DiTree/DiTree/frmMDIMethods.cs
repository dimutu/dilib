using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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

        /// <summary>
        /// Open file from storage
        /// </summary>
        private void openDiFile()
        {
            //open new di file
            DialogResult dr = openFile.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                if (openFile.FileName != "")
                {
                    string zFileExt = Path.GetExtension(openFile.FileName);
                    zFileExt = zFileExt.Replace(".", "");
                    if (zFileExt.CompareTo(DiGlobals.DIEXT_DIDATA) == 0)
                    {
                        frmDiFile n = new frmDiFile();
                        n.MdiParent = this;
                        n.WindowState = FormWindowState.Maximized;
                        n.OpenFile(openFile.FileName);
                        n.Show();
                        openFile.FileName = "";
                    }
                    else if (zFileExt.CompareTo(DiGlobals.DIEXT_DITREE) == 0)
                    {
                       /* frmTreeViewer n = new frmTreeViewer();
                        n.MdiParent = this;
                        n.WindowState = FormWindowState.Maximized;
                        n.OpenTree(openFileTreeData.FileName);
                        n.Show();
                        openFileTreeData.FileName = "";*/
                    }
                    else if (zFileExt.CompareTo(DiGlobals.DIEXT_DICONFIG) == 0)
                    {
                        /*frmConfigViewer n = new frmConfigViewer();
                        n.MdiParent = this;
                        n.WindowState = FormWindowState.Maximized;
                        n.OpenConfig(openFileTreeData.FileName);
                        n.Show();
                        openFileTreeData.FileName = "";*/
                    }
                }
            }
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
