using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
    /// <summary>
    /// This contains the accessors for manipulate the nodes from main application form
    /// from its menus and toolbar
    /// </summary>
    public partial class DiTree : UserControl
    {
        /// <summary>
        /// Move the currently selected node in given direction
        /// </summary>
        /// <param name="a_eDirection"></param>
        public void MoveNode(TREENODEMOVEMENT a_eDirection)
        {
        }

        /// <summary>
        /// Select the current node as copying source to the DiClipboard
        /// </summary>
        public void CopyNode()
        {
        }

        /// <summary>
        /// Select the current node as moving source to the DiClipboard
        /// </summary>
        public void CutNode()
        {
        }

        /// <summary>
        /// Paste the currently copied node in the Clipboard to the selected node
        /// </summary>
        public void PasteNode()
        {
        }

        /// <summary>
        /// Remove the currently selected node
        /// </summary>
        public void RemoveNode()
        {

        }

        public string TreeName
        {
            get
            {
                return m_zTreeName;
            }
            set
            {
                m_zTreeName = value;
            }
        }

        public DiDataHanlder DataHandler
        {
            set
            {
                m_pkDataHandler = value;
            }
        }

    }
}
