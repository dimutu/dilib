
/*
*********************************************************************************************************************************************
* DiLib v2.0
*
* Author: Dimutu Kulawardana
* Date: 28-05-2011
* Description: decription Template class gets to implement a single task that executed in the tree,
*				 this act as the leaf node of the tree and base class for all other tasks.
*				 THIS CLASS MUST BE IMPLEMENTED IN THE GAME CODE IN-ORDER TO USE IT.
*
* Modified: 05-10-2012
* Description: removed DiTimer implementation in task and moved only into DiFilter
*
* Modified: 19-02-2013
* Description: added pointer to tree root, so the task can set itself as last state,
*				to avoid full tree iteration on each execution cycle and root can point and execute this task
*				ROOT FUNCTIONALITY IS TO IMPLEMENTED BY THE PROGRAMMERS
*
* Modified: 20-02-2013
* Description: removed Execute function returning enum and changed to int, to able to have many types of return values
*
*********************************************************************************************************************************************
*/


#ifndef _DI_TASK_H_
#define _DI_TASK_H_

#include <string>
#include "DiBase.h"

namespace DiLib
{
	template <class T>
	class DiRoot;

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
		virtual int Execute(T* a_pkOwner) = 0;

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

		/*
		********************************************************************************************************************************************
		* Function: SetRoot() - set the root node
		* Parameters: const DiTask<T>* a_pkRoot - pointer to root
		* Return: void
		********************************************************************************************************************************************
		*/
		void SetRoot(const DiRoot<T>* a_pkRoot);

	protected:
		const DiRoot<T>* m_pkRoot;

		const DiTask* m_pkParentTask; //parent node

		std::string m_zScriptFile; //location of the lua script 

	};
	//***************************************************************************************************************************************************//

	
	#include "DiTask.inl"

}

#endif



