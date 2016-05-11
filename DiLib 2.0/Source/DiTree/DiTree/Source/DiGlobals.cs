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
        public const int _DIDEBUGSTRUCTSIZE = 528;
        public const int _DIDEBUGCONTROLSIZE = 520;

        public const string DIEXT_DIDATA = "didata";
        public const string DIEXT_DICONFIG = "diconfig";
        public const string DIEXT_DITREE = "ditree";

        private static bool m_bIsConnected = false;
        private static bool m_bDebugOn = false; //is c# is debuggin the c++ code(true) or default just showing where the c++ currently executing (false)
       private static bool m_bIsListening = false;
        private static bool m_bLogDebugInfo = true;

        private static bool m_bIsBreak = false; //flag break is selected from menu, then use that as a breakpoint on whatever current location is
        private static bool m_bIsResume = false; //flag menu action of continue selected

        private static int m_iDebugSpeed = 0; //debug speed to slow down the visual speed
        private static bool m_bIsFirstRun = true; //flag first run after connection establish, this is to set a delay between connection start and first update
        private static bool m_bDisableBreakpoints = false;

        /// <summary>
        /// Debugger connected to C++ source
        /// </summary>
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

        /// <summary>
        /// Debugging is break and using Step functions
        /// </summary>
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

        /// <summary>
        /// Currently waiting for C++ source to connect
        /// </summary>
        public static bool IsListening
        {
            get
            {
                return m_bIsListening;
            }
            set
            {
                m_bIsListening = value;
            }
        }

        /// <summary>
        /// Log debugging data into console
        /// </summary>
        public static bool LogDebugInfo
        {
            get
            {
                return m_bLogDebugInfo;
            }
            set
            {
                m_bLogDebugInfo = value;
            }
        }

        /// <summary>
        /// Break menu selected
        /// </summary>
        public static bool IsBreak
        {
            get
            {
                return m_bIsBreak;
            }
            set
            {
                m_bIsBreak = value;
            }
        }

        /// <summary>
        /// Continue menu selected
        /// </summary>
        public static bool IsResume
        {
            get
            {
                return m_bIsResume;
            }
            set
            {
                m_bIsResume = value;
            }
        }

        /// <summary>
        /// when debugging this will slow down the transfer rate
        /// </summary>
        public static int DebugSpeed
        {
            get
            {
                return m_iDebugSpeed;
            }
            set
            {
                m_iDebugSpeed = value;
            }
        }

        /// <summary>
        /// flag first run after connection establish, this is to set a delay between connection start and first update
        /// </summary>
        public static bool IsFirstRun
        {
            get
            {
                return m_bIsFirstRun;
            }
            set
            {
                m_bIsFirstRun = value;
            }
        }

        /// <summary>
        /// Currently set breakpoints are disabled and gets ignored
        /// </summary>
        public static bool DisableBreakpoints
        {
            get
            {
                return m_bDisableBreakpoints;
            }
            set
            {
                m_bDisableBreakpoints = value;
            }
        }
    }
}
