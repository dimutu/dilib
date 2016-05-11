
/*
********************************************************************************************************
*
* Extended task use with conditional task
*
********************************************************************************************************
*/

#include <stdlib.h>
#include "DiAITaskOne.h"
#include "DiReturnEnums.h" //use this for more readable return values


DiAITaskOne::DiAITaskOne()
{
}

DiAITaskOne::~DiAITaskOne()
{
}

int DiAITaskOne::Execute(AI* p_pkAI)
{
	//connect this to debugger
	DIDEBUGGER_SEND(this);

	printf("DiAITaskOne::Execute\n");

	return DiLib::DITASK_COMPLETE;
}
