namespace OES.UControl
{
    partial class ClassFind
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
            this.radioByDept = new System.Windows.Forms.RadioButton();
            this.radioByClass = new System.Windows.Forms.RadioButton();
            this.textDept = new System.Windows.Forms.TextBox();
            this.textClass = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioByDept
            // 
            this.radioByDept.AutoSize = true;
            this.radioByDept.Location = new System.Drawing.Point(140, 167);
            this.radioByDept.Name = "radioByDept";
            this.radioByDept.Size = new System.Drawing.Size(106, 20);
            this.radioByDept.TabIndex = 0;
            this.radioByDept.TabStop = true;
            this.radioByDept.Text = "按学院查询";
            this.radioByDept.UseVisualStyleBackColor = true;
            this.radioByDept.CheckedChanged += new System.EventHandler(this.radioByDept_CheckedChanged);
            // 
            // radioByClass
            // 
            this.radioByClass.AutoSize = true;
            this.radioByClass.Location = new System.Drawing.Point(140, 223);
            this.radioByClass.Name = "radioByClass";
            this.radioByClass.Size = new System.Drawing.Size(106, 20);
            this.radioByClass.TabIndex = 1;
            this.radioByClass.TabStop = true;
            this.radioByClass.Text = "按班级查询";
            this.radioByClass.UseVisualStyleBackColor = true;
            this.radioByClass.CheckedChanged += new System.EventHandler(this.radioByClass_CheckedChanged);
            // 
            // textDept
            // 
            this.textDept.Location = new System.Drawing.Point(259, 163);
            this.textDept.Name = "textDept";
            this.textDept.Size = new System.Drawing.Size(218, 26);
            this.textDept.TabIndex = 2;
            // 
            // textClass
            // 
            this.textClass.Location = new System.Drawing.Point(259, 219);
            this.textClass.Name = "textClass";
            this.textClass.Size = new System.Drawing.Size(218, 26);
            this.textClass.TabIndex = 3;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(155, 285);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(102, 35);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(329, 285);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(102, 35);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // ClassFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.textClass);
            this.Controls.Add(this.textDept);
            this.Controls.Add(this.radioByClass);
            this.Controls.Add(this.radioByDept);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ClassFind";
            this.Size = new System.Drawing.Size(742, 666);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioByDept;
        private System.Windows.Forms.RadioButton radioByClass;
        private System.Windows.Forms.TextBox textDept;
        private System.Windows.Forms.TextBox textClass;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnReturn;

    }
}
