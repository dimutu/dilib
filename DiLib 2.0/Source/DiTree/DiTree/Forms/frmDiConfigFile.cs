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
    public partial class frmDiConfigFile : Form
    {
        public frmDiConfigFile()
        {
            InitializeComponent();
        }

        public void OpenFile(string filename)
        {
            try
            {
                Text = Path.GetFileName(filename);
                StreamReader sr = new StreamReader(filename);
                string sLine = "";
                bool bSkipLine = true;

                while ((sLine = sr.ReadLine()) != null)
                {
                    if (bSkipLine)
                    {
                        bSkipLine = false;
                    }
                    else
                    {
                        rtxtConfig.Text += sLine + "\n";
                    }
                }


            }
            catch (Exception e)
            {
                DiMethods.SetErrorLog(e);
                DiMethods.SetStatusMessage("Error loading file.");
                DiMethods.MyDialogShow("Unable to load config file.", MessageBoxButtons.OK);
                Console.Write(e.Message.ToString());
            }
        }
    }
}
