

/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 11-11-2011
* Description: windows socket includes and linking library
*
*********************************************************************************************************************************************
*/

#ifndef _WINDOWS_
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#undef WIN32_LEAN_AND_MEAN
#endif

#include <winsock2.h>

#pragma comment(lib, "ws2_32.lib")

