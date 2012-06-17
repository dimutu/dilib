using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;

namespace DiTree
{
    /// <summary>
    /// filter task
    /// </summary>
    public class DiFilter : DiTask
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

        [Category("Filter"),
        Description("Task to run when the filter conditions are met")]
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

        [Category("Filter"),
        Description("The task needs to run in a continuous loop.")]
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

        [Category("Filter"),
        Description("If not in a loop, maximum times the task should get executed.")]
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

        [Category("Filter"),
        Description("Time interval between each execution in milliseconds")]
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
