using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DiTree
{
    static class DiMethods
    {
        private static ToolStripStatusLabel m_pkStatusMsgLable;


        public static ToolStripStatusLabel StatusMessageLable
        {
            set
            {
                m_pkStatusMsgLable = value;
            }
        }

        static public DialogResult MyDialogShow(string sMessage, MessageBoxButtons eButtons)
        {
            return MessageBox.Show(sMessage, "Di Trees", eButtons, MessageBoxIcon.Information);
        }

        static public DialogResult MyInputDialogShow(string sTitle, ref string sOutValue, int iValueMaxLength = 10)
        {
            frmInputBox f = new frmInputBox();
            f.Title = sTitle;
            f.InputText = sOutValue;
            f.TextMaxLength = iValueMaxLength;

            DialogResult d = f.ShowDialog();
            if (d == DialogResult.OK)
            {
                sOutValue = f.InputText;
            }

            return d;
        }

        static public void SetStatusMessage(string a_zMessage)
        {
            if (m_pkStatusMsgLable != null)
            {
                m_pkStatusMsgLable.Text = a_zMessage;
            }
        }

        public static void ResetStatusMessage()
        {
            if (m_pkStatusMsgLable != null)
            {
                m_pkStatusMsgLable.Text = "";
            }
        }

        public static void SetErrorLog(Exception error)
        {
            try
            {
                TextWriter tw = new StreamWriter("ErrorLog.log", true);
                tw.WriteLine(DateTime.Now.ToString() + ", Error: " + error.ToString());
                tw.Close();
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#endif
                SetStatusMessage("Unable to write to error log.");
            }
        }

    }
}
