
/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 28-05-2011
* Description: inherits from DiCondition and do the task on given time intervel and it can be a continuos loop, eg: run animation, play sound
*
*********************************************************************************************************************************************
*/

#ifndef _DI_CLASS_TYPES_H_
#define _DI_CLASS_TYPES_H_

namespace DiLib
{
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


