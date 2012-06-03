using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DiTree
{
    class DiCondition : DiTask
    {
        /*setting reference to task is easy, so dont have to manage change of class ids, only when the whole class is deleted*/

        protected DiTask m_kTrueTask; //when condition is true
        protected DiTask m_kFalseTask; //when condition is false

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
