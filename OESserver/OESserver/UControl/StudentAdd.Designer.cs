namespace OES.UControl
{
    partial class StudentAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioAddOne = new System.Windows.Forms.RadioButton();
            this.radioAddMany = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择需要添加学生的班级：";
            // 
            // radioAddOne
            // 
            this.radioAddOne.AutoSize = true;
            this.radioAddOne.Location = new System.Drawing.Point(200, 288);
            this.radioAddOne.Name = "radioAddOne";
            this.radioAddOne.Size = new System.Drawing.Size(122, 20);
            this.radioAddOne.TabIndex = 1;
            this.radioAddOne.TabStop = true;
            this.radioAddOne.Text = "添加单个学生";
            this.radioAddOne.UseVisualStyleBackColor = true;
            // 
            // radioAddMany
            // 
            this.radioAddMany.AutoSize = true;
            this.radioAddMany.Location = new System.Drawing.Point(286, 346);
            this.radioAddMany.Name = "radioAddMany";
            this.radioAddMany.Size = new System.Drawing.Size(122, 20);
            this.radioAddMany.TabIndex = 2;
            this.radioAddMany.TabStop = true;
            this.radioAddMany.Text = "批量导入学生";
            this.radioAddMany.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(422, 98);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // StudentAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.radioAddMany);
            this.Controls.Add(this.radioAddOne);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StudentAdd";
            this.Size = new System.Drawing.Size(710, 510);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioAddOne;
        private System.Windows.Forms.RadioButton radioAddMany;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
