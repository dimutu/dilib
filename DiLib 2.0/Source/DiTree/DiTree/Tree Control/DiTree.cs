using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
    public partial class DiTree : UserControl
    {
        /// <summary>
        /// Count the number of nodes in the tree and use this as unique identifier for debugging
        /// </summary>
        private long m_lDebugIDCounter = 0;

        protected string m_zTreeName;

        protected DiPropertyControl m_pkPropertyGrid;

        protected DiDataHanlder m_pkDataHandler;
        //protected DiTreeNode m_pkSelectedNode; //currently selected node in the tree without using the default property

        /// <summary>
        /// Tree XML element names
        /// </summary>
        /// 
        /*protected const string XMLELEMENT_ROOT = "RootNode";
        protected const string XMLELEMENT_TEMPLATECLASS = "TemplateClassName";
        protected const string XMLELEMENT_ROOTDEBUGID = "RootDebugID";
        protected const string XMLELEMENT_NODE = "Node";
        protected const string XMLELEMENT_ENUMID = "EnumID";
        protected const string XMLELEMENT_TYPE = "TypeID";
        protected const string XMLELEMENT_CLASSNAME = "ClassName";
        protected const string XMLELEMENT_SCRIPT_FILE = "LuaScript";
        protected const string XMLELEMENT_FILTERTASK = "Task";
        protected const string XMLELEMENT_TIMER_INTERVAL = "TimerInterval";
        protected const string XMLELEMENT_CHILDCOUNT = "ChildCount";
        protected const string XMLELEMENT_TASKDEBUGID = "TaskDebugID";
        protected const string XMLELEMENT_REPEAT = "Repeat";
        protected const string XMLELEMENT_MAXREPEATS = "MaxRunCycle";
        protected const string XMLELEMENT_TASKTRUE = "TaskTrue";
        protected const string XMLELEMENT_TASKFALSE = "TaskFalse";
         * */

        public DiTree()
        {
            InitializeComponent();
            InitializeControl();
            EnableControls(false);
        }
        
        /// <summary>
        /// start the drag when list items has mouse down event and item is selected
        /// </summary>
        private void listTaskTypes_MouseDown(object sender, MouseEventArgs e)
        {
            if (listTaskTypes.SelectedItems.Count == 1)
            {
                DiListViewItem item = (DiListViewItem)listTaskTypes.SelectedItems[0];
                treeBT.DoDragDrop(item.TaskType, DragDropEffects.Link);
            }
        }

        /// <summary>
        /// tree node is dragged into the control
        /// </summary>
        private void treeBT_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DICLASSTYPES))) //dragging single item from the list view
            {
                //change the effect on correct type
                e.Effect = DragDropEffects.Link;
            }
            else if (e.Data.GetDataPresent("DiTree.DiTreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                DiTreeNode DestinationNode = (DiTreeNode)((TreeView)sender).GetNodeAt(pt);
                DiTreeNode SelectedNode = (DiTreeNode)e.Data.GetData("DiTree.DiTreeNode");

                //cant move the root
                if (SelectedNode.Task.ClassType == DICLASSTYPES.DICLASSTYPE_ROOT)
                {
                    e.Effect = DragDropEffects.None;
                }              
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
            else
            {
                //not the class types, ignore
                return;
            }
        }

        /// <summary>
        /// new/current tree node gets dropped on to another node
        /// </summary>
        private void treeBT_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DICLASSTYPES)))
            {
                //get the node currently hovering
                Point p = new Point(e.X, e.Y);
                p = treeBT.PointToClient(p);
                DiTreeNode pkParentNode = (DiTreeNode)treeBT.GetNodeAt(p);
                if (pkParentNode != null)
                {
                    if (IsAddValidate(pkParentNode)) //check the mouse over node is ok to add a new child node
                    {
                        DICLASSTYPES eType = (DICLASSTYPES)e.Data.GetData(typeof(DICLASSTYPES));
                        AddNewTreeNode(pkParentNode, eType);
                    }
                }
            }
            else if (e.Data.GetDataPresent("DiTree.DiTreeNode"))
            {
                //get drag and drop items
                Point pt = treeBT.PointToClient(new Point(e.X, e.Y));
                DiTreeNode DestinationNode = (DiTreeNode)treeBT.GetNodeAt(pt);
                DiTreeNode SelectedNode = (DiTreeNode)e.Data.GetData("DiTree.DiTreeNode");

                if (IsAddValidate(DestinationNode, SelectedNode) == false)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                //after validating
                //create new node
                DiTreeNode kNewNode = (DiTreeNode)SelectedNode.Clone();
                switch (SelectedNode.Task.ClassType)
                {
                    case DICLASSTYPES.DICLASSTYPE_CONDITION:
                        kNewNode.Task = new DiCondition();
                        break;

                    case DICLASSTYPES.DICLASSTYPE_FILTER:
                        kNewNode.Task = new DiFilter();
                        break;

                    case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                        kNewNode.Task = new DiSequence();
                        break;

                    case DICLASSTYPES.DICLASSTYPE_SELECTION:
                        kNewNode.Task = new DiSequence();
                        break;

                    default:
                        kNewNode.Task = new DiTask();
                        break;
                }

                CopyBTreeNodes(ref SelectedNode, ref kNewNode);

                //check adding on to right node
                switch (DestinationNode.Task.ClassType)
                {
                    case DICLASSTYPES.DICLASSTYPE_CONDITION:
                        {
                            DiCondition pkCondition = (DiCondition)DestinationNode.Task;

                            //set true task and false task
                            if (pkCondition.TaskTrue == null) //this is the first task adding,
                            {
                                //default position will be as its true task
                                pkCondition.TaskTrue = kNewNode.Task;
                                pkCondition.Tasks[(int)CONDITION.CONDITION_ELEMENT1] = kNewNode.Task;
                            }
                            else if (pkCondition.TaskFalse == null) //second task is false task
                            {
                                pkCondition.TaskFalse = kNewNode.Task;
                                pkCondition.Tasks[(int)CONDITION.CONDITION_ELEMENT2] = kNewNode.Task;
                            }
                            break;
                        }

                    case DICLASSTYPES.DICLASSTYPE_FILTER:
                        {
                            DiFilter kFilter = (DiFilter)DestinationNode.Task;
                            if (kFilter.Task == null)
                            {
                                kFilter.Task = kNewNode.Task;
                            }
                            break;
                        }

                    case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                        {
                            DiSequence kTaskSeq = (DiSequence)DestinationNode.Task;
                            kTaskSeq.TaskList.Add(kNewNode.Task);
                            break;
                        }
                    default:
                        break;
                }

                //set source tasks parent
                DiTreeNode pkSelectNodeParent = (DiTreeNode)SelectedNode.Parent;
                if (pkSelectNodeParent != null)
                {
                    switch (pkSelectNodeParent.Task.ClassType)
                    {
                        case DICLASSTYPES.DICLASSTYPE_CONDITION:
                            {
                                DiCondition pkCondition = (DiCondition)pkSelectNodeParent.Task;
                                pkCondition.RemoveTask(SelectedNode.Task);
                                break;
                            }

                        case DICLASSTYPES.DICLASSTYPE_FILTER:
                            {
                                DiFilter pkFilter = (DiFilter)pkSelectNodeParent.Task;
                                pkFilter.Task = null;
                                break;
                            }

                        case DICLASSTYPES.DICLASSTYPE_SELECTION:
                        case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                            {
                                DiSequence pkSeq = (DiSequence)pkSelectNodeParent.Task;
                                pkSeq.RemoveTask(SelectedNode.Task);
                                break;
                            }

                        default:
                            break;
                    }
                }

                DestinationNode.Nodes.Add(kNewNode);
                DestinationNode.Expand();
                //Remove Original Node
                SelectedNode.Remove();
            }
        }

        /// <summary>
        /// Tree drag over by a node
        /// </summary>
        private void treeBT_DragOver(object sender, DragEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            p = treeBT.PointToClient(p);
            DiTreeNode pkNode = (DiTreeNode)treeBT.GetNodeAt(p);
            if (pkNode != null)
            {
                pkNode.Expand();
                treeBT.SelectedNode = pkNode;
            }
        }

        /// <summary>
        /// double click on list item adds new task to currently(last) selected node
        /// </summary>
        private void listTaskTypes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
            if (treeBT.SelectedNode != null && listTaskTypes.SelectedItems.Count == 1)
            {
                DiTreeNode kSelectNode = (DiTreeNode)treeBT.SelectedNode;
                DiListViewItem kListItem = (DiListViewItem)listTaskTypes.SelectedItems[0];
                if (IsAddValidate(kSelectNode))
                {
                    AddNewTreeNode(kSelectNode, kListItem.TaskType);
                }
            }
             * */
        }

        /// <summary>
        /// when the user selects a node in the tree, show properties
        /// </summary>
        private void treeBT_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeBT.SelectedNode == null)
            {
                return;
            }
            propertyGridTask.SelectedObject = null;
            DiTreeNode pkNode = (DiTreeNode)treeBT.SelectedNode;
            propertyGridTask.SelectedObject = pkNode.Task;

        }

        private void treeBT_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void btnSetTemplate_Click(object sender, EventArgs e)
        {
            SetTemplateClass();
        }

        /// <summary>
        /// checks for return key which is equallent to pressing set button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTemplateClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SetTemplateClass();
            }
        }

        private void propertyGridTask_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DiTask pkTask = (DiTask)propertyGridTask.SelectedObject;
            if (pkTask == null)
            {
                return;
            }


            //class name changed, check already exists or add new
            if (e.ChangedItem.Label == "ClassName")
            {
                string newVal = e.ChangedItem.Value.ToString();

                if (newVal.Length > 0)
                {
                    //check already exists
                    DiDataRow dr = m_pkDataHandler.GetRow(newVal, txtTemplateClass.Text);
                    if (dr != null)
                    {
                        //do some validations
                        if (pkTask.ClassType != dr.ClassType)
                        {
                            DiMethods.MyDialogShow("Cannot change the task type.", MessageBoxButtons.OK);
                            return;
                        }
                        pkTask.EnumID = dr.EnumID;
                        pkTask.IsTemplate = dr.IsTemplate;

                        dr = null;
                    }
                    else
                    {
                        //class not exists, add new row
                        pkTask.EnumID = m_pkDataHandler.AddNew(false, pkTask.ClassType, newVal, txtTemplateClass.Text);
                    }
                }
            }
            
            Console.WriteLine("value changed" + e.ToString());
        }
       
    }
}
