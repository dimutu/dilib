/*
****************************************************************************************************************************
* DiLib v2.0 (dilib.dimutu.com)
*
* This software is provided 'as-is', without any express or implied warranty. 
* In no event will the authors be held liable for any
* damages arising from the use of this software.
* 
* Permission is granted to anyone to use this software for any
* purpose, including commercial applications, subject to the following restrictions:
* 
* 1. The origin of this software must not be misrepresented; you must
* not claim that you wrote the original software. If you use this
* software in a product, an acknowledgment in the product documentation
* would be appreciated.
*
* 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
* 
* 3. This notice may not be removed or altered from any source distribution.
* 
* 4. Third party open source "TinyXML" is used in this program, and for more information please see its own terms of use.
*******************************************************************************************************************************
*/
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
            this.Text = "DiTree" + a_iIndex.ToString();
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
