namespace OES.OfficeFrm
{
    partial class WordFrm
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
            this.testWord1 = new OESOffice.testWord();
            this.btnComplete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testWord1
            // 
            this.testWord1.Location = new System.Drawing.Point(13, 13);
            this.testWord1.Name = "testWord1";
            this.testWord1.Size = new System.Drawing.Size(567, 468);
            this.testWord1.TabIndex = 0;
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplete.Location = new System.Drawing.Point(440, 432);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(126, 34);
            this.btnComplete.TabIndex = 2;
            this.btnComplete.Text = "完成添加并返回";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // WordFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 480);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.testWord1);
            this.MaximizeBox = false;
            this.Name = "WordFrm";
            this.Text = "添加考点";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WordFrm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private OESOffice.testWord testWord1;
        private System.Windows.Forms.Button btnComplete;

    }
}