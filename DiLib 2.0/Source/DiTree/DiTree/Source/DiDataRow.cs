/*
****************************************************************************************************************************
* DiLib v2.0 (dilib.dimutu.com)
*
* This software is provided 'as-is', without any express or implied warranty. 
* In no event will the authors be held liable for any
* damages arising from the use of this software.
* 
* Permission is granted to anyone to use this software for any
* purpose, including commercial applications, subject to the following restrictions:
* 
* 1. The origin of this software must not be misrepresented; you must
* not claim that you wrote the original software. If you use this
* software in a product, an acknowledgment in the product documentation
* would be appreciated.
*
* 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
* 
* 3. This notice may not be removed or altered from any source distribution.
* 
* 4. Third party open source "TinyXML" is used in this program, and for more information please see its own terms of use.
*******************************************************************************************************************************
*/
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
