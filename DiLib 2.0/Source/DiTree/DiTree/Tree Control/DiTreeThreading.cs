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
        public void SetDebugger(long a_lDebugTaskID)
        {
            if (m_lCurrentDebugID == a_lDebugTaskID)
            {
                return;
            }

            if (m_pkCurrentRunNode != null)
            {
                //change the old running image to normal
                m_pkCurrentRunNode.ImageKey = GetTaskImageKey(m_pkCurrentRunNode.ClassType);
                m_pkCurrentRunNode.SelectedImageKey = m_pkCurrentRunNode.ImageKey;
            }

            DiTreeNode pkRoot = (DiTreeNode)treeBT.Nodes[0];
            DiTreeNode pkDebugTreeNode = GetTreeNode(ref pkRoot, a_lDebugTaskID);

            if (pkDebugTreeNode != null)
            {
                m_lCurrentDebugID = a_lDebugTaskID;
                pkDebugTreeNode.ImageKey = GetImageKeyRun(pkDebugTreeNode.ClassType);
                pkDebugTreeNode.SelectedImageKey = pkDebugTreeNode.ImageKey;
                m_pkCurrentRunNode = pkDebugTreeNode;
            }
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
        /// Gets run task image for currently debugging
        /// </summary>
        /// <param name="a_eClassType"></param>
        /// <returns></returns>
        private string GetImageKeyRun(DICLASSTYPES a_eClassType)
        {
            string zKey = "";
            switch (a_eClassType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    zKey = "condition_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    zKey = "filter_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_ROOT:
                    zKey = "root_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    zKey = "selection_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    zKey = "sequence_run";
                    break;

                default:
                    zKey = "task_run";
                    break;
            }

            return zKey;
        }
    }
}
