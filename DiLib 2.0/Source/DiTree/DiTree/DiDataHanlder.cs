using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DiTree
{
    /// <summary>
    /// Handles the data table as an instance which can access by all the tree files
    /// </summary>
    class DiDataHanlder
    {
        #region Instance
        //instance
        private static DiDataHanlder m_pkInstance = null;

        public static DiDataHanlder instance
        {
            get
            {
                if (m_pkInstance == null)
                {
                    m_pkInstance = new DiDataHanlder();
                }

                return m_pkInstance;
            }
        }
       
        #endregion

        //class properties
        private DataTable m_dtData;

        //data table column names
        public const string DATAFIELD_ID = "id";
        public const string DATAFIELD_ENUMNAME = "Enum";
        public const string DATAFIELD_ISTEMPATE = "IsTemplate";
        public const string DATAFIELD_CLASSTYPE = "ClassType";
        public const string DATAFIELD_CLASSNAME = "ClassName";
        public const string DATAFIELD_TEMPLATECLASS = "TemplateClass";

        private DiDataHanlder()
        {
            InitializeDataTable();
        }

        /// <summary>
        /// creates the data table
        /// </summary>
        private void InitializeDataTable()
        {
            m_dtData = new DataTable();
            DataColumn kIDCol = m_dtData.Columns.Add(DATAFIELD_ID, typeof(int)); //running number, just for reference not used in actual header file
            kIDCol.AutoIncrementSeed = 1; //start from 1, 0 is root
            kIDCol.AutoIncrement = true;
            kIDCol.ReadOnly = true;

            DataColumn kEnumNameCol = m_dtData.Columns.Add(DATAFIELD_ENUMNAME, typeof(string)); //enum name
            //kEnumNameCol.Unique = true; //had to remove as the user update this after adding a new node

            m_dtData.Columns.Add(DATAFIELD_ISTEMPATE, typeof(bool)); //the class is template class or deriving
            m_dtData.Columns.Add(DATAFIELD_CLASSTYPE, typeof(DICLASSTYPES)); //class type
            m_dtData.Columns.Add(DATAFIELD_CLASSNAME, typeof(string)); //class name this can be template class or derived
            m_dtData.Columns.Add(DATAFIELD_TEMPLATECLASS, typeof(string)); //is it Player, Enemy tyep class
        }

        /// <summary>
        /// Adds new data row to the enumeration table
        /// </summary>
        /// <param name="a_zEnumName"></param>
        /// <param name="a_bIsTemplate"></param>
        /// <param name="a_eClassType"></param>
        /// <param name="a_zClassName"></param>
        /// <param name="a_zTempleteClassName"></param>
        /// <returns></returns>
        public int AddNew(string a_zEnumName, bool a_bIsTemplate, DICLASSTYPES a_eClassType,
            string a_zClassName, string a_zTempleteClassName)
        {
            try
            {
                int id = 0;

                DataRow dr = m_dtData.NewRow();
                int.TryParse(dr[DATAFIELD_ID].ToString(), out id);

                dr[DATAFIELD_ENUMNAME] = a_zEnumName;
                dr[DATAFIELD_ISTEMPATE] = a_bIsTemplate;
                dr[DATAFIELD_CLASSTYPE] = a_eClassType;
                dr[DATAFIELD_CLASSNAME] = a_zClassName;
                dr[DATAFIELD_TEMPLATECLASS] = a_zTempleteClassName;

                m_dtData.Rows.Add(dr);

                return id;

            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        /// Adds new row when adding a node, so most of the info isnt available at that point
        /// </summary>
        /// <param name="a_eClassType"></param>
        /// <param name="a_zTempleteClassName"></param>
        /// <returns></returns>
        public int AddNew(DICLASSTYPES a_eClassType, string a_zTempleteClassName)
        {
            try
            {
                int id = 0;

                DataRow dr = m_dtData.NewRow();
                int.TryParse(dr[DATAFIELD_ID].ToString(), out id);

                dr[DATAFIELD_ENUMNAME] = DiMethods.GenerateRandomString();
                dr[DATAFIELD_ISTEMPATE] = false;
                dr[DATAFIELD_CLASSTYPE] = a_eClassType;
                dr[DATAFIELD_CLASSNAME] = "";
                dr[DATAFIELD_TEMPLATECLASS] = a_zTempleteClassName;

                m_dtData.Rows.Add(dr);

                return id;

            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        /// Get the row from the task id
        /// </summary>
        /// <param name="a_iTaskID"></param>
        /// <returns></returns>
        public DataRow[] GetRow(int a_iTaskID)
        {
            return m_dtData.Select(DATAFIELD_ID + "=" + a_iTaskID);
        }



    }
}
