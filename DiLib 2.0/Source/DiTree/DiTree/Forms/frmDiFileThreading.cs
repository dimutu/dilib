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
                            //if (!DiGlobals.IsDebugging)
                            //{
                            //    pkTree.SetDebugger(a_lDebugTaskID);
                            //}
                            //else if (DiGlobals.IsDebugging && DiGlobals.IsDebugNextOn)
                            //{
                            //    pkTree.SetDebugger(a_lDebugTaskID);
                            //    DiGlobals.IsDebugNextOn = false; //reset flag after updating tree current pos
                            //}

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
