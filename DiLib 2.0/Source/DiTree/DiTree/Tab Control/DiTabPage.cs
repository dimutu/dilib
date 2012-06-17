using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
    public class DiTabPage : TabPage
    {
        protected DiTree m_pkTreeControl; //tree user control

        /// <summary>
        /// creates new tab and new tree control with index number as text
        /// </summary>
        /// <param name="a_iIndex"></param>
        public DiTabPage(int a_iIndex)
            : base()
        {
            this.Text = "Tree " + a_iIndex.ToString();
            m_pkTreeControl = new DiTree();
            m_pkTreeControl.Parent = this;
            m_pkTreeControl.Dock = DockStyle.Fill;
            m_pkTreeControl.TreeName = this.Text;
        }

        public DiTree Tree
        {
            get
            {
                return m_pkTreeControl;
            }
        }


    }
}
