using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data;

namespace DiTree
{
    /// <summary>
    /// This contains the accessors for manipulate the nodes from main application form
    /// from its menus and toolbar
    /// </summary>
    public partial class DiTree : UserControl
    {
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
        /// save into the tree data files
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public bool SaveTree(ref XmlWriter writer)
        {
            //try
            {

                //get root node
                DiTreeNode kRoot = (DiTreeNode)treeBT.Nodes[0];

                //write the tree nodes under the root
                SaveXMLTree(ref writer, ref kRoot);
                //end writing nodes

                return true;
            }
//            catch (Exception ex)
//            {
//                DiMethods.SetErrorLog(ex);
//                DiMethods.SetStatusMessage("Unable to save file.");
//#if DEBUG
//                DiMethods.MyDialogShow(ex.Message, MessageBoxButtons.OK);
//#endif
//                return false;
//            }
        }

        private void SaveXMLTree(ref XmlWriter writer, ref DiTreeNode node)
        {
            //if the current node is null something wrong, dont go forward
            if (node == null)
            {
                return;
            }

            if (node.Task == null)
            {
                return;
            }

            DiTask kNodeTask = node.Task;

            if (node.ClassType == DICLASSTYPES.DICLASSTYPE_ROOT)
            {
                writer.WriteStartElement(DiXMLElements.XMLELEMENT_ROOT);
                writer.WriteAttributeString(DiXMLElements.XMLELEMENT_ROOTTEMPLATECLASS, txtTemplateClass.Text);

                //save tree name
                writer.WriteAttributeString(DiXMLElements.XMLELEMENT_ROOTDEBUGID, m_zTreeName.ToString());
            }
            else
            {
                writer.WriteStartElement(DiXMLElements.XMLELEMENT_NODE);
            }

            writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODEENUMID, kNodeTask.EnumID.ToString());
            writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODETYPE, Convert.ToString((int)kNodeTask.ClassType));
            writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODECLASSNAME, kNodeTask.ClassName.Trim());
            writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODESCRIPT_FILE, kNodeTask.ScriptFile.ToString().Trim());

            writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODECHILDCOUNT, node.Nodes.Count.ToString());
            writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODEDEBUGID, kNodeTask.DebuggerID.ToString());

            //if this is condition, set which task runs when true and false
            switch (node.ClassType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    {
                        DiCondition kCondition = (DiCondition)node.Task;
                        //check true task is set
                        if (kCondition.TaskTrue != null)
                        {
                            writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODETASKTRUE, kCondition.TaskTrue.EnumID.ToString());
                        }
                        if (kCondition.TaskFalse != null)
                        {
                            writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODETASKFALSE, kCondition.TaskFalse.EnumID.ToString());
                        }
                        break;
                    }

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    {
                        DiFilter kFilter = (DiFilter)node.Task;
                        writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODETIMER_INTERVAL, kFilter.TimerInterval.ToString());
                        if (kFilter.Task != null)
                        {
                            writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODEFILTERTASK, kFilter.Task.EnumID.ToString());
                        }
                        writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODEREPEAT, kFilter.LoopOn.ToString());
                        writer.WriteAttributeString(DiXMLElements.XMLELEMENT_NODEMAXREPEATS, kFilter.MaxRunCycles.ToString());
                        break;
                    }
                default:
                    break;
            }


            //go through childern nodes
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                DiTreeNode kChildNode = (DiTreeNode)node.Nodes[i];
                SaveXMLTree(ref writer, ref kChildNode); //create new node for each child
            }

            writer.WriteEndElement(); //end writing the current node

        }

        /// <summary>
        /// Tree name
        /// </summary>
        public string TreeName
        {
            get
            {
                return m_zTreeName;
            }
            set
            {
                m_zTreeName = value;
            }
        }

        /// <summary>
        /// Data handler
        /// </summary>
        public DiDataHanlder DataHandler
        {
            set
            {
                m_pkDataHandler = value;
            }
        }

        /// <summary>
        /// Open tree from xml reader
        /// </summary>
        /// <param name="reader"></param>
        public void OpenTree(ref XmlReader reader)
        {
            try
            {
                //create the tree node
                txtTemplateClass.Text = reader[DiXMLElements.XMLELEMENT_TEMPLATECLASS];
                EnableControls(true); //set template class and enable the tree
                m_pkDataHandler.InitializeTemplateData(txtTemplateClass.Text); //initialize template data

                DiTreeNode kTreeRoot = (DiTreeNode)treeBT.Nodes[0];
                DiTask kTask = new DiTask();

                kTreeRoot.ImageKey = GetTaskImageKey(DICLASSTYPES.DICLASSTYPE_ROOT);
                kTask.ClassType = (DICLASSTYPES)Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODETYPE]);
                kTask.EnumID = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODEENUMID]);
                kTask.ScriptFile = reader[DiXMLElements.XMLELEMENT_SCRIPTFILE];

                kTreeRoot.Task = kTask;

                int childcount = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_ROOTNODE_COUNT]);


                m_lDebugIDCounter = 0; //reset id counter to start for this tree
                if (reader[DiXMLElements.XMLELEMENT_NODEDEBUGID] != null)
                {
                    kTask.DebuggerID = Convert.ToInt64(reader[DiXMLElements.XMLELEMENT_NODEDEBUGID]);
                }
                else
                {
                    kTask.DebuggerID = m_lDebugIDCounter;
                }

                //set tree tab name
                if (reader[DiXMLElements.XMLELEMENT_ROOTDEBUGID] != null)
                {
                    m_zTreeName = reader[DiXMLElements.XMLELEMENT_ROOTDEBUGID];
                }
                else
                {
                    m_zTreeName = this.Parent.Name.ToString();
                }

                GenerateTreeView(ref reader, ref kTreeRoot, childcount);//load child nodes

                //Evaluate_DebugIDs(ref kTreeRoot);//set debug ids for nodes that arent set

                kTreeRoot.ExpandAll();
            }
            catch (Exception ex)
            {
                DiMethods.SetErrorLog(ex);
                DiMethods.SetStatusMessage("Error loading file.");
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
            DICLASSTYPES eType =(DICLASSTYPES)Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODETYPE]);
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

            kTask.DataHandler = m_pkDataHandler;
            kTask.ClassName = reader[DiXMLElements.XMLELEMENT_NODECLASSNAME];
            kTask.ClassType = (DICLASSTYPES)Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODETYPE]);
            kTask.EnumID = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_NODEENUMID]);
            kTask.DebuggerID = -1;
            long lDebugID = Convert.ToInt64(reader[DiXMLElements.XMLELEMENT_NODEDEBUGID]);
            if (lDebugID > 0)
            {
                kTask.DebuggerID = Convert.ToInt64(reader[DiXMLElements.XMLELEMENT_NODEDEBUGID]);
            }
            //get the maximum number to avoid duplication
            if (kTask.DebuggerID > m_lDebugIDCounter)
            {
                m_lDebugIDCounter = kTask.DebuggerID;
            }

            kTask.ScriptFile = reader[DiXMLElements.XMLELEMENT_NODESCRIPT_FILE];
            node.Task = kTask;

            node.ImageKey = GetTaskImageKey(eType);
            node.SelectedImageKey = node.ImageKey;
            node.Text = kTask.ClassName;

            
            return node;
        }

    }


}
