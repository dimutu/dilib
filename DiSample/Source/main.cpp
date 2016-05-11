
#include <tinyxml.h>
#include <stdlib.h>
#include <DiRoot.h>
#include <DiFactory.h>
#include <DiDebugger.h>
#include "AI.h"


using namespace DiLib;

// OPEN DiAISample.didata file inside the Data folder from the Tree Creator UI
// Select Tree Creator UI Debug
// Build and run this project
// You can see the execution in the UI and use the slider on the toolbar to slow down the running speed

int main()
{
	//initialize the debugging service (this will only effect in WIN32 and DEBUG)
	DIDEBUGGER_INIT();

	//Your data initializations
	AI* m_pkAI = new AI();

	//creat the tree
	DiRoot<AI>* m_pkRoot = new DiRoot<AI>();

	//load the tree
	DiFactory::CreateTree<AI>("Data/DiSampleTree.ditree", m_pkRoot);
	
	char val = 'n';
	int step = 0;
	do
	{
		m_pkRoot->Execute(m_pkAI); //execute the tree

	} while (val != 'q');

	//free up memory
	delete m_pkRoot;
	delete m_pkAI;

	//shutdown the debugging service
	DIDEBUGGER_SHUTDOWN();

	return 0;
}