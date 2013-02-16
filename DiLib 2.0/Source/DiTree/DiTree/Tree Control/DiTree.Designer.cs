namespace DiTree
{
    partial class DiTree
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiTree));
            this.splitTreeProperties = new System.Windows.Forms.SplitContainer();
            this.splitTree = new System.Windows.Forms.SplitContainer();
            this.btnSetTemplate = new System.Windows.Forms.Button();
            this.txtTemplateClass = new System.Windows.Forms.TextBox();
            this.lblTemplateClass = new System.Windows.Forms.Label();
            this.treeBT = new System.Windows.Forms.TreeView();
            this.contextMenuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListTasks = new System.Windows.Forms.ImageList(this.components);
            this.splitProperties = new System.Windows.Forms.SplitContainer();
            this.listTaskTypes = new System.Windows.Forms.ListView();
            this.propertyGridTask = new System.Windows.Forms.PropertyGrid();
            this.toolTipTreeNode = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitTreeProperties)).BeginInit();
            this.splitTreeProperties.Panel1.SuspendLayout();
            this.splitTreeProperties.Panel2.SuspendLayout();
            this.splitTreeProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTree)).BeginInit();
            this.splitTree.Panel1.SuspendLayout();
            this.splitTree.Panel2.SuspendLayout();
            this.splitTree.SuspendLayout();
            this.contextMenuTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitProperties)).BeginInit();
            this.splitProperties.Panel1.SuspendLayout();
            this.splitProperties.Panel2.SuspendLayout();
            this.splitProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitTreeProperties
            // 
            this.splitTreeProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTreeProperties.Location = new System.Drawing.Point(0, 0);
            this.splitTreeProperties.Name = "splitTreeProperties";
            // 
            // splitTreeProperties.Panel1
            // 
            this.splitTreeProperties.Panel1.Controls.Add(this.splitTree);
            // 
            // splitTreeProperties.Panel2
            // 
            this.splitTreeProperties.Panel2.Controls.Add(this.splitProperties);
            this.splitTreeProperties.Size = new System.Drawing.Size(727, 485);
            this.splitTreeProperties.SplitterDistance = 502;
            this.splitTreeProperties.TabIndex = 0;
            // 
            // splitTree
            // 
            this.splitTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTree.Location = new System.Drawing.Point(0, 0);
            this.splitTree.Name = "splitTree";
            this.splitTree.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitTree.Panel1
            // 
            this.splitTree.Panel1.Controls.Add(this.btnSetTemplate);
            this.splitTree.Panel1.Controls.Add(this.txtTemplateClass);
            this.splitTree.Panel1.Controls.Add(this.lblTemplateClass);
            // 
            // splitTree.Panel2
            // 
            this.splitTree.Panel2.Controls.Add(this.treeBT);
            this.splitTree.Size = new System.Drawing.Size(502, 485);
            this.splitTree.SplitterDistance = 45;
            this.splitTree.TabIndex = 0;
            // 
            // btnSetTemplate
            // 
            this.btnSetTemplate.Location = new System.Drawing.Point(294, 9);
            this.btnSetTemplate.Name = "btnSetTemplate";
            this.btnSetTemplate.Size = new System.Drawing.Size(85, 26);
            this.btnSetTemplate.TabIndex = 1;
            this.btnSetTemplate.Text = "Set Template";
            this.btnSetTemplate.UseVisualStyleBackColor = true;
            this.btnSetTemplate.Click += new System.EventHandler(this.btnSetTemplate_Click);
            // 
            // txtTemplateClass
            // 
            this.txtTemplateClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTemplateClass.Location = new System.Drawing.Point(101, 13);
            this.txtTemplateClass.Name = "txtTemplateClass";
            this.txtTemplateClass.Size = new System.Drawing.Size(177, 20);
            this.txtTemplateClass.TabIndex = 0;
            this.txtTemplateClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemplateClass_KeyDown);
            // 
            // lblTemplateClass
            // 
            this.lblTemplateClass.AutoSize = true;
            this.lblTemplateClass.Location = new System.Drawing.Point(16, 16);
            this.lblTemplateClass.Name = "lblTemplateClass";
            this.lblTemplateClass.Size = new System.Drawing.Size(79, 13);
            this.lblTemplateClass.TabIndex = 0;
            this.lblTemplateClass.Text = "Template Class";
            // 
            // treeBT
            // 
            this.treeBT.AllowDrop = true;
            this.treeBT.ContextMenuStrip = this.contextMenuTree;
            this.treeBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBT.ImageIndex = 0;
            this.treeBT.ImageList = this.imageListTasks;
            this.treeBT.Location = new System.Drawing.Point(0, 0);
            this.treeBT.Name = "treeBT";
            this.treeBT.SelectedImageIndex = 0;
            this.treeBT.Size = new System.Drawing.Size(502, 436);
            this.treeBT.TabIndex = 0;
            this.toolTipTreeNode.SetToolTip(this.treeBT, "dgdfg");
            this.treeBT.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeBT_ItemDrag);
            this.treeBT.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeBT_AfterSelect);
            this.treeBT.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeBT_DragDrop);
            this.treeBT.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeBT_DragEnter);
            this.treeBT.DragOver += new System.Windows.Forms.DragEventHandler(this.treeBT_DragOver);
            this.treeBT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeBT_KeyDown);
            this.treeBT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeBT_MouseMove);
            // 
            // contextMenuTree
            // 
            this.contextMenuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTaskToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.removeTaskToolStripMenuItem,
            this.toolStripMenuItem1,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.moveLeftToolStripMenuItem,
            this.moveRightToolStripMenuItem});
            this.contextMenuTree.Name = "contextMenuTree";
            this.contextMenuTree.Size = new System.Drawing.Size(139, 214);
            // 
            // newTaskToolStripMenuItem
            // 
            this.newTaskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskToolStripMenuItem,
            this.conditionToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.sequenceToolStripMenuItem,
            this.selectionToolStripMenuItem});
            this.newTaskToolStripMenuItem.Name = "newTaskToolStripMenuItem";
            this.newTaskToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newTaskToolStripMenuItem.Text = "New";
            // 
            // taskToolStripMenuItem
            // 
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            this.taskToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.taskToolStripMenuItem.Text = "Task";
            // 
            // conditionToolStripMenuItem
            // 
            this.conditionToolStripMenuItem.Name = "conditionToolStripMenuItem";
            this.conditionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.conditionToolStripMenuItem.Text = "Condition";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // sequenceToolStripMenuItem
            // 
            this.sequenceToolStripMenuItem.Name = "sequenceToolStripMenuItem";
            this.sequenceToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.sequenceToolStripMenuItem.Text = "Sequence";
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.selectionToolStripMenuItem.Text = "Selection";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // removeTaskToolStripMenuItem
            // 
            this.removeTaskToolStripMenuItem.Name = "removeTaskToolStripMenuItem";
            this.removeTaskToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.removeTaskToolStripMenuItem.Text = "Delete";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // moveLeftToolStripMenuItem
            // 
            this.moveLeftToolStripMenuItem.Name = "moveLeftToolStripMenuItem";
            this.moveLeftToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveLeftToolStripMenuItem.Text = "Move Left";
            this.moveLeftToolStripMenuItem.Click += new System.EventHandler(this.moveLeftToolStripMenuItem_Click);
            // 
            // moveRightToolStripMenuItem
            // 
            this.moveRightToolStripMenuItem.Name = "moveRightToolStripMenuItem";
            this.moveRightToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveRightToolStripMenuItem.Text = "Move Right";
            this.moveRightToolStripMenuItem.Click += new System.EventHandler(this.moveRightToolStripMenuItem_Click);
            // 
            // imageListTasks
            // 
            this.imageListTasks.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTasks.ImageStream")));
            this.imageListTasks.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTasks.Images.SetKeyName(0, "task");
            this.imageListTasks.Images.SetKeyName(1, "condition");
            this.imageListTasks.Images.SetKeyName(2, "filter");
            this.imageListTasks.Images.SetKeyName(3, "selection");
            this.imageListTasks.Images.SetKeyName(4, "sequence");
            this.imageListTasks.Images.SetKeyName(5, "root");
            this.imageListTasks.Images.SetKeyName(6, "task_run");
            this.imageListTasks.Images.SetKeyName(7, "condition_run");
            this.imageListTasks.Images.SetKeyName(8, "filter_run");
            this.imageListTasks.Images.SetKeyName(9, "selection_run");
            this.imageListTasks.Images.SetKeyName(10, "sequence_run");
            this.imageListTasks.Images.SetKeyName(11, "root_run");
            this.imageListTasks.Images.SetKeyName(12, "task_bp");
            this.imageListTasks.Images.SetKeyName(13, "condition_bp");
            this.imageListTasks.Images.SetKeyName(14, "filter_bp");
            this.imageListTasks.Images.SetKeyName(15, "selection_bp");
            this.imageListTasks.Images.SetKeyName(16, "sequence_bp");
            this.imageListTasks.Images.SetKeyName(17, "root_bp");
            this.imageListTasks.Images.SetKeyName(18, "task_bp_run");
            this.imageListTasks.Images.SetKeyName(19, "condition_bp_run");
            this.imageListTasks.Images.SetKeyName(20, "filter_bp_run");
            this.imageListTasks.Images.SetKeyName(21, "selection_bp_run");
            this.imageListTasks.Images.SetKeyName(22, "sequence_bp_run");
            this.imageListTasks.Images.SetKeyName(23, "root_bp_run");
            // 
            // splitProperties
            // 
            this.splitProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitProperties.Location = new System.Drawing.Point(0, 0);
            this.splitProperties.Name = "splitProperties";
            this.splitProperties.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitProperties.Panel1
            // 
            this.splitProperties.Panel1.Controls.Add(this.listTaskTypes);
            // 
            // splitProperties.Panel2
            // 
            this.splitProperties.Panel2.Controls.Add(this.propertyGridTask);
            this.splitProperties.Size = new System.Drawing.Size(221, 485);
            this.splitProperties.SplitterDistance = 187;
            this.splitProperties.TabIndex = 0;
            // 
            // listTaskTypes
            // 
            this.listTaskTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTaskTypes.GridLines = true;
            this.listTaskTypes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listTaskTypes.HoverSelection = true;
            this.listTaskTypes.LargeImageList = this.imageListTasks;
            this.listTaskTypes.Location = new System.Drawing.Point(0, 0);
            this.listTaskTypes.MinimumSize = new System.Drawing.Size(200, 180);
            this.listTaskTypes.MultiSelect = false;
            this.listTaskTypes.Name = "listTaskTypes";
            this.listTaskTypes.ShowGroups = false;
            this.listTaskTypes.ShowItemToolTips = true;
            this.listTaskTypes.Size = new System.Drawing.Size(221, 187);
            this.listTaskTypes.SmallImageList = this.imageListTasks;
            this.listTaskTypes.TabIndex = 0;
            this.listTaskTypes.UseCompatibleStateImageBehavior = false;
            this.listTaskTypes.View = System.Windows.Forms.View.List;
            this.listTaskTypes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listTaskTypes_MouseDoubleClick);
            this.listTaskTypes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listTaskTypes_MouseDown);
            // 
            // propertyGridTask
            // 
            this.propertyGridTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridTask.Location = new System.Drawing.Point(0, 0);
            this.propertyGridTask.Name = "propertyGridTask";
            this.propertyGridTask.Size = new System.Drawing.Size(221, 294);
            this.propertyGridTask.TabIndex = 0;
            this.propertyGridTask.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridTask_PropertyValueChanged);
            // 
            // DiTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitTreeProperties);
            this.Name = "DiTree";
            this.Size = new System.Drawing.Size(727, 485);
            this.splitTreeProperties.Panel1.ResumeLayout(false);
            this.splitTreeProperties.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTreeProperties)).EndInit();
            this.splitTreeProperties.ResumeLayout(false);
            this.splitTree.Panel1.ResumeLayout(false);
            this.splitTree.Panel1.PerformLayout();
            this.splitTree.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitTree)).EndInit();
            this.splitTree.ResumeLayout(false);
            this.contextMenuTree.ResumeLayout(false);
            this.splitProperties.Panel1.ResumeLayout(false);
            this.splitProperties.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitProperties)).EndInit();
            this.splitProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitTreeProperties;
        private System.Windows.Forms.SplitContainer splitTree;
        private System.Windows.Forms.TextBox txtTemplateClass;
        private System.Windows.Forms.Label lblTemplateClass;
        private System.Windows.Forms.TreeView treeBT;
        private System.Windows.Forms.SplitContainer splitProperties;
        private System.Windows.Forms.ListView listTaskTypes;
        private System.Windows.Forms.ImageList imageListTasks;
        private System.Windows.Forms.Button btnSetTemplate;
        private System.Windows.Forms.PropertyGrid propertyGridTask;
        private System.Windows.Forms.ContextMenuStrip contextMenuTree;
        private System.Windows.Forms.ToolStripMenuItem newTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conditionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sequenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipTreeNode;

    }
}
