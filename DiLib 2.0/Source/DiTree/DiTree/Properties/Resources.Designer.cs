﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiTree.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DiTree.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #include &quot;[CLASS].h&quot;
        ///#include &quot;DiReturnEnums.h&quot;
        ///#include &quot;[TEMPLATE].h&quot;
        ///
        ///[CLASS]::[CLASS]() : DiLib::[DICLASS]&lt;[TEMPLATE]&gt;()
        ///{
        ///}
        ///
        ///[CLASS]::~[CLASS]()
        ///{
        ///}
        ///
        ///int [CLASS]::Execute([TEMPLATE]* a_pkObject)
        ///{
        ///	if (true)
        ///	{
        ///		return m_pkTrueTask-&gt;Execute(a_pkObject);
        ///	}
        ///	else
        ///	{
        ///		return m_pkFalseTask-&gt;Execute(a_pkObject);
        ///	}
        ///}
        ///.
        /// </summary>
        internal static string condcpp {
            get {
                return ResourceManager.GetString("condcpp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #include &quot;[CLASS].h&quot;
        ///#include &quot;DiReturnEnums.h&quot;
        ///#include &quot;[TEMPLATE].h&quot;
        ///
        ///[CLASS]::[CLASS]() : DiLib::[DICLASS]&lt;[TEMPLATE]&gt;()
        ///{
        ///}
        ///
        ///[CLASS]::~[CLASS]()
        ///{
        ///}
        ///
        ///int [CLASS]::Execute([TEMPLATE]* a_pkObject)
        ///{
        ///	DIDEBUGGER_SEND(this);
        ///
        ///	//if the timer is set, execute code in time intervals
        ///	if ( !m_pkTimer-&gt;IsRunTime() )
        ///	{
        ///		//time not ready, come back later to execute
        ///		return DiLib::DI_TASK_RETURNS::DITASK_CALLBACK;
        ///	}
        ///
        ///	//check loop conditions before executing
        ///	if (m_bIsLoopOn || m_uiRunC [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string filcpp {
            get {
                return ResourceManager.GetString("filcpp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #ifndef [DEFINE]
        ///#define [DEFINE]
        ///
        ///#include &lt;[DICLASS].h&gt;
        ///
        ///class [TEMPLATE];
        ///
        ///class [CLASS] : public DiLib::[DICLASS]&lt;[TEMPLATE]&gt;
        ///{
        ///public:
        ///	[CLASS]();
        ///	
        ///	~[CLASS]();
        ///	
        ///	int Execute([TEMPLATE]* a_pkObject);
        ///	
        ///};
        ///
        ///#endif.
        /// </summary>
        internal static string header {
            get {
                return ResourceManager.GetString("header", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Adds new Condition task to currently selected node..
        /// </summary>
        internal static string ID_ADD_CONDITION {
            get {
                return ResourceManager.GetString("ID_ADD_CONDITION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Adds new Filter task to currently selected node..
        /// </summary>
        internal static string ID_ADD_FILTER {
            get {
                return ResourceManager.GetString("ID_ADD_FILTER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Adds new Selection task to currently selected node..
        /// </summary>
        internal static string ID_ADD_SELECTION {
            get {
                return ResourceManager.GetString("ID_ADD_SELECTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Adds new Sequence task to currently selected node..
        /// </summary>
        internal static string ID_ADD_SEQUENCE {
            get {
                return ResourceManager.GetString("ID_ADD_SEQUENCE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Adds new Task to currently selected node..
        /// </summary>
        internal static string ID_ADD_TASK {
            get {
                return ResourceManager.GetString("ID_ADD_TASK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Adds new Tree tab..
        /// </summary>
        internal static string ID_ADD_TREE {
            get {
                return ResourceManager.GetString("ID_ADD_TREE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Close file..
        /// </summary>
        internal static string ID_CLOSE_FILE {
            get {
                return ResourceManager.GetString("ID_CLOSE_FILE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Break debugger at next node..
        /// </summary>
        internal static string ID_DEBUG_BREAK {
            get {
                return ResourceManager.GetString("ID_DEBUG_BREAK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Toggle breakpoint on selected tree node..
        /// </summary>
        internal static string ID_DEBUG_BREAKPOINT {
            get {
                return ResourceManager.GetString("ID_DEBUG_BREAKPOINT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log debug data to the console window..
        /// </summary>
        internal static string ID_DEBUG_LOG {
            get {
                return ResourceManager.GetString("ID_DEBUG_LOG", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove all the breakpoints on selected tree..
        /// </summary>
        internal static string ID_DEBUG_REMOVEALL_BREAKS {
            get {
                return ResourceManager.GetString("ID_DEBUG_REMOVEALL_BREAKS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This slow the debug speed between task from 0 to 0.5 seconds..
        /// </summary>
        internal static string ID_DEBUG_SPEED {
            get {
                return ResourceManager.GetString("ID_DEBUG_SPEED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start/Continue Debugger..
        /// </summary>
        internal static string ID_DEBUG_START {
            get {
                return ResourceManager.GetString("ID_DEBUG_START", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Step through debug process..
        /// </summary>
        internal static string ID_DEBUG_STEP {
            get {
                return ResourceManager.GetString("ID_DEBUG_STEP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stop debugger..
        /// </summary>
        internal static string ID_DEBUG_STOP {
            get {
                return ResourceManager.GetString("ID_DEBUG_STOP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Delete currently selected tree node and its child nodes..
        /// </summary>
        internal static string ID_DELETE_TASK {
            get {
                return ResourceManager.GetString("ID_DELETE_TASK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Delete currently selected tree tab..
        /// </summary>
        internal static string ID_DELETE_TREE {
            get {
                return ResourceManager.GetString("ID_DELETE_TREE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot modify during tree is running..
        /// </summary>
        internal static string ID_EDIT_DEBUG_BLOCKED {
            get {
                return ResourceManager.GetString("ID_EDIT_DEBUG_BLOCKED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string ID_EMPTY {
            get {
                return ResourceManager.GetString("ID_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error loading file..
        /// </summary>
        internal static string ID_ERROR_LOAD_FILE {
            get {
                return ResourceManager.GetString("ID_ERROR_LOAD_FILE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No data file open for debugging..
        /// </summary>
        internal static string ID_ERROR_NO_DEBUG_FILE {
            get {
                return ResourceManager.GetString("ID_ERROR_NO_DEBUG_FILE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error saving file..
        /// </summary>
        internal static string ID_ERROR_SAVE_FILE {
            get {
                return ResourceManager.GetString("ID_ERROR_SAVE_FILE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to write to error log..
        /// </summary>
        internal static string ID_ERROR_WRITING_LOG {
            get {
                return ResourceManager.GetString("ID_ERROR_WRITING_LOG", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exporting complete..
        /// </summary>
        internal static string ID_EXPORT_COMPLETE {
            get {
                return ResourceManager.GetString("ID_EXPORT_COMPLETE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Export configuration file from active data file..
        /// </summary>
        internal static string ID_EXPORT_CONFIG {
            get {
                return ResourceManager.GetString("ID_EXPORT_CONFIG", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Generate and export C++ source from data set on all the trees on this file..
        /// </summary>
        internal static string ID_EXPORT_SOURCE {
            get {
                return ResourceManager.GetString("ID_EXPORT_SOURCE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Export tree file from active tree on data file..
        /// </summary>
        internal static string ID_EXPORT_TREE {
            get {
                return ResourceManager.GetString("ID_EXPORT_TREE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter C++ Template Class name here and click Set Template to begin creating the behavior tree..
        /// </summary>
        internal static string ID_INFO_TEMPLATE_NAME {
            get {
                return ResourceManager.GetString("ID_INFO_TEMPLATE_NAME", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Move currently selected tree node..
        /// </summary>
        internal static string ID_MOVE_TASK {
            get {
                return ResourceManager.GetString("ID_MOVE_TASK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create new didata file..
        /// </summary>
        internal static string ID_NEW_DIDATA {
            get {
                return ResourceManager.GetString("ID_NEW_DIDATA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open existing didata file..
        /// </summary>
        internal static string ID_OPEN_DIDATA {
            get {
                return ResourceManager.GetString("ID_OPEN_DIDATA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Print currently active tree..
        /// </summary>
        internal static string ID_PRINT {
            get {
                return ResourceManager.GetString("ID_PRINT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Print preview currently active tree..
        /// </summary>
        internal static string ID_PRINT_PREVIEW {
            get {
                return ResourceManager.GetString("ID_PRINT_PREVIEW", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rename currently selected tree tab..
        /// </summary>
        internal static string ID_RENAME_TREE {
            get {
                return ResourceManager.GetString("ID_RENAME_TREE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save currently open didata file..
        /// </summary>
        internal static string ID_SAVE_DIDATA {
            get {
                return ResourceManager.GetString("ID_SAVE_DIDATA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save As currently open diddata file..
        /// </summary>
        internal static string ID_SAVEAS_DIDATA {
            get {
                return ResourceManager.GetString("ID_SAVEAS_DIDATA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show the console window..
        /// </summary>
        internal static string ID_SHOW_CONSOLE {
            get {
                return ResourceManager.GetString("ID_SHOW_CONSOLE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #include &quot;[CLASS].h&quot;
        ///#include &quot;DiReturnEnums.h&quot;
        ///#include &quot;[TEMPLATE].h&quot;
        ///
        ///[CLASS]::[CLASS]() : DiLib::[DICLASS]&lt;[TEMPLATE]&gt;()
        ///{
        ///}
        ///
        ///[CLASS]::~[CLASS]()
        ///{
        ///}
        ///
        ///int [CLASS]::Execute([TEMPLATE]* a_pkObject)
        ///{
        ///	DIDEBUGGER_SEND(this);
        ///
        ///	//get current task
        ///	DiLib::DiTask&lt;[TEMPLATE]&gt;* pkTask = *m_itrCurrentTask;
        ///	if (pkTask != NULL) //check current task is valie
        ///	{
        ///		int eReturn;
        ///		eReturn = pkTask-&gt;Execute(a_pkObject);
        ///
        ///		switch (eReturn)
        ///		{
        ///		case DiLib::DI_TASK_RETURNS::DITASK_NEXTTASK: // [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string selcpp {
            get {
                return ResourceManager.GetString("selcpp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #include &quot;[CLASS].h&quot;
        ///#include &quot;DiReturnEnums.h&quot;
        ///#include &quot;[TEMPLATE].h&quot;
        ///
        ///[CLASS]::[CLASS]() : DiLib::[DICLASS]&lt;[TEMPLATE]&gt;()
        ///{
        ///}
        ///
        ///[CLASS]::~[CLASS]()
        ///{
        ///}
        ///
        ///int [CLASS]::Execute([TEMPLATE]* a_pkObject)
        ///{
        ///	DIDEBUGGER_SEND(this);
        ///
        ///	//run all the taskst in the sequence
        ///	int eReturn = DiLib::DI_TASK_RETURNS::DITASK_COMPLETE;
        ///
        ///	m_itrCurrentTask = m_akTaskSequence.begin();
        ///
        ///	DiLib::DiTask&lt;[TEMPLATE]&gt;* pkTask = NULL;
        ///	for (; m_itrCurrentTask != m_akTaskSequence.end(); ++m_itrCurrentTask)
        ///	{
        ///	 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string seqcpp {
            get {
                return ResourceManager.GetString("seqcpp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///#include &quot;[CLASS].h&quot;
        ///#include &quot;DiReturnEnums.h&quot;
        ///#include &quot;[TEMPLATE].h&quot;
        ///
        ///[CLASS]::[CLASS]() : DiLib::[DICLASS]&lt;[TEMPLATE]&gt;()
        ///{
        ///}
        ///
        ///[CLASS]::~[CLASS]()
        ///{
        ///}
        ///
        ///int [CLASS]::Execute([TEMPLATE]* a_pkObject)
        ///{
        ///	DIDEBUGGER_SEND(this);
        ///
        ///	return DiLib::DITASK_COMPLETE;
        ///}
        ///.
        /// </summary>
        internal static string taskcpp {
            get {
                return ResourceManager.GetString("taskcpp", resourceCulture);
            }
        }
    }
}
