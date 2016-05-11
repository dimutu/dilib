using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiTree
{
    /// <summary>
    /// Local clipboard to keep track of the tree node that needs cut/copy
    /// </summary>
    public static class DiClipboard
    {
        private static DiTreeNode m_pkNode;
        private static bool m_bIsCut;

        /// <summary>
        /// This get called to copy selected node
        /// </summary>
        /// <param name="a_pkNode"></param>
        /// <param name="a_bCut"></param>
        public static void Copy(DiTreeNode a_pkNode, bool a_bCut = false)
        {
            m_pkNode = a_pkNode;
            m_bIsCut = a_bCut;
        }

        /// <summary>
        /// Clear the clipboard
        /// </summary>
        public static void Clear()
        {
            m_pkNode = null;
            m_bIsCut = false;
        }

        public static DiTreeNode Node
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

        public static bool IsCut
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
