
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
* Date: 04-06-2011
* Description: Execute task on given time intervel and it can be a continues loop or fixed iteration count eg: run animation, play sound
*
* Modified: 14-10-2012
* Description: changed inheritance to DiTask and only has single task execution on timer
*
* Modified: 28-11-2012
* Description: fixed issue with loading tree not setting up timer properties
*
* Modified: 20-02-2013
* Description: removed Execute function returning enum and changed to int, to able to have many types of return values
*
*********************************************************************************************************************************************
*/

#ifndef _DI_FILTER_TASK_H_
#define _DI_FILTER_TASK_H_

#include "DiTask.h"
#include "DiTimer.h"

namespace DiLib
{
	template <class T>
	class DiFilter : public DiTask<T>
	{

	public:
		/*
		********************************************************************************************************************************************
		* Function: DiFilter() - constructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		DiFilter();

		/*
		********************************************************************************************************************************************
		* Function: ~DiFilter() - virtual destructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual ~DiFilter();

		/*
		********************************************************************************************************************************************
		* Function: Execute() - execute child task if the filtering time has met and reset timer for next execution if loop or iteration count set
		* Parameters: T* a_pkOwner - ai player that is executing through the function
		* Return: int
		********************************************************************************************************************************************
		*/
		virtual int Execute(T* a_pkOwner);

		/*
		********************************************************************************************************************************************
		* Function: SetTask() - set the task needs to run when filter satisfied
		* Parameters: DiTask<T>* a_pkTask - task to run
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual void SetTask(DiTask<T>* a_pkTask);

		/*
		********************************************************************************************************************************************
		* Function: SetTimer() - set the task timer 
		* Parameters: const unsigned int a_uiTimeInterval - time interval to run the task between time gaps
		* Return: void
		********************************************************************************************************************************************
		*/
		virtual void SetTimer(const unsigned int a_uiTimeInterval);

		/*
		********************************************************************************************************************************************
		* Function: SetMaxRunCycles() - set number of times this task should run
		* Parameters: unsigned int a_MaxRunCycles - number of run cycles
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual void SetMaxRunCycles(unsigned int a_MaxRunCycles);

		/*
		********************************************************************************************************************************************
		* Function: SetLoop() - set task looping or not, if looped it will until task fails
		* Parameters: bool a_bLoop - 
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual void SetLoop(bool a_bLoop);

		/*
		********************************************************************************************************************************************
		* Function: GetMaxRunCycles() - return current maximum run cycles
		* Parameters: void
		* Return: unsigned int 
		********************************************************************************************************************************************
		*/
		unsigned int GetMaxRunCycles() const;

		/*
		********************************************************************************************************************************************
		* Function: GetCurentRunCycle() - return how many times this task has ran
		* Parameters: void
		* Return: unsigned int 
		********************************************************************************************************************************************
		*/
		unsigned int GetCurentRunCycle() const;

		/*
		********************************************************************************************************************************************
		* Function: ResetRunCycleCounter() - reset the current runtime counter back to begining
		* Parameters: void
		* Return: void 
		********************************************************************************************************************************************
		*/
		virtual void ResetRunCycleCounter();

		/*
		********************************************************************************************************************************************
		* Function: IsLoopOn() - return current task is set to loop or not
		* Parameters: void
		* Return: bool - task is looping(true) or not (false) 
		********************************************************************************************************************************************
		*/
		bool IsLoopOn() const;


	protected:
		DiTask<T>* m_pkTask; //task to run on filter conditions satisfied

		DiTimer* m_pkTimer; //timer

		unsigned int m_uiMaxRunCycles; //how many times this should run in loop

		unsigned int m_uiRunCycleCounter; //how many times this already ran

		bool m_bIsLoopOn; //no need for max cycles, this is an endless loop

	};

	#include "DiFilter.inl"

}

#endif
