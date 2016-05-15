
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
* 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
* 
* 3. This notice may not be removed or altered from any source distribution.
* 
* 4. Third party open source "TinyXML" is used in this program, and for more information please see its own terms of use.
*
* Author: Dimutu Kulawardana
* Date: 12-11-2011
* Description: debugger macros to use in behaviour tree task, which is under _DEBUG directive so only effect while debugging and not in
*					final output
*
* Modified: 20-06-2012
* Description: added _DIDEBUG preprocessor to setup debug mode only on WIN platform
*
* Modified: 11-01-2013
* Description: change namespace and renamed Terminate function to Shutdown
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
#define DIDEBUGGER_INIT() DiLib::Initialize()

/*
********************************************************************************************************************************************
* Macro: DIDEBUGGER_SHUTDOWN() - call the debugging service termination functions
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
#define DIDEBUGGER_SHUTDOWN() DiLib::Shutdown()

/*
********************************************************************************************************************************************
* Macro: DIDEBUGGER_SEND() - send the data through the connected dubugging service
* Parameters: task - pointer of DiBase
* Return: none
********************************************************************************************************************************************
*/
#define DIDEBUGGER_SEND(task) DiLib::Debug(task);

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
#define DIDEBUGGER_SEND(task) 


#endif //end directive for checking _DEBUG


#endif

