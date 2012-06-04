using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DiTree
{
    /// <summary>
    /// sequence task
    /// </summary>
    class DiSequence : DiTask
    {
        private List<DiTask> m_akTaskList = new List<DiTask>();

        public DiSequence()
            : base()
        {
            m_eClassType = DICLASSTYPES.DICLASSTYPE_SEQUENCE;
        }

        public List<DiTask> TaskList
        {
            get
            {
                return m_akTaskList;
            }
            set
            {
                m_akTaskList = value;
            }
        }

    }
}
