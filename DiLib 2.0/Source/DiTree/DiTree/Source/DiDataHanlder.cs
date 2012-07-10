using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

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

        //default initialize data enum ids
        protected int m_iDefaultTaskID;
        protected int m_iDefaultConditionID;
        protected int m_iDefaultFilterID;
        protected int m_iDefaultSequenceID;
        protected int m_iDefaultSelectionID;

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
            m_iDefaultConditionID = AddNew(DICLASSTYPES.DICLASSTYPE_CONDITION, a_zTemplateClass);
            m_iDefaultFilterID =  AddNew(DICLASSTYPES.DICLASSTYPE_FILTER, a_zTemplateClass);
            m_iDefaultSelectionID = AddNew(DICLASSTYPES.DICLASSTYPE_SELECTION, a_zTemplateClass);
            m_iDefaultSequenceID = AddNew(DICLASSTYPES.DICLASSTYPE_SEQUENCE, a_zTemplateClass);
            m_iDefaultTaskID = AddNew(DICLASSTYPES.DICLASSTYPE_TASK, a_zTemplateClass);
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
        public int AddNew(DICLASSTYPES a_eClassType, string a_zTempleteClassName)
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

               //zClassName += id.ToString(); //to make class name unique

                dr[DATAFIELD_ISTEMPATE] = true;
                dr[DATAFIELD_CLASSTYPE] = a_eClassType;
                dr[DATAFIELD_CLASSNAME] = zClassName;
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
        /// Get the row from the task id
        /// </summary>
        /// <param name="a_iTaskID"></param>
        /// <returns></returns>
        public DataRow GetRow(int a_iTaskID)
        {
            DataRow dr = null;
            DataRow [] akRows =  m_dtData.Select(DATAFIELD_ID + "=" + a_iTaskID);

            if (akRows.Length == 1)
            {
                dr = akRows[0];
            }

            return dr;
        }

        /// <summary>
        /// Get row by class name and template class
        /// </summary>
        /// <param name="a_zClassName"></param>
        /// <returns></returns>
        public DiDataRow GetRow(string a_zClassName, string a_zTemplateClass)
        {
            DiDataRow dr = null;
            string zQuery = DATAFIELD_CLASSNAME + "='" + DiMethods.SetQueryString(a_zClassName) + "'" +
                " and " + DATAFIELD_TEMPLATECLASS + "='" + DiMethods.SetQueryString(a_zTemplateClass) + "'";
            DataRow[] akRows = m_dtData.Select(zQuery);

            if (akRows.Length == 1)
            {
                dr = new DiDataRow();
                dr.Data = akRows[0];
            }

            return dr;
        }

        /// <summary>
        /// Gets the default data for given class type
        /// </summary>
        /// <param name="a_eClassType"></param>
        /// <returns></returns>
        public DiDataRow GetTemplateDataRow(DICLASSTYPES a_eClassType, string a_zTemplateClass)
        {
            DiDataRow dr = null;
            DataRow [] akRows = null;
            int id = -1;
            string zQuery = "";
            switch (a_eClassType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    {
                        id = m_iDefaultConditionID;
                        break;
                    }
                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    {
                        id = m_iDefaultFilterID;
                        break;
                    }
                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    {
                        id = m_iDefaultSelectionID;
                        break;
                    }
                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    {
                        id = m_iDefaultSequenceID;
                        break;
                    }
                default:
                    {
                        id = m_iDefaultTaskID;
                        break;
                    }
            }

            zQuery = DATAFIELD_ID + "=" + id.ToString() +
                " and " + DATAFIELD_TEMPLATECLASS + "='" + DiMethods.SetQueryString(a_zTemplateClass) + "'";
            akRows = m_dtData.Select(zQuery);

            if (akRows.Length == 1)
            {
                dr = new DiDataRow();
                dr.Data = akRows[0];
            }

            return dr;
        }

        /// <summary>
        /// Retruns data rows matching the class type
        /// </summary>
        /// <param name="a_eType"></param>
        /// <returns></returns>
        public DataRow[] GetRows(DICLASSTYPES a_eType)
        {
            DataRow[] dr = null;
            string typeString = ((int)a_eType).ToString();
            dr = m_dtData.Select(DATAFIELD_CLASSTYPE + "=" + typeString);


            return dr;
        }

        /// <summary>
        /// Write the data table to the passing in xml writer
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXMLData(ref XmlWriter writer)
        {
            //add enums
            writer.WriteStartElement(DiXMLElements.XMLELEMENT_ENUMLIST);
            writer.WriteAttributeString(DiXMLElements.XMLELEMENT_ENUMCOUNT, m_dtData.Rows.Count.ToString());
            for (int iRow = 0; iRow < m_dtData.Rows.Count; iRow++)
            {
                DataRow dr = m_dtData.Rows[iRow];
                writer.WriteStartElement(DiXMLElements.XMLELEMENT_ENUM);
                writer.WriteAttributeString(DiXMLElements.XMLELEMENT_ENUMID, dr[DATAFIELD_ID].ToString());

                if (dr[DATAFIELD_ISTEMPATE].ToString().ToLower() == "true")
                {
                    writer.WriteAttributeString(DiXMLElements.XMLELEMENT_ISTEMPLATE, "True");
                }
                else
                {
                    writer.WriteAttributeString(DiXMLElements.XMLELEMENT_ISTEMPLATE, "False");
                }
                int iID = (int)dr[DATAFIELD_CLASSTYPE];
                writer.WriteAttributeString(DiXMLElements.XMLELEMENT_CLASSTYPE, iID.ToString());
                writer.WriteAttributeString(DiXMLElements.XMLELEMENT_CLASSNAME, dr[DATAFIELD_CLASSNAME].ToString());
                writer.WriteAttributeString(DiXMLElements.XMLELEMENT_TEMPLATECLASS, dr[DATAFIELD_TEMPLATECLASS].ToString());

                writer.WriteEndElement();

            }
            writer.WriteEndElement(); //end enums
        }
    }
}
