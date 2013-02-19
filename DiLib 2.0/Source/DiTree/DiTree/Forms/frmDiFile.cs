using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
    public partial class frmDiFile : Form
    {
        //data handler for the file
        private DiDataHanlder m_pkDataHandler;

        public const int TABSTART_INDEX = 2; //two tabs will be there always (heders, add new*)
        private string m_zFilePath; //save path


        public frmDiFile()
        {
            InitializeComponent();
            InitializeGeneral();
            EnableTabCloseButton();
        }

        private void btnAddInclude_Click(object sender, EventArgs e)
        {
            AddTextToList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listInclues.SelectedIndex >= 0)
            {
                listInclues.Items.RemoveAt(listInclues.SelectedIndex);
            }
        }

        private void tabDiFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check add new tab selected
            if (tabDiFile.SelectedIndex == 0) //first tab, add new clicked, create new tab and focus
            {
                AddNewTreeTab();
            }
            EnableTabCloseButton();
        }

        public string FilePath
        {
            get
            {
                return m_zFilePath;
            }
            set
            {
                m_zFilePath = value;
            }
        }

        /// <summary>
        /// Access the tab control uses for set the exporting tree list
        /// </summary>
        public TabControl Tab
        {
            get
            {
                return tabDiFile;
            }
        }

        public string DebugID
        {
            get
            {
                return txtDebugID.Text;
            }
        }

        public void Print(bool a_bIsPreview)
        {
            if (tabDiFile.SelectedIndex >= TABSTART_INDEX)
            {
                if (tabDiFile.SelectedTab != null)
                {
                    DiTabPage pkTabPage = (DiTabPage)tabDiFile.SelectedTab;
                    pkTabPage.Tree.Print(a_bIsPreview);
                }
            }
        }

        private void btnCloseTab_Click(object sender, EventArgs e)
        {
            if (tabDiFile.SelectedIndex >= TABSTART_INDEX)
            {
                if (tabDiFile.SelectedTab != null)
                {
                    DiTabPage pkTabPage = (DiTabPage)tabDiFile.SelectedTab;
                    RemoveTreeTab();
                }
            }
        }

        private void btnCloseTab_MouseHover(object sender, EventArgs e)
        {
            toolTipHelp.SetToolTip(btnCloseTab, Properties.Resources.ID_DELETE_TREE);
        }

        private void EnableTabCloseButton()
        {
            if (tabDiFile.SelectedIndex >= TABSTART_INDEX)
            {
                btnCloseTab.Enabled = true;
            }
            else
            {
                btnCloseTab.Enabled = false;
            }
        }

        private void frmDiFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabDiFile.SelectedIndex >= TABSTART_INDEX)
            {
                if (tabDiFile.SelectedTab != null)
                {
                    DiTabPage pkTabPage = (DiTabPage)tabDiFile.SelectedTab;
                    pkTabPage.Tree.RemoveNode();
                }
            }
        }
    }
}
