
/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 11-11-2011
* Description: network class to manage data sending to client UI for debugging servince, run as a singleton
*********************************************************************************************************************************************
*/

#include <string>
#include <assert.h>
#include <time.h>
#include <vector>

#include "DiNetwork.h"
#include "DiTask.h"
#include "DiCondition.h"
#include "DiFilter.h"
#include "DiSelection.h"
#include "DiSequence.h"

namespace DiLib
{
	//data from the enumrations in the behaviour tree
	#pragma pack(4)
	struct DiDebugData
	{
		char m_zDebugId[_DIMAXCHARLENGTH];
		char m_zDebugTreeID[_DIMAXCHARLENGTH];
		double m_lTime; //time since the program started
		long m_lDebugTaskID;
		int m_iCommand; //returning values
	};
	#pragma pack()

	//data from UI to control the behaviour tree
	#pragma pack(4)
	struct DiDebugControl
	{
		char m_zDebugId[_DIMAXCHARLENGTH];
		char m_zDebugTreeID[_DIMAXCHARLENGTH];
		int m_iCommand;
		long m_lDebugTaskID;
	};
	#pragma pack()

	SOCKET m_kSendSocket; //socket to send data
	sockaddr_in m_kRecevAddr; 
	bool m_bIsConnected = false;
	std::string m_zDebugID;
	std::string m_zDebugTreeID;
	int m_iDebugCommand = 0;
	std::vector<long> m_alBreakpoints; //all the breakpoints stored here

	//function declaration
	bool InitWinSock(); //initialize windows socket for connection
	void CreateSocket(); //connect to network socket
	void Send(DiBase* a_pkTask);  //send data to connected port 
	void Receive(DiBase* a_pkTask); // receive messages (UI debug commands)
	void SetBreakpoint(long a_lDebugTaskID, bool a_bRemove = false); //set breakpoints list
	void CheckBreakpoint(DiBase* a_pkTask);

	/*
	********************************************************************************************************************************************
	* Function: Initialize() - initialize sockets to prepare debugging data service
	* Parameters: void
	* Return: void
	********************************************************************************************************************************************
	*/
	bool Initialize()
	{
		if (!InitWinSock())
		{
			return false;
		}

		CreateSocket();
		return true;
	}

	/*
	********************************************************************************************************************************************
	* Function: Shutdown() - delete instance
	* Parameters: void
	* Return: void
	********************************************************************************************************************************************
	*/
	void Shutdown()
	{
		if (m_bIsConnected)
		{
			shutdown(m_kSendSocket, SD_SEND);
			closesocket(m_kSendSocket);
		}
	}

	/*
	********************************************************************************************************************************************
	* Function: InitWinSock() - initialize windows socket for connection
	* Parameters: void
	* Return: void
	********************************************************************************************************************************************
	*/
	bool InitWinSock()
	{
		WSADATA kWasaData;
		int iResult = 0;

		//init code here
		iResult = WSAStartup(MAKEWORD(2, 2), &kWasaData);
		if (iResult != 0)
		{
			//failed
			return false;
		}

		return true;
	}

	/*
	********************************************************************************************************************************************
	* Function: CreateSocket() - connect
	* Parameters: void
	* Return: void
	********************************************************************************************************************************************
	*/
	void CreateSocket()
	{
		if (!m_bIsConnected)
		{
			m_kSendSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
			assert(m_kSendSocket != INVALID_SOCKET);
			m_kRecevAddr.sin_family = AF_INET;
			m_kRecevAddr.sin_port = htons(_DINETWORKPORT);
			m_kRecevAddr.sin_addr.s_addr = inet_addr("127.0.0.1");

			int iResult = connect(m_kSendSocket, (sockaddr*)&m_kRecevAddr, sizeof(m_kRecevAddr));
			if (iResult < 0)
			{
				m_bIsConnected = false;
			}
			else
			{
				m_bIsConnected = true;

				//setup to none blocking data receiving
				u_long iMode = 1;
				ioctlsocket(m_kSendSocket, FIONBIO, &iMode);
			}
		}
	}

	/*
	********************************************************************************************************************************************
	* Function: Debug() - do the debug networking here and return the calling function requires to execute or skip
	* Parameters: void
	* Return: bool - does the debug requires to move into the function calling and execute its content(true) or return back to parent function(false)
	********************************************************************************************************************************************
	*/
	bool Debug(DiBase* a_pkTask)
	{
#ifdef _DIDEBUG

		Receive(a_pkTask); //check for incoming data
		CheckBreakpoint(a_pkTask); //check current node is set for breakpoint
		Send(a_pkTask);

		return true;

#else
		return true;
#endif
	}

	/*
	********************************************************************************************************************************************
	* Function: Send() - send data to connected port 
	* Parameters: DiBase* a_pkTask - task data that need to send 
	* Return: void
	********************************************************************************************************************************************
	*/
	void Send(DiLib::DiBase* a_pkTask) //send data to connected clients
	{
#ifdef _DIDEBUG
		DiDebugData kData;
		//strcpy_s(kData.m_zEnumName, a_pkTask->GetDebugIdentifier());
		strcpy_s(kData.m_zDebugId, a_pkTask->GetDebugId());
		strcpy_s(kData.m_zDebugTreeID, a_pkTask->GetDebugTreeId());
		kData.m_lDebugTaskID = a_pkTask->GetDebugTaskId();
		kData.m_lTime = clock();
		kData.m_iCommand = 0;
		sendto(m_kSendSocket, (char*)&kData, sizeof(kData), 0, (SOCKADDR*)&m_kRecevAddr, sizeof(m_kRecevAddr) );

#endif
		
	}

	void Receive(DiLib::DiBase* a_pkTask)
	{
#ifdef _DIDEBUG

		DiDebugControl kControl;
		char zBuff[ sizeof(DiDebugControl) ];
		int iByteRecv = 0;
		long lTaskID = 0;

		if (m_zDebugID.size() > 0) //debug control set
		{
			//only call receive only if this is the task thats paused from UI
			if (m_zDebugID.compare(a_pkTask->GetDebugId()) != 0)
			{
				//this is not the command intended tree, ignore
				return;
			}
			else if (m_zDebugTreeID.compare( a_pkTask->GetDebugTreeId() ) != 0)
			{
				return;
			}
		}

		iByteRecv = recv(m_kSendSocket, zBuff, sizeof(DiDebugControl), 0);

		if (iByteRecv > 0)
		{
			//get the command sent from the c# UI
			/*
			0. DIDEBUGCONTROL_NONE, //for threading so it can set once the current control is sent to c++
			1. DIDEBUGCONTROL_STARTDEBUG, //pressed pause, so start debuging in C++
			2. DIDEBUGCONTROL_NEXTTASK, //move to next task in C++
			3. DIDEBUGCONTROL_RESUME, //stop debugging and business as usual,
			4. DIDEBUGCONTROL_BREAKPOINT_ADD, //added new breakpoint
			5. DIDEBUGCONTROL_BREAKPOINT_REMOVE, //removed breakpoint
			6. DIDEBUGCONTROL_BREAKPOINT_REMOVE_ALL //remove all breakpoints
			7. DIDEBUGCONTROL_BREAKPOINT_EXECUTE //currently executing at the break point
			*/
			memcpy((char*)&kControl, zBuff, sizeof(DiDebugControl));

			//set debug properties
			m_zDebugID = kControl.m_zDebugId;
			m_zDebugTreeID = kControl.m_zDebugTreeID;
			m_iDebugCommand = kControl.m_iCommand;
			lTaskID = kControl.m_lDebugTaskID;

			switch (m_iDebugCommand)
			{
			case 1:
				{
					//pausing, set to hold for UI commands
					u_long iMode = 0;
					ioctlsocket(m_kSendSocket, FIONBIO, &iMode);
					break;
				}
				
			case 2:
				{
					break;
				}

			case 3:
				{
					//set back not blocking
					u_long iMode = 1;
					ioctlsocket(m_kSendSocket, FIONBIO, &iMode);

					m_zDebugID.clear();
					m_zDebugTreeID.clear();
					m_iDebugCommand = 0;
					break;
				}
			case 4: //add new breakpoint
				{
					SetBreakpoint(lTaskID);
					break;
				}
				
			case 5: //remove breakpoint
				{
					SetBreakpoint(lTaskID, true);
					break;
				}

			case 6: //remove all breakpoints
				{
					m_alBreakpoints.erase(m_alBreakpoints.begin(), m_alBreakpoints.end());
					break;
				}

			default:
				break;
			}
			
		}
#endif
	}

	/**
	* Set breakpoints list
	*/
	void SetBreakpoint(long a_lDebugTaskID, bool a_bRemove)
	{
#ifdef _DIDEBUG
		std::vector<long>::iterator itr = m_alBreakpoints.begin();
		bool bExists = false;

		for (; itr != m_alBreakpoints.end(); ++itr)
		{
			if (*itr == a_lDebugTaskID)
			{
				bExists = true;
				if (a_bRemove)
				{
					m_alBreakpoints.erase(itr);
				}
				break;
			}
		}

		if (!bExists && !a_bRemove)
		{
			m_alBreakpoints.push_back(a_lDebugTaskID);
		}
#endif
	}

	/**
	* Check the currently executing node is in the breakpoint list
	*/
	void CheckBreakpoint(DiBase* a_pkTask)
	{
#ifdef _DIDEBUG
		std::vector<long>::iterator itr = m_alBreakpoints.begin();
		u_long iMode = 0;
		for (; itr != m_alBreakpoints.end(); ++itr)
		{
			if (*itr == a_pkTask->GetDebugTaskId())
			{
				//send message to say at the breakpoint
				DiDebugData kData;
				strcpy_s(kData.m_zDebugId, a_pkTask->GetDebugId());
				strcpy_s(kData.m_zDebugTreeID, a_pkTask->GetDebugTreeId());
				kData.m_lDebugTaskID = a_pkTask->GetDebugTaskId();
				kData.m_lTime = clock();
				kData.m_iCommand = 7; //DIDEBUGCONTROL_BREAKPOINT_EXECUTE
				sendto(m_kSendSocket, (char*)&kData, sizeof(kData), 0, (SOCKADDR*)&m_kRecevAddr, sizeof(m_kRecevAddr) );

				ioctlsocket(m_kSendSocket, FIONBIO, &iMode);
				break;
			}
		}
#endif
	}
}


