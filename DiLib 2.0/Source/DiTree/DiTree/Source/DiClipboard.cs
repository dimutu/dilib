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

namespace DiTree
{
    /// <summary>
    /// Local clipboard to keep track of the tree node that needs cut/copy
    /// </summary>
    public static class DiClipboard
    {
        private static DiTreeNode m_pkNode;
        private static bool m_bIsCut;

        /// <summary>
        /// This get called to copy selected node
        /// </summary>
        /// <param name="a_pkNode"></param>
        /// <param name="a_bCut"></param>
        public static void Copy(DiTreeNode a_pkNode, bool a_bCut = false)
        {
            m_pkNode = a_pkNode;
            m_bIsCut = a_bCut;
        }

        /// <summary>
        /// Clear the clipboard
        /// </summary>
        public static void Clear()
        {
            m_pkNode = null;
            m_bIsCut = false;
        }

        public static DiTreeNode Node
        {
            get
            {
                return m_pkNode;
            }
            set
            {
                m_pkNode = value;
            }
        }

        public static bool IsCut
        {
            get
            {
                return m_bIsCut;
            }
            set
            {
                m_bIsCut = value;
            }
        }
    }
}
