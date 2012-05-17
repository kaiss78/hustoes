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
            this.textKey = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioByTeacherName = new System.Windows.Forms.RadioButton();
            this.labelInfo = new System.Windows.Forms.Label();
            this.comboTeacher = new System.Windows.Forms.ComboBox();
            this.btnFind = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnReturn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioByDept
            // 
            this.radioByDept.AutoSize = true;
            this.radioByDept.Location = new System.Drawing.Point(11, 34);
            this.radioByDept.Name = "radioByDept";
            this.radioByDept.Size = new System.Drawing.Size(138, 20);
            this.radioByDept.TabIndex = 0;
            this.radioByDept.TabStop = true;
            this.radioByDept.Text = "按学院名称查询";
            this.radioByDept.UseVisualStyleBackColor = true;
            this.radioByDept.CheckedChanged += new System.EventHandler(this.radioByDept_CheckedChanged);
            // 
            // radioByClass
            // 
            this.radioByClass.AutoSize = true;
            this.radioByClass.Location = new System.Drawing.Point(11, 79);
            this.radioByClass.Name = "radioByClass";
            this.radioByClass.Size = new System.Drawing.Size(138, 20);
            this.radioByClass.TabIndex = 1;
            this.radioByClass.TabStop = true;
            this.radioByClass.Text = "按专业班级查询";
            this.radioByClass.UseVisualStyleBackColor = true;
            this.radioByClass.CheckedChanged += new System.EventHandler(this.radioByClass_CheckedChanged);
            // 
            // textKey
            // 
            this.textKey.Location = new System.Drawing.Point(128, 340);
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(351, 26);
            this.textKey.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioByTeacherName);
            this.groupBox1.Controls.Add(this.radioByDept);
            this.groupBox1.Controls.Add(this.radioByClass);
            this.groupBox1.Location = new System.Drawing.Point(69, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 162);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询方式";
            // 
            // radioByTeacherName
            // 
            this.radioByTeacherName.AutoSize = true;
            this.radioByTeacherName.Location = new System.Drawing.Point(11, 123);
            this.radioByTeacherName.Name = "radioByTeacherName";
            this.radioByTeacherName.Size = new System.Drawing.Size(138, 20);
            this.radioByTeacherName.TabIndex = 2;
            this.radioByTeacherName.TabStop = true;
            this.radioByTeacherName.Text = "按教师姓名查询";
            this.radioByTeacherName.UseVisualStyleBackColor = true;
            this.radioByTeacherName.CheckedChanged += new System.EventHandler(this.radioByTeacherName_CheckedChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(125, 297);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(152, 16);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "请输入查找关键字：";
            // 
            // comboTeacher
            // 
            this.comboTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTeacher.FormattingEnabled = true;
            this.comboTeacher.Location = new System.Drawing.Point(128, 340);
            this.comboTeacher.Name = "comboTeacher";
            this.comboTeacher.Size = new System.Drawing.Size(351, 24);
            this.comboTeacher.TabIndex = 8;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(128, 440);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(101, 35);
            this.btnFind.TabIndex = 9;
            this.btnFind.Values.Text = "查找";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(348, 441);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(102, 34);
            this.btnReturn.TabIndex = 10;
            this.btnReturn.Values.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // ClassFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.comboTeacher);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textKey);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClassFind";
            this.Size = new System.Drawing.Size(742, 666);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioByDept;
        private System.Windows.Forms.RadioButton radioByClass;
        private System.Windows.Forms.TextBox textKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.RadioButton radioByTeacherName;
        private System.Windows.Forms.ComboBox comboTeacher;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFind;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReturn;

    }
}
