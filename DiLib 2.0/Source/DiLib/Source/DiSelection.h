
/*
*********************************************************************************************************************************************
* DiLib v2.0 (dilib.dimutu.com)
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
* 2. NO alteration must be made to the source version.
* 
* 3. This notice may not be removed or altered from any source distribution.
* 
* 4. Third party open source "TinyXML" is used in this program, and for more information please see its own terms of use.
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


