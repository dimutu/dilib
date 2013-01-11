
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

#include "DiNetwork.h"
#include "DiTask.h"
#include "DiCondition.h"
#include "DiFilter.h"
#include "DiSelection.h"
#include "DiSequence.h"

namespace DiLib
{
	SOCKET m_kSendSocket; //socket to send data
	sockaddr_in m_kRecevAddr; 
	bool m_bIsConnected = false;
	std::string m_zDebugID;
	std::string m_zDebugTreeID;
	int m_iDebugCommand = 0;

	//function declaration
	bool InitWinSock(); //initialize windows socket for connection
	void CreateSocket(); //connect to network socket
	void Send(DiBase* a_pkTask);  //send data to connected port 
	void Receive(DiBase* a_pkTask); // receive messages (UI debug commands)

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

		bool bReturn = true;

		Receive(a_pkTask); //check for incoming data
		
		Send(a_pkTask);

		return bReturn;

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

		sendto(m_kSendSocket, (char*)&kData, sizeof(kData), 0, (SOCKADDR*)&m_kRecevAddr, sizeof(m_kRecevAddr) );

#endif
		
	}

	void Receive(DiLib::DiBase* a_pkTask)
	{
#ifdef _DIDEBUG

		DiDebugControl kControl;
		char zBuff[ sizeof(DiDebugControl) ];
		int iByteRecv = 0;

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
			1 - start
			2 - next
			3 - resume
			*/
			memcpy((char*)&kControl, zBuff, sizeof(DiDebugControl));

			//set debug properties
			m_zDebugID = kControl.m_zDebugId;
			m_zDebugTreeID = kControl.m_zDebugTreeID;
			m_iDebugCommand = kControl.m_iCommand;

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

			default:
				break;
			}
			
		}
#endif
	}		
}


