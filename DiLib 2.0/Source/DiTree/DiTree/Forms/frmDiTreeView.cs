﻿/*
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Pitman.Printing;
using System.IO;

namespace DiTree
{
    public partial class frmDiTreeView : Form
    {
        public frmDiTreeView()
        {
            InitializeComponent();
        }

        public bool OpenTree(string filename)
        {
            try
            {
                Text = Path.GetFileName(filename);
                XmlReader reader = XmlReader.Create(filename);

                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case DiXMLElements.XMLELEMENT_NODE:
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
                this.Text = System.IO.Path.GetFileName(filename);
                return true;
            }
            catch (Exception e)
            {
                DiMethods.SetErrorLog(e);
                DiMethods.SetStatusMessage(DiLangID.ID_ERROR_LOAD_FILE);
                DiMethods.MyDialogShow("Unable to open file. Please check the file you are trying to open is valid.", MessageBoxButtons.OK);
#if DEBUG
                Console.WriteLine(e.Message.ToString());
#endif
                return false;
            }

        }

        /// <summary>
        /// Open tree from xml reader
        /// </summary>
        /// <param name="reader"></param>
        private void LoadTree(ref XmlReader reader)
        {
            try
            {
                if (treeBT.Nodes.Count == 0)
                {
                    DiTreeNode node = new DiTreeNode();
                    DiTask task = new DiTask();
                    task.ClassName = DiXMLElements.XMLELEMENT_ROOT;
                    task.ClassType = DICLASSTYPES.DICLASSTYPE_ROOT;
                    task.EnumID = 0;
                    task.DebuggerID = 0;

                    node.Task = task;
                    node.ImageKey = DiUtility.GetTaskImageKey(DICLASSTYPES.DICLASSTYPE_ROOT);
                    node.SelectedImageKey = node.ImageKey;
                    node.Text = DiXMLElements.XMLELEMENT_ROOT;

                    treeBT.Nodes.Add(node);
                }

                DiTreeNode kTreeRoot = (DiTreeNode)treeBT.Nodes[0];
                DiTask kTask = new DiTask();

                kTreeRoot.ImageKey = DiUtility.GetTaskImageKey(DICLASSTYPES.DICLASSTYPE_ROOT);
                kTask.ClassType = (DICLASSTYPES)Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODETYPE]);
                kTask.EnumID = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODEENUMID]);
                kTask.ScriptFile = reader[DiXMLElements.XMLELEMENT_SCRIPTFILE];

                kTreeRoot.Task = kTask;

                int childcount = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_ROOTNODE_COUNT]);

                if (reader[DiXMLElements.XMLELEMENT_NODEDEBUGID] != null)
                {
                    kTask.DebuggerID = Convert.ToInt64(reader[DiXMLElements.XMLELEMENT_NODEDEBUGID]);
                }
                else
                {
                    kTask.DebuggerID = 0;
                }

                GenerateTreeView(ref reader, ref kTreeRoot, childcount);//load child nodes

                kTreeRoot.ExpandAll();
            }
            catch (Exception ex)
            {
                DiMethods.SetErrorLog(ex);
                DiMethods.SetStatusMessage(DiLangID.ID_ERROR_LOAD_FILE);
                DiMethods.MyDialogShow("Unable to load tree, please check the data file is valid.", MessageBoxButtons.OK);

#if DEBUG
                Console.WriteLine(ex.Message);
#endif
            }
        }

        /// <summary>
        /// Generates the tree nodes
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="treenodeparent"></param>
        /// <param name="childnodecount"></param>
        private void GenerateTreeView(ref XmlReader reader, ref DiTreeNode treenodeparent, int childnodecount)
        {
            //create new node
            DiTreeNode node;
            DiTask kTaskParent = treenodeparent.Task;
            int nodecounter = 0;
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case DiXMLElements.XMLELEMENT_NODE:
                            nodecounter++;
                            int iChildCount = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODECHILDCOUNT]);
                            node = GenerateTreeNode(ref reader);

                            //set tool tip
                            //SetToolTip(ref node);

                            switch (treenodeparent.ClassType)
                            {
                                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                                    {
                                        DiCondition kCondition = (DiCondition)kTaskParent;
                                        if (kCondition.EnumTrue == node.Task.EnumID)
                                        {
                                            kCondition.TaskTrue = node.Task;
                                        }
                                        else if (kCondition.EnumFalse == node.Task.EnumID)
                                        {
                                            kCondition.TaskFalse = node.Task;
                                        }
                                        if (kCondition.TaskElement1 == null)
                                        {
                                            kCondition.TaskElement1 = node.Task;
                                        }
                                        else if (kCondition.TaskElement2 == null)
                                        {
                                            kCondition.TaskElement2 = node.Task;
                                        }
                                        break;
                                    }
                                case DICLASSTYPES.DICLASSTYPE_FILTER:
                                    {


                                        break;
                                    }

                                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                                    DiSequence kSeq = (DiSequence)kTaskParent;
                                    //kSeq.TaskList.Add(kTask);
                                    break;
                                default:
                                    break;
                            }
                            treenodeparent.Nodes.Add(node);

                            //set tooltip

                            if (iChildCount > 0) //if current node has children, add them
                            {
                                GenerateTreeView(ref reader, ref node, iChildCount);
                            }

                            //check all the child nodes of the current parent is red
                            if (nodecounter >= childnodecount)
                            {
                                return;
                            }

                            break;
                    }//end switch

                }//end if

            }//end while read

        }//end function

        /// <summary>
        /// Gets called from GenerateTreeView with data for the new node
        /// </summary>
        private DiTreeNode GenerateTreeNode(ref XmlReader reader)
        {
            DiTreeNode node = new DiTreeNode();
            DICLASSTYPES eType = (DICLASSTYPES)Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODETYPE]);
            DiTask kTask;//set task

            switch (eType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    kTask = new DiCondition();
                    DiCondition kCondition = (DiCondition)kTask;
                    //so the child node creating, can set accurate position of condition 
                    kCondition.EnumTrue = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODETASKTRUE]);
                    kCondition.EnumFalse = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODETASKFALSE]);
                    break;

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    kTask = new DiFilter();
                    DiFilter kFilter = (DiFilter)kTask;
                    kFilter.EnumTask = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODETASKTRUE]);
                    kFilter.LoopOn = Convert.ToBoolean(reader[DiXMLElements.XMLELEMENT_NODEREPEAT]);
                    kFilter.MaxRunCycles = Convert.ToUInt16(reader[DiXMLElements.XMLELEMENT_NODEMAXREPEATS]);

                    break;

                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    kTask = new DiSequence();
                    break;

                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    kTask = new DiSequence();
                    break;

                default:
                    kTask = new DiTask();
                    break;
            }

            kTask.ClassName = reader[DiXMLElements.XMLELEMENT_NODECLASSNAME];
            kTask.ClassType = (DICLASSTYPES)Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODETYPE]);
            kTask.EnumID = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODEENUMID]);
            kTask.DebuggerID = -1;

            long lDebugID = Convert.ToInt64(reader[DiXMLElements.XMLELEMENT_NODEDEBUGID]);
            if (lDebugID > 0)
            {
                kTask.DebuggerID = Convert.ToInt64(reader[DiXMLElements.XMLELEMENT_NODEDEBUGID]);
            }

            kTask.ScriptFile = reader[DiXMLElements.XMLELEMENT_NODESCRIPT_FILE];
            node.Task = kTask;

            node.ImageKey = DiUtility.GetTaskImageKey(eType);
            node.SelectedImageKey = node.ImageKey;
            node.Text = kTask.ClassName;
            return node;
        }

        public void Print(bool a_bIsPreview)
        {
            PrintHelper print = new PrintHelper();
            if (a_bIsPreview)
            {
                print.PrintPreviewTree(treeBT, Text);
            }
            else
            {
                print.PrintTree(treeBT, Text);
            }
        }

    }
}
