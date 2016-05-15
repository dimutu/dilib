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
        DIDEBUGCONTROL_BREAKPOINT //current node is in C# has breakpoint, sending back value to C++
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
