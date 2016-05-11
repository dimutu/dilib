
#ifndef _DIAI_FILTER_TASK_
#define _DIAI_FILTER_TASK_

/*
********************************************************************************************************
*
* Extended DiTask to run under the filter
*
********************************************************************************************************
*/

#include <DiTask.h>

class AI;

class DiAIFilterTask : public DiLib::DiTask<AI>
{
public:
	//Constructor
	DiAIFilterTask();

	//Destructor
	~DiAIFilterTask();

	//Execute
	int Execute(AI*);
};

#endif
