
#include "DiParser.h"

namespace DiLib
{
	/*
	********************************************************************************************************************************************
	* Function: DiParser() - constructor
	* Parameters:  none
	* Return: none
	********************************************************************************************************************************************
	*/
	DiParser::DiParser()
	{
		m_zEnumFileName = "DiClassTypeIDs.h";
		m_zClassFileName = "DiClassGenerator.cpp";
	}
	/******************************************************************************************************************************************/

	/*
	********************************************************************************************************************************************
	* Function: DiParser() - destructor
	* Parameters:  none
	* Return: none
	********************************************************************************************************************************************
	*/
	DiParser::~DiParser()
	{

	}
	/******************************************************************************************************************************************/

	/*
	********************************************************************************************************************************************
	* Function: GenerateFiles() - generate header and cpp files using the config file
	* Parameters:	const char* a_zConfigFile - config file name
					const char* a_zDestinationPath - destination path where the files needs to be created and saved
	* Return: bool - process success (true) or not(false)
	********************************************************************************************************************************************
	*/
	bool DiParser::GenerateFiles(const char* a_zConfigFile, const char* a_zDestinationPath)
	{
		std::string zEnumHFileName = a_zDestinationPath;
		zEnumHFileName += "/" + m_zEnumFileName;
		
		std::string zCppFile = a_zDestinationPath;
		zCppFile += "/" + m_zClassFileName;

		GenerateEnumHeader(a_zConfigFile, zEnumHFileName.c_str());

		GenerateClassGenCpp(a_zConfigFile, zCppFile.c_str());

		return false;
	}
	/******************************************************************************************************************************************/

	/*
	********************************************************************************************************************************************
	* Function: GenerateEnumHeader() - create the enumeration header file given the config file and destination file path
	* Parameters:	const char* a_zConfigFile - config file name
					const char* a_zEnumFile - enum header file the config data to outputted
	* Return: bool - process success (true) or not(false)
	********************************************************************************************************************************************
	*/
	bool DiParser::GenerateEnumHeader(const char* a_zConfigFile, const char* a_zEnumFile)
	{
		std::fstream kINIFile;
		std::fstream kEnumHFile;

		kINIFile.open(a_zConfigFile, std::ios_base::in );
		kEnumHFile.open(a_zEnumFile, std::ios_base::out | std::ios_base::trunc);

		std::string sLine;
		std::string sWriteLine;

		bool bHeaders = false;
		bool bEnums = false;


		if (kINIFile.is_open() && kEnumHFile.is_open() ) //open the DI file and enum header to write
		{
			char zBuff[200];
			
			//write a comment on header
			sWriteLine = "\n/*this file generates at runtime to identify each inherited or templated class by a enum id for easy identification*/\n\n";
			kEnumHFile.write(sWriteLine.c_str(), sWriteLine.size());

			//write #defines for header
			sWriteLine = "\n#ifndef _DI_CLASS_TYPE_IDS_H_\n#define _DI_CLASS_TYPE_IDS_H_\n\n";
			kEnumHFile.write(sWriteLine.c_str(), sWriteLine.size());

			bool bSetComma = false; //to set the comma seperator on enum 

			while ( !kINIFile.eof())
			{
				kINIFile.getline(zBuff, 200);

				if (kINIFile.eof()) break;

				sLine = zBuff;

				//ignore comments
				if (zBuff[0] == '#')
				{
					continue;
				}

				if (sLine.size() <= 1) //nothing in this line
				{
					if (bHeaders)
					{
						//currently reading headers, end of headers now
						bHeaders = false;
					}
					if (bEnums)
					{
						bEnums = false;
						bSetComma = false;
						//close namespace stuff
						//set namespace data
						sWriteLine = "\t\t\t};\n\t\t}\n}";
						kEnumHFile.write(sWriteLine.c_str(), sWriteLine.size());
					}
					continue;
				}

				if (sLine == "[Headers]")
				{
					//write out headers from next line
					bHeaders = true;
					continue;
				}

				if (sLine == "[Enum]")
				{
					bEnums = true;
					//set namespace data
					sWriteLine = "\n \tnamespace DiFactory\n\t{\n\t\tenum DI_CLASSTYPEID\n\t\t{";
					kEnumHFile.write(sWriteLine.c_str(), sWriteLine.size());

					//set default class types that are already implemented
					/**sWriteLine = "\n\t\t\tDICLASSTYPE_TEMPLATE_TASK, \
									\n\t\t\tDICLASSTYPE_TEMPLATE_CONDITION, \
									\n\t\t\tDICLASSTYPE_TEMPLATE_FILTER, \
									\n\t\t\tDICLASSTYPE_TEMPLATE_SEQUENCE, \
									\n\t\t\tDICLASSTYPE_TEMPLATE_SELECTION,";
					kEnumHFile.write(sWriteLine.c_str(), sWriteLine.size());
					*/
					continue;
				}

				if (bHeaders)
				{
					sWriteLine = "#include \"" + sLine + "\"\n";
					kEnumHFile.write(sWriteLine.c_str(), sWriteLine.size());
				}

				if (bEnums)
				{
					//loop through current line and get enum id and name and write it
					std::string sNum, sName;
					int iCol = 0;

					for(unsigned int ii = 0; ii < strlen(zBuff); ++ii)
					{
						if (zBuff[ii] == ',')
						{
							++iCol;
							if (iCol > 1) break;

							continue;
						}
						if (iCol == 0) //get id
						{
							sNum = sNum + zBuff[ii];
						}
						else if (iCol == 1)//get enum nae
						{
							sName = sName + zBuff[ii];
						}
					}
					sWriteLine = "";
					if (bSetComma)
					{
						sWriteLine = ",";
					}
					//keep the naming conversion intact, and name it custom if chosen a derived class type
					sWriteLine = sWriteLine + "\n\t\t\tDICLASSTYPE_CUSTOM_" + sName + " = " + sNum; //ignore the number and use with running number with default types added + " = " + sNum;
					kEnumHFile.write(sWriteLine.c_str(), sWriteLine.size());

					if (!bSetComma)
					{
						bSetComma = true; //set the comma after first line
					}
				}

			}

			if (bEnums)
			{
				//namespace didnt close inside the loop
				sWriteLine = "\n\t\t};\n}\n";
				kEnumHFile.write(sWriteLine.c_str(), sWriteLine.size());
			}

			sWriteLine = "\n#endif\n\n";
			kEnumHFile.write(sWriteLine.c_str(), sWriteLine.size());

			kINIFile.close();
			kEnumHFile.close();

			return true;
		}

		return false;
	}
	/******************************************************************************************************************************************/

	/*
	********************************************************************************************************************************************
	* Function: GenerateClassGenCpp() - generate DiFactory function method body to create new instances of each class type using the enum data
	* Parameters:	const char* a_zConfigFile - config file name
					const char* a_zCppFile - cpp file to be generated
	* Return: bool - process success (true) or not(false)
	********************************************************************************************************************************************
	*/
	bool DiParser::GenerateClassGenCpp(const char* a_zConfigFile, const char* a_zCppFile)
	{

		std::fstream kDIFile;
		std::fstream kCppFile;

		kDIFile.open(a_zConfigFile, std::ios_base::in );
		kCppFile.open(a_zCppFile, std::ios_base::out | std::ios_base::trunc);

		std::string sLine;
		std::string sWriteLine;

		bool bEnums = false;

		if (kDIFile.is_open() && kCppFile.is_open() ) //open the DI file and enum header to write
		{
			char zBuff[200];

			//inlcude the header just created, so all the inlcudes can go in
			//write a comment on header
			sWriteLine = "\n#include \"" + m_zEnumFileName;
			sWriteLine += "\"\n";
			sWriteLine += "#include <DiFactory.h>\n\n";
			kCppFile.write(sWriteLine.c_str(), sWriteLine.size());

			//make function
			sWriteLine =	"using namespace DiLib;\nnamespace DiFactory\n \
\t{\n \
\t\tDiBaseTask* CreateTask(DI_CLASSTYPEID a_eClassTypeID)\n \
\t\t{\n \
\t\t\tDiBaseTask* pkTask = NULL;\n \
\t\t\tswitch (a_eClassTypeID)\n \
\t\t\t{\n";
			
			kCppFile.write(sWriteLine.c_str(), sWriteLine.size());

			while (!kDIFile.eof())
			{
				kDIFile.getline(zBuff, 200);

				sLine = zBuff;

				if (sLine == "[Enum]")
				{
					bEnums = true;
					continue;
				}

				if (sLine.size() <= 1) //nothing in this line
				{
					if (bEnums)
					{
						bEnums = false;
						//end of reading enums, no need to read the whole file
						break;
					}
				}

				if (bEnums)
				{
					//loop through current line and get enum id and name and write it
					std::string sNum, sName, sClassID, sTemplate, sClassName, sIsTemplate;
					int iCol = 0;

					for(unsigned int ii = 0; ii < strlen(zBuff); ++ii)
					{
						if (zBuff[ii] == ',')
						{
							++iCol;
							continue;
						}

						switch (iCol)
						{
						case 0:
							sNum = sNum + zBuff[ii]; //id
							break;

						case 1:
							sName = sName + zBuff[ii]; //enum name
							break;

						case 2:
							sIsTemplate = sIsTemplate + zBuff[ii]; //is template class and not user class
							
							break;

						case 3:
							sClassID = sClassID + zBuff[ii]; //class type id, task, selections
							
							break;

						case 4:
							sClassName = sClassName + zBuff[ii]; //class name
							break;

						case 5:
							sTemplate = sTemplate + zBuff[ii];//template class use to create the class, player, enemy
							break;

						default:
							break;
						}

					}

					//check this uses standerd tamplates or not
					if (sIsTemplate == "True")
					{
						sWriteLine = "\n\t\t\tcase DICLASSTYPE_CUSTOM_" + sName + ":\n\
\t\t\t\t{\n\
\t\t\t\t\t" + sClassName + "<" + sTemplate + ">* pkClass = new " + sClassName + "<" + sTemplate + ">();\n \
\t\t\t\t\tpkTask = (DiBaseTask*)pkClass;\n \
\t\t\t\t}\n\
\t\t\t\tbreak;\n";
					}
					else
					{
						sWriteLine = "\n\t\t\tcase DICLASSTYPE_CUSTOM_" + sName + ":\n\
\t\t\t\t{\n\
\t\t\t\t" + sClassName + "* pkClass = new " + sClassName + "();\n \
\t\t\t\tpkTask = (DiBaseTask*)pkClass;\n \
\t\t\t\t}\n\
\t\t\t\tbreak;\n";
					}
					kCppFile.write(sWriteLine.c_str(), sWriteLine.size());


				}

				//if (kDIFile.eof()) break;

			}

			//close the braces and #define
			sWriteLine = "\n \
\t\t\tdefault:\n \
\t\t\t\tbreak;\n \
\t\t\t}\n\n \
\t\treturn pkTask;\n\n \
\t\t}\n \
}\n";
			kCppFile.write(sWriteLine.c_str(), sWriteLine.size());


			kDIFile.close();
			kCppFile.close();

		}

		return true;
	}
	/******************************************************************************************************************************************/

} //end namespace