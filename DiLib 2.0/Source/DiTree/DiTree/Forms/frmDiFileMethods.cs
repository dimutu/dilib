using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

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
            //set default tab
            tabDiFile.SelectedIndex = TABSTART_INDEX - 1;

            //initialize data handler
            m_pkDataHandler = new DiDataHanlder();
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

        /// <summary>
        /// Move the currently selected node in given direction
        /// </summary>
        /// <param name="a_eDirection"></param>
        public void MoveNode(TREENODEMOVEMENT a_eDirection)
        {
        }

        /// <summary>
        /// Select the current node as copying source to the DiClipboard
        /// </summary>
        public void CopyNode()
        {
        }

        /// <summary>
        /// Select the current node as moving source to the DiClipboard
        /// </summary>
        public void CutNode()
        {
        }

        /// <summary>
        /// Paste the currently copied node in the Clipboard to the selected node
        /// </summary>
        public void PasteNode()
        {
        }

        /// <summary>
        /// Remove the currently selected node
        /// </summary>
        public void RemoveNode()
        {

        }

        /// <summary>
        /// Adds new tab page to control
        /// </summary>
        public void AddNewTreeTab()
        {
            int iIndex = tabDiFile.TabCount - TABSTART_INDEX;
            DiTabPage pkTabPage = new DiTabPage(iIndex);

            //set tab page
            tabDiFile.TabPages.Add(pkTabPage);
            tabDiFile.SelectedIndex = tabDiFile.TabCount - 1;
            pkTabPage.Tree.DataHandler = m_pkDataHandler;
            
        }

        /// <summary>
        /// Remove the currently selected tab
        /// </summary>
        public void RemoveTreeTab()
        {
            if (tabDiFile.SelectedIndex < TABSTART_INDEX)
            {
                DiMethods.MyDialogShow("You cannot delete this data.", MessageBoxButtons.OK);
                return;
            }
            if (tabDiFile.TabCount == TABSTART_INDEX)
            {
                DiMethods.MyDialogShow("There are not tree data to remove.", MessageBoxButtons.OK);
                return;
            }

            if (DiMethods.MyDialogShow("Are you sure to delete this data?", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
            {
                int iCurrentTab = tabDiFile.SelectedIndex;
                tabDiFile.SelectedIndex = iCurrentTab - 1;
                tabDiFile.TabPages.RemoveAt(iCurrentTab);
            }
        }

        /// <summary>
        /// Rename selected tab
        /// </summary>
        public void RenameTreeTab()
        {
            if (tabDiFile.SelectedIndex >= TABSTART_INDEX)
            {
                string sTabName = tabDiFile.SelectedTab.Text;
                if (DiMethods.MyInputDialogShow("Rename Tree", ref sTabName) == System.Windows.Forms.DialogResult.OK)
                {
                    bool bExists = false;
                    //check name already exists
                    for (int ii = TABSTART_INDEX; ii < tabDiFile.TabCount; ++ii)
                    {

                        string zValue = tabDiFile.TabPages[ii].Text;
                        if (sTabName.CompareTo(zValue) == 0)
                        {
                            bExists = true;
                            break;
                        }

                    }

                    if (!bExists)
                    {
                        tabDiFile.SelectedTab.Text = sTabName;
                        DiTabPage pkTabPage = (DiTabPage)tabDiFile.SelectedTab;

                        if (pkTabPage.Tree != null)
                        {
                            DiTree pkTree = (DiTree)pkTabPage.Tree;
                            pkTree.TreeName = sTabName;
                        }
                    }
                    else
                    {
                        DiMethods.MyDialogShow("Tree named " + sTabName + " already exists.", MessageBoxButtons.OK);
                    }


                }
            }
        }

        public void SaveFile(string a_zFilePath)
        {
            try
            {
                m_zFilePath = a_zFilePath;
               
                XmlWriter writer;
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;

                string zTempFile = Path.GetTempFileName();

                using (writer = XmlWriter.Create(zTempFile, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(DiXMLElements.XMLELEMENT_TREEROOT);

                    //start di config data
                    writer.WriteStartElement(DiXMLElements.XMLELEMENT_CONFIG);

                    //write debug identifier
                    writer.WriteElementString(DiXMLElements.XMLELEMENT_DEBUGID, txtDebugID.Text);

                    //header files
                    writer.WriteStartElement(DiXMLElements.XMLELEMENT_HEADERFILELIST);
                    writer.WriteAttributeString(DiXMLElements.XMLELEMENT_HEADERFIECOUNT, listInclues.Items.Count.ToString());

                    //add header files
                    for (int ii = 0; ii < listInclues.Items.Count; ++ii)
                    {
                        writer.WriteStartElement(DiXMLElements.XMLELEMENT_HEADERFILE);
                        writer.WriteAttributeString(DiXMLElements.XMLELEMENT_HEADERFILENAME, listInclues.Items[ii].ToString());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement(); //header files

                    //add enums
                    m_pkDataHandler.WriteXMLData(ref writer);

                    writer.WriteEndElement();//end di config

                    //export trees
                    if (tabDiFile.TabCount > TABSTART_INDEX)
                    {
                        int iTreeTabs = tabDiFile.TabCount - TABSTART_INDEX;
                        writer.WriteStartElement(DiXMLElements.XMLELEMENT_ROOTNODES);
                        writer.WriteAttributeString("Count", iTreeTabs.ToString());

                        for (int ii = TABSTART_INDEX; ii < tabDiFile.TabCount; ++ii)
                        {
                            foreach (Control ctrl in tabDiFile.TabPages[ii].Controls)
                            {
                                if (ctrl.GetType() == typeof(DiTree))
                                {
                                    DiTree pkTree = (DiTree)ctrl;
                                    pkTree.SaveTree(ref writer);
                                    break;
                                }
                            }
                        }

                        writer.WriteEndElement(); //end root nodes
                    }

                    writer.WriteEndElement(); //end tree root
                    writer.WriteEndDocument();
                }//end using

                //all done without errors
                File.Copy(zTempFile, a_zFilePath, true);

            }
            catch (Exception ex)
            {
                DiMethods.SetErrorLog(ex);
                DiMethods.SetStatusMessage("Error saving file.");
                DiMethods.MyDialogShow("Unable to save file, make sure the file is not read-only.", MessageBoxButtons.OK);
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
            }
        }
    }
}
