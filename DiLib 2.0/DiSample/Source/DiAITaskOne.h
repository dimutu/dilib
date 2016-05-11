#ifndef _DIAITASKONE_H_
#define _DIAITASKONE_H_

/*
********************************************************************************************************
*
* Extended task use with conditional task
*
********************************************************************************************************
*/

#include <DiTask.h>
#include "AI.h"

class DiAITaskOne : public DiLib::DiTask<AI>
{
public:
	//Constructor
	DiAITaskOne();

	//Destructor
	~DiAITaskOne();

	//Execute
	int Execute(AI* p_pkAI);
};

#endif
