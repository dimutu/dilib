
/*DiLib v2.0 - this file generates at runtime to identify each inherited or templated class by a enum id for easy identification*/


#ifndef _DI_CLASS_TYPE_IDS_H_
#define _DI_CLASS_TYPE_IDS_H_

#include "AI.h"
#include "DiAICondition.h"
#include "DiAITaskOne.h"
#include "DiAITaskTwo.h"
#include "DiAIFilterTask.h"

 	namespace DiFactory
	{
		enum DI_CLASSTYPEID
		{
			DICLASSTYPE_CUSTOM_DIAIFILTER = 2,
			DICLASSTYPE_CUSTOM_DIAISELECTION = 3,
			DICLASSTYPE_CUSTOM_DIAISEQUENCE = 4,
			DICLASSTYPE_CUSTOM_DIAITASKONE = 7,
			DICLASSTYPE_CUSTOM_DIAICONDITION = 8,
			DICLASSTYPE_CUSTOM_DIAITASKTWO = 9,
			DICLASSTYPE_CUSTOM_DIAIFILTERTASK = 10
		};
}

#endif

