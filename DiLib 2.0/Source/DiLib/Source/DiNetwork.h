
/*
*********************************************************************************************************************************************
* DiLib v2.0 (http://dilib.dimutu.com)
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
* 2. NO alteration must be made to the source version.
* 
* 3. This notice may not be removed or altered from any source distribution.
* 
* 4. Third party open source "TinyXML" is used in this program, and for more information please see its own terms of use.
*
* Author: Dimutu Kulawardana
* Date: 11-11-2011
* Description: network class to manage data sending to client UI for debugging servince, run as a singleton
*
* Modified: 11-01-2013
* Description: change namespace and renamed Terminate function to Shutdown
*
* Modified: 13-02-2013
* Description: re-write data transferring method to facilitate UI breakpoints
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


