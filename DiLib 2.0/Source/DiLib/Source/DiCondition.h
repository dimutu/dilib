
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
* Date: 04-06-2011
* Description: check a condition and if child task exists try to run the task or return back to parent
*
* Modified: 20-02-2013
* Description: removed Execute function returning enum and changed to int, to able to have many types of return values
*
*********************************************************************************************************************************************
*/

#ifndef _DI_CONDITION_TASK_H_
#define _DI_CONDITION_TASK_H_

#include "DiTask.h"

namespace DiLib
{
	template <class T>
	class DiCondition : public DiTask<T>
	{
	public:

		/*
		********************************************************************************************************************************************
		* Function: DiCondition() - constructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		DiCondition();

		/*
		********************************************************************************************************************************************
		* Function: ~DiCondition() - virtual destructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual ~DiCondition();

		/*
		********************************************************************************************************************************************
		* Function: Execute() - do the ai stuff to this playr, either using lua script is set or the code set in the function
		*						virtual function that has to implement for do ai stuff
		* Parameters: T* a_pkOwner - ai player that is executing through the function
		* Return: int
		********************************************************************************************************************************************
		*/
		virtual int Execute(T* a_pkOwner) = 0;

		/*
		********************************************************************************************************************************************
		* Function: SetTrueTask() - set the task needs to run when this tasks condition is satisfy
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual void SetTrueTask(DiTask<T>* a_pkTask);

		/*
		********************************************************************************************************************************************
		* Function: SetFalseTask() - task that needs to execute if the condition isnt met
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual void SetFalseTask(DiTask<T>* a_pkTask);

	protected:
		DiTask<T> *m_pkTrueTask; //task that will run when the condition is met
		DiTask<T> *m_pkFalseTask; //task that will run when the condition isnt met

	};
	//***************************************************************************************************************************************************//


	#include "DiCondition.inl"

}

#endif

