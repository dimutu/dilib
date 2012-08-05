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
    public partial class frmSelectExportTree : Form
    {
        private DataTable m_kDT;
        private int m_iTab;

        public int SelectedValue
        {
            get
            {
                return m_iTab;
            }
        }
        
        public frmSelectExportTree()
        {
            InitializeComponent();
            m_kDT = new DataTable();
            m_kDT.Columns.Add("ID", typeof(int));
            m_kDT.Columns.Add("Name", typeof(string));

            lstTreeList.DataSource = m_kDT;
            lstTreeList.DisplayMember = "Name";
            lstTreeList.ValueMember = "ID";
        }

        private void SetListData(ref frmDiFile form)
        {
            TabPage tp;
            m_kDT.Clear();
            for (int ii = frmDiFile.TABSTART_INDEX; ii < form.Tab.TabCount; ++ii)
            {
                tp = form.Tab.TabPages[ii];
                AddListBoxItem(ii, tp.Text);
            }
        }

        private void AddListBoxItem(int tabid, string tabname)
        {
            DataRow dr = m_kDT.NewRow();

            dr["ID"] = tabid;
            dr["Name"] = tabname;

            m_kDT.Rows.Add(dr);
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (lstTreeList.SelectedItem == null)
            {
                m_iTab = -1;
            }
            else
            {
                m_iTab = (int)lstTreeList.SelectedValue;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lstTreeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lstTreeList.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                m_iTab = (int)lstTreeList.SelectedValue;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }

        /// <summary>
        /// Form containing the tab files which has the trees needs to be exported
        /// </summary>
        public frmDiFile TreeForm
        {
            set
            {
                SetListData(ref value);
            }
        }

        public int SelectedIndex
        {
            get
            {
                return m_iTab;
            }
        }


    }
}
