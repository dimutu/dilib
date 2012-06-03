
/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 11-11-2011
* Description: network class to manage data sending to client UI for debugging servince, run as a singleton
*
*********************************************************************************************************************************************
*/

#include "WinsockInclude.h"

#ifndef _DI_NETWORK_H_
#define _DI_NETWORK_H_


#define _DIMAXCHARLENGTH 256
#define _DINETWORKPORT 34542

namespace DiNetwork
{
	class DiBase;

	//data from the enumrations in the behaviour tree
	#pragma pack(4)
	struct DiDebugData
	{
		char m_zDebugId[_DIMAXCHARLENGTH];
		char m_zDebugTreeID[_DIMAXCHARLENGTH];
		double m_lTime; //time since the program started
		long m_lDebugTaskID;
	};
	#pragma pack()

	//data from UI to control the behaviour tree
	#pragma pack(4)
	struct DiDebugControl
	{
		char m_zDebugId[_DIMAXCHARLENGTH];
		char m_zDebugTreeID[_DIMAXCHARLENGTH];
		int m_iCommand;
	};
	#pragma pack()


		/*
		********************************************************************************************************************************************
		* Function: Initialize() - initialize sockets to prepare debugging data service
		* Parameters: void
		* Return: void
		********************************************************************************************************************************************
		*/
		bool Initialize();

		/*
		********************************************************************************************************************************************
		* Function: Debug() - do the debug networking here and return the calling function requires to execute or skip
		* Parameters: void
		* Return: bool - does the debug requires to move into the function calling and execute its content(true) or return back to parent function(false)
		********************************************************************************************************************************************
		*/
		bool Debug(DiBase* a_pkTask);

		/*
		********************************************************************************************************************************************
		* Function: Terminate() - close all the sockets and data transfer
		* Parameters: void
		* Return: void
		********************************************************************************************************************************************
		*/
		void Terminate();
}

#endif


