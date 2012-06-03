using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

/*
 * handle the file system functions, from open/close files to export files
 * drag drop to open with on files
 * 
 */

namespace DiTree
{
    public partial class frmMDI : Form
    {
        private void InitializeFileHandler()
        {
            openFile.Filter = "Di Tree Data File (*.didata)|*.didata|" +
                    "Di Tree View Files (*.ditree)|*.ditree|Di Config Files (*.diconfig)|*.diconfig|" +
                    "All Files (*.didata, *.ditree, *.diconfig)|*.didata;*.ditree;*.diconfig";
        }

        /// <summary>
        /// Load the files from command line argument list
        /// </summary>
        /// <param name="a_azFiles"></param>
        public void LoadFiles(string[] a_azFiles = null)
        {
            string zFile = "";
            int iCounter = 0;
            InitializeComponent();
            InitializeFileHandler();

            if (a_azFiles != null)
            {
                for (iCounter = 0; iCounter < a_azFiles.Length; ++iCounter)
                {
                    OpenFile(zFile);
                }
            }
        }
       
        /// <summary>
        /// Open given file name with path according to its file extension
        /// </summary>
        /// <param name="a_zFileName">File to open</param>
        private void OpenFile(string a_zFileName)
        {

            string zFileExt = Path.GetExtension(a_zFileName);
            if (zFileExt.CompareTo(".didata") == 0)
            {
                /*
                frmDiTreeData n = new frmDiTreeData();
                n.MdiParent = this;
                n.WindowState = FormWindowState.Maximized;
                n.OpenTree(a_zFileName);
                n.Show();
                openFileTreeData.FileName = "";
                 * */
            }
            else if (zFileExt.CompareTo(".ditree") == 0)
            {
                /*
                frmTreeViewer n = new frmTreeViewer();
                n.MdiParent = this;
                n.WindowState = FormWindowState.Maximized;
                n.OpenTree(a_zFileName);
                n.Show();
                openFileTreeData.FileName = "";
                 */
            }
            else if (zFileExt.CompareTo(".diconfig") == 0)
            {
                /*
                frmConfigViewer n = new frmConfigViewer();
                n.MdiParent = this;
                n.WindowState = FormWindowState.Maximized;
                n.OpenConfig(a_zFileName);
                n.Show();
                openFileTreeData.FileName = "";
                 */
            }

        }
    }
}
