using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DiTree
{
    /// <summary>
    /// static methods to use on program
    /// </summary>
    static class DiMethods
    {
        //keep reference to MDI status
        private static ToolStripStatusLabel m_pkStatusMsgLable;

        /// <summary>
        /// set status message on the MDI form
        /// </summary>
        public static ToolStripStatusLabel StatusMessageLable
        {
            set
            {
                m_pkStatusMsgLable = value;
            }
        }

        /// <summary>
        /// Custom dialog to display messages
        /// </summary>
        /// <param name="sMessage"></param>
        /// <param name="eButtons"></param>
        /// <returns></returns>
        static public DialogResult MyDialogShow(string sMessage, MessageBoxButtons eButtons)
        {
            return MessageBox.Show(sMessage, "DiTree", eButtons, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Custom input dialog box to enter text in the program
        /// </summary>
        /// <param name="sTitle"></param>
        /// <param name="sOutValue"></param>
        /// <param name="iValueMaxLength"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Set the MDI status message on if its already set
        /// </summary>
        /// <param name="a_zMessage"></param>
        public static void SetStatusMessage(string a_zID)
        {
            if (m_pkStatusMsgLable != null)
            {
                m_pkStatusMsgLable.Text = DiUtility.GetString(a_zID);
            }
        }

        /// <summary>
        /// Remove the status message
        /// </summary>
        public static void ResetStatusMessage()
        {
            if (m_pkStatusMsgLable != null)
            {
                m_pkStatusMsgLable.Text = "";
            }
        }

        /// <summary>
        /// Creates error log 
        /// </summary>
        /// <param name="error"></param>
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
                SetStatusMessage(DiLangID.ID_ERROR_WRITING_LOG);
            }
        }

        /// <summary>
        /// Generates a random string to set unique identifications for debug id
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomString()
        {
            string str = Path.GetRandomFileName();
            str = str.Replace(".", "");
            return str;
        }

        /// <summary>
        /// Set the given string value to check nothing on it to break a SQL query
        /// </summary>
        /// <param name="a_zValue"></param>
        /// <returns></returns>
        public static string SetQueryString(string a_zValue)
        {
            string zVal = a_zValue;
            zVal = zVal.Replace("\"", "");
            zVal = zVal.Replace("'", "");

            return zVal;
        }

    }
}
