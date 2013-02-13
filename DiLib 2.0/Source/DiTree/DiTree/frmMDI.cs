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
            DebugMenuDisplay();
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
            DebugConnect();
            DebugMenuDisplay();
        }

        private void DebugMenuDisplay()
        {

            if (!DiGlobals.IsConnected && DiGlobals.IsListening)//start view or disconnected
            {
                connectToolStripMenuItem.Text = "Start Debugging";
                connectToolStripMenuItem.Enabled = false;
                breakToolStripMenuItem.Enabled = false;
                debugStepToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
            }
            else if (DiGlobals.IsConnected && !DiGlobals.IsDebugging)
            {
                //connected
                connectToolStripMenuItem.Text = "Continue";
                connectToolStripMenuItem.Enabled = false;
                breakToolStripMenuItem.Enabled = true;
                debugStepToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
            }
            else if (DiGlobals.IsConnected && DiGlobals.IsDebugging)
            {
                //break
                connectToolStripMenuItem.Enabled = true;
                breakToolStripMenuItem.Enabled = false;
                debugStepToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = true;
            }
            else
            {
                connectToolStripMenuItem.Text = "Start Debugging";
                connectToolStripMenuItem.Enabled = true;
                breakToolStripMenuItem.Enabled = false;
                debugStepToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = false;
            }
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

        private void debugStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugPlayForward();
        }

        private void breakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugPlayPause();
            DebugMenuDisplay();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DiGlobals.IsListening)
            {
                DebugStopListenning();
            }
            else if (DiGlobals.IsConnected)
            {
                DebugDisconnect();
            }
            DebugMenuDisplay();
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.MoveNode(TREENODEMOVEMENT.TREENODEMOVE_UP);
            }
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.MoveNode(TREENODEMOVEMENT.TREENODEMOVE_DOWN);
            }
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.MoveNode(TREENODEMOVEMENT.TREENODEMOVE_LEFT);
            }
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.MoveNode(TREENODEMOVEMENT.TREENODEMOVE_RIGHT);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.CopyNode();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.CutNode();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.PasteNode();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.RemoveNode();
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiGlobals.LogDebugInfo = !DiGlobals.LogDebugInfo;
            if (DiGlobals.LogDebugInfo)
            {
                logToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                logToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void toggleBreakpointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                DiTreeNode node = frmActive.ToggleBreakpoint();
                if (node != null)
                {
                    m_frmDebugControlForm = frmActive;
                    DebugToggleBreakpoint(node.Task);
                }
            }
        }

        private void deleteAllBreakpointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.RemoveAllBreakpoints();
            }
        }

        
    }
}
