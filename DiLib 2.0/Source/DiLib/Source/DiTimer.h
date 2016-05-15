
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
* Date: 28-05-2011
* Description: timer class to help execute code in time intervals
*
*********************************************************************************************************************************************
*/

#ifndef _DI_TIMER_H_
#define _DI_TIMER_H_

#include <time.h>

namespace DiLib
{
	class DiTimer
	{
	public:
		/*
		********************************************************************************************************************************************
		* Function: DiTimer() - constructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		DiTimer();

		/*
		********************************************************************************************************************************************
		* Function: DiTimer() - constructor
		* Parameters: const unsigned int a_uiTimeInterval - time interval for the timer (milliseconds) 
		* Return: none
		********************************************************************************************************************************************
		*/
		DiTimer(const unsigned int a_uiTimeInterval);

		/*
		********************************************************************************************************************************************
		* Function: ~DiTimer() - destructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		~DiTimer();

		/*
		********************************************************************************************************************************************
		* Function: SetTimeInterval() - set a new time interval
		* Parameters: const unsigned int a_uiTimeInterval - time interval for the timer 
		* Return: void
		********************************************************************************************************************************************
		*/
		void SetTimeInterval(const unsigned int a_uiTimeInterval);

		/*
		********************************************************************************************************************************************
		* Function: GetTimeInterval() - get current time interval
		* Parameters: void
		* Return: const unsigned int a_uiTimeInterval
		********************************************************************************************************************************************
		*/
		unsigned int GetTimeInterval() const;

		/*
		********************************************************************************************************************************************
		* Function: IsRunTime() - checks currently passed or at next execution time, and if so calculate next again
		* Parameters: none
		* Return: bool - given time interval is passed (true) or pending(false)
		********************************************************************************************************************************************
		*/
		bool IsRunTime() const; 

		/*
		********************************************************************************************************************************************
		* Function: SetNextTimeInterval() - set the time to next time interval using current interval, so have a repeat effect
		* Parameters: none
		* Return: void
		********************************************************************************************************************************************
		*/
		void SetNextTimeInterval(); 

	private:
		/*
		********************************************************************************************************************************************
		* Function: CaclNextRunTime() - calculate next run time
		* Parameters: none
		* Return: void
		********************************************************************************************************************************************
		*/
		void CaclNextRunTime();

	private:
		unsigned int m_uiTimeInterval; //time gap between each execution

		clock_t m_lLastRunTime; //time at last execution

		clock_t m_lNextRunTime; //next execution time
	};

}
#endif


