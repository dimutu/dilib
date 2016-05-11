using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
    /// <summary>
    /// List box item which shows task types uses to drag drop to tree
    /// </summary>
    class DiListViewItem : ListViewItem
    {
        private DICLASSTYPES m_eTaskType;

        public DICLASSTYPES TaskType
        {
            get
            {
                return m_eTaskType;
            }
            set
            {
                m_eTaskType = value;
            }
        }
    }
}
