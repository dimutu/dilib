
/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 28-05-2011
* Description: inherits from DiCondition and do the task on given time intervel and it can be a continuos loop, eg: run animation, play sound
*
*********************************************************************************************************************************************
*/

#ifndef _DI_DATA_TYPES_H_
#define _DI_DATA_TYPES_H_

namespace DiLib
{
	//data types that uses in the template classes

	//when tasks executed, this returns as the result of that execution
	enum DI_TASK_RETURNS
	{
		DITASK_COMPLETE, //task successfully done and now can exit the task
		DITASK_FAILED, //task failed, return back to parent class
		DITASK_CALLBACK, //task completed, or waiting... dont return to parent, need to comeback to execute the same task (i.e. filter or selection)
		DITASK_NEXTTASK //move to next task

	};

	//to identify each class by its type inhertinf from template task class (sort of typeof functionality)
	enum DI_CLASSID
	{
		DICLASS_TASK,
		DICLASS_SEQUENCE,
		DICLASS_SELECTION,
		DICLASS_CONDITION,
		DICLASS_FILTER,
		DICLASS_ROOT
	};

}


#endif 


