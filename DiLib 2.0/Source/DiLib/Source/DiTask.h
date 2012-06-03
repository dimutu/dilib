
/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 28-05-2011
* Description: template class gets to implement a single task that executed by a player,		
*		** NOTE THAT THIS IS JUST A TEMPLATE THAT HAS TO IMPLEMENT TO EACH TASK SO THE FUNCTION BODIES HERE ARE ONLY TO EXPLAIN HOW THE FUNCTION
*			WORKS!!!**
*
*********************************************************************************************************************************************
*/


#ifndef _DI_TASK_H_
#define _DI_TASK_H_

#include <string>
#include "DiBase.h"
#include "DiDataTypes.h"

namespace DiLib
{
	template <class T>
	class DiTask : public DiBase
	{
	public:
		/*
		********************************************************************************************************************************************
		* Function: DiTask() - empty constructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		DiTask();

		/*
		********************************************************************************************************************************************
		* Function: ~DiTask() - virtual destructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual ~DiTask();

		/*
		********************************************************************************************************************************************
		* Function: LoadScript() - load the lua script using the given file
		* Parameters: const char* a_zScriptFile - lua script file that nees to be loading
		* Return: bool - loading script successful (true) or not (false)
		********************************************************************************************************************************************
		*/
		virtual bool LoadScript(const char* a_zScriptFile);

		/*
		********************************************************************************************************************************************
		* Function: ReloadScript() - reload the current script to update script modification
		* Parameters: void
		* Return: void
		********************************************************************************************************************************************
		*/
		virtual void ReloadScript(); 

		/*
		********************************************************************************************************************************************
		* Function: Execute() - do the ai stuff to this playr, either using lua script is set or the code set in the function
								virtual function that has to implement for do ai stuff
		* Parameters: T* a_pkOwner - ai player that is executing through the function
		* Return: DI_TASK_RETURNS
		********************************************************************************************************************************************
		*/
		virtual DI_TASK_RETURNS Execute(T* a_pkOwner) = 0;

		/*
		********************************************************************************************************************************************
		* Function: GetParent() - get the parent of this task
		* Parameters: void
		* Return: DiTask* - pointer to parent task of this
		********************************************************************************************************************************************
		*/
		DiTask<T>* GetParent() const;

		/*
		********************************************************************************************************************************************
		* Function: SetParent() - set the parent node
		* Parameters: const DiTask<T>* a_pkParentTask - pointer to parent class
		* Return: void
		********************************************************************************************************************************************
		*/
		void SetParent(const DiTask<T>* a_pkParentTask);

	protected:
		const DiTask* m_pkParentTask; //parent node

		std::string m_zScriptFile; //location of the lua script 

	};
	//***************************************************************************************************************************************************//

	
	#include "DiTask.inl"

}

#endif



