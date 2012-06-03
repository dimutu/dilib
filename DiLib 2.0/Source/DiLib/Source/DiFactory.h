
/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 06-06-2011
* Description: factory class which handles all the copying and instances of each task in the behaviour tree
*				map key is to identify each task so if same number pass in, create new number of the new instance 
*				but copy all of the values from that identifier to new instance
*
*********************************************************************************************************************************************
*/

/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 06-06-2011
* Description: factory class that create each task node, and create the tree using tree file created using,
*				DiTreeCreator application
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
#include "DiClassTypeIDs.h"
#include "DiTask.h"
#include "DiClassTypeIDs.h"
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
	* Parameters: DI_CLASSTYPEID a_eClassTypeID - class type that needs new instance of
	* Return: DiLib::DiBase* - new class instance of given type
	********************************************************************************************************************************************
	*/
	DiLib::DiBase* CreateTask(DI_CLASSTYPEID a_eClassTypeID);

	/*
	********************************************************************************************************************************************
	* Function: CreateRoot() - create the header root file using the passing data
	* Parameters:	const char* a_zDiTreeFile - tree file that has all the data to create the tree
	*				DiLib::DiRoot<T>* a_pkRoot - header root file that needs all this data put-in
	*				DiBillboard* a_pkExternalData - external data
	* Return: bool - tree creation success(true) or not(false)
	********************************************************************************************************************************************
	*/
	template <class T>
	bool CreateRoot(const char* a_zDiTreeFile, DiLib::DiRoot<T>* a_pkRoot);

	/*
	********************************************************************************************************************************************
	* Function: CreateTree() - recursive function creating the tree using xml data in the tree file
	* Parameters:	TiXmlElement* a_xmlNode - current xml node which has the data for the current task node
	*				DiLib::DiTask<T>* a_pkCurNode - parent node created a step before in the recursive function
	*				DiLib::DiRoot<T>* a_pkRoot - pointer to root node
	*				DiBillboard* a_pkExternalData - external
	* Return: bool - tree creation success(true) or not(false)
	********************************************************************************************************************************************
	*/
	template <class T>
	void CreateTree(TiXmlElement* a_xmlNode, DiLib::DiTask<T>* a_pkCurNode, DiLib::DiRoot<T>* a_pkRoot);

	
	#include "DiFactory.inl"


}
	
//***************************************************************************************************************************************************//


#endif