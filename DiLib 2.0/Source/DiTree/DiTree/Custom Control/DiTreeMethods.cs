using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

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
                task.ClassName = "Root";
                task.ClassType = DICLASSTYPES.DICLASSTYPE_ROOT;
                task.EnumID = 0;
                task.DebuggerID = m_lDebugIDCounter;

                node.Task = task;
                node.ImageKey = GetTaskImageKey(DICLASSTYPES.DICLASSTYPE_ROOT);
                node.SelectedImageKey = node.ImageKey;

                treeBT.Nodes.Add(node);
            }
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

            //set new data record
            pkTask.EnumID = DiDataHanlder.instance.AddNew(a_eType, txtTemplateClass.Text);

            pkTask.ClassType = a_eType;
            pkTreeNode.Task = pkTask;//set the task for the tree node
            pkTreeNode.ImageKey = GetTaskImageKey(a_eType);
            pkTreeNode.SelectedImageKey = pkTreeNode.ImageKey;

            a_pkParent.Nodes.Add(pkTreeNode);
            a_pkParent.Expand(); //expand the parent if not

            
            
        }

    }
}
