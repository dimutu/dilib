﻿namespace DiTree
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
            this.txtTemplateClass = new System.Windows.Forms.TextBox();
            this.lblTemplateClass = new System.Windows.Forms.Label();
            this.treeBT = new System.Windows.Forms.TreeView();
            this.splitProperties = new System.Windows.Forms.SplitContainer();
            this.listTaskTypes = new System.Windows.Forms.ListView();
            this.imageListTasks = new System.Windows.Forms.ImageList(this.components);
            this.propertyNode = new System.Windows.Forms.PropertyGrid();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitTreeProperties)).BeginInit();
            this.splitTreeProperties.Panel1.SuspendLayout();
            this.splitTreeProperties.Panel2.SuspendLayout();
            this.splitTreeProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTree)).BeginInit();
            this.splitTree.Panel1.SuspendLayout();
            this.splitTree.Panel2.SuspendLayout();
            this.splitTree.SuspendLayout();
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
            this.splitTree.Panel1.Controls.Add(this.button1);
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
            // txtTemplateClass
            // 
            this.txtTemplateClass.Location = new System.Drawing.Point(101, 13);
            this.txtTemplateClass.Name = "txtTemplateClass";
            this.txtTemplateClass.Size = new System.Drawing.Size(177, 20);
            this.txtTemplateClass.TabIndex = 1;
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
            this.treeBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBT.Location = new System.Drawing.Point(0, 0);
            this.treeBT.Name = "treeBT";
            this.treeBT.Size = new System.Drawing.Size(502, 436);
            this.treeBT.TabIndex = 0;
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
            this.splitProperties.Panel2.Controls.Add(this.propertyNode);
            this.splitProperties.Size = new System.Drawing.Size(221, 485);
            this.splitProperties.SplitterDistance = 187;
            this.splitProperties.TabIndex = 0;
            // 
            // listTaskTypes
            // 
            this.listTaskTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTaskTypes.GridLines = true;
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
            // 
            // propertyNode
            // 
            this.propertyNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyNode.Location = new System.Drawing.Point(0, 0);
            this.propertyNode.Name = "propertyNode";
            this.propertyNode.Size = new System.Drawing.Size(221, 294);
            this.propertyNode.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 18);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
        private System.Windows.Forms.PropertyGrid propertyNode;
        private System.Windows.Forms.SplitContainer splitProperties;
        private System.Windows.Forms.ListView listTaskTypes;
        private System.Windows.Forms.ImageList imageListTasks;
        private System.Windows.Forms.Button button1;

    }
}