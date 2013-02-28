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
        private DiRecentFileManager m_recentFileManager;
        private frmTaskView m_frmTaskView;
        private frmRemoteDebug m_frmRemoteDebug;
        private frmExportSource m_frmExportSource;

        public frmMDI()
        {
            InitializeComponent();
            m_frmSelectTree = new frmSelectExportTree();
            m_frmConsole = new frmConsole();
            m_frmTaskView = new frmTaskView();
            m_frmRemoteDebug = new frmRemoteDebug();
            m_frmExportSource = new frmExportSource();

            DiMethods.StatusMessageLable = toolStripStatusMessage;

            m_recentFileManager = new DiRecentFileManager(this, ref recentFilesToolStripMenuItem, 
                                        ref clearRecentFilesToolStripMenuItem, 
                                        ref emptyRecentFilesToolStripMenuItem,
                                        ref separateRecentToolStripMenuItem);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2)
            {
                List<string> arglist = new List<string>(args);
                arglist.RemoveAt(0);
                args = arglist.ToArray();
            }
            LoadFiles(args); 
            DebugMenuDisplay();
        }

        private void showHelptoolStrip(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menu = (ToolStripMenuItem)sender;
                DiMethods.SetStatusMessage(menu.Tag.ToString());
            }
            else if (sender is ToolStripButton)
            {
                ToolStripButton btn = (ToolStripButton)sender;
                DiMethods.SetStatusMessage(btn.Tag.ToString());
            }
            else if (sender is TrackBar)
            {
                TrackBar track = (TrackBar)sender;
                DiMethods.SetStatusMessage(track.Tag.ToString());
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
                trackBarDebugSpeed.Enabled = false;

                toolStripBtnDebugStart.Text = "Debug";
                toolStripBtnDebugStart.Enabled = false;
                toolStripBtnDebugBreak.Enabled = false;
                toolStripBtnDebugStep.Enabled = false;
                toolStripBtnDebugStop.Enabled = true;
            }
            else if (DiGlobals.IsConnected && !DiGlobals.IsDebugging)
            {
                //connected
                connectToolStripMenuItem.Text = "Continue";
                connectToolStripMenuItem.Enabled = false;
                breakToolStripMenuItem.Enabled = true;
                debugStepToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
                trackBarDebugSpeed.Enabled = true;

                toolStripBtnDebugStart.Enabled = false;
                toolStripBtnDebugStart.Text = "Resume";
                toolStripBtnDebugBreak.Enabled = true;
                toolStripBtnDebugStep.Enabled = false;
                toolStripBtnDebugStop.Enabled = true;
            }
            else if (DiGlobals.IsConnected && DiGlobals.IsDebugging)
            {
                //break
                connectToolStripMenuItem.Enabled = true;
                breakToolStripMenuItem.Enabled = false;
                debugStepToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = true;
                trackBarDebugSpeed.Enabled = false;

                toolStripBtnDebugStart.Enabled = true;
                toolStripBtnDebugBreak.Enabled = false;
                toolStripBtnDebugStep.Enabled = true;
                toolStripBtnDebugStop.Enabled = true;
            }
            else
            {
                connectToolStripMenuItem.Text = "Start Debugging";
                connectToolStripMenuItem.Enabled = true;
                breakToolStripMenuItem.Enabled = false;
                debugStepToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = false;
                trackBarDebugSpeed.Enabled = false;

                toolStripBtnDebugStart.Enabled = true;
                toolStripBtnDebugStart.Text = "Debug";
                toolStripBtnDebugBreak.Enabled = false;
                toolStripBtnDebugStep.Enabled = false;
                toolStripBtnDebugStop.Enabled = false;
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
                DebugDisconnectMainThread();
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
            if (DiGlobals.IsListening)
            {
                DebugStopListenning();
                DiGlobals.IsListening = false;
            }
            else if (DiGlobals.IsConnected)
            {
                m_bIsQutting = true;
                DebugDisconnectMainThread();
            }
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

        private void toolStripBtnDebugStart_Click(object sender, EventArgs e)
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

        private void toolStripBtnDebugStop_Click(object sender, EventArgs e)
        {
            if (DiGlobals.IsListening)
            {
                DebugStopListenning();
                DiGlobals.IsListening = false;
            }
            else if (DiGlobals.IsConnected)
            {
                m_bIsQutting = true;
                DebugDisconnectMainThread();
            }
            DebugMenuDisplay();
        }

        private void toolStripBtnDebugBreak_Click(object sender, EventArgs e)
        {
            DebugPlayPause();
            DebugMenuDisplay();
        }

        private void toolStripBtnDebugStep_Click(object sender, EventArgs e)
        {
            DebugPlayForward();
        }

        private void clearRecentFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_recentFileManager.ClearAll();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDiFile(false);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDiFile(true);
        }

        private void toolStripMainSave_Click(object sender, EventArgs e)
        {
            saveDiFile(false);
        }

        private void outputWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_frmConsole.Show();
        }

        private void tasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiFile frmActive = (frmDiFile)ActiveMdiChild;
            if (frmActive != null)
            {
                frmActive.ProcessData();
                m_frmTaskView.SetData(frmActive.DataHandler);
                m_frmTaskView.ShowDialog();
            }
            else
            {
                DiMethods.MyDialogShow("Need to open a didata file to view the tasks list.", MessageBoxButtons.OK);
            }
        }

        private void trackBarDebugSpeed_Scroll(object sender, EventArgs e)
        {
            DiGlobals.DebugSpeed = trackBarDebugSpeed.Value;
        }

        private void remoteDebuggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if DEBUG
            DialogResult result = m_frmRemoteDebug.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //debug connect to different address
            }
#else
            if (DiMethods.MyDialogShow("This feature will be available in future release." +
             "Do you wish visit DiLIB website to check for new updates?", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("http://www.dilib.dimutu.com/");
            }
#endif
        }

        private void exportCppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportSource();
        }

        private void exportConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportConfig();
        }

        private void exportTreeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportTree();
        }

        private void insertDropDownToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dilib.dimutu.com/documentation/");
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dilib.dimutu.com/");
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if DEBUG

#else
            if (DiMethods.MyDialogShow("This feature will be available in future release." +
             "Do you wish visit DiLIB website to check for new updates?", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("http://www.dilib.dimutu.com/");
            }
#endif
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if DEBUG

#else
            if (DiMethods.MyDialogShow("This feature will be available in future release." +
             "Do you wish visit DiLIB website to check for new updates?", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("http://www.dilib.dimutu.com/");
            }
#endif
        }

    }
}
