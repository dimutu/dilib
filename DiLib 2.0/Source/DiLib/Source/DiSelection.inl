
/*
********************************************************************************************************************************************
* Function: DiSelection() - empty constructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiSelection<T>::DiSelection() : DiSequence() 
{
	m_eClassID = DICLASS_SELECTION;
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: ~DiSelection() - destructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiSelection<T>::~DiSelection()
{

}
//***************************************************************************************************************************************************//


/*
********************************************************************************************************************************************
* Function: Execute() - run current task until its completed and move on to next and loop until one fails
* Parameters: T* a_pkOwner - ai player that is executing through the function
* Return: DI_TASK_RETURNS
********************************************************************************************************************************************
*/
template <class T>
int DiSelection<T>::Execute(T* a_pkOwner)
{
	DIDEBUGGER_SEND(this);

	//get current task
	DiTask<T>* pkTask = *m_itrCurrentTask;
	if (pkTask != NULL) //check current task is valie
	{
		int eReturn;
		eReturn = pkTask->Execute(a_pkOwner);

		switch (eReturn)
		{
		case 3: //check needs to get next task (DiLib::DI_TASK_RETURNS::DITASK_NEXTTASK)
		case 0://current task ran successfully (currently works like a sequence) (DiLib::DI_TASK_RETURNS::DITASK_COMPLETE)
			++m_itrCurrentTask; //move to next task
			break;

		case 1: //DiLib::DI_TASK_RETURNS::DITASK_FAILED
			//current task failed, all selection is failed and return back to parent
			return 1;
			break;

		default:
			break;
		}
			

	}
	else
	{
		//invalid task, move to the next task
		++m_itrCurrentTask;
	}//end if curretn task null


	if (m_itrCurrentTask == m_akTaskSequence.end()) //check all the task are ran through
	{
		return 0; //all the task has ran through, go back to parent with all complete message(DiLib::DI_TASK_RETURNS::DITASK_COMPLETE)
	}
	else
	{
		//more task has to run
		return 2; //(DiLib::DI_TASK_RETURNS::DITASK_CALLBACK)
	}

}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: SetExecutePosition() - set the current task to given position in the array
* Parameters: unsigned int a_iPosition - task position in the array
* Return: void
********************************************************************************************************************************************
*/
template <class T>
void DiSelection<T>::SetExecutePosition(unsigned int a_uiPosition)
{
	//validate position
	if (a_uiPosition < m_akTaskSequence.size() )
	{
		m_itrCurrentTask = m_akTaskSequence.begin() + a_uiPosition;
	}

}
//***************************************************************************************************************************************************//	

/*
********************************************************************************************************************************************
* Function: SetBegin() - set the current task back to begining
* Parameters: void
* Return: void
********************************************************************************************************************************************
*/
template <class T>
void DiSelection<T>::SetExecuteBegin() 
{
	m_itrCurrentTask = m_akTaskSequence.begin(); 
}
//***************************************************************************************************************************************************//	

/*
********************************************************************************************************************************************
* Function: SetEnd() - set the current task to end so it will exit back to parent
* Parameters: void
* Return: void
********************************************************************************************************************************************
*/
template <class T>
void DiSelection<T>::SetExecuteEnd() 
{
	m_itrCurrentTask = m_akTaskSequence.end(); 
}
//***************************************************************************************************************************************************//	
