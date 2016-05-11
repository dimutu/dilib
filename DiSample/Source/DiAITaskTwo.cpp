
/*
********************************************************************************************************
*
* Extended task use with conditional task
*
********************************************************************************************************
*/

#include <stdlib.h>
#include "DiAITaskTwo.h"
#include "DiReturnEnums.h" //use this for more readable return values

DiAITaskTwo::DiAITaskTwo()
{
}

DiAITaskTwo::~DiAITaskTwo()
{
}

int DiAITaskTwo::Execute(AI* p_pkAI)
{
	//connect to debugger
	DIDEBUGGER_SEND(this);

	printf("DiAITaskTwo::Execute\n");

	return DiLib::DITASK_COMPLETE;
}
