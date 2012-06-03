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
        private const int TABSTART_INDEX = 2; //two tabs will be there always (heders, add new*)

        public frmDiFile()
        {
            InitializeComponent();
            InitializeGeneral();

            //test
            TabPage t = tabDiFile.TabPages[2];
            DiTree tr = new DiTree();
            tr.Parent = t;
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
    }
}
