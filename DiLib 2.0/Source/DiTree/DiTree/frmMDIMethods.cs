﻿/*
****************************************************************************************************************************
* DiLib v2.0 (dilib.dimutu.com)
*
* This software is provided 'as-is', without any express or implied warranty. 
* In no event will the authors be held liable for any
* damages arising from the use of this software.
* 
* Permission is granted to anyone to use this software for any
* purpose, including commercial applications, subject to the following restrictions:
* 
* 1. The origin of this software must not be misrepresented; you must
* not claim that you wrote the original software. If you use this
* software in a product, an acknowledgment in the product documentation
* would be appreciated.
*
* 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
* 
* 3. This notice may not be removed or altered from any source distribution.
* 
* 4. Third party open source "TinyXML" is used in this program, and for more information please see its own terms of use.
*******************************************************************************************************************************
*/
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
                        if (n.OpenFile(openFile.FileName))
                        {
                            n.Show();
                            m_recentFileManager.AddRecentFile(openFile.FileName);
                        }
                        else
                        {
                            n = null;
                        }
                        openFile.FileName = "";
                    }
                    else if (zFileExt.CompareTo(DiGlobals.DIEXT_DITREE) == 0)
                    {
                        frmDiTreeView n = new frmDiTreeView();
                        n.MdiParent = this;
                        n.WindowState = FormWindowState.Maximized;
                        if (n.OpenTree(openFile.FileName))
                        {
                            n.Show();
                            m_recentFileManager.AddRecentFile(openFile.FileName);
                        }
                        else
                        {
                            n = null;
                        }
                        openFile.FileName = "";
                    }
                    else if (zFileExt.CompareTo(DiGlobals.DIEXT_DICONFIG) == 0)
                    {
                        frmDiConfigFile n = new frmDiConfigFile();
                        n.MdiParent = this;
                        n.WindowState = FormWindowState.Maximized;
                        if (n.OpenFile(openFile.FileName))
                        {
                            n.Show();
                            m_recentFileManager.AddRecentFile(openFile.FileName);
                        }
                        else
                        {
                            n = null;
                        }
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
            if (a_bSaveAs || frm.FilePath == "")
            {
                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frm.FilePath = saveFile.FileName;
                    saveFile.FileName = "";
                }
                else
                {
                    return false;
                }
            }

            if (frm.FilePath != "")
            {
                frm.SaveFile(frm.FilePath);
                m_recentFileManager.AddRecentFile(frm.FilePath);
            }
            //end if file not blank
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
                        DiMethods.SetStatusMessage(DiLangID.ID_EXPORT_COMPLETE);
                    }
                    else
                    {
                        DiMethods.SetStatusMessage(DiLangID.ID_ERROR_EXPORT_FILE);
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
                            DiMethods.SetStatusMessage(DiLangID.ID_EXPORT_COMPLETE);
                        }
                        else
                        {
                            DiMethods.SetStatusMessage(DiLangID.ID_ERROR_EXPORT_FILE);
                        }
                    }
                }
                
            }
        }

        public void InsertTreeNode(DICLASSTYPES a_eType, frmDiFile a_frmDiFile)
        {
            a_frmDiFile.AddTreeNode(a_eType);
        }

        private void ExportSource()
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

                m_frmExportSource.SetData(f.DataHandler);
                m_frmExportSource.ShowDialog();

            }
        }

        private void ToggleDisableBreakpoints()
        {
            DiGlobals.DisableBreakpoints = !DiGlobals.DisableBreakpoints;
            disableBreakpointsToolStripMenuItem.Checked = DiGlobals.DisableBreakpoints;
        }
    }
}
