
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

//! \details Main library namespace

//! \namespace DiLib
namespace DiLib
{
	//! to identify each class by its type inhertinf from template task class (sort of typeof functionality)
	enum DI_CLASSID
	{
		DICLASS_TASK, //!< Behavior single task
		DICLASS_SEQUENCE, //!< Sequence task type executes list of single tasks in order they are added
		DICLASS_SELECTION, //!< Selection task type executes task in any given order
		DICLASS_CONDITION, //!< Conditional task runs on true/false condition
		DICLASS_FILTER, //!< Filtering task executes on a timer
		DICLASS_ROOT //!< Main root class containing the entire behavior tree
	};

}


#endif 


