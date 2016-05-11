
/*
********************************************************************************************************
*
* Extended DiTask to run under the filter
*
********************************************************************************************************
*/

#include <stdlib.h>
#include "DiAIFilterTask.h"
#include "AI.h"
#include "DiReturnEnums.h" //use this for more readable return values

DiAIFilterTask::DiAIFilterTask() : DiLib::DiTask<AI>()
{
}

DiAIFilterTask::~DiAIFilterTask()
{
}

int DiAIFilterTask::Execute(AI* a_pkEnemy)
{
	//connect to debugger
	DIDEBUGGER_SEND(this);

	//print the arguments set and passed from the UI
	printf("%s\n", m_zArgs);

	//return back to parent
	return DiLib::DITASK_COMPLETE;
}

