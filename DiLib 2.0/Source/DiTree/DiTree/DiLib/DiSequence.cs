using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;

namespace DiTree
{
    /// <summary>
    /// sequence task
    /// </summary>
    public class DiSequence : DiTask
    {
        private List<DiTask> m_akTaskList;

        public DiSequence()
            : base()
        {
            m_eClassType = DICLASSTYPES.DICLASSTYPE_SEQUENCE;
            m_akTaskList = new List<DiTask>();
        }

        [Category("Task List"), Browsable(false),
        Description("Task list to execute.")]
        public List<DiTask> TaskList
        {
            get
            {
                return m_akTaskList;
            }
        }

    }
}
