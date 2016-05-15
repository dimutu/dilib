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
        protected int m_iTaskEnum; //enumeration index of the child task

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
        Description("Task to run when the filtering time has met.")]
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
        Description("Sets the task should run in a loop.")]
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
        Description("If not in a loop, maximum times the task should get executed. This only works if LoopOn property is false.")]
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
        Description("Time interval between each execution in milliseconds.")]
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

        /// <summary>
        /// Enumeration index of the child task
        /// </summary>
        [Browsable(false)]
        public int EnumTask
        {
            get
            {
                return m_iTaskEnum;
            }
            set
            {
                m_iTaskEnum = value;
            }
        }
    }
}
