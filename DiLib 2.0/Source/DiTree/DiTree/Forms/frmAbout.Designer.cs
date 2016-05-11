namespace DiTree
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.okButton = new System.Windows.Forms.Button();
            this.lblReference = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.linkSite = new System.Windows.Forms.LinkLabel();
            this.linkIconReference = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.linkPrintTree = new System.Windows.Forms.LinkLabel();
            this.linkIconRef2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(348, 255);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 30;
            this.okButton.Text = "&OK";
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.Location = new System.Drawing.Point(12, 246);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(65, 13);
            this.lblReference.TabIndex = 31;
            this.lblReference.Text = "References:";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(12, 195);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(51, 13);
            this.labelCopyright.TabIndex = 34;
            this.labelCopyright.Text = "Copyright";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 149);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 35;
            this.labelDescription.Text = "Description";
            // 
            // linkSite
            // 
            this.linkSite.AutoSize = true;
            this.linkSite.Location = new System.Drawing.Point(171, 217);
            this.linkSite.Name = "linkSite";
            this.linkSite.Size = new System.Drawing.Size(82, 13);
            this.linkSite.TabIndex = 37;
            this.linkSite.TabStop = true;
            this.linkSite.Text = "dilib.dimutu.com";
            this.linkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSite_LinkClicked);
            // 
            // linkIconReference
            // 
            this.linkIconReference.AutoSize = true;
            this.linkIconReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkIconReference.Location = new System.Drawing.Point(83, 246);
            this.linkIconReference.Name = "linkIconReference";
            this.linkIconReference.Size = new System.Drawing.Size(80, 13);
            this.linkIconReference.TabIndex = 38;
            this.linkIconReference.TabStop = true;
            this.linkIconReference.Text = "gentleface.com";
            this.linkIconReference.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIconReference_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(411, 121);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(12, 172);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 41;
            this.lblVersion.Text = "Version";
            // 
            // linkPrintTree
            // 
            this.linkPrintTree.AutoSize = true;
            this.linkPrintTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkPrintTree.Location = new System.Drawing.Point(83, 264);
            this.linkPrintTree.Name = "linkPrintTree";
            this.linkPrintTree.Size = new System.Drawing.Size(77, 13);
            this.linkPrintTree.TabIndex = 42;
            this.linkPrintTree.TabStop = true;
            this.linkPrintTree.Text = "Pitman.Printing";
            this.linkPrintTree.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPrintTree_LinkClicked);
            // 
            // linkIconRef2
            // 
            this.linkIconRef2.AutoSize = true;
            this.linkIconRef2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkIconRef2.Location = new System.Drawing.Point(173, 246);
            this.linkIconRef2.Name = "linkIconRef2";
            this.linkIconRef2.Size = new System.Drawing.Size(89, 13);
            this.linkIconRef2.TabIndex = 43;
            this.linkIconRef2.TabStop = true;
            this.linkIconRef2.Text = "www.fatcow.com";
            this.linkIconRef2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIconRef2_LinkClicked);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 287);
            this.Controls.Add(this.linkIconRef2);
            this.Controls.Add(this.linkPrintTree);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkIconReference);
            this.Controls.Add(this.linkSite);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAbout";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.LinkLabel linkSite;
        private System.Windows.Forms.LinkLabel linkIconReference;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.LinkLabel linkPrintTree;
        private System.Windows.Forms.LinkLabel linkIconRef2;

    }
}
