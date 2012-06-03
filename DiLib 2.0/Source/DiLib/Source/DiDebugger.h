
/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 12-11-2011
* Description: debugger macros to use in behaviour tree task, which is under _DEBUG directive so only effect while debugging and not in
*					final output
*
*********************************************************************************************************************************************
*/

#ifndef _DI_DEBUGGER_H_
#define _DI_DEBUGGER_H_


#if defined(_DEBUG) && defined(_WIN32)

//flag debug mode is on to setup debugger with tree UI
#define _DIDEBUG
#endif


#ifdef _DIDEBUG

#include "DiNetwork.h"

/*
********************************************************************************************************************************************
* Macro: DIDEBUGGER_INIT() - call the initialization function for debugging service
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
#define DIDEBUGGER_INIT() DiNetwork::Initialize()

/*
********************************************************************************************************************************************
* Macro: DIDEBUGGER_SHUTDOWN() - call the debugging service termination functions
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
#define DIDEBUGGER_SHUTDOWN() DiNetwork::Shutdown()

/*
********************************************************************************************************************************************
* Macro: DIDEBUGGER_SEND() - send the data through the connected dubugging service
* Parameters: a_pkTask - pointer of DiBase
* Return: none
********************************************************************************************************************************************
*/
#define DIDEBUGGER_SEND(a_pkTask) DiNetwork::Debug(DiLib::DiBase* a_pkTask) 

#else //not running on debug build

/*
********************************************************************************************************************************************
* Macro: DIDEBUGGER_INIT() - release version (doesnt execute any functionality for debug service
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
#define DIDEBUGGER_INIT() 

/*
********************************************************************************************************************************************
* Macro: DIDEBUGGER_SHUTDOWN() - release version (doesnt execute any functionality for debug service
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
#define DIDEBUGGER_SHUTDOWN() 

/*
********************************************************************************************************************************************
* Macro: DIDUBGGER_SEND() - release version (doesnt execute any functionality for debug service
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
#define DIDEBUGGER_SEND(a_pkTask) 


#endif //end directive for checking _DEBUG


#endif

