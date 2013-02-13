
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

namespace DiLib
{
	class DiBase;
	struct DiDebugData;
	struct DiDebugControl;
	struct DiDebugBreakpoint;
	

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
	* Function: Shutdown() - close all the sockets and data transfer
	* Parameters: void
	* Return: void
	********************************************************************************************************************************************
	*/
	void Shutdown();
}

#endif


