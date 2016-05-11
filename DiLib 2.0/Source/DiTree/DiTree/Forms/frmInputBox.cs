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
    public partial class frmInputBox : Form
    {

        public frmInputBox()
        {
            InitializeComponent();
        }

        public string InputText
        {
            get
            {
                return txtValue.Text;
            }
            set
            {
                txtValue.Text = value;
                txtValue.Focus();
            }
        }

        public int TextMaxLength
        {
            set
            {
                txtValue.MaxLength = value;
            }
        }

        public string Title
        {
            set
            {
                this.Text = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            //select current text
            txtValue.Focus();
            txtValue.SelectAll();
        }

    }
}
