
/*
this class will be generated on the fly to get instances of inherited template functions
*/
//

#ifndef _DI_CLASS_GENERATOR_H_
#define _DI_CLASS_GENERATOR_H_

//include files, list all the deriving class headers
#include "DiFactory.h"

namespace dim
{
	namespace DiFactory
	{
		DiBaseTask* CreateTask(DI_CLASSTYPEID a_eClassTypeID)
		{
			DiBaseTask* pkTask = NULL;

			switch (a_eClassTypeID)
			{
			case DICLASSTYPE_TEMPLATE_TASK:
				Class* pkClass = new Class();

				pkTask = (DiBaseTask*)pkClass;
				break;

			default:
			}


			return pkTask;
		}
		/*template <class T>
		DiTask<T>* GenerateClass(DI_CLASSTYPEID a_eClassType)
		{
			DiTask<T>* pkTask = NULL;

			switch(a_eClassType)
			{
			case DICLASSTYPE_TEMPLATE_TASK:
				pkTask = new DiTask<T>(NULL, NULL, NULL);
				break;

			case DICLASSTYPE_TEMPLATE_CONDITION:
				pkTask = new DiTask<T>(NULL, NULL, NULL);
				break;

			case DICLASSTYPE_TEMPLATE_FILTER:
				pkTask = new DiTask<T>(NULL, NULL, NULL);
				break;

			case DICLASSTYPE_TEMPLATE_SEQUENCE:
				pkTask = new DiTask<T>(NULL, NULL, NULL);
				break;

			case DICLASSTYPE_TEMPLATE_SELECTION:
				pkTask = new DiTask<T>(NULL, NULL, NULL);
				break;

			default:
				break;
			}

			return pkTask;


		}*/

	}

}


#endif