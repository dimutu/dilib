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
using System.ComponentModel;

namespace DiTree
{
    /// <summary>
    /// condition class
    /// </summary>
    public class DiCondition : DiTask
    {
        protected DiTask m_pkTrueTask; //when condition is true
        protected DiTask m_pkFalseTask; //when condition is false

        protected DiTask[] m_apkTasks; //both tasks to show in the property grid

        protected int m_iEnumTrue; //eumeration index of the true task
        protected int m_iEnumFalse; //enumeration index of false task

        public DiCondition()
            : base()
        {
            m_eClassType = DICLASSTYPES.DICLASSTYPE_FILTER;
            m_pkFalseTask = null;
            m_pkTrueTask = null;
            m_apkTasks = new DiTask[(int)CONDITION.CONDITION_COUNT];
        }

        [Category("Condition"), 
        TypeConverter(typeof(DiTaskTypeConverter)),
        Description("Task to execute when the condition is satisfied or true.")]
        public string TrueTask
        {
            get
            {
                if (m_pkTrueTask != null)
                {
                    return m_pkTrueTask.ClassName;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                for (int ii = 0; ii < (int)CONDITION.CONDITION_COUNT; ++ii)
                {
                    DiTask pkTask = m_apkTasks[ii];

                    if (pkTask.ClassName == value)
                    {
                        m_pkTrueTask = pkTask;
                        break;
                    }
                }
            }
        }

        [Category("Condition"),
        TypeConverter(typeof(DiTaskTypeConverter)),
        Description("Task to execute when the condition unsatisfied or false.")]
        public string FalseTask
        {
            get
            {
                if (m_pkFalseTask != null)
                {
                    return m_pkFalseTask.ClassName;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                //set task from the unique class name got from the property grid
                for (int ii = 0; ii < (int)CONDITION.CONDITION_COUNT; ++ii)
                {
                    DiTask pkTask = m_apkTasks[ii];

                    if (pkTask.ClassName == value)
                    {
                        m_pkFalseTask = pkTask;
                        break;
                    }
                }
            }
        }

        [Browsable(false)]
        public DiTask TaskElement1
        {
            get
            {
                return m_apkTasks[(int)CONDITION.CONDITION_ELEMENT1];
            }
            set
            {
                m_apkTasks[(int)CONDITION.CONDITION_ELEMENT1] = value;
            }
        }

        [Browsable(false)]
        public DiTask TaskElement2
        {
            get
            {
                return m_apkTasks[(int)CONDITION.CONDITION_ELEMENT2];
            }
            set
            {
                m_apkTasks[(int)CONDITION.CONDITION_ELEMENT2] = value;
            }
        }

        [Browsable(false)]
        public DiTask[] Tasks
        {
            get
            {
                return m_apkTasks;
            }
        }

        [Browsable(false)]
        public DiTask TaskTrue
        {
            get
            {
                return m_pkTrueTask;
            }
            set
            {
                m_pkTrueTask = value;
            }
        }

        [Browsable(false)]
        public DiTask TaskFalse
        {
            get
            {
                return m_pkFalseTask;
            }
            set
            {
                m_pkFalseTask = value;
            }
        }

        /// <summary>
        /// Enumeration index of the true task set in this condition
        /// </summary>
        [Browsable(false)]
        public int EnumTrue
        {
            get
            {
                return m_iEnumTrue;
            }
            set
            {
                m_iEnumTrue = value;
            }
        }

        /// <summary>
        /// Enumeration index of the false task set in this condition
        /// </summary>
        [Browsable(false)]
        public int EnumFalse
        {
            get
            {
                return m_iEnumFalse;
            }
            set
            {
                m_iEnumFalse = value;
            }
        }

        /// <summary>
        /// Remove task from condition children
        /// </summary>
        /// <param name="?"></param>
        public void RemoveTask(DiTask a_pkTask)
        {
            if (m_pkFalseTask == a_pkTask)
            {
                m_pkFalseTask = null;
            }
            else if (m_pkTrueTask == a_pkTask)
            {
                m_pkTrueTask = null;
            }

            for (int ii = 0; ii < (int)CONDITION.CONDITION_COUNT; ++ii)
            {
                if (m_apkTasks[ii] == a_pkTask)
                {
                    m_apkTasks[ii] = null;
                    break;
                }
            }
        }

    }
}
