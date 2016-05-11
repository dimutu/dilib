
/*
*********************************************************************************************************************************************
*
* Author: Dimutu Kulawardana
* Date: 04-06-2011
* Description: check a condition and if child task exists try to run the task or return back to parent
*
*********************************************************************************************************************************************
*/

#ifndef _DI_CONDITION_TASK_H_
#define _DI_CONDITION_TASK_H_

#include "DiTask.h"
//! \details Main library namespace

//! \namespace DiLib
namespace DiLib
{
	//! \class DiCondition
	//! \details This act as IF statement and check condition and if child task exists try to run the task or return back to parent
	//! \par This class must be implemented in the game code in-order to use it.
	template <class T>
	class DiCondition : public DiTask<T>
	{
	public:

		//! Constructor
		DiCondition();

		//! Virtual destructor
		virtual ~DiCondition();


		//! Execute the conditional task, and call either true or false task matching to the condition
		//! \par This is a pure virtual function to be used on extended classes.
		//! \param a_pkOwner Template class that this task to be executed upon.
		//! \return Integer to evaluate the new state of the template class or the AI object
		//!< This is more efficiently described through DI_TASK_RETURNS enumeration generated by the DiParser when \link setup_cpp Setting up C++ project \endlink
		virtual int Execute(T* a_pkOwner) = 0;

		//! Set the true task during tree intialization
		//! \param a_pkTask Pointer reference to the true task
		virtual void SetTrueTask(DiTask<T>* a_pkTask);

		//! Set the false task during tree intialization
		//! \param a_pkTask Pointer reference to the false task
		virtual void SetFalseTask(DiTask<T>* a_pkTask);

	protected:
		DiTask<T> *m_pkTrueTask; //!< Task to run on conditon met
		DiTask<T> *m_pkFalseTask; //!< Task to run when the condition isn't met

	};
	//***************************************************************************************************************************************************//


}

#endif

