
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
* 2. NO alteration must be made to the source version.
* 
* 3. This notice may not be removed or altered from any source distribution.
* 
* 4. Third party open source "TinyXML" is used in this program, and for more information please see its own terms of use.
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
* Modified: 01-03-2013
* Description: added argument property to set any additional arguments from UI
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
		* Function: LoadScript() - Load an external script using the given file, this gets parameter value set from the UI 
		*							during the loading process of the tree and sets m_zScriptFile.
		*							Function must be overriden in-order to set the rest of the process of opening and executing the selected scrip file 
		*
		* Parameters: const char* a_zScriptFile Script file path set's through the tree creation interface
		* Return: bool - For extending purposes to evaluate loading success or failure.
		********************************************************************************************************************************************
		*/
		virtual bool LoadScript(const char* a_zScriptFile);

		/*
		********************************************************************************************************************************************
		* Function: ReloadScript() - Reload the current script to update script modification.
		*								Function must be overriden in-order to use the features.
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
		* Return: int
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

		/*
		********************************************************************************************************************************************
		* Function: SetArgs() - set additional arguments need for this task set from the UI
		* Parameters: const char* a_zArgs - all the arguments in single string
		* Return: void
		********************************************************************************************************************************************
		*/
		void SetArgs(const char* a_zArgs);

	protected:
		const DiRoot<T>* m_pkRoot; //root node

		const DiTask* m_pkParentTask; //parent node

		std::string m_zScriptFile; //location of the external script file

		std::string m_zArgs; //additional settings from the UI to use inside this task

	};
	//***************************************************************************************************************************************************//

	
	#include "DiTask.inl"

}

#endif



