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
        private static bool m_bDebugNextOn = false; //is next button pressed
        private static bool m_bDebugView = false; //ability to see where the current nodes are executing
        private static bool m_bIsListening = false;
        private static bool m_bLogDebugInfo = true;

        private static bool m_bIsBreak = false; //flag break is selected from menu, then use that as a breakpoint on whatever current location is
        private static bool m_bIsResume = false; //flag menu action of continue selected

        private static int m_iDebugSpeed = 0; //debug speed to slow down the visual speed

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
    }
}
