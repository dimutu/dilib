using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
    public partial class DiTree : UserControl
    {
        private void MoveNodeUp(DiTreeNode node)
        {
            if (node == null) return;
            if (node.ClassType == DICLASSTYPES.DICLASSTYPE_ROOT) return;

            TreeNode parent = node.Parent;

            if (node.Index > 0 && parent != null)
            {
                parent.Nodes.Remove(node);
                parent.Nodes.Insert(node.Index - 1, node);
            }
            treeBT.SelectedNode = node;
            treeBT.Focus();
        }

        private void MoveNodeDown(DiTreeNode node)
        {
            if (node == null) return;
            if (node.ClassType == DICLASSTYPES.DICLASSTYPE_ROOT) return;

            TreeNode parent = node.Parent;

            if (node.Index < parent.Nodes.Count - 1 && parent != null)
            {
                parent.Nodes.Remove(node);
                parent.Nodes.Insert(node.Index + 1, node);

            }
            treeBT.SelectedNode = node;
            treeBT.Focus();
        }

        private void MoveNodeLeft(DiTreeNode node)
        {
            if (node == null) return;
            if (node.ClassType == DICLASSTYPES.DICLASSTYPE_ROOT) return;

            DiTreeNode parent = (DiTreeNode)node.Parent;
            if (parent == null) return;
            if (parent.ClassType == DICLASSTYPES.DICLASSTYPE_ROOT) return; //already at the maximum level of left

            DiTreeNode parentroot = (DiTreeNode)parent.Parent;
            if (parentroot == null) return; //no top level to move to

            //check parent root (new parent) node allows any more children
            if (parentroot.ClassType == DICLASSTYPES.DICLASSTYPE_CONDITION)
            {
                DiCondition kCondition = (DiCondition)parentroot.Task;
                if (kCondition.Tasks.Length >= 2)
                {
                    DiMethods.MyDialogShow("Cannot move node. Condition node already contains maximum nodes allowed.", MessageBoxButtons.OK);
                    return;
                }
            }
            else if (parentroot.ClassType == DICLASSTYPES.DICLASSTYPE_FILTER)
            {
                DiMethods.MyDialogShow("Cannot move node. Condition node already contains maximum nodes allowed.", MessageBoxButtons.OK);
                return;
            }

            //TODO:
        }

        private void MoveNodeRight(DiTreeNode node)
        {
            //TODO:
        }
    }
}
