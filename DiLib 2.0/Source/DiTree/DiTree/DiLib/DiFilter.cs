using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiTree
{
    class DiFilter : DiTask
    {
        protected DiTask m_kTask; //task to run on filter 
        protected bool m_bLoopOn; //loop the task
        protected uint m_uiMaxRunCycles; //if not loop, number of times to run
        protected double iTimeInterval = 0; //time interval for the filter task

        public DiTask Task
        {
            get
            {
                return m_kTask;
            }
            set
            {
                m_kTask = value;
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
                return iTimeInterval;
            }
            set
            {
                iTimeInterval = value;
            }
        }
    }
}
