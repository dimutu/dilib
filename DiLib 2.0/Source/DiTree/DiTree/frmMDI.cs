﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*
 * main file 
 * 
 */

namespace DiTree
{
    public partial class frmMDI : Form
    {
        
        public frmMDI()
        {
            DiMethods.StatusMessageLable = toolStripStatusMsg;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string[] args = Environment.GetCommandLineArgs();
            LoadFiles(args);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showNewDiFile();
        }

        private void toolStripMainNew_Click(object sender, EventArgs e)
        {
            showNewDiFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDiFile();
        }

        private void toolStripMainSave_Click(object sender, EventArgs e)
        {
            saveDiFile(false);
        }

        private void toolStripMainOpen_Click(object sender, EventArgs e)
        {
            openDiFile();
        }

        private void toolStripMainExportConfig_Click(object sender, EventArgs e)
        {
            ExportConfig();
        }


    }
}
