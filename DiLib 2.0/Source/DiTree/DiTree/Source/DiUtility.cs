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
using System.Reflection;
using System.Resources;

namespace DiTree
{
    public static class DiUtility
    {
        private static ResourceManager m_kResourceManager = Properties.Resources.ResourceManager;
        /// <summary>
        /// Gets run task image for currently debugging
        /// </summary>
        /// <param name="a_eClassType"></param>
        /// <returns></returns>
        public static string GetImageKeyRun(DICLASSTYPES a_eClassType)
        {
            string zKey = "";
            switch (a_eClassType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    zKey = "condition_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    zKey = "filter_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_ROOT:
                    zKey = "root_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    zKey = "selection_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    zKey = "sequence_run";
                    break;

                default:
                    zKey = "task_run";
                    break;
            }

            return zKey;
        }

        /// <summary>
        /// Get image list image key from the class type
        /// </summary>
        /// <param name="a_eType"></param>
        /// <returns></returns>
        public static string GetTaskImageKey(DICLASSTYPES a_eType)
        {
            string zKey = "";
            switch (a_eType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    zKey = "condition";
                    break;

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    zKey = "filter";
                    break;

                case DICLASSTYPES.DICLASSTYPE_ROOT:
                    zKey = "root";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    zKey = "selection";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    zKey = "sequence";
                    break;

                default:
                    zKey = "task";
                    break;
            }

            return zKey;
        }

        public static string GetTaskBreakImageKey(DICLASSTYPES a_eType)
        {
            string zKey = "";
            switch (a_eType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    zKey = "condition_bp";
                    break;

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    zKey = "filter_bp";
                    break;

                case DICLASSTYPES.DICLASSTYPE_ROOT:
                    zKey = "root_bp";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    zKey = "selection_bp";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    zKey = "sequence_bp";
                    break;

                default:
                    zKey = "task_bp";
                    break;
            }

            return zKey;
        }

        public static string GetTaskBreakRunImageKey(DICLASSTYPES a_eType)
        {
            string zKey = "";
            switch (a_eType)
            {
                case DICLASSTYPES.DICLASSTYPE_CONDITION:
                    zKey = "condition_bp_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_FILTER:
                    zKey = "filter_bp_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_ROOT:
                    zKey = "root_bp_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SELECTION:
                    zKey = "selection_bp_run";
                    break;

                case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                    zKey = "sequence_bp_run";
                    break;

                default:
                    zKey = "task_bp_run";
                    break;
            }

            return zKey;
        }

        public static string GetString(string a_zID)
        {
            return m_kResourceManager.GetString(a_zID);
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}
