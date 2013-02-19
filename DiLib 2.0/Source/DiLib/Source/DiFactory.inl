

/*
********************************************************************************************************************************************
* Function: CreateRoot() - create the header root file using the passing data
* Parameters:	const char* a_zDiTreeFile - tree file that has all the data to create the tree
*				DiLib::DiRoot<T>* a_pkRoot - header root file that needs all this data put-in
* Return: bool - tree creation success(true) or not(false)
********************************************************************************************************************************************
*/
template <class T>
bool CreateRoot(const char* a_zXMLFile, DiLib::DiRoot<T>* a_pkRoot)
{
	//cannot return a tree if root is not passed in 
	if (a_pkRoot == NULL)
	{
		std::cout << "root is null." << std::endl;
		return false;
	}
	//cannot do anything if no file set
	if (a_zXMLFile == NULL)
	{
		std::cout << "xml file empty." << std::endl;
		return false;
	}

	//open xml file
	TiXmlDocument xmlDoc;
	TiXmlElement* xmlRoot;

	if ( !xmlDoc.LoadFile(a_zXMLFile))
	{
		std::cout << "unable to open xml file." << std::endl;
		return false;
	}

	xmlRoot = xmlDoc.FirstChildElement("TreeRoot");
#ifdef _DIDEBUG
	//set root properties to debug
	TiXmlElement* xmlDebugData = xmlRoot->FirstChildElement("DI");
	a_pkRoot->SetDebugIds(xmlDebugData->Attribute("DebugID"), xmlDebugData->Attribute("TreeDebugID"), 0);
#endif


	xmlRoot = xmlRoot->FirstChildElement("Node");

	//call tree create recursive function
	CreateTree(xmlRoot, a_pkRoot, a_pkRoot);	

	return true;
}
//***************************************************************************************************************************************************//


/*
********************************************************************************************************************************************
* Function: CreateTree() - recursive function creating the tree using xml data in the tree file
* Parameters:	TiXmlElement* a_xmlNode - current xml node which has the data for the current task node
*				DiLib::DiTask<T>* a_pkCurNode - parent node created a step before in the recursive function
*				DiLib::DiRoot<T>* a_pkRoot - pointer to root node
* Return: bool - tree creation success(true) or not(false)
********************************************************************************************************************************************
*/
template <class T>
void CreateTree(TiXmlElement* a_xmlNode, DiLib::DiTask<T>* a_pkCurNode, DiLib::DiRoot<T>* a_pkRoot)
{
	if (a_xmlNode == NULL) //if current xml is empty, reach to a leaf node
	{
		return;
	}

	int iChildCount = atoi(a_xmlNode->Attribute("ChildCount")); //get child node cound of the parent

	if (iChildCount == 0) //parent node doesnt have any childs
	{
		return;
	}
	else
	{
		//has children
		TiXmlElement* pkXmlChild = a_xmlNode->FirstChildElement();
		for (int ii = 0; ii < iChildCount; ++ii)
		{
			//get a new instance of the node
			DiLib::DiTask<T>* pkChildNode = (DiLib::DiTask<T>*)CreateTask( (DI_CLASSTYPEID)atoi(pkXmlChild->Attribute("EnumID")));
			a_pkRoot->AddTaskNode(pkChildNode); //add to root task list array(helps when clearing memory)

			//set child data
			pkChildNode->SetParent(a_pkCurNode); //set parent
			pkChildNode->SetRoot(a_pkRoot);

#ifdef _DIDEBUG
			//set debugging information
			long lDebugTreeID = atol(pkXmlChild->Attribute("TaskDebugID"));
			pkChildNode->SetDebugIds(a_pkRoot->GetDebugId(), a_pkRoot->GetDebugTreeId(), lDebugTreeID);

#endif
			//setup current task of being a filter
			if (pkChildNode->ClassID() == DiLib::DICLASS_FILTER)
			{
				DiLib::DiFilter<T>* pkF = (DiLib::DiFilter<T>*)pkChildNode;
				pkF->SetTimer((unsigned int)atof(pkXmlChild->Attribute("TimerInterval")));
				std::string zTimer = pkXmlChild->Attribute("Repeat");
				if (zTimer.compare("True") == 0)
				{
					//loop
					pkF->SetLoop(true);
				} 

				if (pkXmlChild->Attribute("MaxRunCycle") != NULL)
				{
					pkF->SetMaxRunCycles((unsigned int)atoi(pkXmlChild->Attribute("MaxRunCycle")));
				}
			}

			//check parent node type, and set the child task
			switch (a_pkCurNode->ClassID())
			{
			case DiLib::DICLASS_SEQUENCE: //parent is sequence
				{
					DiLib::DiSequence<T>* pkSeq = (DiLib::DiSequence<T>*)a_pkCurNode;
					pkSeq->AddTask(pkChildNode);
					break;
				}

			case DiLib::DICLASS_SELECTION: case DiLib::DICLASS_ROOT: //prent a selection
				{
					DiLib::DiSelection<T>* pkSel = (DiLib::DiSelection<T>*)a_pkCurNode;
					pkSel->AddTask(pkChildNode);
					break;
				}

			case DiLib::DICLASS_CONDITION: //parent a condition
				{
					DiLib::DiCondition<T>* pkCod = (DiLib::DiCondition<T>*)a_pkCurNode;
					//check which tasks are set
					const char* val = a_xmlNode->Attribute("TaskTrue");
					int iTaskTrue = 0;
					if (val != NULL)
					{
						iTaskTrue = atoi(a_xmlNode->Attribute("TaskTrue"));
						if (iTaskTrue == atoi(pkXmlChild->Attribute("EnumID"))	)
						{
							pkCod->SetTrueTask(pkChildNode);
						}
					}

					val = a_xmlNode->Attribute("TaskFalse");
					if (val != NULL)
					{
						iTaskTrue = atoi(a_xmlNode->Attribute("TaskFalse"));
						if (iTaskTrue == atoi(pkXmlChild->Attribute("EnumID"))	)
						{
							pkCod->SetFalseTask(pkChildNode);
						}
					}
					
					
					break;
				}

			case DiLib::DICLASS_FILTER: //parent a filter
				{
					DiLib::DiFilter<T>* pkFil = (DiLib::DiFilter<T>*)a_pkCurNode;
					pkFil->SetTask(pkChildNode);

					break;
				}

			default: //parent doesnt support child tasks
				break;
			}

			//check child node has any of its own children nodes
			CreateTree(pkXmlChild, pkChildNode, a_pkRoot);

			pkXmlChild = pkXmlChild->NextSiblingElement(); //get the next xml sibling node

		}//end for loop of child tasks

	}


}
//***************************************************************************************************************************************************//

