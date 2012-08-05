using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace DiTree
{
    public partial class DiTree : UserControl
    {
        /// <summary>
        /// Initialize each control in the UserControl
        /// </summary>
        private void InitializeControl()
        {
            //populate the list view with each task type
            AddTaskItem(DICLASSTYPES.DICLASSTYPE_TASK);
            AddTaskItem(DICLASSTYPES.DICLASSTYPE_CONDITION);
            AddTaskItem(DICLASSTYPES.DICLASSTYPE_FILTER);
            AddTaskItem(DICLASSTYPES.DICLASSTYPE_SEQUENCE);
            AddTaskItem(DICLASSTYPES.DICLASSTYPE_SELECTION);

            //creates the root node on the tree view
            if (treeBT.Nodes.Count == 0)
            {
                DiTreeNode node = new DiTreeNode();
                DiTask task = new DiTask();
                task.ClassName = DiXMLElements.XMLELEMENT_ROOT;
                task.ClassType = DICLASSTYPES.DICLASSTYPE_ROOT;
                task.EnumID = 0;
                task.DebuggerID = m_lDebugIDCounter;

                node.Task = task;
                node.ImageKey = GetTaskImageKey(DICLASSTYPES.DICLASSTYPE_ROOT);
                node.SelectedImageKey = node.ImageKey;
                node.Text = DiXMLElements.XMLELEMENT_ROOT;

                treeBT.Nodes.Add(node);
            }

            //create property control
            /*m_pkPropertyGrid = new DiPropertyControl();
            splitProperties.Panel2.Controls.Add(m_pkPropertyGrid);
            m_pkPropertyGrid.Dock = DockStyle.Fill;
            */
            EnableControls(false);
        }

        /// <summary>
        /// Disable controls first start and wait until enter the template claass which cannot change afterwards
        /// </summary>
        /// <param name="a_bEnable"></param>
        public void EnableControls(bool a_bEnable)
        {
            treeBT.Enabled = a_bEnable;
            listTaskTypes.Enabled = a_bEnable;
            //m_pkPropertyGrid.Enabled = a_bEnable;
            txtTemplateClass.Enabled = !a_bEnable;
            btnSetTemplate.Visible = !a_bEnable;
        }

        /// <summary>
        /// Creates new list view item from the class type
        /// </summary>
        /// <param name="a_eType"></param>
        private void AddTaskItem(DICLASSTYPES a_eType)
        {
            DiListViewItem item = new DiListViewItem();
            string zKey = GetTaskImageKey(a_eType);
            item.TaskType = a_eType;
            item.ImageKey = zKey;
            item.Text = zKey[0].ToString().ToUpper() + zKey.Substring(1);
            listTaskTypes.Items.Add(item);
        }

        /// <summary>
        /// Get image list image key from the class type
        /// </summary>
        /// <param name="a_eType"></param>
        /// <returns></returns>
        public string GetTaskImageKey(DICLASSTYPES a_eType)
        {
            string zKey = "";
            switch (a_eType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    zKey = "condition";
                    break;

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    zKey = "filter";
                    break;

                case DICLASSTYPES.DICLASSTYPE_ROOT:
                    zKey = "root";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    zKey = "selection";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    zKey = "sequence";
                    break;

                default:
                    zKey = "task";
                    break;
            }

            return zKey;
        }

        /// <summary>
        /// Check the this node is valid to add a new node under it
        /// </summary>
        /// <param name="a_pkNode"></param>
        /// <returns></returns>
        private bool IsAddValidate(DiTreeNode a_pkParent)
        {
            bool bIsOK = true; 
            switch (a_pkParent.ClassType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    {
                        //condition can have only two
                        if (a_pkParent.Nodes.Count >= 2)
                        {
                            bIsOK = false;
                        }
                        break;
                    }

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    {
                        //filter can only have single child
                        if (a_pkParent.Nodes.Count >= 1)
                        {
                            bIsOK = false;
                        }
                        break;
                    }

                case DICLASSTYPES.DICLASSTYPE_TASK:
                    {
                        //task cannot have children nodes
                        bIsOK = false;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            return bIsOK;
        }

        /// <summary>
        /// Check the nodes are valid when moving nodes to a new parent node
        /// </summary>
        /// <param name="a_pkParent"></param>
        /// <param name="a_pkChild"></param>
        /// <returns></returns>
        private bool IsAddValidate(DiTreeNode a_pkParent, DiTreeNode a_pkChild)
        {
            bool bIsValid = true;
            //some error handling
            if (a_pkChild == null || a_pkParent == null)
            {
                bIsValid = false;
            }
            else if (a_pkParent == a_pkChild)
            {
                //trying to move same node on to same objectd
                DiMethods.MyDialogShow("Cannot move to same task.", MessageBoxButtons.OK);
                bIsValid = false;
            }
            else if (a_pkChild.Parent == a_pkParent)
            {
                DiMethods.MyDialogShow("Already at the destination node.", MessageBoxButtons.OK);
                bIsValid = false;
            }
            else if (a_pkParent.Level > a_pkChild.Level)
            {
                //if the desitination is lower level of tree check they both has the same parent
                DiTreeNode pkTempParent = (DiTreeNode)a_pkParent.Parent;
                while (pkTempParent != null)
                {
                    if (a_pkChild == pkTempParent)
                    {
                        //destination is a child of the selected node, this cannot be happen
                        DiMethods.MyDialogShow("Selected node cannot be a parent of Destination node.", MessageBoxButtons.OK);
                        bIsValid = false;
                        break;
                    }

                    pkTempParent = (DiTreeNode)pkTempParent.Parent;
                }

               
            }
            else if (a_pkParent.Task.ClassType == DICLASSTYPES.DICLASSTYPE_TASK)
            {
                //cannot move under to task
                DiMethods.MyDialogShow("Cannot move to a task node.", MessageBoxButtons.OK);
                bIsValid = false;
            }
            else if (a_pkParent.Task.ClassType == DICLASSTYPES.DICLASSTYPE_CONDITION )
            {
                DiCondition kCondition = (DiCondition)a_pkParent.Task;

                //check either of two tasks remaining to be added
                if (kCondition.TaskTrue != null && kCondition.TaskFalse != null) //this is the first task adding,
                {
                    DiMethods.MyDialogShow("Condition has maximum child tasks.", MessageBoxButtons.OK);
                    bIsValid = false;
                }
            }
            else if (a_pkParent.Task.ClassType == DICLASSTYPES.DICLASSTYPE_FILTER)
            {
                DiFilter kFilter = (DiFilter)a_pkParent.Task;
                if (kFilter.Task != null)
                {
                    DiMethods.MyDialogShow("Filter already has a task.", MessageBoxButtons.OK);
                    bIsValid = false;
                }
            }

            return bIsValid;
        }

        /// <summary>
        /// Creates a new node using the class type and add it to the passing in parent node
        /// </summary>
        /// <param name="a_pkParent"></param>
        /// <param name="a_eType"></param>
        private void AddNewTreeNode(DiTreeNode a_pkParent, DICLASSTYPES a_eType)
        {
            DiTreeNode pkTreeNode = new DiTreeNode(); //new tree node
            DiTask pkTask;

            switch (a_eType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    {
                        pkTask = new DiCondition();
                        break;
                    }

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    {
                        pkTask = new DiFilter();
                        break;
                    }

                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    {
                        pkTask = new DiSequence();
                        break;
                    }

                default:
                    {
                        pkTask = new DiTask();
                        break;
                    }
            }

            pkTask.DataHandler = m_pkDataHandler;

            //get the default template data record for the new node and wait until the
            // changes in the property grid
            //set new data record
            DiDataRow dr = m_pkDataHandler.GetTemplateDataRow(a_eType, txtTemplateClass.Text);
            if (dr != null)
            {
                pkTask.EnumID = dr.EnumID;
                pkTask.ClassName = dr.ClassName;
                pkTask.ClassType = a_eType;
                pkTask.DebuggerID = ++m_lDebugIDCounter;

                pkTreeNode.Task = pkTask;//set the task for the tree node
                pkTreeNode.ImageKey = GetTaskImageKey(a_eType);
                pkTreeNode.SelectedImageKey = pkTreeNode.ImageKey;

                //set parent task node 
                switch (a_pkParent.Task.ClassType)
                {
                    case DICLASSTYPES.DICLASSTYPE_FILTER:
                        {
                            DiFilter temp = (DiFilter)a_pkParent.Task;
                            temp.Task = pkTask;
                            break;
                        }

                    case DICLASSTYPES.DICLASSTYPE_CONDITION:
                        {
                            DiCondition temp = (DiCondition)a_pkParent.Task;
                            if (temp.TaskElement1 == null)
                            {
                                temp.TaskElement1 = pkTask;
                            }
                            else if (temp.TaskElement2 == null)
                            {
                                temp.TaskElement2 = pkTask;
                            }

                            //set default true and false tasks
                            if (temp.TaskTrue == null)
                            {
                                temp.TaskTrue = pkTask;
                            }
                            else if (temp.TaskFalse == null)
                            {
                                temp.TaskFalse = pkTask;
                            }
                            break;
                        }

                    case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                        {
                            DiSequence temp = (DiSequence)a_pkParent.Task;
                            temp.TaskList.Add(pkTask);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                a_pkParent.Nodes.Add(pkTreeNode);
                a_pkParent.Expand(); //expand the parent if not

                dr = null;
            }//end checking null data row
            
        }

        /// <summary>
        /// Copy source tree node structure to the destination node
        /// </summary>
        /// <param name="a_pkSource"></param>
        /// <param name="a_pkDestination"></param>
        private void CopyBTreeNodes(ref DiTreeNode a_pkSource, ref DiTreeNode a_pkDestination)
        {
            //check destination is already created
                switch (a_pkSource.Task.ClassType)
                {
                    case DICLASSTYPES.DICLASSTYPE_CONDITION:
                        DiCondition pkCondNew = new DiCondition();
                        DiCondition pkCondSource = (DiCondition)a_pkSource.Task;
                        pkCondNew = pkCondSource;
                        a_pkDestination.Task = pkCondNew;
                        break;

                    case DICLASSTYPES.DICLASSTYPE_FILTER:
                        DiFilter pkFilnew = new DiFilter();
                        DiFilter pkFilSource = (DiFilter)a_pkSource.Task;
                        pkFilnew = pkFilSource;
                        a_pkDestination.Task = pkFilnew;
                        break;

                    case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    case DICLASSTYPES.DICLASSTYPE_SELECTION:
                        DiSequence pkSeqNew = new DiSequence();
                        DiSequence pkSeqSource = (DiSequence)a_pkSource.Task;
                        pkSeqNew = pkSeqSource;
                        a_pkDestination.Task = pkSeqNew;
                        break;

                    default:
                        a_pkDestination.Task = new DiTask();
                        a_pkDestination.Task = a_pkSource.Task;
                        break;
                }
            


            if (a_pkSource.Nodes.Count > 0)
            {
                //had child nodes
                for (int ii = 0; ii < a_pkSource.Nodes.Count; ++ii)
                {
                    DiTreeNode btSource = (DiTreeNode)a_pkSource.Nodes[ii];
                    DiTreeNode btDest = (DiTreeNode)a_pkDestination.Nodes[ii];
                    CopyBTreeNodes(ref btSource, ref btDest);
                }
            }
        }

        /// <summary>
        /// sets the template class
        /// </summary>
        private void SetTemplateClass()
        {
            if (txtTemplateClass.Text.Length > 0)
            {
                //eneable controls to create the tree
                EnableControls(true);
                //set default templete data 
                m_pkDataHandler.InitializeTemplateData(txtTemplateClass.Text);
            }
            else
            {
                if (DiMethods.MyDialogShow("Enter a template class name.", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    txtTemplateClass.Focus();
                }

            }
        }

    }
}
