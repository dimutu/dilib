
/*
*********************************************************************************************************************************************
* DiLib v2.0
*
* Author: Dimutu Kulawardana
* Date: 06-06-2011
* Description: execute tasks in selected order
*
* Modified: 20-02-2013
* Description: removed Execute function returning enum and changed to int, to able to have many types of return values
*
*********************************************************************************************************************************************
*/

#ifndef _DI_SELECTION_TASK_H_
#define _DI_SELECTION_TASK_H_

#include "DiSequence.h"

namespace DiLib
{
	template <class T>
	class DiSelection : public DiSequence<T>
	{
	public:

		/*
		********************************************************************************************************************************************
		* Function: DiSelection() - constructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		DiSelection();

		/*
		********************************************************************************************************************************************
		* Function: ~DiSelection() - destructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual ~DiSelection();

		/*
		********************************************************************************************************************************************
		* Function: Execute() - run current task until its completed and move on to next and loop until one fails
		* Parameters: T* a_pkOwner - ai player that is executing through the function
		* Return: int
		********************************************************************************************************************************************
		*/
		virtual int Execute(T* a_pkOwner);

		/*
		********************************************************************************************************************************************
		* Function: SetExecuteBegin() - set the current task back to begining
		* Parameters: void
		* Return: void
		********************************************************************************************************************************************
		*/
		void SetExecuteBegin();

		/*
		********************************************************************************************************************************************
		* Function: SetExecuteEnd() - set the current task to end so it will exit back to parent
		* Parameters: void
		* Return: void
		********************************************************************************************************************************************
		*/
		void SetExecuteEnd();

		/*
		********************************************************************************************************************************************
		* Function: SetExecutePosition() - set the current task to given position in the array
		* Parameters: unsigned int a_iPosition - task position in the array
		* Return: void
		********************************************************************************************************************************************
		*/
		void SetExecutePosition(unsigned int a_iPosition);

	protected:
		//member variable goes here
		

	};
	//***************************************************************************************************************************************************//

	#include "DiSelection.inl"
}
//***************************************************************************************************************************************************//

#endif


