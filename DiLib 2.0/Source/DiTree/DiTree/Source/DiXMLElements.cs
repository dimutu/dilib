using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiTree
{
    public static class DiXMLElements
    {
        public const string XMLELEMENT_TREEROOT = "TreeRoot";
        public const string XMLELEMENT_CONFIG = "DiConfig";
        public const string XMLELEMENT_DEBUGID = "DebugID";
        public const string XMLELEMENT_HEADERFILELIST = "HeaderFiles";
        public const string XMLELEMENT_HEADERFIECOUNT = "Count";
        public const string XMLELEMENT_HEADERFILE = "File";
        public const string XMLELEMENT_HEADERFILENAME = "Name"; //file name
        public const string XMLELEMENT_ENUMLIST = "Enums"; //enums parent element
        public const string XMLELEMENT_ENUMCOUNT = "Count"; //enum count
        public const string XMLELEMENT_ENUM = "Enum"; //child element
        public const string XMLELEMENT_ENUMID = "ID"; //enum id
        public const string XMLELEMENT_ISTEMPLATE = "IsTemplate";
        public const string XMLELEMENT_CLASSTYPE = "ClassTypeID";
        public const string XMLELEMENT_CLASSNAME = "ClassName";
        public const string XMLELEMENT_TEMPLATECLASS = "TemplateClassName";

        public const string XMLELEMENT_ROOTNODES = "RootNodes";
    }
}
