
/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 06-06-2011
* Description: base class deriving to template classes, so this can use as base pointer to point to
*					what ever the template class implements into and dont have to use void* pointers
*
* Modified: 11-11-2011
* Description: added debugging service data
*********************************************************************************************************************************************
*/

#ifndef _DI_BASE_TASK_H_
#define _DI_BASE_TASK_H_

#include <string>
#include "DiDataTypes.h"
#include "DiDebugger.h"

#ifndef NULL
#define NULL 0
#endif

namespace DiLib
{
	class DiBase
	{
	public:
		/*
		********************************************************************************************************************************************
		* Function: DiBase() - constructor
		* Parameters: void
		* Return: none
		********************************************************************************************************************************************
		*/
		DiBase();

		/*
		********************************************************************************************************************************************
		* Function: ~DiBase() - virtual destructor
		* Parameters: void
		* Return: none
		********************************************************************************************************************************************
		*/
		virtual ~DiBase();

		/*
		********************************************************************************************************************************************
		* Function: ClassID() - get the class type
		* Parameters: void
		* Return: DI_CLASSID - enum class type to identify class 
		********************************************************************************************************************************************
		*/
		DI_CLASSID ClassID() const;

#ifdef _DIDEBUG
		/*
		********************************************************************************************************************************************
		* Function: SetDebugIds() - set debugging properties for base task ( DEBUG BUILD ONLY )
		* Parameters: const char* a_zDebugID - main tree data file identification name
		*			  const char* a_zDebugTreeID - identifier to tree file containing this node
		*			  long a_lDebugTaskID - unique number to identify this node inside the tree
		* Return: void
		********************************************************************************************************************************************
		*/
		void SetDebugIds(const char* a_zDebugID, const char* a_zDebugTreeID, long a_lDebugTaskID);

		/*
		********************************************************************************************************************************************
		* Function: GetDebugId() - get main tree data file identification name ( DEBUG BUILD ONLY )
		* Parameters: void
		* Return: const char*
		********************************************************************************************************************************************
		*/
		const char* GetDebugId();

		/*
		********************************************************************************************************************************************
		* Function: GetDebugTreeId() - get identifier to tree file containing this node ( DEBUG BUILD ONLY )
		* Parameters: void
		* Return: const char*
		********************************************************************************************************************************************
		*/
		const char* GetDebugTreeId();

		/*
		********************************************************************************************************************************************
		* Function: GetDebugTaskId() - unique number to identify this node inside the tree ( DEBUG BUILD ONLY )
		* Parameters: void
		* Return: long
		********************************************************************************************************************************************
		*/
		long GetDebugTaskId() const;
#endif

	protected:
		DI_CLASSID m_eClassID; //class type identifier

#ifdef _DIDEBUG
		//( DEBUG BUILD ONLY )

		std::string m_zDebugID; // id from the data file
		std::string m_zDebugTreeID; //tree file id
		long m_lDebugTaskID; //individual task id
#endif

	};

}

#endif

