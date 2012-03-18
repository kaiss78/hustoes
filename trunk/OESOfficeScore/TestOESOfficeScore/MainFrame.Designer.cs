namespace TestOESOfficeScore
{
    partial class MainFrame
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnWord = new System.Windows.Forms.Button();
            this.btnXls = new System.Windows.Forms.Button();
            this.btnPPT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWord
            // 
            this.btnWord.Location = new System.Drawing.Point(13, 12);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(105, 40);
            this.btnWord.TabIndex = 0;
            this.btnWord.Text = "Word评分";
            this.btnWord.UseVisualStyleBackColor = true;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // btnXls
            // 
            this.btnXls.Location = new System.Drawing.Point(124, 12);
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(105, 40);
            this.btnXls.TabIndex = 1;
            this.btnXls.Text = "Excel评分";
            this.btnXls.UseVisualStyleBackColor = true;
            this.btnXls.Click += new System.EventHandler(this.btnXls_Click);
            // 
            // btnPPT
            // 
            this.btnPPT.Location = new System.Drawing.Point(235, 12);
            this.btnPPT.Name = "btnPPT";
            this.btnPPT.Size = new System.Drawing.Size(105, 40);
            this.btnPPT.TabIndex = 2;
            this.btnPPT.Text = "PPT评分";
            this.btnPPT.UseVisualStyleBackColor = true;
            this.btnPPT.Click += new System.EventHandler(this.btnPPT_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 66);
            this.Controls.Add(this.btnPPT);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnWord);
            this.Name = "MainFrame";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.Button btnXls;
        private System.Windows.Forms.Button btnPPT;
    }
}

