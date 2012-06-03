using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Data;

/*
 *  each tree node in the behaviour tree actually derives from windows tree node so each 
 *      tree node in the tree view controller has the game behaviour tree properties
 */

namespace DiTree
{
    class DiTask : TreeNode
    {
        protected DICLASSTYPES iClassID; //template class type id, is it task, sequence, condition, etc....

        protected int iEnumID = -1; //for class instance generation on the fly

        protected string zLuaScript = ""; //script file path

        protected string zName = ""; //class name

        protected long lDebuggerTaskID = 0; //to identify each task seperately in the tree, duplicated will have different number 

        protected string zEnumName = ""; //enumeration name, to display in tool tip

        //[ReadOnly(true)]
        public string Name
        {
            get
            {
                return zName;
            }
            set
            {
                zName = value;
            }
        }

        public long DebuggerID
        {
            get
            {
                return lDebuggerTaskID;
            }
            set
            {
                lDebuggerTaskID = value;
            }
        }

        public int EnumID
        {
            get
            {
                return iEnumID;
            }
            set
            {
                iEnumID = value;
            }
        }

        //[Category("File")]
        //[EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string LuaScriptFile
        {
            get
            {
                return zLuaScript;
            }
            set
            {
                zLuaScript = value;
            }
        }

        //[ReadOnly(true)]
        public DICLASSTYPES ClassID
        {
            get
            {
                return iClassID;
            }
            set
            {
                iClassID = value;
            }
        }

        public string EnumName
        {
            get
            {
                return zEnumName;
            }
            set
            {
                zEnumName = value;
            }
        }

    }
}
