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
 */

namespace DiTree
{
    public partial class frmMDI : Form
    {
        private frmConsole m_frmConsole;
        private frmSelectExportTree m_frmSelectTree; //select tree fro exporting the tree from currently selected frmDiFile
        public frmMDI()
        {
            m_frmSelectTree = new frmSelectExportTree();
            DiMethods.StatusMessageLable = toolStripStatusMsg;

            m_frmConsole = new frmConsole();
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

        private void toolStripMainNew_Click(object sender, EventArgs e)
        {
            showNewDiFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDiFile();
        }

        private void toolStripMainSave_Click(object sender, EventArgs e)
        {
            saveDiFile(false);
        }

        private void toolStripMainOpen_Click(object sender, EventArgs e)
        {
            openDiFile();
        }

        private void toolStripMainExportConfig_Click(object sender, EventArgs e)
        {
            ExportConfig();
        }

        private void toolStripMainExportTree_Click(object sender, EventArgs e)
        {
            ExportTree();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiGlobals.IsConnected = true;
            DebugConnect();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != null)
                {
                    frm.Dispose();
                }
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frmActive = this.ActiveMdiChild;

            if (frmActive != null)
            {
                frmActive.Dispose();
            }
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_frmConsole.Show();
        }


    }
}
