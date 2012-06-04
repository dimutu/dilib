using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiTree
{
    /// <summary>
    /// filter task
    /// </summary>
    class DiFilter : DiTask
    {
        protected DiTask m_pkTask; //task to run on filter 
        protected bool m_bLoopOn; //loop the task
        protected uint m_uiMaxRunCycles; //if not loop, number of times to run
        protected double m_dTimeInterval = 0; //time interval for the filter task (in milliseconds)

        public DiFilter()
            : base()
        {
            m_eClassType = DICLASSTYPES.DICLASSTYPE_FILTER;
            m_bLoopOn = false;
            m_pkTask = null;
            m_uiMaxRunCycles = 1;
            m_dTimeInterval = 0;
        }

        public DiTask Task
        {
            get
            {
                return m_pkTask;
            }
            set
            {
                m_pkTask = value;
            }
        }

        public bool LoopOn
        {
            get
            {
                return m_bLoopOn;
            }
            set
            {
                m_bLoopOn = value;
            }
        }


        public uint MaxRunCycles
        {
            get
            {
                return m_uiMaxRunCycles;
            }
            set
            {
                m_uiMaxRunCycles = value;
            }
        }

        public double TimerInterval
        {
            get
            {
                return m_dTimeInterval;
            }
            set
            {
                m_dTimeInterval = value;
            }
        }
    }
}
