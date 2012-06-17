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
