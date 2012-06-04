using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Data;

namespace DiTree
{
    /// <summary>
    /// each tree node in the behaviour tree actually derives from windows tree node so each 
    /// tree node in the tree view controller has the game behaviour tree properties
    ///  setting reference to task is easy, so dont have to manage change of class ids,
    ///  only when the whole class is deleted
    /// </summary>
    class DiTask 
    {
        protected DICLASSTYPES m_eClassType; //template class type id, is it task, sequence, condition, etc....

        protected int m_iEnumID; //for class instance generation on the fly

        protected string m_zLuaScript; //script file path

        protected string m_zClassName; //class name

        protected long m_lDebuggerID; //to identify each task seperately in the tree, duplicated will have different number 

        protected string m_zEnumName; //enumeration name, to display in tool tip

        public DiTask()
        {
            m_eClassType = DICLASSTYPES.DICLASSTYPE_TASK;
            m_iEnumID = -1;
            m_lDebuggerID = 0;
            m_zClassName = "";
            m_zEnumName = "";
            m_zLuaScript = "";
        }

        //[ReadOnly(true)]
        public string ClassName
        {
            get
            {
                return m_zClassName;
            }
            set
            {
                m_zClassName = value;
            }
        }

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

       //[Category("File")]
        //[EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string LuaScriptFile
        {
            get
            {
                return m_zLuaScript;
            }
            set
            {
                m_zLuaScript = value;
            }
        }

        //[ReadOnly(true)]
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

        public string EnumName
        {
            get
            {
                return m_zEnumName;
            }
            set
            {
                m_zEnumName = value;
            }
        }

    }
}
