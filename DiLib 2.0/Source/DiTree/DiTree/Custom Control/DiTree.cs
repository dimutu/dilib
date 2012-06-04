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

        public DiTree()
        {
            InitializeComponent();
            InitializeControl();
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
        }

        
    }
}
