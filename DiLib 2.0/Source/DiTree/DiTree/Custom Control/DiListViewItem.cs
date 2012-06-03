using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
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
