
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
*
* Author: Dimutu Kulawardana
* Date: 06-06-2011
* Description: factory class which handles all the copying and instances of each task in the behaviour tree
*				map key is to identify each task so if same number pass in, create new number of the new instance 
*				but copy all of the values from that identifier to new instance
*
* Modified: 05-08-2012
* Description: removed DiBillboard
*
* Modified: 10-12-2012
* Description: updated loading structure with modified DiTask, DiFilter structures
*
* Modified: 20-02-2013
* Description: set root reference pointer when setting up each task
*
* ModifiedL 21-02-2013
* Description: renamed CreateRoot to CreateTree, and CreateTree to GenerateTree for misreading function naming
*
*********************************************************************************************************************************************
*/


#ifndef _DI_TASK_FACTORY_H_
#define _DI_TASK_FACTORY_H_

#include <map>
#include <vector>
#include <iostream>
#include <string>

#include "DiBase.h"
#include "DiRoot.h"
#include "DiTask.h"
#include "DiCondition.h"
#include "DiFilter.h"
#include "DiSelection.h"
#include "DiSequence.h"

//include tinyxml header before including this file and make sure using keywords used if under any namespaces
//include the creation of DiBillboard structure before DiTask.h

#include <tinyxml.h>

#ifdef EE_TINYXML_INCLUDED //use gamebryo namespace if the tinyxml path is set to gamebryo sources
using efd::TiXmlDocument;
using efd::TiXmlElement;
#endif

//factory class that handles all the loading functions of the tree
namespace DiFactory
{
	/*
	********************************************************************************************************************************************
	* THIS FUNCTION CONTENT IS GENERATED AT RUNTIME BY COMPILING THE DICONFIG FILE
	* Function: CreateTask() - create a task node using the given type in enum value, this enum is runtime generated using
	*							DiParser
	* Parameters: int a_eClassTypeID - class type that needs new instance of
	* Return: DiLib::DiBase* - new class instance of given type
	********************************************************************************************************************************************
	*/
	DiLib::DiBase* CreateTask(int a_eClassTypeID);

	/*
	********************************************************************************************************************************************
	* INTERNAL USE ONLY
	* Function: CreateTree() - create the header root file using the passing data
	* Parameters:	const char* a_zDiTreeFile - tree file that has all the data to create the tree
	*				DiLib::DiRoot<T>* a_pkRoot - header root file that needs all this data put-in
	*				DiBillboard* a_pkExternalData - external data
	* Return: bool - tree creation success(true) or not(false)
	********************************************************************************************************************************************
	*/
	template <class T>
	bool CreateTree(const char* a_zDiTreeFile, DiLib::DiRoot<T>* a_pkRoot);

	/*
	********************************************************************************************************************************************
	* INTERNAL USE ONLY
	* Function: GenerateTree() - recursive function creating the tree using xml data in the tree file
	* Parameters:	TiXmlElement* a_xmlNode - current xml node which has the data for the current task node
	*				DiLib::DiTask<T>* a_pkCurNode - parent node created a step before in the recursive function
	*				DiLib::DiRoot<T>* a_pkRoot - pointer to root node
	* Return: bool - tree creation success(true) or not(false)
	********************************************************************************************************************************************
	*/
	template <class T>
	void GenerateTree(TiXmlElement* a_xmlNode, DiLib::DiTask<T>* a_pkCurNode, DiLib::DiRoot<T>* a_pkRoot);

	
	#include "DiFactory.inl"


}
	
//***************************************************************************************************************************************************//


#endif