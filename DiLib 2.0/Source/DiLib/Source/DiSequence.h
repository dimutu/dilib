

/*
*********************************************************************************************************************************************
* DiLib v2.0
*
* Author: Dimutu Kulawardana
* Date: 28-05-2011
* Description: inherits from DiCondition and do the task on given time intervel and it can be a continuos loop, eg: run animation, play sound
*
* Modified: 20-02-2013
* Description: removed Execute function returning enum and changed to int, to able to have many types of return values
*
*********************************************************************************************************************************************
*/

#ifndef _DI_SEQUENCE_TASK_H_
#define _DI_SEQUENCE_TASK_H_

#include <vector>
#include "DiTask.h"

namespace DiLib
{
	template <class T>
	class DiSequence : public DiTask<T>
	{
	public:
		/*
		********************************************************************************************************************************************
		* Function: DiSequence() - constructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		DiSequence();

		/*
		********************************************************************************************************************************************
		* Function: ~DiSequence() - destructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual ~DiSequence();

		/*
		********************************************************************************************************************************************
		* Function: AddTask() - add a task to end of the sequence task list
		* Parameters:  DiTask<T>* a_pkTask  - pointer to the task
		* Return: bool - insertion success(true) or not(false)
		********************************************************************************************************************************************
		*/
		bool AddTask( DiTask<T>* a_pkTask );

		/*
		********************************************************************************************************************************************
		* Function: AddTask() - add a task to given position in the sequence task list
		* Parameters:   DiTask<T>* a_pkTask  - pointer to the task
		*				unsigned int a_uiPosition - task position in the array
		* Return: bool - insertion success(true) or not(false)
		********************************************************************************************************************************************
		*/
		bool AddTask( DiTask<T>* a_pkTask, unsigned int a_uiPosition );

		/*
		********************************************************************************************************************************************
		* Function: RemoveTask() - remove a task in given position in the array
		* Parameters:  unsigned int a_uiPosition - array position of the task that needs removing
		* Return: bool - remove success(true) or not(false)
		********************************************************************************************************************************************
		*/
		bool RemoveTask(unsigned int a_uiPosition );

		/*
		********************************************************************************************************************************************
		* Function: RemoveAllTasks() - remove all tasks in the array
		* Parameters:  void
		* Return: bool - remove success(true) or not(false)
		********************************************************************************************************************************************
		*/
		bool RemoveAllTasks();

		/*
		********************************************************************************************************************************************
		* Function: Execute() - run all the child tasks sequenctially
		* Parameters: T* a_pkOwner - ai player that is executing through the function
		* Return: DI_TASK_RETURNS
		********************************************************************************************************************************************
		*/
		virtual int Execute(T* a_pkOwner);

		/*
		********************************************************************************************************************************************
		* Function: GetTasksCount() - return total tasks in the list
		* Parameters:  void
		* Return: unsigned int - array element cound
		********************************************************************************************************************************************
		*/
		unsigned int GetTasksCount() const;

	protected:
		typename std::vector< DiTask<T>* > m_akTaskSequence; //task list to execute

		//currently running task in the task array
		typename std::vector< DiTask<T>* >::iterator m_itrCurrentTask;

	};
	//***************************************************************************************************************************************************//

	#include "DiSequence.inl"

}
//***************************************************************************************************************************************************//

#endif

