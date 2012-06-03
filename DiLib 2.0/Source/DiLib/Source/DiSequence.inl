
/*
********************************************************************************************************************************************
* Function: DiSequence() - empty constructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiSequence<T>::DiSequence()
	: DiTask()
{
	m_eClassID = DICLASS_SEQUENCE;
	RemoveAllTasks();
}

/*
********************************************************************************************************************************************
* Function: DiSequence() - destructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiSequence<T>::~DiSequence()
{
	RemoveAllTasks();
}

/*
********************************************************************************************************************************************
* Function: AddTask() - add a task to end of the sequence task list
* Parameters:  DiTask<T>* a_pkTask  - pointer to the task
* Return: bool - insertion success(true) or not(false)
********************************************************************************************************************************************
*/
template <class T>
bool DiSequence<T>::AddTask( DiTask<T>* a_pkTask )
{
	return AddTask(a_pkTask, m_akTaskSequence.size());
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: AddTask() - add a task to given position in the sequence task list
* Parameters:   DiTask<T>* a_pkTask  - pointer to the task
*				unsigned int a_uiPosition - task position in the array
* Return: bool - insertion success(true) or not(false)
********************************************************************************************************************************************
*/
template <class T>
bool DiSequence<T>::AddTask( DiTask<T>* a_pkTask, unsigned int a_uiPosition )
{
	if ( a_uiPosition < m_akTaskSequence.size()) //check the position valid
	{
		std::vector< DiTask<T>* >::iterator itrPos = m_akTaskSequence.begin();
		itrPos += a_uiPosition; //get the iterator to that  position
		m_akTaskSequence.insert(itrPos, a_pkTask); //insert into the position
	}
	else
	{
		//invalid position, add it to the end of sequence
		m_akTaskSequence.push_back(a_pkTask);
	}

	//current iterator not valid, reset to begining
	m_itrCurrentTask = m_akTaskSequence.begin();

	return true;
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: RemoveTask() - remove a task in given position in the array
* Parameters:  unsigned int a_uiPosition - array position of the task that needs removing
* Return: bool - remove success(true) or not(false)
********************************************************************************************************************************************
*/
template <class T>
bool DiSequence<T>::RemoveTask(unsigned int a_uiPosition )
{
	if (a_iPosition < m_akTaskSequence.size() ) //validate the position
	{
		std::vector< DiTask<T>* >::iterator itrPos = m_akTaskSequence.begin();
		itrPos += a_iPosition; //get the iterator to the position needs to be removed

		//remove cause to reset current task to begin **IMPLEMENTED LATER TO VALIDATE AND CALCULATE NEXT POSITION
		m_akTaskSequence.erase(itrPos);

		//current iterator not valid, reset to begining
		m_itrCurrentTask = m_akTaskSequence.begin();

		return true;
	}

	return false; //unable to erase
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: RemoveAllTasks() - remove all tasks in the array
* Parameters:  void
* Return: bool - remove success(true) or not(false)
********************************************************************************************************************************************
*/
template <class T>
bool DiSequence<T>::RemoveAllTasks()
{
	m_akTaskSequence.clear();
	m_itrCurrentTask = m_akTaskSequence.begin();

	return true;
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: Execute() - run all the child tasks sequenctially
* Parameters: T* a_pkOwner - ai player that is executing through the function
* Return: DI_TASK_RETURNS
********************************************************************************************************************************************
*/
template <class T>
DI_TASK_RETURNS DiSequence<T>::Execute(T* a_pkOwner)
{
	DIDEBUGGER_SEND(this);

	//run all the taskst in the sequence
	DI_TASK_RETURNS eReturn = DITASK_COMPLETE;

	m_itrCurrentTask = m_akTaskSequence.begin();

	DiTask<T>* pkTask = NULL;
	for (; m_itrCurrentTask != m_akTaskSequence.end(); ++m_itrCurrentTask)
	{
		pkTask = *m_itrCurrentTask;
		if (pkTask != NULL)
		{
			eReturn = pkTask->Execute(a_pkOwner); //run the task
			if (eReturn == DITASK_FAILED)
			{
				return DITASK_FAILED; //something wrong running this task, exit sequence and back to parent
			}
		}
	}

	return DITASK_COMPLETE;//all run well 
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: GetTasksCount() - return total tasks in the list
* Parameters:  void
* Return: unsigned int - array element cound
********************************************************************************************************************************************
*/
template <class T>
unsigned int DiSequence<T>::GetTasksCount() const
{
	return m_akTaskSequence.size();
}
//***************************************************************************************************************************************************//

