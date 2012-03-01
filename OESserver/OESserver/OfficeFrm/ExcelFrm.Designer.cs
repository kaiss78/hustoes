namespace OES.OfficeFrm
{
    partial class ExcelFrm
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
            this.testExcel1 = new OESOffice.testExcel();
            this.btnComplete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testExcel1
            // 
            this.testExcel1.Location = new System.Drawing.Point(12, 12);
            this.testExcel1.Name = "testExcel1";
            this.testExcel1.Size = new System.Drawing.Size(364, 470);
            this.testExcel1.TabIndex = 0;
            // 
            // btnComplete
            // 
            this.btnComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComplete.Location = new System.Drawing.Point(235, 476);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(126, 34);
            this.btnComplete.TabIndex = 2;
            this.btnComplete.Text = "完成添加并返回";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // ExcelFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 522);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.testExcel1);
            this.MaximizeBox = false;
            this.Name = "ExcelFrm";
            this.Text = "ExcelFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExcelFrm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private OESOffice.testExcel testExcel1;
        private System.Windows.Forms.Button btnComplete;

    }
}