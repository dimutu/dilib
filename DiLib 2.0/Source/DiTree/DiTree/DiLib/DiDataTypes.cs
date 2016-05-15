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
*******************************************************************************************************************************
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiTree
{
	public enum DICLASSTYPES
	{
		DICLASSTYPE_TASK = 0,
		DICLASSTYPE_SEQUENCE,
		DICLASSTYPE_SELECTION,
		DICLASSTYPE_CONDITION ,
		DICLASSTYPE_FILTER,
        DICLASSTYPE_ROOT,
		DICLASSTYPE_COUNT 
	};

    /// <summary>
    /// this is to create condition task array with COUNT and use the enum to access
    ///     each element
    /// </summary>
    public enum CONDITION
    {
        CONDITION_ELEMENT1 = 0,
        CONDITION_ELEMENT2,
        CONDITION_COUNT
    };

    /// <summary>
    /// Moves the selected node in the tree in these directions from the main menu commands
    /// </summary>
    public enum TREENODEMOVEMENT
    {
        TREENODEMOVE_LEFT, //make the selected node to be same level as its parent
        TREENODEMOVE_RIGHT, //make the selected node to be child of the same level previous/next node
        TREENODEMOVE_UP, //re-arrange the node order by moving selected node up
        TREENODEMOVE_DOWN, //re-arrage the node order index 
        TREENODEMOVE_COUNT
    };

}
