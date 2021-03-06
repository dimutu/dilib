﻿/*
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
