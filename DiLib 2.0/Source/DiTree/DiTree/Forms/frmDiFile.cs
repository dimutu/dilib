/*
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

        public const int TABSTART_INDEX = 3; //two tabs will be there always (heders, add new*)
        private string m_zFilePath; //save path


        public frmDiFile()
        {
            InitializeComponent();
            InitializeGeneral();
            AddNewTreeTab();
            tabDiFile.SelectedIndex = 1;
            EnableTabCloseButton();
        }

        /// <summary>
        /// Data Handler
        /// </summary>
        public DiDataHanlder DataHandler
        {
            get
            {
                return m_pkDataHandler;
            }
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
            if (!DiGlobals.IsConnected)
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
            if (e.KeyCode == Keys.Delete)
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

        private void btnAddEnum_Click(object sender, EventArgs e)
        {
            AddEnumToList();
        }

        private void btnRemoveEnum_Click(object sender, EventArgs e)
        {
            if (listReturnEnums.SelectedIndex >= 0)
            {
                listReturnEnums.Items.RemoveAt(listReturnEnums.SelectedIndex);
            }
        }

        private void txtIncludeFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddTextToList();
            }
        }

        private void txtReturnEnum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddEnumToList();
            }
        }

        private void listReturnEnums_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listReturnEnums.SelectedIndex >= 0)
                {
                    int index = listReturnEnums.SelectedIndex;
                    listReturnEnums.Items.RemoveAt(listReturnEnums.SelectedIndex);
                    listReturnEnums.SelectedIndex = --index;
                }
            }
        }

        private void listInclues_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listInclues.SelectedIndex >= 0)
                {
                    int index = listInclues.SelectedIndex;
                    listInclues.Items.RemoveAt(listReturnEnums.SelectedIndex);
                    listInclues.SelectedIndex = --index;
                }
            }
        }
    }
}
