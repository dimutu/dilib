
/*
*********************************************************************************************************************************************
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


