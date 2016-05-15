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
    public partial class frmDiFile : Form
    {
        public string GetTabTreeName()
        {
            if (tabDiFile.SelectedIndex >= TABSTART_INDEX)
            {
                if (tabDiFile.SelectedTab != null)
                {
                    DiTabPage kTab = (DiTabPage)tabDiFile.SelectedTab;
                    return kTab.Tree.TreeName;
                }
            }
            return "";
        }

        public DiTreeNode SetTreeDebugData(string a_zDebugTreeID, long a_lDebugTaskID)
        {
            //only if tree is active
            if (tabDiFile.SelectedIndex >= TABSTART_INDEX)
            {
                if (tabDiFile.SelectedTab.GetType() == typeof(DiTabPage))
                {
                    DiTabPage tabActive = (DiTabPage)tabDiFile.SelectedTab;

                    if (tabActive.Text.CompareTo(a_zDebugTreeID) == 0) //active tab is the debug data sent for
                    {
                        if (tabActive.Tree != null)
                        {
                            DiTree pkTree = tabActive.Tree;
                            DiTreeNode node  = pkTree.SetDebugger(a_lDebugTaskID);
                            //send node is updated back to C++
                            return node;
                        }
                    }
                }


            }

            return null;

        }

        public DiTreeNode ToggleBreakpoint()
        {
            if (tabDiFile.SelectedIndex >= TABSTART_INDEX)
            {
                if (tabDiFile.SelectedTab.GetType() == typeof(DiTabPage))
                {
                    DiTabPage tabActive = (DiTabPage)tabDiFile.SelectedTab;
                    if (tabActive != null)
                    {
                        return tabActive.Tree.ToggleBreakpoint();
                    }
                }
            }
            return null;
        }

        public void RemoveAllBreakpoints()
        {
            if (tabDiFile.SelectedIndex >= TABSTART_INDEX)
            {
                if (tabDiFile.SelectedTab.GetType() == typeof(DiTabPage))
                {
                    DiTabPage tabActive = (DiTabPage)tabDiFile.SelectedTab;
                    if (tabActive != null)
                    {
                        tabActive.Tree.RemoveAllBreakpoints();
                    }
                }
            }
        }

    }
}
