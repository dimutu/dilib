using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiTree
{
    public static class DiXMLElements
    {
        public const string XMLELEMENT_DILIB = "DiLIB";
        public const string XMLELEMENT_DILIB_VERSION = "version"; //file version

        public const string XMLELEMENT_TREEROOT = "TreeRoot"; //main xml header

        //configuration details
        public const string XMLELEMENT_CONFIG = "DiConfig"; //diconfig xml tag
        public const string XMLELEMENT_DEBUGID = "DebugID"; //configuration attribute diconfig

        public const string XMLELEMENT_HEADERFILELIST = "HeaderFiles";//all header file parent tag
        public const string XMLELEMENT_HEADERFIECOUNT = "Count";//header files attribute - count
        public const string XMLELEMENT_HEADERFILE = "File";//header file tag
        public const string XMLELEMENT_HEADERFILENAME = "Name"; //header file attribute - name

        //custom enumerations for return types
        public const string XMLELEMENT_CUSTOMRETURNENUMS = "CustomReturn";//all return type enum parent tag
        public const string XMLELEMENT_CUSTOMRETURNENUM_COUNT = "Count";//enum type attribute - count
        public const string XMLELEMENT_CUSTOMENUM = "ReturnType";//return enum tag
        public const string XMLELEMENT_CUSTOMENUM_NAME = "Enum"; //return enum attribute - name

        //data table
        public const string XMLELEMENT_ENUMLIST = "Enums"; //enums parent tag
        public const string XMLELEMENT_ENUMCOUNT = "Count"; //enums attribute count

        public const string XMLELEMENT_ENUM = "Enum"; //child element tag of Enums
        public const string XMLELEMENT_ENUMID = "ID"; //enum attribute
        public const string XMLELEMENT_ISTEMPLATE = "IsTemplate";//enum attribute
        public const string XMLELEMENT_CLASSTYPE = "ClassTypeID"; //enum attribute
        public const string XMLELEMENT_CLASSNAME = "ClassName"; //enum attribute
        public const string XMLELEMENT_TEMPLATECLASS = "TemplateClassName"; //enum attribute
        public const string XMLELEMENT_SCRIPTFILE = "ScriptFile"; //enum attribute

        //xml tags for the tree xml
        public const string XMLELEMENT_ROOTNODES = "RootNodes"; //all tree roots tag
        public const string XMLELEMENT_ROOTNODE_COUNT = "ChildCount"; //attribute

        public const string XMLELEMENT_ROOT = "RootNode"; //single tree root tag
        public const string XMLELEMENT_ROOTTEMPLATECLASS = "TemplateClassName"; //root node attribute
        public const string XMLELEMENT_ROOTDEBUGID = "RootDebugID"; //root node attribute - debug name or tab name 
        
        public const string XMLELEMENT_NODE = "Node"; //individual tree node tag
        public const string XMLELEMENT_NODEENUMID = "EnumID"; //node attribute - enum id matching to data table
        public const string XMLELEMENT_NODETYPE = "TypeID"; //node attribute - class type
        public const string XMLELEMENT_NODECLASSNAME = "ClassName"; //node attribute - class name
        public const string XMLELEMENT_NODESCRIPT_FILE = "LuaScript"; //node attribute - script file
        public const string XMLELEMENT_NODEFILTERTASK = "Task"; //filter node attribute - child task enum id
        public const string XMLELEMENT_NODETIMER_INTERVAL = "TimerInterval"; //filter node attribute - 
        public const string XMLELEMENT_NODECHILDCOUNT = "ChildCount"; //node attribute - if any children tasks in and will have the same of this
        public const string XMLELEMENT_NODEDEBUGID = "TaskDebugID"; //node attribute - debug identifier
        public const string XMLELEMENT_NODEREPEAT = "Repeat"; //filter node attribute
        public const string XMLELEMENT_NODEMAXREPEATS = "MaxRunCycle"; //filter node attribute
        public const string XMLELEMENT_NODETASKTRUE = "TaskTrue"; //condition node attribute - enum id of the task
        public const string XMLELEMENT_NODETASKFALSE = "TaskFalse";//condition node attribute - enum id of the task
        public const string XMLELEMENT_NODEBREAKPOINT = "Breakpoint"; //has a breakpoint
        public const string XMLELEMENT_NODEARGS = "TaskArgs"; //additional arguments passing to C++
    }
}
