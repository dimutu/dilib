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
                        frmDiTreeView n = new frmDiTreeView();
                        n.MdiParent = this;
                        n.WindowState = FormWindowState.Maximized;
                        n.OpenTree(openFile.FileName);
                        n.Show();
                        openFile.FileName = "";
                    }
                    else if (zFileExt.CompareTo(DiGlobals.DIEXT_DICONFIG) == 0)
                    {
                        frmDiConfigFile n = new frmDiConfigFile();
                        n.MdiParent = this;
                        n.WindowState = FormWindowState.Maximized;
                        n.OpenFile(openFile.FileName);
                        n.Show();
                        openFile.FileName = "";
                    }
                }
            }
        }

        /// <summary>
        /// Save currently active data
        /// </summary>
        /// <param name="a_bSaveAs"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Export configuration file of active didata form
        /// </summary>
        private void ExportConfig()
        {
            Form frmActive = this.ActiveMdiChild;

            if (frmActive == null)
            {
                return;
            }

            //there is active file to export
            if (frmActive.GetType() == typeof(frmDiFile))
            {
                saveConfigFile.FileName = "";
                //find a path and file to save
                if (saveConfigFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //active window is enum id, save that
                    frmDiFile f = (frmDiFile)frmActive;
                    if (f.ExportConfig(saveConfigFile.FileName))
                    {
                        DiMethods.SetStatusMessage("Export completed.");
                    }
                    else
                    {
                        DiMethods.SetStatusMessage("Export failed.");
                    }
                }
            }
        }

        /// <summary>
        /// Export tree file of active didata form
        /// </summary>
        private void ExportTree()
        {
            Form frmActive = this.ActiveMdiChild;

            if (frmActive == null)
            {
                return;
            }

            if (frmActive.GetType() == typeof(frmDiFile))
            {
                //active window is enum id, save that
                frmDiFile f = (frmDiFile)frmActive;

                //show the select tree from the active form
                m_frmSelectTree.TreeForm = f;
                saveTreeFile.FileName = ""; //reset last file
                if (m_frmSelectTree.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //now get the path to save
                    if (saveTreeFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (f.ExportTree(saveTreeFile.FileName, m_frmSelectTree.SelectedIndex))
                        {
                            DiMethods.SetStatusMessage("Export completed.");
                        }
                        else
                        {
                            DiMethods.SetStatusMessage("Export failed.");
                        }
                    }
                }
                
            }
        }
    }
}
