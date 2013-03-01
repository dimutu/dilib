#ifndef _DIAITASKTWO_H_
#define _DIAITASKTWO_H_

/*
********************************************************************************************************
*
* Extended task use with conditional task
*
********************************************************************************************************
*/

#include <DiTask.h>
#include "AI.h"

class DiAITaskTwo : public DiLib::DiTask<AI>
{
public:
	//Constructor
	DiAITaskTwo();

	//Destructor
	~DiAITaskTwo();

	//Execute
	int Execute(AI* p_pkAI);
};

#endif