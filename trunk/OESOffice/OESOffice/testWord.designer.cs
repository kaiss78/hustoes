namespace OESOffice
{
    partial class testWord
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.testWordView = new System.Windows.Forms.TreeView();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnRet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(293, 420);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(123, 34);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "添加考点";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // testWordView
            // 
            this.testWordView.Location = new System.Drawing.Point(6, 6);
            this.testWordView.Name = "testWordView";
            this.testWordView.Size = new System.Drawing.Size(281, 448);
            this.testWordView.TabIndex = 9;
            this.testWordView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.testWordView_AfterSelect);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(293, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(259, 404);
            this.checkedListBox1.TabIndex = 8;
            // 
            // btnRet
            // 
            this.btnRet.Location = new System.Drawing.Point(429, 420);
            this.btnRet.Name = "btnRet";
            this.btnRet.Size = new System.Drawing.Size(123, 34);
            this.btnRet.TabIndex = 12;
            this.btnRet.Text = "返回";
            this.btnRet.UseVisualStyleBackColor = true;
            this.btnRet.Click += new System.EventHandler(this.btnRet_Click);
            // 
            // testWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRet);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.testWordView);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "testWord";
            this.Size = new System.Drawing.Size(558, 462);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TreeView testWordView;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnRet;
    }
}
