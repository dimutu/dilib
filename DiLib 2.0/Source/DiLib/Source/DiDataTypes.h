
/*
*********************************************************************************************************************************************
* DiLib v2.0 (http://dilib.dimutu.com)
*
* This software is provided 'as-is', without any express or implied warranty. 
* In no event will the authors be held liable for any
* damages arising from the use of this software.
* 
* Permission is granted to anyone to use this software for any
* purpose, including commercial applications, subject to the following restrictions:
* 
* 1. The origin of this software must not be misrepresented; you must
* not claim that you wrote the original software. If you use this
* software in a product, an acknowledgment in the product documentation
* would be appreciated.
* 
* 2. NO alteration must be made to the source version.
* 
* 3. This notice may not be removed or altered from any source distribution.
* 
* 4. Third party open source "TinyXML" is used in this program, and for more information please see its own terms of use.
*
* Author: Dimutu Kulawardana
* Date: 28-05-2011
* Description: inherits from DiCondition and do the task on given time intervel and it can be a continuos loop, 
*				eg: run animation, play sound
*
* Modified: 20-02-2013
* Description: removed DI_TASK_RETURNS enumeration as return type changed to int
*				this DI_TASK_RETURNS enumration still gets created from DiParser
*
*********************************************************************************************************************************************
*/

#ifndef _DI_CLASS_TYPES_H_
#define _DI_CLASS_TYPES_H_

namespace DiLib
{
	//to identify each class by its type inherting from template task class (sort of typeof functionality)
	enum DI_CLASSID
	{
		DICLASS_TASK, //Behavior single task
		DICLASS_SEQUENCE, //Sequence task type executes list of single tasks in order they are added
		DICLASS_SELECTION, //Selection task type executes task in any given order
		DICLASS_CONDITION, //Conditional task runs on true/false condition
		DICLASS_FILTER, //Filtering task executes on a timer
		DICLASS_ROOT //Main root class containing the entire behavior tree
	};

}


#endif 


