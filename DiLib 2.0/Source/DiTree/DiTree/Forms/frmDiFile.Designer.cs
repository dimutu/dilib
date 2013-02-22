namespace DiTree
{
    partial class frmDiFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiFile));
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDebugID = new System.Windows.Forms.TextBox();
            this.txtIncludeFile = new System.Windows.Forms.TextBox();
            this.lblDebugName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddInclude = new System.Windows.Forms.Button();
            this.listInclues = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageNew = new System.Windows.Forms.TabPage();
            this.tabDiFile = new System.Windows.Forms.TabControl();
            this.tabPageReturns = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtReturnEnum = new System.Windows.Forms.TextBox();
            this.btnRemoveEnum = new System.Windows.Forms.Button();
            this.btnAddEnum = new System.Windows.Forms.Button();
            this.listReturnEnums = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCloseTab = new System.Windows.Forms.Button();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.imageListDiFille = new System.Windows.Forms.ImageList(this.components);
            this.tabPageGeneral.SuspendLayout();
            this.tabDiFile.SuspendLayout();
            this.tabPageReturns.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.label4);
            this.tabPageGeneral.Controls.Add(this.txtDebugID);
            this.tabPageGeneral.Controls.Add(this.txtIncludeFile);
            this.tabPageGeneral.Controls.Add(this.lblDebugName);
            this.tabPageGeneral.Controls.Add(this.label1);
            this.tabPageGeneral.Controls.Add(this.label3);
            this.tabPageGeneral.Controls.Add(this.btnRemove);
            this.tabPageGeneral.Controls.Add(this.btnAddInclude);
            this.tabPageGeneral.Controls.Add(this.listInclues);
            this.tabPageGeneral.Controls.Add(this.label2);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 54);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(772, 432);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.ToolTipText = "Lists Including Header Files";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(212, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "To identify debugging behaviour tree ";
            // 
            // txtDebugID
            // 
            this.txtDebugID.Location = new System.Drawing.Point(215, 35);
            this.txtDebugID.MaxLength = 255;
            this.txtDebugID.Name = "txtDebugID";
            this.txtDebugID.Size = new System.Drawing.Size(268, 21);
            this.txtDebugID.TabIndex = 1;
            // 
            // txtIncludeFile
            // 
            this.txtIncludeFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtIncludeFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtIncludeFile.Location = new System.Drawing.Point(215, 107);
            this.txtIncludeFile.Name = "txtIncludeFile";
            this.txtIncludeFile.Size = new System.Drawing.Size(268, 21);
            this.txtIncludeFile.TabIndex = 2;
            this.txtIncludeFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIncludeFile_KeyDown);
            // 
            // lblDebugName
            // 
            this.lblDebugName.AutoSize = true;
            this.lblDebugName.Location = new System.Drawing.Point(41, 37);
            this.lblDebugName.Name = "lblDebugName";
            this.lblDebugName.Size = new System.Drawing.Size(154, 15);
            this.lblDebugName.TabIndex = 8;
            this.lblDebugName.Text = "Unique Debgging Identifier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "This is all the behaviour tree tasks header files, deriving from the template cla" +
    "sses";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "eg: Enemy.h";
            // 
            // btnRemove
            // 
            this.btnRemove.ImageKey = "delete.png";
            this.btnRemove.Location = new System.Drawing.Point(500, 190);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(53, 37);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddInclude
            // 
            this.btnAddInclude.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddInclude.ImageKey = "add.png";
            this.btnAddInclude.Location = new System.Drawing.Point(500, 99);
            this.btnAddInclude.Name = "btnAddInclude";
            this.btnAddInclude.Size = new System.Drawing.Size(53, 37);
            this.btnAddInclude.TabIndex = 3;
            this.btnAddInclude.UseVisualStyleBackColor = true;
            this.btnAddInclude.Click += new System.EventHandler(this.btnAddInclude_Click);
            // 
            // listInclues
            // 
            this.listInclues.FormattingEnabled = true;
            this.listInclues.ItemHeight = 15;
            this.listInclues.Location = new System.Drawing.Point(215, 190);
            this.listInclues.Name = "listInclues";
            this.listInclues.Size = new System.Drawing.Size(268, 229);
            this.listInclues.TabIndex = 4;
            this.listInclues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listInclues_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Including Headers";
            // 
            // tabPageNew
            // 
            this.tabPageNew.BackColor = System.Drawing.Color.Transparent;
            this.tabPageNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPageNew.ImageKey = "bullet_add.png";
            this.tabPageNew.Location = new System.Drawing.Point(4, 54);
            this.tabPageNew.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageNew.Name = "tabPageNew";
            this.tabPageNew.Size = new System.Drawing.Size(772, 432);
            this.tabPageNew.TabIndex = 2;
            this.tabPageNew.Tag = "Add";
            this.tabPageNew.ToolTipText = "Add New Tree";
            // 
            // tabDiFile
            // 
            this.tabDiFile.Controls.Add(this.tabPageNew);
            this.tabDiFile.Controls.Add(this.tabPageGeneral);
            this.tabDiFile.Controls.Add(this.tabPageReturns);
            this.tabDiFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDiFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDiFile.ImageList = this.imageListDiFille;
            this.tabDiFile.ItemSize = new System.Drawing.Size(80, 50);
            this.tabDiFile.Location = new System.Drawing.Point(0, 0);
            this.tabDiFile.Margin = new System.Windows.Forms.Padding(30);
            this.tabDiFile.Name = "tabDiFile";
            this.tabDiFile.Padding = new System.Drawing.Point(20, 5);
            this.tabDiFile.SelectedIndex = 0;
            this.tabDiFile.Size = new System.Drawing.Size(780, 490);
            this.tabDiFile.TabIndex = 2;
            this.tabDiFile.SelectedIndexChanged += new System.EventHandler(this.tabDiFile_SelectedIndexChanged);
            // 
            // tabPageReturns
            // 
            this.tabPageReturns.Controls.Add(this.textBox1);
            this.tabPageReturns.Controls.Add(this.txtReturnEnum);
            this.tabPageReturns.Controls.Add(this.btnRemoveEnum);
            this.tabPageReturns.Controls.Add(this.btnAddEnum);
            this.tabPageReturns.Controls.Add(this.listReturnEnums);
            this.tabPageReturns.Controls.Add(this.label6);
            this.tabPageReturns.Location = new System.Drawing.Point(4, 54);
            this.tabPageReturns.Name = "tabPageReturns";
            this.tabPageReturns.Size = new System.Drawing.Size(772, 432);
            this.tabPageReturns.TabIndex = 3;
            this.tabPageReturns.Text = "Enumerations";
            this.tabPageReturns.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(563, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(181, 240);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // txtReturnEnum
            // 
            this.txtReturnEnum.AcceptsReturn = true;
            this.txtReturnEnum.Location = new System.Drawing.Point(208, 64);
            this.txtReturnEnum.Name = "txtReturnEnum";
            this.txtReturnEnum.Size = new System.Drawing.Size(268, 21);
            this.txtReturnEnum.TabIndex = 8;
            this.txtReturnEnum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReturnEnum_KeyDown);
            // 
            // btnRemoveEnum
            // 
            this.btnRemoveEnum.ImageKey = "delete.png";
            this.btnRemoveEnum.Location = new System.Drawing.Point(493, 147);
            this.btnRemoveEnum.Name = "btnRemoveEnum";
            this.btnRemoveEnum.Size = new System.Drawing.Size(53, 37);
            this.btnRemoveEnum.TabIndex = 12;
            this.btnRemoveEnum.UseVisualStyleBackColor = true;
            this.btnRemoveEnum.Click += new System.EventHandler(this.btnRemoveEnum_Click);
            // 
            // btnAddEnum
            // 
            this.btnAddEnum.ImageKey = "add.png";
            this.btnAddEnum.Location = new System.Drawing.Point(493, 56);
            this.btnAddEnum.Name = "btnAddEnum";
            this.btnAddEnum.Size = new System.Drawing.Size(53, 37);
            this.btnAddEnum.TabIndex = 10;
            this.btnAddEnum.UseVisualStyleBackColor = true;
            this.btnAddEnum.Click += new System.EventHandler(this.btnAddEnum_Click);
            // 
            // listReturnEnums
            // 
            this.listReturnEnums.FormattingEnabled = true;
            this.listReturnEnums.ItemHeight = 15;
            this.listReturnEnums.Location = new System.Drawing.Point(208, 147);
            this.listReturnEnums.Name = "listReturnEnums";
            this.listReturnEnums.Size = new System.Drawing.Size(268, 229);
            this.listReturnEnums.TabIndex = 11;
            this.listReturnEnums.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listReturnEnums_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Additional Return Types";
            // 
            // btnCloseTab
            // 
            this.btnCloseTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseTab.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseTab.Image")));
            this.btnCloseTab.Location = new System.Drawing.Point(751, 4);
            this.btnCloseTab.Name = "btnCloseTab";
            this.btnCloseTab.Size = new System.Drawing.Size(20, 20);
            this.btnCloseTab.TabIndex = 3;
            this.btnCloseTab.UseVisualStyleBackColor = true;
            this.btnCloseTab.Click += new System.EventHandler(this.btnCloseTab_Click);
            this.btnCloseTab.MouseHover += new System.EventHandler(this.btnCloseTab_MouseHover);
            // 
            // imageListDiFille
            // 
            this.imageListDiFille.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDiFille.ImageStream")));
            this.imageListDiFille.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDiFille.Images.SetKeyName(0, "bullet_star.png");
            // 
            // frmDiFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 490);
            this.Controls.Add(this.btnCloseTab);
            this.Controls.Add(this.tabDiFile);
            this.KeyPreview = true;
            this.Name = "frmDiFile";
            this.Text = "frmDiFile";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDiFile_KeyDown);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabDiFile.ResumeLayout(false);
            this.tabPageReturns.ResumeLayout(false);
            this.tabPageReturns.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDebugID;
        private System.Windows.Forms.TextBox txtIncludeFile;
        private System.Windows.Forms.Label lblDebugName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddInclude;
        private System.Windows.Forms.ListBox listInclues;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageNew;
        private System.Windows.Forms.TabControl tabDiFile;
        private System.Windows.Forms.Button btnCloseTab;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.TabPage tabPageReturns;
        private System.Windows.Forms.TextBox txtReturnEnum;
        private System.Windows.Forms.Button btnRemoveEnum;
        private System.Windows.Forms.Button btnAddEnum;
        private System.Windows.Forms.ListBox listReturnEnums;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ImageList imageListDiFille;
    }
}