namespace DiTree
{
    partial class frmExportSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportSource));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridSource = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressExport = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkCpp = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imageListButton = new System.Windows.Forms.ImageList(this.components);
            this.chkHeaders = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.folderDlgSource = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridSource, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.27297F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.72704F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(677, 456);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridSource
            // 
            this.dataGridSource.AllowUserToAddRows = false;
            this.dataGridSource.AllowUserToDeleteRows = false;
            this.dataGridSource.AllowUserToResizeRows = false;
            this.dataGridSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridSource.Location = new System.Drawing.Point(3, 65);
            this.dataGridSource.Name = "dataGridSource";
            this.dataGridSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSource.Size = new System.Drawing.Size(671, 313);
            this.dataGridSource.TabIndex = 0;
            this.dataGridSource.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridSource_CellBeginEdit);
            this.dataGridSource.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridSource_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressExport);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 69);
            this.panel1.TabIndex = 1;
            // 
            // progressExport
            // 
            this.progressExport.Location = new System.Drawing.Point(3, 58);
            this.progressExport.Name = "progressExport";
            this.progressExport.Size = new System.Drawing.Size(665, 10);
            this.progressExport.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(8, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(396, 41);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Marked rows cannot be exported due to its Class is only implemented as a template" +
    ".";
            // 
            // chkCpp
            // 
            this.chkCpp.AutoSize = true;
            this.chkCpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCpp.Location = new System.Drawing.Point(532, 33);
            this.chkCpp.Name = "chkCpp";
            this.chkCpp.Size = new System.Drawing.Size(96, 17);
            this.chkCpp.TabIndex = 4;
            this.chkCpp.Text = "All Cpp Files";
            this.chkCpp.UseVisualStyleBackColor = true;
            this.chkCpp.CheckedChanged += new System.EventHandler(this.chkCpp_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCancel.ImageKey = "cancel";
            this.btnCancel.ImageList = this.imageListButton;
            this.btnCancel.Location = new System.Drawing.Point(563, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // imageListButton
            // 
            this.imageListButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListButton.ImageStream")));
            this.imageListButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListButton.Images.SetKeyName(0, "folder");
            this.imageListButton.Images.SetKeyName(1, "doc_export");
            this.imageListButton.Images.SetKeyName(2, "cancel");
            // 
            // chkHeaders
            // 
            this.chkHeaders.AutoSize = true;
            this.chkHeaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHeaders.Location = new System.Drawing.Point(532, 10);
            this.chkHeaders.Name = "chkHeaders";
            this.chkHeaders.Size = new System.Drawing.Size(115, 17);
            this.chkHeaders.TabIndex = 3;
            this.chkHeaders.Text = "All Header Files";
            this.chkHeaders.UseVisualStyleBackColor = true;
            this.chkHeaders.CheckedChanged += new System.EventHandler(this.chkHeaders_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnExport.ImageKey = "doc_export";
            this.btnExport.ImageList = this.imageListButton;
            this.btnExport.Location = new System.Drawing.Point(464, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 40);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtPath);
            this.panel2.Controls.Add(this.chkCpp);
            this.panel2.Controls.Add(this.btnBrowse);
            this.panel2.Controls.Add(this.chkHeaders);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 56);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Export Folder Path";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(126, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(335, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnBrowse.ImageKey = "folder";
            this.btnBrowse.ImageList = this.imageListButton;
            this.btnBrowse.Location = new System.Drawing.Point(467, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(39, 39);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // frmExportSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 456);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmExportSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate Source";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmExportSource_FormClosed);
            this.Shown += new System.EventHandler(this.frmExportSource_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderDlgSource;
        private System.Windows.Forms.ImageList imageListButton;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkCpp;
        private System.Windows.Forms.CheckBox chkHeaders;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressExport;

    }
}