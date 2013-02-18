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
            string[] list = m_kRecentSub.GetValueNames();
            string value;
            bool bNew = true;

            if (list.Length < MAXCOUNT)
            {
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
                    m_kRecentSub.SetValue(m_kRecentSub.ValueCount.ToString(), a_zFileName);
                    AddMenuItem(a_zFileName);
                    ShowDefault();
                }
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
            ToolStripItem menu = m_kParentMenuItem.DropDownItems.Add(a_zFileName);
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
