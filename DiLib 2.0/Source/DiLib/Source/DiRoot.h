
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
* Description: the behaviour tree root node, this will keep track of all the task nodes in the tree, handles the memory and reloading scripts
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

#ifndef _DI_ROOT_TREE_H_
#define _DI_ROOT_TREE_H_

#include "DiSelection.h"

namespace DiLib
{
	template <class T>
	class DiRoot : public DiSelection<T>
	{
	public:
		/*
		********************************************************************************************************************************************
		* Function: DiRoot() - constructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		DiRoot();

		/*
		********************************************************************************************************************************************
		* Function: ~DiRoot() - destructor, remove the root and its child nodes
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual ~DiRoot();

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
		* Function: AddTaskNode() - add new child node to task list, this is to keep track of all the child nodes
		*								in the tree, and for memory management
		* Parameters: DiTask<T>* a_pkNode - child node
		* Return: none
		********************************************************************************************************************************************
		*/
		void AddTaskNode(DiTask<T>* a_pkNode);

		/*
		********************************************************************************************************************************************
		* Function: AddScriptNode() - this is to keep track of scriptable nodes in the root, not for memory management,
		*								but to reload scripts to update these tasks without exiting the program
		* Parameters: DiTask<T>* a_pkNode - child node, that has scripting
		* Return: none
		********************************************************************************************************************************************
		*/
		void AddScriptNode(DiTask<T>* a_pkNode); //add a task that have scrips **this is only for reference

		/*
		********************************************************************************************************************************************
		* Function: ClearAll() - clean up all memory, using the task node list and deleting all of it
		* Parameters: void
		* Return: none
		********************************************************************************************************************************************
		*/
		void ClearAll(); 

		/*
		********************************************************************************************************************************************
		* Function: ReloadScripts() - to be implemented if needs to reload the scripts nodes and doesnt have to go through all the nodes
		* Parameters: void
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual void ReloadScripts();

		/*
		********************************************************************************************************************************************
		* Function: SetLastTask() - for extending purpose, keep track of last task if need to avoid executing whole tree
		* Parameters: void
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual void SetLastTask(const DiTask* a_pkTask);

	protected:
		const DiTask<T>* m_pkLastTask; //for extending purpose, keep track of last task if need to avoid executing whole tree

		std::vector< DiTask<T>* > m_akTreeNodesList; //all the nodes belongs to this tree root

		std::vector< DiTask<T>* > m_akScriptNodeList; //the nodes that have scripts, so running through this node list can reload its scripts

	};
	//***************************************************************************************************************************************************//

	#include "DiRoot.inl"
}
#endif


