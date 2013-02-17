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
            m_frmConsole = new frmConsole();
            DiMethods.StatusMessageLable = toolStripStatusMessage;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string[] args = Environment.GetCommandLineArgs();
            LoadFiles(args); 
            DebugMenuDisplay();
        }

        private void showHelptoolStrip(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menu = (ToolStripMenuItem)sender;
                DiMethods.StatusMessageLable = toolStripStatusMessage;
                DiMethods.SetStatusMessage(menu.Tag.ToString());
            }
            else if (sender is ToolStripButton)
            {
                ToolStripButton btn = (ToolStripButton)sender;
                DiMethods.StatusMessageLable = toolStripStatusMessage;
                DiMethods.SetStatusMessage(btn.Tag.ToString());
            }
        }

        private void hideHelptoolStrip(object sender, EventArgs e)
        {
            DiMethods.StatusMessageLable = toolStripStatusMessage;
            DiMethods.SetStatusMessage(DiLangID.ID_EMPTY);
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
            if (!DiGlobals.IsConnected)
            {
                //connect
                DebugConnect();
            }
            else if (DiGlobals.IsDebugging)
            {
                //continue
                DebugPlayPause();
            }
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
                DiGlobals.IsListening = false;
            }
            else if (DiGlobals.IsConnected)
            {
                m_bIsQutting = true;
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

        private void toggleBreakpointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.ToggleBreakpoint();
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

        private void frmMDI_MdiChildActivate(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                m_frmDebugControlForm = frmActive;
            }
        }

        private void frmMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_bIsQutting = true;
            DebugDisconnect();
        }

        private void frmMDI_DragEnter(object sender, DragEventArgs e)
        {
            FileDragEnter(sender, e);
        }

        private void frmMDI_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //open each file
            foreach (string file in files)
            {
                OpenFile(file);
            }
        }

        private void logToConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiGlobals.LogDebugInfo = !DiGlobals.LogDebugInfo;
           logToConsoleToolStripMenuItem.Checked = DiGlobals.LogDebugInfo;
        }

        private void renameTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.RenameTreeTab();
            }
        }

        private void deleteTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.RemoveTreeTab();
            }
        }

        private void deleteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.RemoveNode();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmActive = this.ActiveMdiChild;
            if (frmActive != null)
            {
                if (frmActive is frmDiFile)
                {
                    frmDiFile fdi = (frmDiFile)frmActive;
                    fdi.Print(false);
                }
                else if (frmActive is frmDiTreeView)
                {
                    frmDiTreeView ftree = (frmDiTreeView)frmActive;
                    ftree.Print(false);
                }
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmActive = this.ActiveMdiChild;
            if (frmActive != null)
            {
                if (frmActive is frmDiFile)
                {
                    frmDiFile fdi = (frmDiFile)frmActive;
                    fdi.Print(true);
                }
                else if (frmActive is frmDiTreeView)
                {
                    frmDiTreeView ftree = (frmDiTreeView)frmActive;
                    ftree.Print(true);
                }
            }
        }

        private void treeInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.AddNewTreeTab(true);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void taskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                InsertTreeNode(DICLASSTYPES.DICLASSTYPE_TASK, frmActive);
            }
        }

        private void conditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                InsertTreeNode(DICLASSTYPES.DICLASSTYPE_CONDITION, frmActive);
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                InsertTreeNode(DICLASSTYPES.DICLASSTYPE_FILTER, frmActive);
            }
        }

        private void sequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                InsertTreeNode(DICLASSTYPES.DICLASSTYPE_SEQUENCE, frmActive);
            }
        }

        private void selectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                InsertTreeNode(DICLASSTYPES.DICLASSTYPE_SELECTION, frmActive);
            }
        }

        private void insertTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                InsertTreeNode(DICLASSTYPES.DICLASSTYPE_TASK, frmActive);
            }
        }

        private void insertConditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                InsertTreeNode(DICLASSTYPES.DICLASSTYPE_CONDITION, frmActive);
            }
        }

        private void insertSequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                InsertTreeNode(DICLASSTYPES.DICLASSTYPE_SEQUENCE, frmActive);
            }
        }

        private void insertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                InsertTreeNode(DICLASSTYPES.DICLASSTYPE_SELECTION, frmActive);
            }
        }

        private void insertFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                InsertTreeNode(DICLASSTYPES.DICLASSTYPE_FILTER, frmActive);
            }
        }

        private void insertTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)this.ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.AddNewTreeTab(true);
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
