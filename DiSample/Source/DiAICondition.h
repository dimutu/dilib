#ifndef _DIAITASKCONDITION_H_
#define _DIAITASKCONDITION_H_


/*
********************************************************************************************************
*
* Extended condition class with states running for starting and ending functions
*
********************************************************************************************************
*/


#include <DiCondition.h>
#include <DiTimer.h>
#include "AI.h"

class DiAICondition : public DiLib::DiCondition<AI>
{
private:
	//internal state machine for initialize the condition and end
	enum RUNNINGSTATE
	{
		START,
		RUN,
		END
	};

public:
	//Constructor
	DiAICondition();

	//Destructor
	~DiAICondition();

	//Execute
	int Execute(AI* p_pkAI);

private:
	//State Start function
	void Start();

	//State End function
	void End();

	DiLib::DiTimer m_kTimer;
	RUNNINGSTATE m_eRunState;

};

#endif
