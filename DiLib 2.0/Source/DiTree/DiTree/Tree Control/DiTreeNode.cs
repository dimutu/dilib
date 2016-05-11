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
    public class DiTreeNode : TreeNode
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

        public string ToolTip
        {
            get
            {
                return string.Format("Enum: {0}\nClass Name:{1}\nType: {2}\nScript :{3}\nDebug ID: {4}",
                  m_kTaskNode.EnumID.ToString(), m_kTaskNode.ClassName, m_kTaskNode.ClassType.ToString(),
                  m_kTaskNode.ScriptFile, m_kTaskNode.DebuggerID.ToString()); ;
            }
        }

        public void ToggleBreakpoint()
        {
            m_kTaskNode.Breakpoint = !m_kTaskNode.Breakpoint;
        }
    }
}
