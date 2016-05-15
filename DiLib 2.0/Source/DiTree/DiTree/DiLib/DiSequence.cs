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
