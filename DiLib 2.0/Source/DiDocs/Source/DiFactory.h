
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

//! \details Functions handles initializing tree
//! \namespace DiFactory
namespace DiFactory
{
	//! Create a task node using the given type in enum value, this enum is runtime generated compiling DICONFIG FILE.
	//!< For more info look at \link setup_cpp Setting up C++ Project \endlink .
	//! \par INTERNAL USE ONLY
	//! \param a_eClassTypeID Class type that needs new instance of
	//! \return Pointer to created task, type casted to DiBase
	DiLib::DiBase* CreateTask(int a_eClassTypeID);

	//!  Create the tree on given DITREE file on to the root
	//! \param a_zDiTreeFile DITREE file that has all the data to create the tree
	//! \param a_pkRoot Root instance to create the tree 
	//! \return  tree creation success(true) or not(false)
	template <class T>
	bool CreateTree(const char* a_zDiTreeFile, DiLib::DiRoot<T>* a_pkRoot);

	//! Recursive function creating the tree using xml data in the tree file
	//! \par INTERANL USE ONLY
	//! \param a_xmlNode Current xml node which has the data for the current task node
	//! \param a_pkCurNode Parent node created a step before in the recursive function
	//! \param a_pkRoot Pointer to root node
	//! \return  tree creation success(true) or not(false)
	template <class T>
	void GenerateTree(TiXmlElement* a_xmlNode, DiLib::DiTask<T>* a_pkCurNode, DiLib::DiRoot<T>* a_pkRoot);

}
	
//***************************************************************************************************************************************************//


#endif