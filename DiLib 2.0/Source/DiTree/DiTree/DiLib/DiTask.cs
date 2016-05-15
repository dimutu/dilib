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
using System.Windows.Forms.Design;
using System.Data;
using System.Drawing;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace DiTree
{
    /// <summary>
    /// each tree node in the behaviour tree actually derives from windows tree node so each 
    /// tree node in the tree view controller has the game behaviour tree properties
    ///  setting reference to task is easy, so dont have to manage change of class ids,
    ///  only when the whole class is deleted
    /// </summary>
    public class DiTask 
    {
        protected DICLASSTYPES m_eClassType; //template class type id, is it task, sequence, condition, etc....

        protected int m_iEnumID; //for class instance generation on the fly

        protected string m_zLuaScript; //script file path

        protected string m_zClassName; //class name

        protected long m_lDebuggerID; //to identify each task seperately in the tree, duplicated will have different number 

        protected bool m_bIsTemplate; //use of template class or extended, this is not to show but keep referencec to tasks that arent set the properties yet

        protected DiDataHanlder m_pkDataHandler; //reference to data handler for auto complete text for class names

        private TreeNode m_pkParent; //keep reference of parent tree node to update text and tooltip when task properties changed

        private string m_zTemplateClass; //template class name ref as this needs for property grid to filter out data

        private bool m_bBreakpoint;// this node is has a breakpoint or not

        private string m_zArgs; //additional arguments needs to setup this task

        public DiTask()
        {
            m_eClassType = DICLASSTYPES.DICLASSTYPE_TASK;
            m_iEnumID = -1;
            m_lDebuggerID = 0;
            m_zClassName = "";
            m_zLuaScript = "";
            m_bIsTemplate = true;
            m_pkParent = null;
            m_zTemplateClass = "";
            m_bBreakpoint = false;
            m_zArgs = "";
        }

        [Category("Task"), TypeConverter( typeof(DiStringAutoComplete)),
        Description("Name of the inherited class created from the base class.")]
        public string ClassName
        {
            get
            {
                return m_zClassName;
            }
            set
            {
                m_zClassName = value;
                if (m_pkParent != null)
                {
                    m_pkParent.Text = m_zClassName;
                }
            }
        }

        [Category("Task"),
#if DEBUG
        ReadOnly(true), 
#else
        Browsable(false),
#endif
        Description("Unique identifier for each tree node to use in debugging.")] 
        public long DebuggerID
        {
            get
            {
                return m_lDebuggerID;
            }
            set
            {
                m_lDebuggerID = value;
            }
        }

        [Browsable(false)] //no need to show or change the data table running number for the enumeration
        public int EnumID
        {
            get
            {
                return m_iEnumID;
            }
            set
            {
                m_iEnumID = value;
            }
        }

        [Category("Task"),
        Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor)),
        Description("Script file path uses to run any additional instructions or data for the implementing task.")]
        public string ScriptFile
        {
            get
            {
                return m_zLuaScript;
            }
            set
            {
                if (value == null)
                {
                    value = "";
                }
                m_zLuaScript = value;
                
            }
        }

        [Browsable(false)]
        public bool IsTemplate
        {
            get
            {
                return m_bIsTemplate;
            }
            set
            {
                m_bIsTemplate = value;
            }
        }

        [Browsable(false)] //no need to show the class type and allow to change it
        public DICLASSTYPES ClassType
        {
            get
            {
                return m_eClassType;
            }
            set
            {
                m_eClassType = value;
            }
        }

        /// <summary>
        /// reference to data handler
        /// this uses to create class name list for auto complete on property grid
        /// </summary>
        [Browsable(false)]
        public DiDataHanlder DataHandler
        {
            get
            {
                return m_pkDataHandler;
            }
            set
            {
                m_pkDataHandler = value;
            }
        }

        /// <summary>
        /// Reference to parent tree node keeping this task as properties
        /// This is to modify the node Text and ToolTip when properties changed through property grid
        /// </summary>
        [Browsable(false)]
        public TreeNode Parent
        {
            get
            {
                return m_pkParent;
            }
            set
            {
                m_pkParent = value;
            }
        }

        /// <summary>
        /// Template class this task belongs to
        /// which uses to filter out list of property grid
        /// </summary>
        [Browsable(false)]
        public string TemplateClass
        {
            get
            {
                return m_zTemplateClass;
            }
            set
            {
                m_zTemplateClass = value;
            }
        }

        /// <summary>
        /// this task has a breakpoint
        /// </summary>
        [Browsable(false)]
        public bool Breakpoint
        {
            get
            {
                return m_bBreakpoint;
            }
            set
            {
                m_bBreakpoint = value;
            }
        }

        /// <summary>
        /// Additional arguments needs to pass to C++ project
        /// </summary>
        [Category("Task"), 
        Description("Additional arguments and settings to pass to the C++ project as a string value."),
        Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))] 
        public string Arguments
        {
            get
            {
                return m_zArgs;
            }
            set
            {
                m_zArgs = value;
            }
        }
    }
}
