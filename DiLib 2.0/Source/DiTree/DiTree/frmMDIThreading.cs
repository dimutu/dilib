using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Runtime.InteropServices;

namespace DiTree
{
    public partial class frmMDI : Form
    {
        private Socket m_kMainSocket;
        private Socket m_kClientSocket;

        private Thread m_kMainThread;
        private Thread m_kListenThread;

        private bool m_bIsQutting;

        private frmDiFile m_frmDebugControlForm;

        private bool DebugConnect()
        {
            try
            {
                m_kMainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, DiGlobals.DEBUG_PORT);

                m_kMainSocket.Bind(ip);
                m_kMainSocket.Listen(10);
                m_kListenThread = new Thread(ConnectionAccept);
                m_kListenThread.IsBackground = true;
                m_kListenThread.Name = "Connection Listening Thread";
                m_kListenThread.Start();

                m_bIsQutting = false;

                m_frmConsole.addOutputText("Debugger connection listener started.");
                DiGlobals.IsListening = true;
                DiGlobals.IsFirstRun = true;
                return true;

            }
            catch (Exception ex)
            {
                DiMethods.SetErrorLog(ex);
                DiMethods.MyDialogShow("Unable to open socket\nError: " + ex.Message, MessageBoxButtons.OK);
                m_frmConsole.addOutputText("Error connecting: " + ex.Message);

                return false;
            }
        }

        private void DebugStopListenning()
        {
            try
            {
                if (m_kMainSocket != null)
                {
                    m_kMainSocket.Dispose();
                    m_kMainSocket = null;
                }
                if (m_kListenThread != null)
                {
                    m_kListenThread.Abort();
                    m_kListenThread = null;
                }
                m_frmConsole.addOutputText("Debugger stoped listenning for connections.");
            }
            catch (Exception e)
            {
                m_frmConsole.addOutputText("Error stop listenning." + e.Message);
            }
        }

        private void DebugDisconnectMainThread()
        {
            if (m_kMainThread != null)
            {
                m_kMainThread.Abort();
                m_kMainThread = null;
            }

            if (m_kMainSocket != null)
            {
                if (m_kMainSocket.Connected)
                {
                    m_kMainSocket.Shutdown(SocketShutdown.Both);
                    m_kMainSocket.Disconnect(false);
                }
                m_kMainSocket.Dispose();
                m_kMainSocket = null;
            }

            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    DebugDisconnectListenThread();
                }
                ));
            }

            DiGlobals.IsConnected = false;
            DiGlobals.IsDebugging = false;
            m_frmConsole.addOutputText("Debugger Disconnected.");
        }

        private void DebugDisconnectListenThread()
        {
            if (m_kListenThread != null)
            {
                m_kListenThread.Abort();
                m_kListenThread = null;
            }

            if (m_kClientSocket != null)
            {
                m_kClientSocket.Shutdown(SocketShutdown.Both);
                if (m_kClientSocket.Connected)
                {
                    m_kClientSocket.Disconnect(false);
                }
                m_kClientSocket.Dispose();
                m_kClientSocket = null;
            }

        }

        private void ConnectionAccept()
        {
            try
            {
                while (true)
                {
                    m_kClientSocket = m_kMainSocket.Accept();

                    if (m_kClientSocket.Connected)
                    {
                        ParameterizedThreadStart pts = new ParameterizedThreadStart(ListenForData);

                        m_kMainThread = new Thread(pts);
                        m_kMainThread.IsBackground = true;
                        m_kMainThread.Name = "Listening Thread";
                        m_kMainThread.Start(m_kClientSocket);

                        SetConnectedClientSocketInThread(m_kClientSocket);
                        m_frmConsole.addOutputText("Debugger connection established.");
                        
                        if (InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                DiGlobals.IsConnected = true;
                                DiGlobals.IsListening = false;
                                DebugMenuDisplay();
                            }
                             ));
                         }
                    }

                }
            }
            catch (Exception ex)
            {
                DiMethods.SetErrorLog(ex);
#if DEBUG
                Console.WriteLine(ex.Message);
#endif
            }
        }

        private void ListenForData(object a_kSocket)
        {
            Socket kClientSocket = (Socket)a_kSocket;
            IPEndPoint kSender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint kRemote = (EndPoint)kSender;
            int iReceiveDataLength = 0;

            while (!m_bIsQutting)
            {
                //receiving data
                byte[] abFuncNamePacket = new byte[DiGlobals._DIDEBUGSTRUCTSIZE];
                try
                {
                    iReceiveDataLength = kClientSocket.Receive(abFuncNamePacket, DiGlobals._DIDEBUGSTRUCTSIZE, SocketFlags.None);

                    //only take node data send from C++
                    if (iReceiveDataLength != DiGlobals._DIDEBUGSTRUCTSIZE)
                    {
                        UpdateConsole("Debugger receieve data incomplete.");
                        break;
                    }

                }
                catch (Exception e)
                {
#if DEBUG
                    Console.WriteLine(e.Message.ToString());
#endif
                    UpdateConsole("Debugger disconnected.");
                    UpdateSocketDisconnect();
                    DiMethods.SetErrorLog(e);
                    break;
                }

                GCHandle kPinnedPacket = GCHandle.Alloc(abFuncNamePacket, GCHandleType.Pinned);
                DiDebugData kMsgData = (DiDebugData)Marshal.PtrToStructure(kPinnedPacket.AddrOfPinnedObject(), typeof(DiDebugData));
                kPinnedPacket.Free();

                //do only for the active tab for now
                if (kMsgData.m_lDebugTaskID >= 0)
                {
                    if (DiGlobals.IsConnected)
                    {
                        if (DiGlobals.IsFirstRun)
                        {
                            Thread.Sleep(100);
                            DiGlobals.IsFirstRun = false;
                        }

                        if (!DiGlobals.IsDebugging)
                        {
                            Thread.Sleep(DiGlobals.DebugSpeed);
                        }
                        UpdateFrame(kMsgData);
                    }
                }

            }
        }

        //set client socket connected, to be accessible to everyone
        delegate void SetConnectedClientSocketDelegate(Socket a_kSocket);
        private void SetConnectedClientSocket(Socket a_kSocket)
        {
            m_kClientSocket = a_kSocket;
        }

        private void SetConnectedClientSocketInThread(Socket a_kSocket)
        {
            SetConnectedClientSocketDelegate d = new SetConnectedClientSocketDelegate(this.SetConnectedClientSocket);
            IAsyncResult result = d.BeginInvoke(a_kSocket, new AsyncCallback(this.CallbackMethodConnectdClient), d);
        }

        private void CallbackMethodConnectdClient(IAsyncResult ar)
        {
            SetConnectedClientSocketDelegate d = (SetConnectedClientSocketDelegate)ar.AsyncState;
            d.EndInvoke(ar);
        }
        //

        public void UpdateSocketDisconnect()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    DiGlobals.IsConnected = false;
                    m_frmConsole.addOutputText("Debug disconnected.");
                    DebugMenuDisplay();
                    DebugDisconnectMainThread();
                }
                ));
            }
        }

        public void UpdateConsole(string str)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker( delegate
                    {
                        m_frmConsole.addOutputText(str, true);
                    }
                ));
            }
        }

        public void UpdateFrame(DiDebugData a_kDebugData)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        //returning current executing node data
                        bool bUpdated = false;
                        Form frmActive = this.ActiveMdiChild;
                        if (frmActive != null)
                        {

                            if (frmActive.GetType() == typeof(frmDiFile))
                            {
                                frmDiFile f = (frmDiFile)frmActive;
                                if (f.DebugID == a_kDebugData.m_zDebugID) //check active tree is the one that data is coming for
                                {
                                    DiTreeNode node = f.SetTreeDebugData(a_kDebugData.m_zDebugTreeID, a_kDebugData.m_lDebugTaskID);
                                    //send back the node is updated
                                    if (node != null)
                                    {
                                        SendDebugTask(node.Task);

                                        string str = "";
                                        switch (node.ClassType)
                                        {
                                            case DICLASSTYPES.DICLASSTYPE_CONDITION:
                                                str = "DiCondition"; break;
                                            case DICLASSTYPES.DICLASSTYPE_FILTER:
                                                str = "DiFilter"; break;
                                            case DICLASSTYPES.DICLASSTYPE_ROOT:
                                                str = "DiRoot"; break;
                                            case DICLASSTYPES.DICLASSTYPE_SELECTION:
                                                str = "DiSelection"; break;
                                            case DICLASSTYPES.DICLASSTYPE_SEQUENCE:
                                                str = "DiSequence"; break;
                                            case DICLASSTYPES.DICLASSTYPE_TASK:
                                                str = "DiTask"; break;
                                            default:
                                                str = "Unknow Task"; break;
                                        };
                                        m_frmConsole.addOutputText(str + ":" + node.DebuggerID + " : " + a_kDebugData.m_zDebugTreeID + " : " + a_kDebugData.m_lDebugTaskID.ToString(), true);
                                        bUpdated = true;
                                    }

                                }
                            }
                        }

                        if (!bUpdated)
                        {
                            //couldnt reach the node, send back something to keep the connection alive
                            m_frmConsole.addOutputText("Task:" + a_kDebugData.m_lDebugTaskID + " : " + a_kDebugData.m_zDebugTreeID + " : " + a_kDebugData.m_lDebugTaskID.ToString(), true);

                            SendDebugCommands(DIDEBUGCONTROLS.DIDEBUGCONTROL_RESUME);
                        }
                    }
                    ));
                }
            }
            catch (Exception ex)
            {
                DiMethods.SetErrorLog(ex);
            }
        }

        /// <summary>
        /// Debug play and pause currently connected tree
        /// </summary>
        private void DebugPlayPause()
        {
            if (!DiGlobals.IsConnected)
            {
                DialogResult dr = DiMethods.MyDialogShow("You are not connected to debug service.", MessageBoxButtons.OK);
                return;
            }

            DiGlobals.IsDebugging = !DiGlobals.IsDebugging;

            if (DiGlobals.IsDebugging)
            {
                //debgging started
                DiGlobals.IsDebugNextOn = true;
                DiGlobals.IsBreak = true;

                //on debug through UI must have the viewable on
                if (!DiGlobals.IsDebugViewable)
                {
                    DiGlobals.IsDebugViewable = true;
                }

            }
            else
            {
                //debugging stoped
                SendDebugCommands(DIDEBUGCONTROLS.DIDEBUGCONTROL_RESUME);
            }
        }

        private void DebugPlayForward()
        {
            if (!DiGlobals.IsConnected)
            {
                return;
            }

            if (DiGlobals.IsDebugging)
            {
                SendDebugCommands(DIDEBUGCONTROLS.DIDEBUGCONTROL_NEXTTASK);
                DiGlobals.IsDebugNextOn = true; //flag so the tree can see that next update to set tree
            }
        }
        /// <summary>
        /// Send debugging commands back to C++
        /// </summary>
        /// <param name="eControl"></param>
        private void SendDebugCommands(DIDEBUGCONTROLS eControl)
        {
            if (m_kClientSocket != null)
            {
                if (m_kClientSocket.Connected)
                {
                    if (eControl != DIDEBUGCONTROLS.DIDEBUGCONTROL_NONE)
                    {
                        DiDebugControl kDebugControl = new DiDebugControl();
                        kDebugControl.m_eCommand = eControl;
                        if (m_frmDebugControlForm != null)
                        {
                            kDebugControl.m_zDebugID = m_frmDebugControlForm.DebugID;
                            kDebugControl.m_zDebugTreeID = m_frmDebugControlForm.GetTabTreeName();

                            byte[] barr = new byte[DiGlobals._DIDEBUGCONTROLSIZE];
                            IntPtr ptr = Marshal.AllocHGlobal(DiGlobals._DIDEBUGCONTROLSIZE);

                            Marshal.StructureToPtr(kDebugControl, ptr, true);
                            Marshal.Copy(ptr, barr, 0, DiGlobals._DIDEBUGCONTROLSIZE);
                            Marshal.FreeHGlobal(ptr);

                            m_kClientSocket.Send(barr, DiGlobals._DIDEBUGCONTROLSIZE, SocketFlags.None);
                        }

                    }
                }
            }


        }

        /// <summary>
        /// Send the task back to C++
        /// </summary>
        /// <param name="a_pkTask"></param>
        private void SendDebugTask(DiTask a_pkTask)
        {
            if (m_kClientSocket != null && a_pkTask != null)
            {
                if (m_kClientSocket.Connected)
                {
                    DiDebugControl kDebugControl = new DiDebugControl();
                    bool debug = DiGlobals.IsDebugging;
                    if (a_pkTask.Breakpoint)
                    {
                        kDebugControl.m_eCommand = DIDEBUGCONTROLS.DIDEBUGCONTROL_BREAKPOINT;
                        DiGlobals.IsDebugging = true;
                    }
                    else if (DiGlobals.IsBreak)
                    {
                        kDebugControl.m_eCommand = DIDEBUGCONTROLS.DIDEBUGCONTROL_STARTDEBUG;
                        DiGlobals.IsBreak = false;
                    }
                    else if (DiGlobals.IsResume)
                    {
                        kDebugControl.m_eCommand = DIDEBUGCONTROLS.DIDEBUGCONTROL_RESUME;
                        DiGlobals.IsResume = false;
                    }
                    else
                    {
                        kDebugControl.m_eCommand = DIDEBUGCONTROLS.DIDEBUGCONTROL_NONE;
                    }
                    if (debug != DiGlobals.IsDebugging)
                    {
                        DebugMenuDisplay();
                    }
                    if (m_frmDebugControlForm != null)
                    {
                        kDebugControl.m_zDebugID = m_frmDebugControlForm.DebugID;
                        kDebugControl.m_zDebugTreeID = m_frmDebugControlForm.GetTabTreeName();
                        kDebugControl.m_lDebugTaskID = a_pkTask.DebuggerID;

                        byte[] barr = new byte[DiGlobals._DIDEBUGCONTROLSIZE];
                        IntPtr ptr = Marshal.AllocHGlobal(DiGlobals._DIDEBUGCONTROLSIZE);

                        Marshal.StructureToPtr(kDebugControl, ptr, true);
                        Marshal.Copy(ptr, barr, 0, DiGlobals._DIDEBUGCONTROLSIZE);
                        Marshal.FreeHGlobal(ptr);

                        m_kClientSocket.Send(barr, DiGlobals._DIDEBUGCONTROLSIZE, SocketFlags.None);
                    }

                    
                }
            }


        }
    }
}
