

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
* 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
* 
* 3. This notice may not be removed or altered from any source distribution.
* 
* 4. Third party open source "TinyXML" is used in this program, and for more information please see its own terms of use.
*/
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

#include "DiBase.h"

namespace DiLib
{
	/*
	********************************************************************************************************************************************
	* Function: DiBase() - constructor
	* Parameters: void
	* Return: none
	********************************************************************************************************************************************
	*/
	DiBase::DiBase()
		:  m_eClassID(DICLASS_TASK)
	{
	}

	/*
	********************************************************************************************************************************************
	* Function: ~DiBase() - virtual destructor
	* Parameters: void
	* Return: none
	********************************************************************************************************************************************
	*/
	DiBase::~DiBase()
	{
	}

	/*
	********************************************************************************************************************************************
	* Function: ClassID() - get the class type
	* Parameters: void
	* Return: DI_CLASSID - enum class type to identify class 
	********************************************************************************************************************************************
	*/
	DI_CLASSID DiBase::ClassID() const 
	{
		return m_eClassID; 
	} 
	//***************************************************************************************************************************************************//


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
	void DiBase::SetDebugIds(const char* a_zDebugID, const char* a_zDebugTreeID, long a_lDebugTaskID)
	{
		m_zDebugID = a_zDebugID;
		m_zDebugTreeID = a_zDebugTreeID;
		m_lDebugTaskID = a_lDebugTaskID;
	}

	/*
	********************************************************************************************************************************************
	* Function: GetDebugId() - get main tree data file identification name ( DEBUG BUILD ONLY )
	* Parameters: void
	* Return: const char*
	********************************************************************************************************************************************
	*/
	const char* DiBase::GetDebugId()
	{
		return m_zDebugID.c_str();
	}


	/*
	********************************************************************************************************************************************
	* Function: GetDebugTreeId() - get identifier to tree file containing this node ( DEBUG BUILD ONLY )
	* Parameters: void
	* Return: const char*
	********************************************************************************************************************************************
	*/
	const char* DiBase::GetDebugTreeId()
	{
		return m_zDebugTreeID.c_str();
	}

	/*
	********************************************************************************************************************************************
	* Function: GetDebugTaskId() - unique number to identify this node inside the tree ( DEBUG BUILD ONLY )
	* Parameters: void
	* Return: long
	********************************************************************************************************************************************
	*/
	long DiBase::GetDebugTaskId() const
	{
		return m_lDebugTaskID;
	}

#endif

}


