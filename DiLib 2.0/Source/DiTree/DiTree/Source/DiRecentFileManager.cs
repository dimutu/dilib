using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DiTree
{
    public class DiRecentFileManager
    {
        private const int MAXCHARLENGTH = 50;
        private const int MAXCOUNT = 10;
        private string m_zSubKeyName = "DiLib";
        private frmMDI m_kMDI;
        private ToolStripMenuItem m_kParentMenuItem;
        private ToolStripMenuItem m_kClearMenuItem;
        private ToolStripMenuItem m_kEmptyMenuItem;
        private ToolStripSeparator m_kSeparatorMenuItem;

        private RegistryKey m_kRegMain;
        private RegistryKey m_kRecentSub;

        public DiRecentFileManager(frmMDI a_mdi, ref ToolStripMenuItem a_parent, 
                                    ref ToolStripMenuItem a_clear,
                                    ref ToolStripMenuItem a_empty,
                                    ref ToolStripSeparator a_separator)
        {
            m_kMDI = a_mdi;
            m_kClearMenuItem = a_clear;
            m_kEmptyMenuItem = a_empty;
            m_kParentMenuItem = a_parent;
            m_kSeparatorMenuItem = a_separator;

            m_kRegMain = Registry.CurrentUser.CreateSubKey(m_zSubKeyName);
            m_kRecentSub = m_kRegMain.CreateSubKey("Recent");

            Load();

        }

        private void Load()
        {
            string[] list = m_kRecentSub.GetValueNames();
            string value;

            foreach (string str in list)
            {
                value = (string)m_kRecentSub.GetValue(str);
                AddMenuItem(value);
            }
            ShowDefault();
        }

        public void AddRecentFile(string a_zFileName)
        {
            try
            {
                string[] list = m_kRecentSub.GetValueNames();
                string value;
                bool bNew = true;
                int i = 0;

                foreach (string str in list)
                {
                    value = (string)m_kRecentSub.GetValue(str);
                    if (value == a_zFileName)
                    {
                        bNew = false;
                        break;
                    }
                }

                if (bNew)
                {
                    if (list.Length >= MAXCOUNT) //maximum reached, remove first
                    {
                        list = m_kRecentSub.GetValueNames();
                        for (i = 0; i <= list.Length - 2; ++i)
                        {
                            m_kRecentSub.SetValue(list[i], (string)m_kRecentSub.GetValue(list[i + 1]));
                        }
                        string delval = (string)m_kRecentSub.GetValue( list[list.Length - 1]);
                        m_kRecentSub.DeleteValue(list[list.Length - 1]);

                        //remove from menu
                        foreach (ToolStripItem menu in m_kParentMenuItem.DropDownItems)
                        {
                            if (menu.Text == delval)
                            {
                                m_kParentMenuItem.DropDownItems.Remove(menu);
                                break;
                            }
                        }
                    }
                    m_kRecentSub.SetValue((m_kRecentSub.ValueCount).ToString(), a_zFileName);
                    AddMenuItem(a_zFileName);
                    ShowDefault();
                }
            }
            catch (Exception ex)
            {
                DiMethods.SetErrorLog(ex);
            }
        }

        public void ClearAll()
        {
            string[] list = m_kRecentSub.GetValueNames();
            foreach (string str in list)
            {
                m_kRecentSub.DeleteValue(str);
            }

            m_kParentMenuItem.DropDownItems.Clear();
            m_kParentMenuItem.DropDownItems.Add(m_kClearMenuItem);
            m_kParentMenuItem.DropDownItems.Add(m_kEmptyMenuItem);
            ShowDefault();
        }

        private void ShowDefault()
        {
            m_kClearMenuItem.Visible = false;
            m_kEmptyMenuItem.Visible = false;
            m_kSeparatorMenuItem.Visible = false;
            if (m_kParentMenuItem.DropDownItems.Count > 3)
            {
                m_kClearMenuItem.Visible = true;
                m_kSeparatorMenuItem.Visible = true;
                m_kParentMenuItem.DropDownItems.Remove(m_kSeparatorMenuItem);
                m_kParentMenuItem.DropDownItems.Remove(m_kClearMenuItem);
                m_kParentMenuItem.DropDownItems.Add(m_kSeparatorMenuItem);
                m_kParentMenuItem.DropDownItems.Add(m_kClearMenuItem);
            }
            else
            {
                m_kEmptyMenuItem.Visible = true;
            }
        }

        private void AddMenuItem(string a_zFileName)
        {
            //show only 50 chars on the menu
            string filename = a_zFileName;
            if (filename.Length > MAXCHARLENGTH)
            {
                //and not show any parts of path, but first \ on the path at the end strings
                string fileend = filename.Substring(filename.Length - MAXCHARLENGTH + 3);
                fileend = fileend.Substring(fileend.IndexOf("\\"));
                filename = filename.Substring(0, 3) + "..." + fileend; //create string
            }
            ToolStripItem menu = m_kParentMenuItem.DropDownItems.Add(filename);
            menu.Tag = a_zFileName;
            menu.Click += toolStripRecentFile_Click;
        }
            

        private void toolStripRecentFile_Click(object sender, EventArgs e)
        {
            ToolStripItem menu = (ToolStripItem)sender;
            if (menu != null)
            {
                m_kMDI.OpenFile(menu.Tag.ToString());
            }
        }
    }
}
