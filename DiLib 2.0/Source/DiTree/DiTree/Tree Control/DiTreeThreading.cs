using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
    public partial class DiTree : UserControl
    {
        private long m_lCurrentDebugID;
        private DiTreeNode m_pkCurrentRunNode;

        /// <summary>
        /// Set debugging node to display
        /// </summary>
        /// <param name="a_lDebugTaskID"></param>
        public DiTreeNode SetDebugger(long a_lDebugTaskID)
        {
            if (m_pkCurrentRunNode != null)
            {
                //change the old running image to normal
                if (m_pkCurrentRunNode.Task.Breakpoint)
                {
                    m_pkCurrentRunNode.ImageKey = DiUtility.GetTaskBreakImageKey(m_pkCurrentRunNode.ClassType);
                }
                else
                {
                    m_pkCurrentRunNode.ImageKey = DiUtility.GetTaskImageKey(m_pkCurrentRunNode.ClassType);
                }
                m_pkCurrentRunNode.SelectedImageKey = m_pkCurrentRunNode.ImageKey;
            }

            DiTreeNode pkRoot = (DiTreeNode)treeBT.Nodes[0];
            DiTreeNode pkDebugTreeNode = GetTreeNode(ref pkRoot, a_lDebugTaskID);

            if (pkDebugTreeNode != null)
            {
                m_lCurrentDebugID = a_lDebugTaskID;
                
                if (pkDebugTreeNode.Task.Breakpoint)
                {
                    pkDebugTreeNode.ImageKey = DiUtility.GetTaskBreakRunImageKey(pkDebugTreeNode.ClassType);
                }
                else
                {
                    pkDebugTreeNode.ImageKey = DiUtility.GetImageKeyRun(pkDebugTreeNode.ClassType);
                }

                pkDebugTreeNode.SelectedImageKey = pkDebugTreeNode.ImageKey;
                m_pkCurrentRunNode = pkDebugTreeNode;
            }

            return m_pkCurrentRunNode;
        }

        public DiTreeNode GetTreeNode(long a_lDebugTaskID)
        {
            DiTreeNode root = (DiTreeNode)treeBT.Nodes[0];
            return GetTreeNode(ref root, a_lDebugTaskID);
        }

        /// <summary>
        /// Return tree node matching the debug id
        /// </summary>
        /// <param name="a_pkNode"></param>
        /// <param name="a_lDebugTaskID"></param>
        /// <returns></returns>
        DiTreeNode GetTreeNode(ref DiTreeNode a_pkNode, long a_lDebugTaskID)
        {
            DiTreeNode pkReturnNode = null;

            //this is the node that looking for
            if (a_pkNode.DebuggerID == a_lDebugTaskID)
            {
                return a_pkNode;
            }

            //look for its childern
            foreach (TreeNode pktreeNode in a_pkNode.Nodes)
            {
                DiTreeNode pkBNode = (DiTreeNode)pktreeNode;
                pkReturnNode = GetTreeNode(ref pkBNode, a_lDebugTaskID);

                if (pkReturnNode != null)
                {
                    return pkReturnNode;
                }

            }


            return pkReturnNode;
        }

       

        /// <summary>
        /// Gets currently selected node in the tree
        /// </summary>
        /// <returns></returns>
        public DiTreeNode ToggleBreakpoint()
        {
            DiTreeNode node = (DiTreeNode)treeBT.SelectedNode;
            if (node != null)
            {
                node.ToggleBreakpoint();
                if (node.Task.Breakpoint)
                {
                    node.ImageKey = DiUtility.GetTaskBreakImageKey(node.ClassType);
                }
                else
                {
                    node.ImageKey = DiUtility.GetTaskImageKey(node.ClassType);
                }
                node.SelectedImageKey = node.ImageKey;
            }
            return node;
        }

        public void RemoveAllBreakpoints()
        {
            DiTreeNode node = (DiTreeNode)treeBT.Nodes[0];
            RemoveAllBreakpoints(ref node);
        }

        private void RemoveAllBreakpoints(ref DiTreeNode node)
        {
            DiTreeNode childnode;
            if (node.Task.Breakpoint)
            {
                node.Task.Breakpoint = false;
                node.ImageKey = DiUtility.GetTaskImageKey(node.ClassType);
                node.SelectedImageKey = node.ImageKey;
            }
            for (int i = node.Nodes.Count - 1; i >= 0; --i)
            {
                childnode = (DiTreeNode)node.Nodes[i];
                RemoveAllBreakpoints(ref childnode);
            }
        }
    }
}
