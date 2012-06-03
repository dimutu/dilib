using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiTree
{
    public partial class DiTree : UserControl
    {

        private long m_lDebugIDCounter = 0;

        public DiTree()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            AddTaskItem(DICLASSTYPES.DICLASSTYPE_TASK, "task");
            AddTaskItem(DICLASSTYPES.DICLASSTYPE_CONDITION, "condition");
            AddTaskItem(DICLASSTYPES.DICLASSTYPE_FILTER, "filter");
            AddTaskItem(DICLASSTYPES.DICLASSTYPE_SEQUENCE, "sequence");
            AddTaskItem(DICLASSTYPES.DICLASSTYPE_SELECTION, "selection");
        }

        private void AddTaskItem(DICLASSTYPES a_eType, string a_zImageKey)
        {
            DiListViewItem item = new DiListViewItem();
            item.TaskType = a_eType;
            item.ImageKey = a_zImageKey;
            item.Text = a_zImageKey[0].ToString().ToUpper() + a_zImageKey.Substring(1);
            listTaskTypes.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiDataHanlder.instance.AddNew(txtTemplateClass.Text, true, DICLASSTYPES.DICLASSTYPE_CONDITION, "ccc", "ttt");
        }

        
    }
}
