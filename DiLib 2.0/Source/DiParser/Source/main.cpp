/*
****************************************************************************************************************************
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
******************************************************************************************************************************
*/

#include <stdlib.h>
#include "DiParser.h"

int main(int argc, char** argv)
{
	
	DiLib::DiParser p;

	if (argc == 3)
	{
		p.GenerateFiles(argv[1], argv[2]);
	}
	else
	{
		printf("\nDiLIB DiParser version 2.0.1\n");
		printf("Generates C++ source files from the exported diconfig file from the DiLIB tree creator.\n\n");
		printf("Usage:\n \tDiParser.exe [di-config-file] [destination-folder]\n");
	}
	
	return 0;
}
