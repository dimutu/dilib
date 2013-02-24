
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

//! \details Main library namespace

//! \namespace DiLib
namespace DiLib
{

	//! Initialize network sockets to prepare debugging data service. INTERNAL USE ONLY
	bool Initialize();

	//! Debug networking here and return the calling function requires to execute or skip. INTERNAL USE ONLY
	bool Debug(DiBase* a_pkTask);

	//! Close all the sockets and data transfer. INTERNAL USE ONLY
	void Shutdown();
}

#endif


