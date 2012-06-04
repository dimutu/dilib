using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

/*
 * holds the functions for the form
 * 
 */
namespace DiTree
{
    public partial class frmDiFile : Form
    {
        /// <summary>
        /// Initialize the general tab 
        /// </summary>
        private void InitializeGeneral()
        {
            txtDebugID.Text = DiMethods.GenerateRandomString();
            txtIncludeFile.Text = "";
            listInclues.Items.Clear();
        }

        

        /// <summary>
        /// Adds text in the include to the list
        /// </summary>
        private void AddTextToList()
        {
            if (txtIncludeFile.Text.Length > 0)
            {
                string s = txtIncludeFile.Text.Substring(txtIncludeFile.Text.Length - 2);
                //add header extension if not entered
                if (s.ToLower() != ".h")
                {
                    txtIncludeFile.Text = txtIncludeFile.Text + ".h";
                }

                listInclues.Items.Add(txtIncludeFile.Text);
                txtIncludeFile.Text = "";
                txtIncludeFile.Focus();
            }
        }

        public void StartDrag(DICLASSTYPES a_eTaskType, DragDropEffects a_eEffect)
        {
            Console.WriteLine("here");
        }
    }
}
