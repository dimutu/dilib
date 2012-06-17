using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiTree
{
    /// <summary>
    /// Local clipboard to keep track of the tree node that needs cut/copy
    /// </summary>
    class DiClipboard
    {
        #region Instancec
        private static DiClipboard m_pkInstance = null;

        public static DiClipboard Instance
        {
            get
            {
                if (m_pkInstance == null)
                {
                    m_pkInstance = new DiClipboard();
                }

                return m_pkInstance;
            }
        }
        #endregion

        private DiTreeNode m_pkNode;
        private bool m_bIsCut;

        /// <summary>
        /// This get called to copy selected node
        /// </summary>
        /// <param name="a_pkNode"></param>
        /// <param name="a_bCut"></param>
        public void Copy(DiTreeNode a_pkNode, bool a_bCut = false)
        {
            m_pkNode = a_pkNode;
            m_bIsCut = a_bCut;
        }

        /// <summary>
        /// Clear the clipboard
        /// </summary>
        public void Clear()
        {
            m_pkNode = null;
            m_bIsCut = false;
        }

        public DiTreeNode Node
        {
            get
            {
                return m_pkNode;
            }
            set
            {
                m_pkNode = value;
            }
        }

        public bool IsCut
        {
            get
            {
                return m_bIsCut;
            }
            set
            {
                m_bIsCut = value;
            }
        }
    }
}
