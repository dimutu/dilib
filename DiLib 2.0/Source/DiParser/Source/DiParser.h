
/*
*********************************************************************************************************************************************
* DiLib v2.0 (dilib.dimutu.com)
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
* Date: 09-06-2011
* Description: this executable is use to generate the header and cpp using the ini file at run time
*
* Modified: 20-02-2013
* Description: 
*********************************************************************************************************************************************
*/

#ifndef _DI_PARSER_H_
#define _DI_PARSER_H_

#include <iostream>
#include <fstream>
#include <string>

namespace DiLib
{

	class DiParser
	{
	public:
		/*
		********************************************************************************************************************************************
		* Function: DiParser() - constructor
		* Parameters:  none
		* Return: none
		********************************************************************************************************************************************
		*/
		DiParser();

		/*
		********************************************************************************************************************************************
		* Function: DiParser() - destructor
		* Parameters:  none
		* Return: none
		********************************************************************************************************************************************
		*/
		~DiParser();

		/*
		********************************************************************************************************************************************
		* Function: GenerateFiles() - generate header and cpp files using the config file
		* Parameters:	const char* a_zConfigFile - config file name
						const char* a_zDestinationPath - destination path where the files needs to be created and saved
		* Return: bool - process success (true) or not(false)
		********************************************************************************************************************************************
		*/
		bool GenerateFiles(const char* a_zConfigFile, const char* a_zDestinationPath);

	private:
		/*
		********************************************************************************************************************************************
		* Function: GenerateEnumHeader() - create the enumeration header file given the config file and destination file path
		* Parameters:	const char* a_zConfigFile - config file name
						const char* a_zEnumFile - enum header file the config data to outputted
		* Return: bool - process success (true) or not(false)
		********************************************************************************************************************************************
		*/
		bool GenerateEnumHeader(const char* a_zConfigFile, const char* a_zEnumFile);

		/*
		********************************************************************************************************************************************
		* Function: GenerateClassGenCpp() - generate DiFactory function method body to create new instances of each class type using the enum data
		* Parameters:	const char* a_zConfigFile - config file name
						const char* a_zCppFile - cpp file to be generated
		* Return: bool - process success (true) or not(false)
		********************************************************************************************************************************************
		*/
		bool GenerateClassGenCpp(const char* a_zConfigFile, const char* a_zCppFile);

		/*
		********************************************************************************************************************************************
		* Function: GenerateReturnTypeEnumHeader() - generate DI_RETURN_TYPE enum
		* Parameters:	const char* a_zConfigFile - config file name
						const char* a_zEnumFile - cpp file to be generated
		* Return: bool - process success (true) or not(false)
		********************************************************************************************************************************************
		*/
		bool GenerateReturnTypeEnumHeader(const char* a_zConfigFile, const char* a_zEnumFile);
	private:
		//generating file names
		std::string m_zEnumFileName;
		std::string m_zClassFileName;
		std::string m_zReturnTypesFileName;

	};

}

#endif


