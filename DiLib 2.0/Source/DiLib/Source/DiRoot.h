
/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 06-06-2011
* Description: the behaviour tree root node, this will keep track of all the task nodes in the tree, handles the memory and reloading scripts
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
		* Function: DiSelection() - constructor
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		DiRoot();

		/*
		********************************************************************************************************************************************
		* Function: ~DiSelection() - destructor, remove the root and its child nodes
		* Parameters: none
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual ~DiRoot();

		/*
		********************************************************************************************************************************************
		* Function: Execute() - run current task until its completed and move on to next and loop until one fails
		* Parameters: T* a_pkOwner - ai player that is executing through the function
		* Return: DI_TASK_RETURNS
		********************************************************************************************************************************************
		*/
		virtual DI_TASK_RETURNS Execute(T* a_pkOwner);

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

	protected:
		std::vector< DiTask<T>* > m_akTreeNodesList; //all the nodes belongs to this tree root

		std::vector< DiTask<T>* > m_akScriptNodeList; //the nodes that have scripts, so running through this node list can reload its scripts

	};
	//***************************************************************************************************************************************************//

	#include "DiRoot.inl"
}
#endif


