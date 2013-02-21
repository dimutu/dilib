
/*
********************************************************************************************************************************************
* Function: DiSelection() - constructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiRoot<T>::DiRoot() : DiSelection() 
{
	m_eClassID = DICLASS_ROOT;
	m_akTreeNodesList.clear();
	m_akScriptNodeList.clear();
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: DiSelection() - destructor, remove the root and its child nodes
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiRoot<T>::~DiRoot() 
{
	ClearAll(); 
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: Execute() - run current task until its completed and move on to next and loop until one fails
* Parameters: T* a_pkOwner - ai player that is executing through the function
* Return: int
********************************************************************************************************************************************
*/
template <class T>
int DiRoot<T>::Execute(T* a_pkOwner)
{
	DIDEBUGGER_SEND(this);

	//repeating task if executed all the tasks
	if (m_itrCurrentTask == m_akTaskSequence.end())
	{
		m_itrCurrentTask = m_akTaskSequence.begin();
	}

	//get current task
	DiTask<T>* pkTask = *m_itrCurrentTask;
	if (pkTask != NULL) //check current task is valie
	{
		int eReturn;
		eReturn = pkTask->Execute(a_pkOwner);

		//move to next if its not callback (its complete or failed)
		if (eReturn != 2) //DiLib::DI_TASK_RETURNS::DITASK_CALLBACK
		{
			++m_itrCurrentTask; //move to next task
		}			

	}
	else
	{
		//invalid task, move to the next task
		++m_itrCurrentTask;
	}//end if curretn task null

	//root always gets callback
	return 2; //DiLib::DI_TASK_RETURNS::DITASK_CALLBACK

}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: ClearAll() - clean up all memory, using the task node list and deleting all of it
* Parameters: void
* Return: none
********************************************************************************************************************************************
*/
template <class T>
void DiRoot<T>::ClearAll()
{
	std::vector< DiTask<T>* >::iterator itr = m_akTreeNodesList.begin();

	for (; itr != m_akTreeNodesList.end(); ++itr)
	{
		DiTask<T>* pkTask = *itr;

		if (pkTask != NULL)
		{
			delete pkTask;
			pkTask = NULL;
		}

	}

	m_akTaskSequence.clear();
	m_akTreeNodesList.clear();
	m_akScriptNodeList.clear();
	m_pkLastTask = NULL;

}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: AddTaskNode() - add new child node to task list, this is to keep track of all the child nodes
*								in the tree, and for memory management
* Parameters: DiTask<T>* a_pkNode - child node
* Return: none
********************************************************************************************************************************************
*/
template <class T>
void DiRoot<T>::AddTaskNode(DiTask<T>* a_pkNode)
{
	m_akTreeNodesList.push_back(a_pkNode); 
} 
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: AddScriptNode() - this is to keep track of scriptable nodes in the root, not for memory management,
*								but to reload scripts to update these tasks without exiting the program
* Parameters: DiTask<T>* a_pkNode - child node, that has scripting
* Return: none
********************************************************************************************************************************************
*/
template <class T>
void DiRoot<T>::AddScriptNode(DiTask<T>* a_pkNode)
{
	m_akScriptNodeList.push_back(a_pkNode);
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: ReloadScripts() - to be implemented if needs to reload the scripts nodes and doesnt have to go through all the nodes
* Parameters: void
* Return: none
********************************************************************************************************************************************
*/
template <class T>
void DiRoot<T>::ReloadScripts()
{
	//iterate through task that has scripting
	std::vector<DiTask<T>*>::iterator itr = m_akScriptNodeList.begin();
	for(; itr != m_akScriptNodeList.end(); ++itr)
	{
		DiTask<T>* pkTask = *itr;
		if (pkTask != NULL)
		{	
			//call the tasks reload scripting
			pkTask->ReloadScript();
		}
	}
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: SetLastTask() - for extending purpose, keep track of last task if need to avoid executing whole tree
* Parameters: void
* Return: none
********************************************************************************************************************************************
*/
template <class T>
void DiRoot<T>::SetLastTask(const DiTask<T>* a_pkTask)
{
	m_pkLastTask = a_pkTask;
}
//***************************************************************************************************************************************************//


