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
    class DiCondition : DiTask
    {
        protected DiTask m_kTrueTask; //when condition is true
        protected DiTask m_kFalseTask; //when condition is false

        public DiCondition()
            : base()
        {
            m_eClassType = DICLASSTYPES.DICLASSTYPE_FILTER;
        }

        public DiTask TrueTask
        {
            get
            {
                return m_kTrueTask;
            }
            set
            {
                m_kTrueTask = value;
            }
        }

        public DiTask FalseTask
        {
            get
            {
                return m_kFalseTask;
            }
            set
            {
                m_kFalseTask = value;
            }
        }

    }
}
