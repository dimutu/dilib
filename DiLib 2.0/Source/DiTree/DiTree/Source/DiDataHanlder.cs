using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DiTree
{
    /// <summary>
    /// Handles the data table for each tree file
    /// </summary>
    public class DiDataHanlder
    {
        //class properties
        private DataTable m_dtData;

        //data table column names
        public const string DATAFIELD_ID = "id";
        public const string DATAFIELD_ISTEMPATE = "IsTemplate";
        public const string DATAFIELD_CLASSTYPE = "ClassType";
        public const string DATAFIELD_CLASSNAME = "ClassName";
        public const string DATAFIELD_TEMPLATECLASS = "TemplateClass";

        public DiDataHanlder()
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

            m_dtData.Columns.Add(DATAFIELD_ISTEMPATE, typeof(bool)); //the class is template class or deriving
            m_dtData.Columns.Add(DATAFIELD_CLASSTYPE, typeof(DICLASSTYPES)); //class type
            m_dtData.Columns.Add(DATAFIELD_CLASSNAME, typeof(string)); //class name this can be template class or derived
            m_dtData.Columns.Add(DATAFIELD_TEMPLATECLASS, typeof(string)); //is it Player, Enemy type class
        }

        /// <summary>
        /// creates default data for template class types
        /// </summary>
        /// <param name="a_zTemplateClass"></param>
        public void InitializeTemplateData(string a_zTemplateClass)
        {
            AddNew(true, DICLASSTYPES.DICLASSTYPE_SELECTION, "DiSelection", a_zTemplateClass);
            AddNew(true, DICLASSTYPES.DICLASSTYPE_SEQUENCE, "DiSequece", a_zTemplateClass);
            AddNew(true, DICLASSTYPES.DICLASSTYPE_FILTER, "DiFilter", a_zTemplateClass);
        }

        /// <summary>
        /// Adds new data row to the enumeration table
        /// </summary>
        /// <param name="a_bIsTemplate"></param>
        /// <param name="a_eClassType"></param>
        /// <param name="a_zClassName"></param>
        /// <param name="a_zTempleteClassName"></param>
        /// <returns></returns>
        public int AddNew(bool a_bIsTemplate, DICLASSTYPES a_eClassType,
            string a_zClassName, string a_zTempleteClassName)
        {
            try
            {
                int id = 0;

                DataRow dr = m_dtData.NewRow();
                int.TryParse(dr[DATAFIELD_ID].ToString(), out id);

                dr[DATAFIELD_ISTEMPATE] = a_bIsTemplate;
                dr[DATAFIELD_CLASSTYPE] = a_eClassType;
                dr[DATAFIELD_CLASSNAME] = a_zClassName;
                dr[DATAFIELD_TEMPLATECLASS] = a_zTempleteClassName;

                m_dtData.Rows.Add(dr);

                return id;

            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#endif
                return -1;
            }
        }

        /// <summary>
        /// Adds new row when adding a node, so most of the info isnt available at that point
        /// and return the new data row
        /// </summary>
        /// <param name="a_eClassType"></param>
        /// <param name="a_zTempleteClassName"></param>
        /// <param name="a_bIsTemplate"></param>
        /// <returns></returns>
        public DataRow AddNew(DICLASSTYPES a_eClassType, string a_zTempleteClassName)
        {
            try
            {
                int id = 0;
                string zClassName = "Di" + a_zTempleteClassName; //genereate class name

                switch (a_eClassType)
                {
                    case DICLASSTYPES.DICLASSTYPE_CONDITION:
                        {
                            zClassName += "Condition";
                            break;
                        }
                    case DICLASSTYPES.DICLASSTYPE_FILTER:
                        {
                            zClassName += "Filter";
                            break;
                        }
                    case DICLASSTYPES.DICLASSTYPE_SELECTION:
                        {
                            zClassName += "Selection";
                            break;
                        }
                    case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                        {
                            zClassName += "Sequence";
                            break;
                        }
                    default:
                        {
                            zClassName += "Task";
                            break;
                        }
                }

                DataRow dr = m_dtData.NewRow();
                int.TryParse(dr[DATAFIELD_ID].ToString(), out id);

                zClassName += id.ToString(); //to make class name unique

                dr[DATAFIELD_ISTEMPATE] = true;
                dr[DATAFIELD_CLASSTYPE] = a_eClassType;
                dr[DATAFIELD_CLASSNAME] = zClassName;
                dr[DATAFIELD_TEMPLATECLASS] = a_zTempleteClassName;

                m_dtData.Rows.Add(dr);

                return dr;

            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(e.ToString());
#endif
                return null;
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
