using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;

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

        /// <summary>
        /// Constructor
        /// </summary>
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
            AddNew(DICLASSTYPES.DICLASSTYPE_CONDITION, a_zTemplateClass);
            AddNew(DICLASSTYPES.DICLASSTYPE_FILTER, a_zTemplateClass);
            AddNew(DICLASSTYPES.DICLASSTYPE_SELECTION, a_zTemplateClass);
            AddNew(DICLASSTYPES.DICLASSTYPE_SEQUENCE, a_zTemplateClass);
            AddNew(DICLASSTYPES.DICLASSTYPE_TASK, a_zTemplateClass);
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

                //check this already exitss before adding
                string zQuery = "";

                zQuery = DATAFIELD_CLASSNAME + "='" + DiMethods.SetQueryString(zClassName) + "'" +
                    " and " + DATAFIELD_TEMPLATECLASS + "='" + DiMethods.SetQueryString(a_zTempleteClassName) + "'";
                DataRow[] akRows = m_dtData.Select(zQuery);
                DataRow dr;
                if (akRows.Length == 0) //creates new record
                {
                    dr = m_dtData.NewRow();
                    int.TryParse(dr[DATAFIELD_ID].ToString(), out id);

                    //zClassName += id.ToString(); //to make class name unique

                    dr[DATAFIELD_ISTEMPATE] = true;
                    dr[DATAFIELD_CLASSTYPE] = a_eClassType;
                    dr[DATAFIELD_CLASSNAME] = zClassName;
                    dr[DATAFIELD_TEMPLATECLASS] = a_zTempleteClassName;

                    m_dtData.Rows.Add(dr);
                }
                else
                {
                    dr = akRows[0];
                    id = (int)dr[DATAFIELD_ID]; //already exists, return the enum id
                }

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
        public DiDataRow GetRow(int a_iTaskID)
        {
            DiDataRow dr = null;
            DataRow [] akRows =  m_dtData.Select(DATAFIELD_ID + "=" + a_iTaskID);

            if (akRows.Length == 1)
            {
                dr = new DiDataRow();
                dr.Data = akRows[0];
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
            string zQuery = "";
            zQuery = DATAFIELD_CLASSTYPE + "=" + ((int)a_eClassType).ToString() +
                " and " + DATAFIELD_TEMPLATECLASS + "='" + DiMethods.SetQueryString(a_zTemplateClass) + "'" +
                " and " + DATAFIELD_ISTEMPATE + "='true'";
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
        /// Returns data rows matching class type and template
        /// </summary>
        /// <param name="a_eType"></param>
        /// <param name="a_zTemplateClass"></param>
        /// <returns></returns>
        public DataRow[] GetRows(DICLASSTYPES a_eType, string a_zTemplateClass)
        {
            DataRow[] dr = null;
            string typeString = ((int)a_eType).ToString();
            dr = m_dtData.Select(DATAFIELD_CLASSTYPE + "=" + typeString + 
                " and " + DATAFIELD_TEMPLATECLASS + "='" + DiMethods.SetQueryString(a_zTemplateClass) + "'");


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

        /// <summary>
        /// Reads xml enum data and creates the table
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXMLData(ref XmlReader reader)
        {
            bool bEnumRead = false;
            while (reader.Read())
            {
                switch (reader.Name)
                {
                    case DiXMLElements.XMLELEMENT_ENUMLIST:
                        {
                            if (reader.NodeType == XmlNodeType.EndElement)
                            {
                                //all enumerations added
                                bEnumRead = true;
                            }
                            break;
                        }

                    case DiXMLElements.XMLELEMENT_ENUM:
                        {
                            DataRow dr = m_dtData.NewRow();
                            int iVal = -1;

                            dr[DATAFIELD_ID] = Convert.ToInt32(reader[DiXMLElements.XMLELEMENT_ENUMID].ToString().Trim()); //id
                            dr[DATAFIELD_CLASSNAME] = reader[DiXMLElements.XMLELEMENT_CLASSNAME].ToString().Trim(); //enum name
                            if (reader[DiXMLElements.XMLELEMENT_ISTEMPLATE].ToString().Trim().ToLower() == "true") //is template
                            {
                                dr[DATAFIELD_ISTEMPATE] = true;
                            }
                            else
                            {
                                dr[DATAFIELD_ISTEMPATE] = false;
                            }

                            if (int.TryParse(reader[DiXMLElements.XMLELEMENT_CLASSTYPE].ToString().Trim(), out iVal))
                            {
                                dr[DATAFIELD_CLASSTYPE] = (DICLASSTYPES)iVal; //class type
                            }
                            else
                            {
                                dr[DATAFIELD_CLASSTYPE] = 0;
                            }
                            dr[DATAFIELD_TEMPLATECLASS] = reader[DiXMLElements.XMLELEMENT_TEMPLATECLASS].ToString().Trim(); //template class name
                            m_dtData.Rows.Add(dr);
                            //iECounter++;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                
                }//end switch

                if (bEnumRead) //all the enums read and read close element, exit loop and function
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Checks all the configuration data is valid and filled
        /// </summary>
        /// <returns></returns>
        public bool IsConfigValid()
        {
            //check any empty strings are there
            bool isOK = true;
            for (int iRow = 0; iRow < m_dtData.Rows.Count; iRow++)
            {
                DataRow dr = m_dtData.Rows[iRow];
                for (int iCol = 0; iCol < m_dtData.Columns.Count; iCol++)
                {
                    if (dr[iCol].ToString().Length <= 0)
                    {
                        isOK = false;
                        break;
                    }
                }


            }

            return isOK;
        }

        /// <summary>
        /// Writes configuration data used in C++ import
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public bool WriteConfigData(ref StreamWriter writer)
        {
            string zLine = "";
            DataRow dr;
            DiDataRow data = new DiDataRow();
            for (int iRow = 0; iRow < m_dtData.Rows.Count; iRow++)
            {
                dr = m_dtData.Rows[iRow];
                data.Data = dr;

                if (data.IsTemplate && data.ClassType == DICLASSTYPES.DICLASSTYPE_TASK)
                {
                   continue;
                }
                else if (data.IsTemplate && data.ClassType == DICLASSTYPES.DICLASSTYPE_CONDITION)
                {
                    continue;
                }

                zLine = dr[DATAFIELD_ID].ToString() + ","; //enum id
                zLine += dr[DATAFIELD_CLASSNAME].ToString().ToUpper() + ","; //unique identification
                zLine += dr[DATAFIELD_ISTEMPATE].ToString() + ","; //is template
                zLine += dr[DATAFIELD_CLASSTYPE].ToString() + ","; //class type

                if (data.IsTemplate)
                {
                    //use template names
                    switch (data.ClassType)
                    {
                        case DICLASSTYPES.DICLASSTYPE_FILTER:
                            zLine += "DiFilter,"; //class name
                            break;
                        case DICLASSTYPES.DICLASSTYPE_SELECTION:
                            zLine += "DiSelection,"; //class name
                            break;
                        case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                            zLine += "DiSequence,"; //class name
                            break;
                        default:
                            continue;
                    };
                }
                else
                {
                    zLine += dr[DATAFIELD_CLASSNAME].ToString() + ","; //class name
                }
                zLine += dr[DATAFIELD_TEMPLATECLASS].ToString(); //template class

                writer.WriteLine(zLine);
                

            }

            return true;
        }
    }
}
