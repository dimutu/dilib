
/*DiLib v2.0 - this file generates at runtime, do not make any modifications.*/


#include "DiClassTypeIDs.h"
#include <DiFactory.h>

using namespace DiLib;
namespace DiFactory
 	{
 		DiBase* CreateTask(int a_eClassTypeID)
 		{
 			DiBase* pkTask = NULL;
 			switch (a_eClassTypeID)
 			{

			case DICLASSTYPE_CUSTOM_DIAIFILTER:
				{
					DiFilter<AI>* pkClass = new DiFilter<AI>();
 					pkTask = (DiBase*)pkClass;
 				}
				break;

			case DICLASSTYPE_CUSTOM_DIAISELECTION:
				{
					DiSelection<AI>* pkClass = new DiSelection<AI>();
 					pkTask = (DiBase*)pkClass;
 				}
				break;

			case DICLASSTYPE_CUSTOM_DIAISEQUENCE:
				{
					DiSequence<AI>* pkClass = new DiSequence<AI>();
 					pkTask = (DiBase*)pkClass;
 				}
				break;

			case DICLASSTYPE_CUSTOM_DIAITASKONE:
				{
				DiAITaskOne* pkClass = new DiAITaskOne();
 				pkTask = (DiBase*)pkClass;
 				}
				break;

			case DICLASSTYPE_CUSTOM_DIAICONDITION:
				{
				DiAICondition* pkClass = new DiAICondition();
 				pkTask = (DiBase*)pkClass;
 				}
				break;

			case DICLASSTYPE_CUSTOM_DIAITASKTWO:
				{
				DiAITaskTwo* pkClass = new DiAITaskTwo();
 				pkTask = (DiBase*)pkClass;
 				}
				break;

			case DICLASSTYPE_CUSTOM_DIAIFILTERTASK:
				{
				DiAIFilterTask* pkClass = new DiAIFilterTask();
 				pkTask = (DiBase*)pkClass;
 				}
				break;

 			default:
 				break;
 			}

 		return pkTask;

 		}
 }
