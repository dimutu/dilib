using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DiTree
{
	public partial class frmSplashScreen : Form
	{

		public frmSplashScreen()
		{
			InitializeComponent();
            lblVersion.Text = "Version " + DiUtility.AssemblyVersion;

            var pos = this.PointToScreen(lblVersion.Location);
            pos = pictureBox1.PointToClient(pos);
            lblVersion.Parent = pictureBox1;
            lblVersion.Location = pos;
            lblVersion.BackColor = Color.Transparent;

            pos = this.PointToScreen(lblCopyright.Location);
            pos = pictureBox1.PointToClient(pos);
            lblCopyright.Parent = pictureBox1;
            lblCopyright.Location = pos;
            lblCopyright.BackColor = Color.Transparent;
		}

		private void timerSplash_Tick(object sender, EventArgs e)
		{
			Thread.Sleep(1000);
			this.Close();
		}
	}
}
