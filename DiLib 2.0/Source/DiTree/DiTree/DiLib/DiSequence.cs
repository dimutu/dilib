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

        [Browsable(false)]
        public List<DiTask> TaskList
        {
            get
            {
                return m_akTaskList;
            }
        }

        /// <summary>
        /// Remove given task from the task list
        /// </summary>
        /// <param name="a_pkTask"></param>
        public void RemoveTask(DiTask a_pkTask)
        {
            m_akTaskList.Remove(a_pkTask);
        }
    }
}
