


/********************************************************************************************************************************************
* Function: DiFilter() - empty constructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiFilter<T>::DiFilter() : DiTask() 
{
	m_eClassID = DICLASS_FILTER;

	m_uiMaxRunCycles = 0;
	m_uiRunCycleCounter = 0;
	m_bIsLoopOn = false;
	m_pkTask = NULL;
	m_pkTimer = new DiTimer();

}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: ~DiFilter() - virtual destructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiFilter<T>::~DiFilter() 
{
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: Execute() - do the ai stuff to this playr, either using lua script is set or the code set in the function
						virtual function that has to implement for do ai stuff
* Parameters: T* a_pkOwner - ai player that is executing through the function
* Return: DI_TASK_RETURNS
********************************************************************************************************************************************
*/
template <class T>
int DiFilter<T>::Execute(T* a_pkOwner)
{
	DIDEBUGGER_SEND(this);

	//if the timer is set, execute code in time intervals
	if ( !m_pkTimer->IsRunTime() )
	{
		//time not ready, come back later to execute
		return 2; //DiLib::DI_TASK_RETURNS::DITASK_CALLBACK
	}

	//check loop conditions before executing
	if (m_bIsLoopOn || m_uiRunCycleCounter < m_uiMaxRunCycles)
	{
		++m_uiRunCycleCounter;
		m_pkTimer->SetNextTimeInterval();
		//for default will run the true task only
		if (m_pkTask != NULL)
		{
			return m_pkTask->Execute(a_pkOwner);
		}

	}

	return 0; //DiLib::DI_TASK_RETURNS::DITASK_COMPLETE

}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: SetTimer() - set the task timer 
* Parameters: const unsigned int a_uiTimeInterval - time interval to run the task between time gaps
* Return: void
********************************************************************************************************************************************
*/
template <class T>
void DiFilter<T>::SetTimer(const unsigned int a_uiTimeInterval)
{
	//change the current time interval
	m_pkTimer->SetTimeInterval(a_uiTimeInterval);
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: SetMaxRunCycles() - set number of times this task should run
* Parameters: unsigned int a_MaxRunCycles - number of run cycles
* Return: none
********************************************************************************************************************************************
*/
template <class T>
void DiFilter<T>::SetMaxRunCycles(unsigned int a_MaxRunCycles)
{
	m_uiMaxRunCycles = a_MaxRunCycles; 
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: SetLoop() - set task looping or not, if looped it will until task fails
* Parameters: bool a_bLoop - 
* Return: none
********************************************************************************************************************************************
*/
template <class T>
void DiFilter<T>::SetLoop(bool a_bLoop) 
{
	m_bIsLoopOn = a_bLoop; 
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: GetMaxRunCycles() - return current maximum run cycles
* Parameters: void
* Return: unsigned int 
********************************************************************************************************************************************
*/
template <class T>
unsigned int DiFilter<T>::GetMaxRunCycles() const 
{
	return m_uiMaxRunCycles; 
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: GetCurentRunCycle() - return how many times this task has ran
* Parameters: void
* Return: unsigned int 
********************************************************************************************************************************************
*/
template <class T>
unsigned int DiFilter<T>::GetCurentRunCycle() const 
{
	return m_uiRunCycleCounter; 
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: ResetRunCycleCounter() - reset the current runtime counter back to begining
* Parameters: void
* Return: void 
********************************************************************************************************************************************
*/
template <class T>
void DiFilter<T>::ResetRunCycleCounter() 
{
	m_uiRunCycleCounter = 0; 
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: IsLoopOn() - return current task is set to loop or not
* Parameters: void
* Return: bool - task is looping(true) or not (false) 
********************************************************************************************************************************************
*/
template <class T>
bool DiFilter<T>::IsLoopOn() const 
{
	return m_bIsLoopOn; 
}
//***************************************************************************************************************************************************//

template <class T>
void DiFilter<T>::SetTask(DiTask* a_pkTask)
{
	m_pkTask = a_pkTask;
}
