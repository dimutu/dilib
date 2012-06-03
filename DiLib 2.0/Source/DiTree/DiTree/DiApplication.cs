using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;

namespace DiTree
{
    class DiApplication : WindowsFormsApplicationBase
    {
        public DiApplication()
        {
            IsSingleInstance = true;

            StartupNextInstance += onNextInstance;
        }
 
        void onNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            frmMDI frmApp = MainForm as frmMDI;
            frmApp.LoadFiles(e.CommandLine.ToArray());
        }
 
        protected override void OnCreateMainForm()
        {
            MainForm = new frmMDI();
        }
    }
}
