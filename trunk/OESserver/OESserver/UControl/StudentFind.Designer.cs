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
            this.radioByTeacher = new System.Windows.Forms.RadioButton();
            this.radioByID = new System.Windows.Forms.RadioButton();
            this.radioByName = new System.Windows.Forms.RadioButton();
            this.radioByClass = new System.Windows.Forms.RadioButton();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.textKey = new System.Windows.Forms.TextBox();
            this.comboTeacher = new System.Windows.Forms.ComboBox();
            this.comboDept = new System.Windows.Forms.ComboBox();
            this.comboClass = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(79, 283);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(152, 16);
            this.labelInfo.TabIndex = 12;
            this.labelInfo.Text = "请输入查找关键字：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioByTeacher);
            this.groupBox1.Controls.Add(this.radioByID);
            this.groupBox1.Controls.Add(this.radioByName);
            this.groupBox1.Controls.Add(this.radioByClass);
            this.groupBox1.Location = new System.Drawing.Point(69, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 190);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询方式";
            // 
            // radioByTeacher
            // 
            this.radioByTeacher.AutoSize = true;
            this.radioByTeacher.Location = new System.Drawing.Point(13, 66);
            this.radioByTeacher.Name = "radioByTeacher";
            this.radioByTeacher.Size = new System.Drawing.Size(138, 20);
            this.radioByTeacher.TabIndex = 3;
            this.radioByTeacher.TabStop = true;
            this.radioByTeacher.Text = "按教师信息查询";
            this.radioByTeacher.UseVisualStyleBackColor = true;
            this.radioByTeacher.CheckedChanged += new System.EventHandler(this.radioByTeacher_CheckedChanged);
            // 
            // radioByID
            // 
            this.radioByID.AutoSize = true;
            this.radioByID.Location = new System.Drawing.Point(13, 107);
            this.radioByID.Name = "radioByID";
            this.radioByID.Size = new System.Drawing.Size(138, 20);
            this.radioByID.TabIndex = 2;
            this.radioByID.TabStop = true;
            this.radioByID.Text = "按学生学号查询";
            this.radioByID.UseVisualStyleBackColor = true;
            this.radioByID.CheckedChanged += new System.EventHandler(this.radioByID_CheckedChanged);
            // 
            // radioByName
            // 
            this.radioByName.AutoSize = true;
            this.radioByName.Location = new System.Drawing.Point(13, 148);
            this.radioByName.Name = "radioByName";
            this.radioByName.Size = new System.Drawing.Size(138, 20);
            this.radioByName.TabIndex = 0;
            this.radioByName.TabStop = true;
            this.radioByName.Text = "按学生姓名查询";
            this.radioByName.UseVisualStyleBackColor = true;
            this.radioByName.CheckedChanged += new System.EventHandler(this.radioByName_CheckedChanged);
            // 
            // radioByClass
            // 
            this.radioByClass.AutoSize = true;
            this.radioByClass.Location = new System.Drawing.Point(13, 25);
            this.radioByClass.Name = "radioByClass";
            this.radioByClass.Size = new System.Drawing.Size(138, 20);
            this.radioByClass.TabIndex = 1;
            this.radioByClass.TabStop = true;
            this.radioByClass.Text = "按学院班级查询";
            this.radioByClass.UseVisualStyleBackColor = true;
            this.radioByClass.CheckedChanged += new System.EventHandler(this.radioByClass_CheckedChanged);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(349, 400);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(102, 35);
            this.btnReturn.TabIndex = 10;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(128, 400);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(102, 35);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // textKey
            // 
            this.textKey.Location = new System.Drawing.Point(128, 330);
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(323, 26);
            this.textKey.TabIndex = 8;
            // 
            // comboTeacher
            // 
            this.comboTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTeacher.FormattingEnabled = true;
            this.comboTeacher.Location = new System.Drawing.Point(128, 330);
            this.comboTeacher.Name = "comboTeacher";
            this.comboTeacher.Size = new System.Drawing.Size(323, 24);
            this.comboTeacher.TabIndex = 13;
            // 
            // comboDept
            // 
            this.comboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDept.FormattingEnabled = true;
            this.comboDept.Location = new System.Drawing.Point(128, 330);
            this.comboDept.Name = "comboDept";
            this.comboDept.Size = new System.Drawing.Size(157, 24);
            this.comboDept.TabIndex = 14;
            this.comboDept.SelectedIndexChanged += new System.EventHandler(this.comboDept_SelectedIndexChanged);
            // 
            // comboClass
            // 
            this.comboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClass.FormattingEnabled = true;
            this.comboClass.Location = new System.Drawing.Point(294, 330);
            this.comboClass.Name = "comboClass";
            this.comboClass.Size = new System.Drawing.Size(157, 24);
            this.comboClass.TabIndex = 15;
            // 
            // StudentFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboClass);
            this.Controls.Add(this.comboDept);
            this.Controls.Add(this.comboTeacher);
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
        private System.Windows.Forms.RadioButton radioByName;
        private System.Windows.Forms.RadioButton radioByClass;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox textKey;
        private System.Windows.Forms.RadioButton radioByTeacher;
        private System.Windows.Forms.RadioButton radioByID;
        private System.Windows.Forms.ComboBox comboTeacher;
        private System.Windows.Forms.ComboBox comboDept;
        private System.Windows.Forms.ComboBox comboClass;

    }
}
