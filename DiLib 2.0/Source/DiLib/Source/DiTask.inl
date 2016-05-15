/*
****************************************************************************************************************************
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
*******************************************************************************************************************************
*/

/*
********************************************************************************************************************************************
* Function: DiTask() - empty constructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiTask<T>::DiTask()
	: m_pkParentTask(NULL)
{
	m_zScriptFile.clear();
}


/*
********************************************************************************************************************************************
* Function: ~DiTask() - virtual destructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiTask<T>::~DiTask()
{
	m_zScriptFile.clear();
	m_pkRoot = NULL;
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: LoadScript() - Load an external script using the given file, this gets parameter value set from the UI 
*							during the loading process of the tree and sets m_zScriptFile.
*							Function must be overriden in-order to set the rest of the process of opening and executing the selected scrip file 
*
* Parameters: const char* a_zScriptFile Script file path set's through the tree creation interface
* Return: bool - For extending purposes to evaluate loading success or failure.
********************************************************************************************************************************************
*/
template <class T>
bool DiTask<T>::LoadScript(const char* a_zScriptFile)
{
	m_zScriptFile = a_zScriptFile;
	return true;
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: ReloadScript() - Reload the current script to update script modification.
*								Function must be overriden in-order to use the features.
* Parameters: void
* Return: void
********************************************************************************************************************************************
*/
template <class T>
void DiTask<T>::ReloadScript()
{
	//reload the script data, or execute a script

}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: GetParent() - get the parent of this task
* Parameters: void
* Return: DiTask* - pointer to parent task of this
********************************************************************************************************************************************
*/
template <class T>
DiTask<T>* DiTask<T>::GetParent() const 
{
	return m_pkParentTask; 
}
//***************************************************************************************************************************************************//


/*
********************************************************************************************************************************************
* Function: SetParent() - set the parent node
* Parameters: const DiTask<T>* a_pkParentTask - pointer to parent class
* Return: void
********************************************************************************************************************************************
*/
template <class T>
void DiTask<T>::SetParent(const DiTask<T>* a_pkParentTask) 
{
	m_pkParentTask = a_pkParentTask;
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: SetRoot() - set the root node
* Parameters: const DiTask<T>* a_pkRoot - pointer to root
* Return: void
********************************************************************************************************************************************
*/
template <class T>
void DiTask<T>::SetRoot(const DiRoot<T>* a_pkRoot)
{
	m_pkRoot = a_pkRoot;
}

/*
********************************************************************************************************************************************
* Function: SetArgs() - set additional arguments need for this task set from the UI
* Parameters: const char* a_zArgs - all the arguments in single string
* Return: void
********************************************************************************************************************************************
*/
template <class T>
void DiTask<T>::SetArgs(const char* a_zArgs)
{
	if (a_zArgs != NULL)
	{
		m_zArgs = a_zArgs;
	}
}

