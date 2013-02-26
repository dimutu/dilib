using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DiTree
{
    public partial class frmExportSource : Form
    {
        private DataTable m_pkTable;

        private const string COLUMN_HEADER_FILES = "Headers";
        private const string COLUMN_CPP_FILES = "Cpp";
        private const string COLUMN_EXPORTABLE = "Exportable";

        public frmExportSource()
        {
            InitializeComponent();
            txtPath.Text = Directory.GetCurrentDirectory();
        }

        public void SetData(DiDataHanlder a_pkDataHandler)
        {
            DataColumn dcol;
            m_pkTable = a_pkDataHandler.Data.Copy();
            dcol = new DataColumn(COLUMN_HEADER_FILES, typeof(bool));
            dcol.DefaultValue = false;
            m_pkTable.Columns.Add(dcol);

            dcol = new DataColumn(COLUMN_CPP_FILES, typeof(bool));
            dcol.DefaultValue = false;
            m_pkTable.Columns.Add(dcol);

            dcol = new DataColumn(COLUMN_EXPORTABLE, typeof(bool));
            dcol.DefaultValue = true;
            m_pkTable.Columns.Add(dcol);

            DataRow[] rows = m_pkTable.Select(DiDataHanlder.DATAFIELD_ISTEMPATE + "=true");

            foreach(DataRow dr in rows)
            {
                if ((DICLASSTYPES)dr[DiDataHanlder.DATAFIELD_CLASSTYPE] == DICLASSTYPES.DICLASSTYPE_TASK ||
                    (DICLASSTYPES)dr[DiDataHanlder.DATAFIELD_CLASSTYPE] == DICLASSTYPES.DICLASSTYPE_CONDITION ||
                    (DICLASSTYPES)dr[DiDataHanlder.DATAFIELD_CLASSTYPE] == DICLASSTYPES.DICLASSTYPE_ROOT)
                {
                    dr.BeginEdit();
                    dr[COLUMN_HEADER_FILES] = false;
                    dr[COLUMN_CPP_FILES] = false;
                    dr[COLUMN_EXPORTABLE] = false;
                    dr.AcceptChanges();
                }
            }

            dataGridSource.DataSource = m_pkTable;
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderDlgSource.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                txtPath.Text = folderDlgSource.SelectedPath;
            }
        }

        private void DisposeData()
        {
            if (m_pkTable != null)
            {
                m_pkTable.Dispose();
            }
        }

        private void frmExportSource_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridSource_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 6 && e.ColumnIndex != 7)
            {
                e.Cancel = true;
            }
            else
            {
                DataGridViewRow row = dataGridSource.Rows[e.RowIndex];
                if ((bool)row.Cells[COLUMN_EXPORTABLE].Value == false)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dataGridSource_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridSource.Columns[0].Visible = false;
            dataGridSource.Columns[1].Visible = false;
            dataGridSource.Columns[2].Visible = false;
            dataGridSource.Columns[4].Visible = false;
            dataGridSource.Columns[5].Visible = false;
            dataGridSource.Columns[8].Visible = false;


            DataGridViewRow row;
            for (int irow = 0; irow < dataGridSource.Rows.Count; ++irow)
            {
                row = dataGridSource.Rows[irow];
                if ((bool)row.Cells[DiDataHanlder.DATAFIELD_ISTEMPATE].Value == true)
                {
                    if ((DICLASSTYPES)row.Cells[DiDataHanlder.DATAFIELD_CLASSTYPE].Value == DICLASSTYPES.DICLASSTYPE_CONDITION ||
                        (DICLASSTYPES)row.Cells[DiDataHanlder.DATAFIELD_CLASSTYPE].Value == DICLASSTYPES.DICLASSTYPE_TASK)
                    {
                        row.DefaultCellStyle.BackColor = Color.Tomato;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private void chkHeaders_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridSource.Rows)
            {
                if ((bool)row.Cells[COLUMN_EXPORTABLE].Value)
                {
                    row.Cells[COLUMN_HEADER_FILES].Value = chkHeaders.Checked;
                }
            }
        }

        private void chkCpp_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridSource.Rows)
            {
                if ((bool)row.Cells[COLUMN_EXPORTABLE].Value)
                {
                    row.Cells[COLUMN_CPP_FILES].Value = chkCpp.Checked;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            bool bOK = true;
            try
            {
                int iTotal = GetTotalSelected();
                if (iTotal <= 0)
                {
                    DiMethods.MyDialogShow("Nothing is selected to export. Please select any header and cpp source files to generate.", MessageBoxButtons.OK);
                    return;
                }

                if (txtPath.Text.Substring(txtPath.Text.Length - 1) == "\\")
                {
                    txtPath.Text = txtPath.Text.Substring(txtPath.Text.Length - 1);
                }

                if (!Directory.Exists(txtPath.Text))
                {
                    if (DiMethods.MyDialogShow("Selected folder path not exists, do you wish to create the path?", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
                    {
                        DirectoryInfo di = Directory.CreateDirectory(txtPath.Text);
                    }
                    else
                    {
                        bOK = false;
                    }
                }

                if(bOK)
                {
                    progressExport.Maximum = iTotal;
                    progressExport.Value = 0;
                    progressExport.Visible = true;
                    foreach (DataGridViewRow row in dataGridSource.Rows)
                    {
                        if ((bool)row.Cells[COLUMN_EXPORTABLE].Value)
                        {
                            ExportFile((DICLASSTYPES)row.Cells[DiDataHanlder.DATAFIELD_CLASSTYPE].Value,
                                row.Cells[DiDataHanlder.DATAFIELD_TEMPLATECLASS].Value.ToString(),
                                row.Cells[DiDataHanlder.DATAFIELD_CLASSNAME].Value.ToString(),
                                (bool)row.Cells[COLUMN_HEADER_FILES].Value,
                                (bool)row.Cells[COLUMN_CPP_FILES].Value);
                            progressExport.Value += 1;
                        }
                    }
                    progressExport.Visible = false;
                    DiMethods.MyDialogShow("Source files generated.", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                DiMethods.MyDialogShow("Exporting source files failed. Please make sure path exists and have neccessory permissions.", MessageBoxButtons.OK);
            }
        }

        private void ExportFile(DICLASSTYPES a_eClassType, string a_zTemplateClass, string a_zClassName,
            bool a_bHeader, bool a_bCpp)
        {
            string strDiLIBH = "";
            string strHeader = "";
            string strCpp = "";
            switch (a_eClassType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    strDiLIBH = "DiCondition";
                    strCpp = Properties.Resources.condcpp;
                    break;

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    strDiLIBH = "DiFilter";
                    strCpp = Properties.Resources.filcpp;
                    break;

                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    strDiLIBH = "DiSelection";
                    strCpp = Properties.Resources.selcpp;
                    break;

                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    strDiLIBH = "DiSequence";
                    strCpp = Properties.Resources.seqcpp;
                    break;

                case DICLASSTYPES.DICLASSTYPE_TASK:
                    strDiLIBH = "DiTask";
                    strCpp = Properties.Resources.taskcpp;
                    break;

                default:
                    break;
            }

            StreamWriter sw;

            if (a_bHeader)
            {
                strHeader = Properties.Resources.header;
                strHeader = strHeader.Replace("[DEFINE]", "_" + a_zClassName.ToUpper() + "_");
                strHeader = strHeader.Replace("[DICLASS]", strDiLIBH);
                strHeader = strHeader.Replace("[TEMPLATE]", a_zTemplateClass);
                strHeader = strHeader.Replace("[CLASS]", a_zClassName);

                sw = new StreamWriter(txtPath.Text + "\\" + a_zClassName + ".h");
                sw.Write(strHeader);
                sw.Flush();
                sw.Close();
                sw = null;
            }

            if (strCpp != "" && a_bCpp)
            {
                strCpp = strCpp.Replace("[CLASS]", a_zClassName);
                strCpp = strCpp.Replace("[TEMPLATE]", a_zTemplateClass);
                strCpp = strCpp.Replace("[DICLASS]", strDiLIBH);

                sw = new StreamWriter(txtPath.Text + "\\" + a_zClassName + ".cpp");
                sw.Write(strCpp);
                sw.Flush();
                sw.Close();
                sw = null;
            }
        }

        private int GetTotalSelected()
        {
            int total = 0;
            foreach (DataGridViewRow row in dataGridSource.Rows)
            {
                if ((bool)row.Cells[COLUMN_EXPORTABLE].Value)
                {
                    if ((bool)row.Cells[COLUMN_HEADER_FILES].Value || (bool)row.Cells[COLUMN_CPP_FILES].Value)
                    {
                        ++total;
                    }
                }
            }

            return total;
        }

        private void frmExportSource_Shown(object sender, EventArgs e)
        {
            progressExport.Visible = false;
        }
    }
}
