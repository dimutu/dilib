
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

//! \details Main library namespace

//! \namespace DiLib
namespace DiLib
{
	//! \class DiTimer
	//! \details Timer class to help execute code in time intervals using time in milliseconds
	class DiTimer
	{
	public:
		//! Constructor
		DiTimer();

		//! Constructor with default time interval
		//! \param a_uiTimeInterval Time interval for the timer (milliseconds) 
		DiTimer(const unsigned int a_uiTimeInterval);

		//! Destructor
		~DiTimer();

		//! Sets a new time interval
		//! \param a_uiTimeInterval New time interval for the timer 
		void SetTimeInterval(const unsigned int a_uiTimeInterval);

		//! Gets current time interval
		//! \return Current time interval in milliseconds
		unsigned int GetTimeInterval() const;

		//! Checks currently passed or at next execution time
		//! \return bool value of time is reached (true) or pending (false)
		bool IsRunTime() const; 

		//! Set the time to next time interval using current set interval, to have a repeat effect
		void SetNextTimeInterval(); 

	private:

		void CaclNextRunTime();

	private:
		unsigned int m_uiTimeInterval; //time gap between each execution

		clock_t m_lLastRunTime; //time at last execution

		clock_t m_lNextRunTime; //next execution time


	};

}
#endif


