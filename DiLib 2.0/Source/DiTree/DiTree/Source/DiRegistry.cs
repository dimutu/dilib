using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;

namespace DiTree
{
    public static class DiRegistry
    {
        private static string m_zSubKeyName = "DiLib";
        private static RegistryKey m_kRegMain;

        private static bool m_bShowToolText;
        private static bool m_bInitialized = false; //to avoid getting init when opening multiple windows
        private static string m_zSourceExportPath; //last place source exported

        public static void Initialize()
        {
            if (!m_bInitialized)
            {
                m_kRegMain = Registry.CurrentUser.CreateSubKey(m_zSubKeyName);

                object val = m_kRegMain.GetValue("ShowToolText");
                if (val != null)
                {
                    if (!bool.TryParse((string)val, out m_bShowToolText))
                    {
                        m_bShowToolText = true;
                    }
                }
                else
                {
                    m_bShowToolText = true;
                }

                m_zSourceExportPath = "";
                val = m_kRegMain.GetValue("ExportSourcePath");
                if (val != null)
                {
                    m_zSourceExportPath = val.ToString();
                }
                if (!Directory.Exists(m_zSourceExportPath))
                {
                    m_zSourceExportPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                }

                m_bInitialized = true;
            }
        }

        public static bool ShowToolText
        {
            get
            {
                return m_bShowToolText;
            }
            set
            {
                m_bShowToolText = value;
                m_kRegMain.SetValue("ShowToolText", m_bShowToolText);
            }
        }

        public static string ExportSourcePath
        {
            get
            {
                return m_zSourceExportPath;
            }
            set
            {
                m_zSourceExportPath = value;
                m_kRegMain.SetValue("ExportSourcePath", m_zSourceExportPath);
            }
        }
    }
}
