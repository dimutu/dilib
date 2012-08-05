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

        /// <summary>
        /// Save all the data into the file path
        /// </summary>
        /// <param name="a_zFilePath"></param>
        public void SaveFile(string a_zFilePath)
        {
            //try
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
                        writer.WriteAttributeString(DiXMLElements.XMLELEMENT_ROOTNODE_COUNT, iTreeTabs.ToString());
                        
                        for (int ii = TABSTART_INDEX; ii < tabDiFile.TabCount; ++ii)
                        {
                            foreach (Control ctrl in tabDiFile.TabPages[ii].Controls)
                            {
                                if (ctrl.GetType() == typeof(DiTree))
                                {
                                    DiTree pkTree = (DiTree)ctrl;
                                    pkTree.SaveTree(ref writer); //export individual tree
                                    break;
                                }
                            }
                        }

                        writer.WriteEndElement(); //end root nodes all
                    }

                    writer.WriteEndElement(); //end tree root
                    writer.WriteEndDocument();
                }//end using

                //all done without errors
                File.Copy(zTempFile, a_zFilePath, true);

            }
//            catch (Exception ex)
//            {
//                DiMethods.SetErrorLog(ex);
//                DiMethods.SetStatusMessage("Error saving file.");
//                DiMethods.MyDialogShow("Unable to save file, make sure the file is not read-only.", MessageBoxButtons.OK);
//#if DEBUG
//                Console.WriteLine(ex.Message);
//#endif
//            }
        }

        /// <summary>
        /// Open the tree data in the file path
        /// </summary>
        /// <param name="a_zFilePath"></param>
        public void OpenFile(string a_zFilePath)
        {
            try
            {
                XmlReader reader = XmlReader.Create(a_zFilePath);

                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case DiXMLElements.XMLELEMENT_CONFIG:
                            {
                                if (reader.NodeType != XmlNodeType.EndElement)
                                {
                                    LoadConfiguration(ref reader);
                                }
                                break;
                            }


                        case DiXMLElements.XMLELEMENT_ROOT:
                            {
                                if (reader.NodeType != XmlNodeType.EndElement)
                                {
                                    LoadTree(ref reader);
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }

                reader.Close();
                //saveFileExportTree.FileName = filename;
                //saveFileDiDataTree.FileName = filename;
                this.Text = System.IO.Path.GetFileName(a_zFilePath);
            }
            catch (Exception e)
            {
                DiMethods.SetErrorLog(e);
                DiMethods.SetStatusMessage("Error loading file.");
                DiMethods.MyDialogShow("Unable to open file. Please check the file you are trying to open is valid.", MessageBoxButtons.OK);
#if DEBUG
                Console.WriteLine(e.Message.ToString());
#endif
            }
        }

        /// <summary>
        /// Loads Configuration data from xml reader
        /// </summary>
        /// <param name="reader"></param>
        private void LoadConfiguration(ref XmlReader reader)
        {
            try
            {
                //check both has red or not
                bool bHeaderRead = false;
                bool bEnumRead = false;

                //generate string to initialize, if data file has one, it will replace this :)
                txtDebugID.Text = DiMethods.GenerateRandomString();

                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case DiXMLElements.XMLELEMENT_DEBUGID:
                            {
                                txtDebugID.Text = reader.ReadString();
                                break;
                            }
                        case DiXMLElements.XMLELEMENT_HEADERFILELIST:
                            {
                                //set total header files in the list
                                if (reader.NodeType == XmlNodeType.EndElement)
                                {
                                    bHeaderRead = true;
                                }
                                else
                                {
                                    //check count is not zer0, and if it is set hedaer read to true
                                    int iHeaderCount = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_HEADERFIECOUNT].ToString().Trim());
                                    if (iHeaderCount == 0)
                                    {
                                        bHeaderRead = true;
                                    }
                                }

                                break;
                            }
                        case DiXMLElements.XMLELEMENT_HEADERFILE:
                            {
                                listInclues.Items.Add(reader[DiXMLElements.XMLELEMENT_HEADERFILENAME].ToString());
                                break;
                            }
                        case DiXMLElements.XMLELEMENT_ENUMLIST:
                            {
                                m_pkDataHandler.ReadXMLData(ref reader);
                                if (reader.NodeType == XmlNodeType.EndElement)
                                {
                                    bEnumRead = true;
                                    //iEMax = Convert.ToInt32(reader["Count"].ToString());
                                }
                                break;
                            }
                        
                        default:
                            break;
                    }

                    if (bHeaderRead && bEnumRead)
                    {
                        //all the data has been red
                        return;
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

        /// <summary>
        /// Load the tree data from xml reader
        /// </summary>
        /// <param name="reader"></param>
        private void LoadTree(ref XmlReader reader)
        {
            //create new tab
            DiTabPage pkTabPage = null;
            int iCount = tabDiFile.TabCount - TABSTART_INDEX;
            string sTabName = "";

            if (reader[DiXMLElements.XMLELEMENT_ROOTDEBUGID] != null)
            {
                sTabName = reader[DiXMLElements.XMLELEMENT_ROOTDEBUGID].ToString();
            }
            else
            {
                sTabName = "Tree " + iCount.ToString();

            }

            pkTabPage = new DiTabPage(iCount);
            pkTabPage.Text = sTabName;

            pkTabPage.Tree.DataHandler = m_pkDataHandler;

            tabDiFile.TabPages.Add(pkTabPage);
            
            pkTabPage.Tree.OpenTree(ref reader);

        }

        /// <summary>
        /// Export configuration data of the this data file
        /// </summary>
        /// <returns></returns>
        public bool ExportConfig(string a_zFilePath)
        {
            //validate data first
            if (!m_pkDataHandler.IsConfigValid())
            {
                DiMethods.MyDialogShow("Cannot save config file, please check all the data fields are filled and valid.", MessageBoxButtons.OK);
                return false;
            }

            //open writer
            System.IO.StreamWriter kWriter = new System.IO.StreamWriter(a_zFilePath);

            //write some comments not to modify this
            string sLine = "# do not modify this file, this is a generated file - DiLib 2.0";
            kWriter.WriteLine(sLine);
            kWriter.WriteLine();

            //listing all the header files needs to be included
            sLine = "[Headers]";
            kWriter.WriteLine(sLine);

            //go through header files list
            for (int i = 0; i < listInclues.Items.Count; i++)
            {
                sLine = listInclues.Items[i].ToString();
                kWriter.WriteLine(sLine);
            }

            //write the enum values
            sLine = "[Enum]";
            kWriter.WriteLine();
            kWriter.WriteLine(sLine);

            //export data
            m_pkDataHandler.WriteConfigData(ref kWriter);

            kWriter.Close(); //close writing

            return true;
        }

        /// <summary>
        /// Export tree data of this data file for C++ project
        /// </summary>
        /// <param name="a_zFilePath"></param>
        /// <param name="a_iTabIndex"></param>
        /// <returns></returns>
        public bool ExportTree(string a_zFilePath, int a_iTabIndex)
        {
            if (tabDiFile.TabPages.Count > TABSTART_INDEX)
            {
                //check enum table has valid data before start
                if (!m_pkDataHandler.IsConfigValid())
                {
                    DiMethods.MyDialogShow("Error in config data, please check the error before exporting the tree.", MessageBoxButtons.OK);
                    return false;
                }


                if (a_iTabIndex == -1)
                {
                    DiMethods.MyDialogShow("You haven't select the tree to export.", MessageBoxButtons.OK);
                    return false;
                }
                //focus to the exporting tab
                tabDiFile.SelectedIndex = a_iTabIndex;

                foreach (Control ctrl in tabDiFile.TabPages[a_iTabIndex].Controls)
                {
                    if (ctrl.GetType() == typeof(DiTree))
                    {
                        DiTree pkTab = (DiTree)ctrl;
                        if (!pkTab.ExportTree(a_zFilePath, txtDebugID.Text))
                        {

                            pkTab.Focus();
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        //break;
                    }
                }
            }//end if tab count > m_iStaticTabCount
            else
            {
                DiMethods.MyDialogShow("No tree files to export.", MessageBoxButtons.OK);
                return false;
            }

            return false;
        }
       
    }
}
