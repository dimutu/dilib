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
* Function: DiCondition() - constructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiCondition<T>::DiCondition() : DiTask()
{
	m_pkTrueTask = NULL;
	m_pkFalseTask = NULL;
	m_eClassID = DICLASS_CONDITION; 
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: ~DiCondition() - virtual destructor
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
DiCondition<T>::~DiCondition()
{
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: SetRunTask() - set the task needs to run when this tasks condition is satisfy
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
void DiCondition<T>::SetTrueTask(DiTask<T>* a_pkRunTask) 
{
	m_pkTrueTask = a_pkRunTask;
}
//***************************************************************************************************************************************************//

/*
********************************************************************************************************************************************
* Function: SetFalseRunTask() - task that needs to execute if the condition isnt met
* Parameters: none
* Return: none
********************************************************************************************************************************************
*/
template <class T>
void DiCondition<T>::SetFalseTask(DiTask<T>* a_pkRunTask)
{
	m_pkFalseTask = a_pkRunTask;
}
//***************************************************************************************************************************************************//
