using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace DiTree
{
    public partial class frmRemoteDebug : Form
    {
        public frmRemoteDebug()
        {
            InitializeComponent();
        }

        public string IPAddress
        {
            get
            {
                return txtIPAddress.Text;
            }
        }

        public string Port
        {
            get
            {
                return txtPort.Text;
            }
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            IPAddress adr;
            string strAddress = txtIPAddress.Text + ":" + txtPort.Text;
            if (!System.Net.IPAddress.TryParse(txtIPAddress.Text, out adr))
            {
                DiMethods.MyDialogShow("Invalid IPv4 address or port number", MessageBoxButtons.OK);
                return;
            }
            else if (adr.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
            {
                DiMethods.MyDialogShow("Please provide IPv4 address.", MessageBoxButtons.OK);
                return;
            }
            Hide();
        }
    }
}
