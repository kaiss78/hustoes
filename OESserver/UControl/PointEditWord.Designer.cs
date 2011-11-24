namespace OES.UControl
{
    partial class PointEditWord
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
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.testWord1 = new testWordApp.testWord();
            this.SuspendLayout();
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(447, 517);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(119, 31);
            this.btnComplete.TabIndex = 5;
            this.btnComplete.Text = "完成添加";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(309, 517);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "放弃添加";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // testWord1
            // 
            this.testWord1.Location = new System.Drawing.Point(14, 12);
            this.testWord1.Name = "testWord1";
            this.testWord1.Size = new System.Drawing.Size(558, 462);
            this.testWord1.TabIndex = 0;
            // 
            // PointEditWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.testWord1);
            this.Name = "PointEditWord";
            this.Size = new System.Drawing.Size(593, 666);
            this.ResumeLayout(false);

        }

        #endregion

        private testWordApp.testWord testWord1;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnCancel;
    }
}
