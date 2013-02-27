namespace DiTree
{
    partial class frmDiTreeView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiTreeView));
            this.treeBT = new System.Windows.Forms.TreeView();
            this.imageListTasks = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeBT
            // 
            this.treeBT.AllowDrop = true;
            this.treeBT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBT.ImageIndex = 0;
            this.treeBT.ImageList = this.imageListTasks;
            this.treeBT.Location = new System.Drawing.Point(0, 0);
            this.treeBT.Name = "treeBT";
            this.treeBT.SelectedImageIndex = 0;
            this.treeBT.Size = new System.Drawing.Size(597, 454);
            this.treeBT.TabIndex = 1;
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
            // frmDiTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 454);
            this.Controls.Add(this.treeBT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDiTreeView";
            this.Text = "frmDiTreeView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeBT;
        private System.Windows.Forms.ImageList imageListTasks;
    }
}