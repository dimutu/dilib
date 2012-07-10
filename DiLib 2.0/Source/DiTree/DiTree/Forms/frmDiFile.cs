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

        private const int TABSTART_INDEX = 2; //two tabs will be there always (heders, add new*)
        private string m_zFilePath; //save path

        public frmDiFile()
        {
            InitializeComponent();
            InitializeGeneral();
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

    }
}
