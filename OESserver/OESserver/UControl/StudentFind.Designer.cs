namespace OES.UControl
{
    partial class StudentFind
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
            this.labelInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioByDept = new System.Windows.Forms.RadioButton();
            this.radioByClass = new System.Windows.Forms.RadioButton();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.textKey = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(75, 285);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(152, 16);
            this.labelInfo.TabIndex = 12;
            this.labelInfo.Text = "请输入查找关键字：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioByDept);
            this.groupBox1.Controls.Add(this.radioByClass);
            this.groupBox1.Location = new System.Drawing.Point(75, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 162);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询方式";
            // 
            // radioByDept
            // 
            this.radioByDept.AutoSize = true;
            this.radioByDept.Location = new System.Drawing.Point(13, 50);
            this.radioByDept.Name = "radioByDept";
            this.radioByDept.Size = new System.Drawing.Size(106, 20);
            this.radioByDept.TabIndex = 0;
            this.radioByDept.TabStop = true;
            this.radioByDept.Text = "按学院查询";
            this.radioByDept.UseVisualStyleBackColor = true;
            // 
            // radioByClass
            // 
            this.radioByClass.AutoSize = true;
            this.radioByClass.Location = new System.Drawing.Point(13, 110);
            this.radioByClass.Name = "radioByClass";
            this.radioByClass.Size = new System.Drawing.Size(106, 20);
            this.radioByClass.TabIndex = 1;
            this.radioByClass.TabStop = true;
            this.radioByClass.Text = "按班级查询";
            this.radioByClass.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(346, 359);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(102, 35);
            this.btnReturn.TabIndex = 10;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(125, 359);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(102, 35);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // textKey
            // 
            this.textKey.Location = new System.Drawing.Point(233, 280);
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(303, 26);
            this.textKey.TabIndex = 8;
            // 
            // StudentFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.textKey);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StudentFind";
            this.Size = new System.Drawing.Size(742, 666);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioByDept;
        private System.Windows.Forms.RadioButton radioByClass;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox textKey;

    }
}
