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
		}

		private void timerSplash_Tick(object sender, EventArgs e)
		{
			Thread.Sleep(1000);
			this.Close();
		}
	}
}
