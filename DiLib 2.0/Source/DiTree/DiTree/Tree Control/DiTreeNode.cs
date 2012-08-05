using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
    /// <summary>
    /// extended tree node to have behaviour tree properties in the tree view
    /// </summary>
    class DiTreeNode : TreeNode
    {
        private DiTask m_kTaskNode; //task represent by the tree node in the tree view

        /// <summary>
        /// DiTask this node represent
        /// </summary>
        public DiTask Task
        {
            get
            {
                return m_kTaskNode;
            }
            set
            {
                m_kTaskNode = value;
                m_kTaskNode.Parent = this; //set the parent as this for the task
            }
        }

        /// <summary>
        /// class type getting from the set taks node
        /// </summary>
        public DICLASSTYPES ClassType
        {
            get
            {
                return m_kTaskNode.ClassType;
            }
        }

        public string ClassName
        {
            get
            {
                return m_kTaskNode.ClassName;
            }
        }

        public int EnumID
        {
            get
            {
                return m_kTaskNode.EnumID;
            }
        }

        public long DebuggerID
        {
            get
            {
                return m_kTaskNode.DebuggerID;
            }
        }

        public string ScriptFile
        {
            get
            {
                return m_kTaskNode.ScriptFile;
            }
        }

    }
}
