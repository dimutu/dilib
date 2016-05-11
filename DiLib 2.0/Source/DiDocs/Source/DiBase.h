

#ifndef _DI_BASE_TASK_H_
#define _DI_BASE_TASK_H_

#include <string>
#include "DiDataTypes.h"
#include "DiDebugger.h"

#ifndef NULL
#define NULL 0
#endif

//! \details Main library namespace

//! \namespace DiLib
namespace DiLib
{
//! \class DiBase
	//! \details Base class deriving to template classes, so this can use as base pointer to point to
	//!<			what ever the template class implements into and dont have to use void* pointers
	class DiBase
	{
	public:
		//! constructor
		DiBase();

		//! virtual destructor
		virtual ~DiBase();

		//! Get the class type		
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
		DI_CLASSID m_eClassID; //!< Class type identifier

#ifdef _DIDEBUG
		//( DEBUG BUILD ONLY )

		std::string m_zDebugID; // id from the data file
		std::string m_zDebugTreeID; //tree file id
		long m_lDebugTaskID; //individual task id
#endif

	};

}

#endif

