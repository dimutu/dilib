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
    public partial class frmTaskView : Form
    {
        private DiDataHanlder m_pkDataHandler;

        public frmTaskView()
        {
            InitializeComponent();
        }

        public void SetData(DiDataHanlder a_pkDataHandler)
        {
            m_pkDataHandler = a_pkDataHandler;
            ShowData();
        }

        private void ShowData()
        {
            DataView dv = m_pkDataHandler.Data.DefaultView;
            dv.RowFilter = DiDataHanlder.DATAFIELD_ISTEMPATE + "=false and " + DiDataHanlder.DATAFIELD_USECOUNT + "<=0" ;
            dataGridViewTasks.DataSource = dv;
         }

        private void dataGridViewTasks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewTasks.Columns[0].Visible = false; //hide id and istemplate 
            dataGridViewTasks.Columns[1].Visible = false;
            dataGridViewTasks.Columns[2].Width = 200;
            dataGridViewTasks.Columns[3].Width = 200;
            dataGridViewTasks.Columns[4].Width = 200;
            dataGridViewTasks.Columns[5].Visible = false;
            foreach (DataGridViewRow row in dataGridViewTasks.Rows)
            {
                if ((int)row.Cells[5].Value <= 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewTasks.SelectedRows)
                {
                    dataGridViewTasks.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            for(int i = dataGridViewTasks.Rows.Count -1; i >= 0; --i)
            {
                row = dataGridViewTasks.Rows[i];
                if ((int)row.Cells[5].Value <= 0)
                {
                    dataGridViewTasks.Rows.RemoveAt(row.Index);
                }
            }
        }

    }
}
