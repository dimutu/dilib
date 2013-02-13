using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace DiTree
{
    //values to send to C++ to move on C# toolbutton pressing
    public enum DIDEBUGCONTROLS
    {
        DIDEBUGCONTROL_NONE, //for threading so it can set once the current control is sent to c++
        DIDEBUGCONTROL_STARTDEBUG, //pressed pause, so start debuging in C++
        DIDEBUGCONTROL_NEXTTASK, //move to next task in C++
        DIDEBUGCONTROL_RESUME, //stop debugging and business as usual,
        DIDEBUGCONTROL_BREAKPOINT_ADD, //added new breakpoint
        DIDEBUGCONTROL_BREAKPOINT_REMOVE, //removed breakpoint
        DIDEBUGCONTROL_BREAKPOINT_REMOVE_ALL, //remove all breakpoints
        DIDEBUGCONTROL_BREAKPOINT_EXECUTE //currently executing a breakpoint (RETURN DATA)
    };

    [StructLayout(LayoutKind.Explicit, Size = DiGlobals._DIDEBUGSTRUCTSIZE)]
    public struct DiDebugData
    {
        [FieldOffset(0), MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_zDebugID;

        [FieldOffset(256), MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_zDebugTreeID;

        [FieldOffset(512)]
        public double m_lTime;

        [FieldOffset(520)]
        public long m_lDebugTaskID;

         [FieldOffset(524)]
        public DIDEBUGCONTROLS m_eCommand;

        // These change the calling code's correctness
        public static bool operator ==(DiDebugData f1, DiDebugData f2) { return false; }
        public static bool operator !=(DiDebugData f1, DiDebugData f2) { return false; }

        // These aren't relevant, but the compiler will issue an
        // unrelated warning if they're missing
        public override bool Equals(object x) { return false; }
        public override int GetHashCode() { return 0; }
    };

    [StructLayout(LayoutKind.Explicit, Size = DiGlobals._DIDEBUGCONTROLSIZE)]
    public struct DiDebugControl
    {
        [FieldOffset(0), MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_zDebugID;

        [FieldOffset(256), MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string m_zDebugTreeID;

        [FieldOffset(512)]
        public DIDEBUGCONTROLS m_eCommand;

        [FieldOffset(516)]
        public long m_lDebugTaskID;
    };
}
