namespace DiTree
{
    partial class DiPropertyControl
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
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblScript = new System.Windows.Forms.Label();
            this.txtGenScriptFile = new System.Windows.Forms.TextBox();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.btnGenBrowseScript = new System.Windows.Forms.Button();
            this.numGenTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.cboClassID = new System.Windows.Forms.ComboBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblInterval = new System.Windows.Forms.Label();
            this.cboGenTimerEnabled = new System.Windows.Forms.ComboBox();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.numFilterMaxRun = new System.Windows.Forms.NumericUpDown();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.cboFilterRepeat = new System.Windows.Forms.ComboBox();
            this.lblMaxRun = new System.Windows.Forms.Label();
            this.grpCondition = new System.Windows.Forms.GroupBox();
            this.lblFalseTaskTree1 = new System.Windows.Forms.Label();
            this.lblTrueTaskTree1 = new System.Windows.Forms.Label();
            this.cboCondRunTrue = new System.Windows.Forms.ComboBox();
            this.cboCondRunFalse = new System.Windows.Forms.ComboBox();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenTimeInterval)).BeginInit();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFilterMaxRun)).BeginInit();
            this.grpCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.lblClassName);
            this.grpGeneral.Controls.Add(this.lblScript);
            this.grpGeneral.Controls.Add(this.txtGenScriptFile);
            this.grpGeneral.Controls.Add(this.lblSeconds);
            this.grpGeneral.Controls.Add(this.btnGenBrowseScript);
            this.grpGeneral.Controls.Add(this.numGenTimeInterval);
            this.grpGeneral.Controls.Add(this.cboClassID);
            this.grpGeneral.Controls.Add(this.lblTimer);
            this.grpGeneral.Controls.Add(this.lblInterval);
            this.grpGeneral.Controls.Add(this.cboGenTimerEnabled);
            this.grpGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGeneral.Location = new System.Drawing.Point(14, 7);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(278, 132);
            this.grpGeneral.TabIndex = 66;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "Task";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.Location = new System.Drawing.Point(9, 16);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(63, 13);
            this.lblClassName.TabIndex = 33;
            this.lblClassName.Text = "Class Name";
            // 
            // lblScript
            // 
            this.lblScript.AutoSize = true;
            this.lblScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScript.Location = new System.Drawing.Point(9, 43);
            this.lblScript.Name = "lblScript";
            this.lblScript.Size = new System.Drawing.Size(53, 13);
            this.lblScript.TabIndex = 34;
            this.lblScript.Text = "Script File";
            // 
            // txtGenScriptFile
            // 
            this.txtGenScriptFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenScriptFile.Location = new System.Drawing.Point(66, 40);
            this.txtGenScriptFile.Name = "txtGenScriptFile";
            this.txtGenScriptFile.Size = new System.Drawing.Size(180, 20);
            this.txtGenScriptFile.TabIndex = 35;
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.Location = new System.Drawing.Point(147, 99);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(61, 13);
            this.lblSeconds.TabIndex = 56;
            this.lblSeconds.Text = "miliseconds";
            // 
            // btnGenBrowseScript
            // 
            this.btnGenBrowseScript.Location = new System.Drawing.Point(249, 40);
            this.btnGenBrowseScript.Name = "btnGenBrowseScript";
            this.btnGenBrowseScript.Size = new System.Drawing.Size(26, 20);
            this.btnGenBrowseScript.TabIndex = 38;
            this.btnGenBrowseScript.Text = "...";
            this.btnGenBrowseScript.UseVisualStyleBackColor = true;
            // 
            // numGenTimeInterval
            // 
            this.numGenTimeInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGenTimeInterval.Location = new System.Drawing.Point(67, 96);
            this.numGenTimeInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numGenTimeInterval.Name = "numGenTimeInterval";
            this.numGenTimeInterval.Size = new System.Drawing.Size(73, 20);
            this.numGenTimeInterval.TabIndex = 55;
            // 
            // cboClassID
            // 
            this.cboClassID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClassID.FormattingEnabled = true;
            this.cboClassID.Location = new System.Drawing.Point(66, 13);
            this.cboClassID.Name = "cboClassID";
            this.cboClassID.Size = new System.Drawing.Size(205, 21);
            this.cboClassID.TabIndex = 39;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(9, 72);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(33, 13);
            this.lblTimer.TabIndex = 40;
            this.lblTimer.Text = "Timer";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterval.Location = new System.Drawing.Point(9, 99);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(42, 13);
            this.lblInterval.TabIndex = 42;
            this.lblInterval.Text = "Interval";
            // 
            // cboGenTimerEnabled
            // 
            this.cboGenTimerEnabled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGenTimerEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGenTimerEnabled.FormattingEnabled = true;
            this.cboGenTimerEnabled.Items.AddRange(new object[] {
            "False",
            "True"});
            this.cboGenTimerEnabled.Location = new System.Drawing.Point(66, 69);
            this.cboGenTimerEnabled.Name = "cboGenTimerEnabled";
            this.cboGenTimerEnabled.Size = new System.Drawing.Size(121, 21);
            this.cboGenTimerEnabled.TabIndex = 41;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.numFilterMaxRun);
            this.grpFilter.Controls.Add(this.lblRepeat);
            this.grpFilter.Controls.Add(this.cboFilterRepeat);
            this.grpFilter.Controls.Add(this.lblMaxRun);
            this.grpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(15, 258);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(276, 87);
            this.grpFilter.TabIndex = 65;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // numFilterMaxRun
            // 
            this.numFilterMaxRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFilterMaxRun.Location = new System.Drawing.Point(69, 52);
            this.numFilterMaxRun.Name = "numFilterMaxRun";
            this.numFilterMaxRun.Size = new System.Drawing.Size(94, 20);
            this.numFilterMaxRun.TabIndex = 54;
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeat.Location = new System.Drawing.Point(11, 27);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(42, 13);
            this.lblRepeat.TabIndex = 51;
            this.lblRepeat.Text = "Repeat";
            // 
            // cboFilterRepeat
            // 
            this.cboFilterRepeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFilterRepeat.FormattingEnabled = true;
            this.cboFilterRepeat.Items.AddRange(new object[] {
            "False",
            "True"});
            this.cboFilterRepeat.Location = new System.Drawing.Point(68, 24);
            this.cboFilterRepeat.Name = "cboFilterRepeat";
            this.cboFilterRepeat.Size = new System.Drawing.Size(121, 21);
            this.cboFilterRepeat.TabIndex = 52;
            // 
            // lblMaxRun
            // 
            this.lblMaxRun.AutoSize = true;
            this.lblMaxRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxRun.Location = new System.Drawing.Point(11, 54);
            this.lblMaxRun.Name = "lblMaxRun";
            this.lblMaxRun.Size = new System.Drawing.Size(50, 13);
            this.lblMaxRun.TabIndex = 53;
            this.lblMaxRun.Text = "Max Run";
            // 
            // grpCondition
            // 
            this.grpCondition.Controls.Add(this.lblFalseTaskTree1);
            this.grpCondition.Controls.Add(this.lblTrueTaskTree1);
            this.grpCondition.Controls.Add(this.cboCondRunTrue);
            this.grpCondition.Controls.Add(this.cboCondRunFalse);
            this.grpCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCondition.Location = new System.Drawing.Point(15, 155);
            this.grpCondition.Name = "grpCondition";
            this.grpCondition.Size = new System.Drawing.Size(276, 87);
            this.grpCondition.TabIndex = 64;
            this.grpCondition.TabStop = false;
            this.grpCondition.Text = "Condition";
            // 
            // lblFalseTaskTree1
            // 
            this.lblFalseTaskTree1.AutoSize = true;
            this.lblFalseTaskTree1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFalseTaskTree1.Location = new System.Drawing.Point(1, 50);
            this.lblFalseTaskTree1.Name = "lblFalseTaskTree1";
            this.lblFalseTaskTree1.Size = new System.Drawing.Size(59, 13);
            this.lblFalseTaskTree1.TabIndex = 45;
            this.lblFalseTaskTree1.Text = "False Task";
            // 
            // lblTrueTaskTree1
            // 
            this.lblTrueTaskTree1.AutoSize = true;
            this.lblTrueTaskTree1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrueTaskTree1.Location = new System.Drawing.Point(1, 23);
            this.lblTrueTaskTree1.Name = "lblTrueTaskTree1";
            this.lblTrueTaskTree1.Size = new System.Drawing.Size(56, 13);
            this.lblTrueTaskTree1.TabIndex = 43;
            this.lblTrueTaskTree1.Text = "True Task";
            // 
            // cboCondRunTrue
            // 
            this.cboCondRunTrue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondRunTrue.FormattingEnabled = true;
            this.cboCondRunTrue.Location = new System.Drawing.Point(58, 20);
            this.cboCondRunTrue.Name = "cboCondRunTrue";
            this.cboCondRunTrue.Size = new System.Drawing.Size(212, 21);
            this.cboCondRunTrue.TabIndex = 44;
            // 
            // cboCondRunFalse
            // 
            this.cboCondRunFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondRunFalse.FormattingEnabled = true;
            this.cboCondRunFalse.Location = new System.Drawing.Point(58, 47);
            this.cboCondRunFalse.Name = "cboCondRunFalse";
            this.cboCondRunFalse.Size = new System.Drawing.Size(212, 21);
            this.cboCondRunFalse.TabIndex = 46;
            // 
            // DiPropertyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpCondition);
            this.Name = "DiPropertyControl";
            this.Size = new System.Drawing.Size(306, 352);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenTimeInterval)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFilterMaxRun)).EndInit();
            this.grpCondition.ResumeLayout(false);
            this.grpCondition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblScript;
        private System.Windows.Forms.TextBox txtGenScriptFile;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Button btnGenBrowseScript;
        private System.Windows.Forms.NumericUpDown numGenTimeInterval;
        private System.Windows.Forms.ComboBox cboClassID;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.ComboBox cboGenTimerEnabled;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.NumericUpDown numFilterMaxRun;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.ComboBox cboFilterRepeat;
        private System.Windows.Forms.Label lblMaxRun;
        private System.Windows.Forms.GroupBox grpCondition;
        private System.Windows.Forms.Label lblFalseTaskTree1;
        private System.Windows.Forms.Label lblTrueTaskTree1;
        private System.Windows.Forms.ComboBox cboCondRunTrue;
        private System.Windows.Forms.ComboBox cboCondRunFalse;
    }
}
