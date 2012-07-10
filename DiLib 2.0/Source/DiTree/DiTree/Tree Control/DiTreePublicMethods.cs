using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

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
            try
            {

                //get root node
                DiTreeNode kRoot = (DiTreeNode)treeBT.Nodes[0];

                //write the tree nodes under the root
                SaveXMLTree(ref writer, ref kRoot);
                //end writing nodes

                return true;
            }
            catch (Exception ex)
            {
                DiMethods.SetErrorLog(ex);
                DiMethods.SetStatusMessage("Unable to save file.");
#if DEBUG
                DiMethods.MyDialogShow(ex.Message, MessageBoxButtons.OK);
#endif
                return false;
            }
        }

        private void SaveXMLTree(ref XmlWriter writer, ref DiTreeNode node)
        {
            //if the current node is null something wrong, dont go forward
            if (node == null)
            {
                return;
            }

            if (node.Text == "Root")
            {
                writer.WriteStartElement(XMLELEMENT_ROOT);
                writer.WriteAttributeString(XMLELEMENT_CLASSNAME, txtTemplateClass.Text);

                //save tree name
                writer.WriteAttributeString(XMLELEMENT_ROOTDEBUGID, m_zTreeName.ToString());
            }
            else
            {
                writer.WriteStartElement(XMLELEMENT_NODE);
            }

            writer.WriteAttributeString(XMLELEMENT_ENUMID, node.EnumID.ToString());
            writer.WriteAttributeString(XMLELEMENT_TYPE, Convert.ToString((int)node.ClassType));
            writer.WriteAttributeString(XMLELEMENT_CLASSNAME, node.Text.Trim());
            writer.WriteAttributeString(XMLELEMENT_SCRIPT_FILE, node.ScriptFile.ToString().Trim());
            
            writer.WriteAttributeString(XMLELEMENT_CHILDCOUNT, node.Nodes.Count.ToString());
            writer.WriteAttributeString(XMLELEMENT_TASKDEBUGID, node.DebuggerID.ToString());

            //if this is condition, set which task runs when true and false
            switch (node.ClassType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    {
                        DiCondition kCondition = (DiCondition)node.Task;
                        //check true task is set
                        if (kCondition.TaskTrue != null)
                        {
                            writer.WriteAttributeString(XMLELEMENT_TASKTRUE, kCondition.TaskTrue.EnumID.ToString());
                        }
                        if (kCondition.TaskFalse != null)
                        {
                            writer.WriteAttributeString(XMLELEMENT_TASKFALSE, kCondition.TaskFalse.EnumID.ToString());
                        }
                        break;
                    }

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    {
                        DiFilter kFilter = (DiFilter)node.Task;
                        writer.WriteAttributeString(XMLELEMENT_TIMER_INTERVAL, kFilter.TimerInterval.ToString());
                        writer.WriteAttributeString(XMLELEMENT_FILTERTASK, kFilter.Task.EnumID.ToString());
                        writer.WriteAttributeString(XMLELEMENT_REPEAT, kFilter.LoopOn.ToString());
                        writer.WriteAttributeString(XMLELEMENT_MAXREPEATS, kFilter.MaxRunCycles.ToString());
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

        public DiDataHanlder DataHandler
        {
            set
            {
                m_pkDataHandler = value;
            }
        }

    }
}
