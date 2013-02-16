namespace DiTree
{
    partial class frmDiConfigFile
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
            this.rtxtConfig = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxtConfig
            // 
            this.rtxtConfig.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtConfig.Location = new System.Drawing.Point(0, 0);
            this.rtxtConfig.Name = "rtxtConfig";
            this.rtxtConfig.ReadOnly = true;
            this.rtxtConfig.Size = new System.Drawing.Size(615, 406);
            this.rtxtConfig.TabIndex = 0;
            this.rtxtConfig.Text = "";
            // 
            // frmDiConfigFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 406);
            this.Controls.Add(this.rtxtConfig);
            this.Name = "frmDiConfigFile";
            this.Text = "DiConfig";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtConfig;
    }
}