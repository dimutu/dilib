using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiTree
{
    /// <summary>
    /// global data
    /// </summary>
    public static class DiGlobals
    {
        public const int DEBUG_PORT = 34542; //debug port to connect
        public const int _DIDEBUGSTRUCTSIZE = 524;
        public const int _DIDEBUGCONTROLSIZE = 516;
        private static bool m_bIsConnected = false;
        private static bool m_bDebugOn = false; //is c# is debuggin the c++ code(true) or default just showing where the c++ currently executing (false)
        private static bool m_bDebugNextOn = false; //is next button pressed
        private static bool m_bDebugView = false; //ability to see where the current nodes are executing

        public static bool IsConnected
        {
            get
            {
                return m_bIsConnected;
            }
            set
            {
                m_bIsConnected = value;
            }
        }

        public static bool IsDebugging
        {
            get
            {
                return m_bDebugOn;
            }
            set
            {
                m_bDebugOn = value;
            }
        }

        public static bool IsDebugNextOn
        {
            get
            {
                return m_bDebugNextOn;
            }
            set
            {
                m_bDebugNextOn = value;
            }
        }

        public static bool IsDebugViewable
        {
            get
            {
                return m_bDebugView;
            }
            set
            {
                m_bDebugView = value;
            }
        }
    }
}
