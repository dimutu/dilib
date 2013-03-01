
/*this file generates at runtime to identify each inherited or templated class by a enum id for easy identification*/


#ifndef _DI_TASK_RETURN_TYPE_IDS_H_
#define _DI_TASK_RETURN_TYPE_IDS_H_

namespace DiLib
{
	enum DI_TASK_RETURNS
	{
		DITASK_COMPLETE = 0, //task successfully done and now can exit the task
		DITASK_FAILED = 1, //task failed, return back to parent class
		DITASK_CALLBACK = 2, //task completed, or waiting... dont return to parent, need to comeback to execute the same task (i.e. filter or selection)
		DITASK_NEXTTASK = 3, //move to next task
		DITASK_OTHER,
		DITASK_SOMETHING,
	};
}

#endif
