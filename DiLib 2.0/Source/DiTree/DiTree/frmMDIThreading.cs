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

        private void DebugConnect()
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

            }
            catch (Exception ex)
            {
                DiMethods.SetErrorLog(ex);
                DiMethods.MyDialogShow("Unable to open socket\nError: " + ex.Message, MessageBoxButtons.OK);
                m_frmConsole.addOutputText("Error connecting: " + ex.Message);
            }
        }

        private void DebugDisconnect()
        {
            if (m_kMainThread != null)
            {
                m_kMainThread.Abort();
                m_kMainThread = null;
            }
            if (m_kListenThread != null)
            {
                m_kListenThread.Abort();
                m_kListenThread = null;
            }

            m_frmConsole.addOutputText("Debugger Disconnected.");
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
                        m_frmConsole.addOutputText("Debugger receieve data incomplete.");
                        break;
                    }

                }
                catch (Exception e)
                {
#if DEBUG
                    Console.WriteLine(e.Message.ToString());
#endif
                    m_frmConsole.addOutputText("Debugger connection error:" + e.Message);
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
                        UpdateFrame(kMsgData);
                    }
                }

                //do whatever using the data
                 Console.WriteLine("task : " + kMsgData.m_zDebugID + " : " + kMsgData.m_zDebugTreeID + " : " + kMsgData.m_lDebugTaskID.ToString() + " : " + kMsgData.m_lTime.ToString());
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
                    //  toolStripStatusDebugProgress.Visible = false;
                    DiGlobals.IsConnected = false;
                    //ShowDebugConnectMenu();
                }
                ));
            }
        }

        public void UpdateFrame(DiDebugData a_kDebugData)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    Form frmActive = this.ActiveMdiChild;
                    if (frmActive != null)
                    {
                        
                        if (frmActive.GetType() == typeof(frmDiFile))
                        {
                            frmDiFile f = (frmDiFile)frmActive;
                            if (f.DebugID == a_kDebugData.m_zDebugID) //check active tree is the one that data is coming for
                            {
                                f.SetTreeDebugData(a_kDebugData.m_zDebugTreeID, a_kDebugData.m_lDebugTaskID);
                            }


                        }
                    }


                    //place any data coming in to console
                    if (a_kDebugData != null)
                    {
                        m_frmConsole.addOutputText("Debug data:" + a_kDebugData.m_zDebugID + " : " + a_kDebugData.m_zDebugTreeID + " : " + a_kDebugData.m_lDebugTaskID.ToString() + " : " + a_kDebugData.m_lTime.ToString());
                    }

                }
                ));
            }
        }
    }
}
