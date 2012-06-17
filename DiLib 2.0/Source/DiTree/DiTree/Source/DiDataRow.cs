using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DiTree
{
    /// <summary>
    /// Returns the data row using it as property variable and set of properties for each data item
    ///     with use of casting
    /// </summary>
    public class DiDataRow
    {
        private DataRow m_pkDataRow;

        public DataRow Data
        {
            get
            {
                return m_pkDataRow;
            }
            set
            {
                m_pkDataRow = value;
            }
        }

        public int EnumID
        {
            get
            {
                return (int)m_pkDataRow[DiDataHanlder.DATAFIELD_ID];
            }
        }

        public string ClassName
        {
            get
            {
                return (string)m_pkDataRow[DiDataHanlder.DATAFIELD_CLASSNAME];
            }
        }

        public DICLASSTYPES ClassType
        {
            get
            {
                return (DICLASSTYPES)m_pkDataRow[DiDataHanlder.DATAFIELD_CLASSTYPE];
            }
        }

        public bool IsTemplate
        {
            get
            {
                return (bool)m_pkDataRow[DiDataHanlder.DATAFIELD_ISTEMPATE];
            }
        }

        public string TemplateClass
        {
            get
            {
                return (string)m_pkDataRow[DiDataHanlder.DATAFIELD_TEMPLATECLASS];
            }
        }
    }
}
