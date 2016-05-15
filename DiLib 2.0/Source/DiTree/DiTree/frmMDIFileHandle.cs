/*
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
        /// <summary>
        /// Initialize the file handling control properties
        /// </summary>
        private void InitializeFileHandler()
        {
            //open file filters
            openFile.Filter = "Di Data File (*.didata)|*.didata|" +
                    "Di Tree View Files (*.ditree)|*.ditree|Di Config Files (*.diconfig)|*.diconfig|" +
                    "All Files (*.didata, *.ditree, *.diconfig)|*.didata;*.ditree;*.diconfig";

            //main save file saving only DiData
            saveFile.Filter = "Di Tree Data File (*.didata)|*.didata";

            //exporting configuration filter
            saveConfigFile.Filter = "Di Config File (*.diconfig)|*.diconfig";

            //exporting tree
            saveTreeFile.Filter = "Di Tree File (*.ditree)|*.ditree";
        }

        /// <summary>
        /// Load the files from command line argument list
        /// </summary>
        /// <param name="a_azFiles"></param>
        public void LoadFiles(string[] a_azFiles = null)
        {
            string zFile = "";
            int iCounter = 0;
            
            InitializeFileHandler();
            
            if (a_azFiles != null)
            {
                for (iCounter = 0; iCounter < a_azFiles.Length; ++iCounter)
                {
                    zFile = a_azFiles[iCounter];
                    OpenFile(zFile);
                }
            }
        }
       
        /// <summary>
        /// Open given file name with path according to its file extension
        /// </summary>
        /// <param name="a_zFileName">File to open</param>
        public void OpenFile(string a_zFileName)
        {

            string zFileExt = Path.GetExtension(a_zFileName);
            if (zFileExt.CompareTo(".didata") == 0)
            {
                frmDiFile n = new frmDiFile();
                n.MdiParent = this;
                n.WindowState = FormWindowState.Maximized;
                if (n.OpenFile(a_zFileName))
                {
                    n.Show();
                }
                else
                {
                    n = null;
                }
            }
            else if (zFileExt.CompareTo(".ditree") == 0)
            {
                frmDiTreeView n = new frmDiTreeView();
                n.MdiParent = this;
                n.WindowState = FormWindowState.Maximized;
                if (n.OpenTree(a_zFileName))
                {
                    n.Show();
                }
                else
                {
                    n = null;
                }
            }
            else if (zFileExt.CompareTo(".diconfig") == 0)
            {
                frmDiConfigFile n = new frmDiConfigFile();
                n.MdiParent = this;
                n.WindowState = FormWindowState.Maximized;
                if (n.OpenFile(a_zFileName))
                {
                    n.Show();
                }
                else
                {
                    n = null;
                }
            }

        }

        private void FileDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                //check file extention
                string[] fileExt = (string[])e.Data.GetData(DataFormats.FileDrop);
                bool bFilesGood = true;

                foreach (string file in fileExt)
                {
                    if (Path.GetExtension(file).CompareTo(".didata") != 0
                                && Path.GetExtension(file).CompareTo(".ditree") != 0
                                && Path.GetExtension(file).CompareTo(".diconfig") != 0)
                    {
                        bFilesGood = false;
                        break;
                    }
                }

                if (bFilesGood)
                {
                    e.Effect = DragDropEffects.All;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }
    }
}
