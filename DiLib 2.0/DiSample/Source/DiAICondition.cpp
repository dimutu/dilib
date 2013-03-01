
/*
********************************************************************************************************
*
* Extended condition class with states running for starting and ending functions
*
********************************************************************************************************
*/
#include <stdlib.h>
#include "DiAICondition.h"
#include "DiReturnEnums.h" //use this for more readable return values

DiAICondition::DiAICondition() : DiLib::DiCondition<AI>(), m_eRunState(START)
{
	
}

DiAICondition::~DiAICondition()
{
}

int DiAICondition::Execute(AI* p_pkAI)
{
	//connect this debugger
	DIDEBUGGER_SEND(this);

	//run initialzing/end states
	switch (m_eRunState)
	{
	case DiAICondition::START:
		{
			Start();
			return DiLib::DITASK_CALLBACK; //callback to here
			break;
		}
	case DiAICondition::RUN:
		{
			//execute the condition and use true and false task with the condition
			printf ("DiAICondition::Execute RUNNING\n");
			if (m_kTimer.IsRunTime())
			{
				m_kTimer.SetNextTimeInterval();
				return m_pkTrueTask->Execute(p_pkAI);
			}
			else
			{
				return m_pkFalseTask->Execute(p_pkAI);
			}
		}
		break;
	case DiAICondition::END:
		{
			End();
			break;
		}
	default:
		break;
	};

	//use custom enumeration or other with use of DiReturnEnum.h
	return DiLib::DITASK_OTHER;

}

//Start state
void DiAICondition::Start()
{
	m_kTimer.SetTimeInterval(500);
	printf ("DiAICondition::Execute STARTING\n");
	m_eRunState = RUN;
}

//End state
void DiAICondition::End()
{
}

