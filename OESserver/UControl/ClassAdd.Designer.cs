namespace OES.UControl
{
    partial class ClassAdd
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.groupAddMany = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddMany = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.textFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupAddOne = new System.Windows.Forms.GroupBox();
            this.comboTeacher = new System.Windows.Forms.ComboBox();
            this.textClass = new System.Windows.Forms.TextBox();
            this.textDept = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddOne = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.radioAddMany = new System.Windows.Forms.RadioButton();
            this.radioAddOne = new System.Windows.Forms.RadioButton();
            this.groupAddMany.SuspendLayout();
            this.groupAddOne.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(513, 438);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(87, 32);
            this.btnReturn.TabIndex = 15;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // groupAddMany
            // 
            this.groupAddMany.Controls.Add(this.label2);
            this.groupAddMany.Controls.Add(this.btnAddMany);
            this.groupAddMany.Controls.Add(this.btnBrowse);
            this.groupAddMany.Controls.Add(this.textFile);
            this.groupAddMany.Controls.Add(this.label7);
            this.groupAddMany.Location = new System.Drawing.Point(62, 267);
            this.groupAddMany.Name = "groupAddMany";
            this.groupAddMany.Size = new System.Drawing.Size(557, 150);
            this.groupAddMany.TabIndex = 14;
            this.groupAddMany.TabStop = false;
            this.groupAddMany.Text = "导入文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "注意：班级信息包括学院名、班级名以及教工号信息";
            // 
            // btnAddMany
            // 
            this.btnAddMany.Location = new System.Drawing.Point(427, 98);
            this.btnAddMany.Name = "btnAddMany";
            this.btnAddMany.Size = new System.Drawing.Size(88, 32);
            this.btnAddMany.TabIndex = 7;
            this.btnAddMany.Text = "导入";
            this.btnAddMany.UseVisualStyleBackColor = true;
            this.btnAddMany.Click += new System.EventHandler(this.btnAddMany_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(463, 39);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 28);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // textFile
            // 
            this.textFile.Location = new System.Drawing.Point(201, 39);
            this.textFile.Name = "textFile";
            this.textFile.Size = new System.Drawing.Size(256, 26);
            this.textFile.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "要导入的班级信息文件：";
            // 
            // groupAddOne
            // 
            this.groupAddOne.Controls.Add(this.comboTeacher);
            this.groupAddOne.Controls.Add(this.textClass);
            this.groupAddOne.Controls.Add(this.textDept);
            this.groupAddOne.Controls.Add(this.label8);
            this.groupAddOne.Controls.Add(this.label1);
            this.groupAddOne.Controls.Add(this.btnAddOne);
            this.groupAddOne.Controls.Add(this.label6);
            this.groupAddOne.Location = new System.Drawing.Point(62, 54);
            this.groupAddOne.Name = "groupAddOne";
            this.groupAddOne.Size = new System.Drawing.Size(557, 151);
            this.groupAddOne.TabIndex = 13;
            this.groupAddOne.TabStop = false;
            this.groupAddOne.Text = "班级信息";
            // 
            // comboTeacher
            // 
            this.comboTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTeacher.FormattingEnabled = true;
            this.comboTeacher.Location = new System.Drawing.Point(118, 94);
            this.comboTeacher.Name = "comboTeacher";
            this.comboTeacher.Size = new System.Drawing.Size(237, 24);
            this.comboTeacher.TabIndex = 22;
            // 
            // textClass
            // 
            this.textClass.Location = new System.Drawing.Point(348, 36);
            this.textClass.Name = "textClass";
            this.textClass.Size = new System.Drawing.Size(190, 26);
            this.textClass.TabIndex = 2;
            // 
            // textDept
            // 
            this.textDept.Location = new System.Drawing.Point(118, 36);
            this.textDept.Name = "textDept";
            this.textDept.Size = new System.Drawing.Size(141, 26);
            this.textDept.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "班级名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "学院名称：";
            // 
            // btnAddOne
            // 
            this.btnAddOne.Location = new System.Drawing.Point(414, 92);
            this.btnAddOne.Name = "btnAddOne";
            this.btnAddOne.Size = new System.Drawing.Size(94, 33);
            this.btnAddOne.TabIndex = 4;
            this.btnAddOne.Text = "添加班级";
            this.btnAddOne.UseVisualStyleBackColor = true;
            this.btnAddOne.Click += new System.EventHandler(this.btnAddOne_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "教师信息：";
            // 
            // radioAddMany
            // 
            this.radioAddMany.AutoSize = true;
            this.radioAddMany.Location = new System.Drawing.Point(51, 241);
            this.radioAddMany.Name = "radioAddMany";
            this.radioAddMany.Size = new System.Drawing.Size(122, 20);
            this.radioAddMany.TabIndex = 12;
            this.radioAddMany.TabStop = true;
            this.radioAddMany.Text = "批量导入班级";
            this.radioAddMany.UseVisualStyleBackColor = true;
            this.radioAddMany.CheckedChanged += new System.EventHandler(this.radioAddMany_CheckedChanged);
            // 
            // radioAddOne
            // 
            this.radioAddOne.AutoSize = true;
            this.radioAddOne.Location = new System.Drawing.Point(51, 28);
            this.radioAddOne.Name = "radioAddOne";
            this.radioAddOne.Size = new System.Drawing.Size(122, 20);
            this.radioAddOne.TabIndex = 0;
            this.radioAddOne.TabStop = true;
            this.radioAddOne.Text = "添加单个班级";
            this.radioAddOne.UseVisualStyleBackColor = true;
            this.radioAddOne.CheckedChanged += new System.EventHandler(this.radioAddOne_CheckedChanged);
            // 
            // ClassAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.groupAddMany);
            this.Controls.Add(this.groupAddOne);
            this.Controls.Add(this.radioAddMany);
            this.Controls.Add(this.radioAddOne);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClassAdd";
            this.Size = new System.Drawing.Size(710, 510);
            this.groupAddMany.ResumeLayout(false);
            this.groupAddMany.PerformLayout();
            this.groupAddOne.ResumeLayout(false);
            this.groupAddOne.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.GroupBox groupAddMany;
        private System.Windows.Forms.Button btnAddMany;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox textFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupAddOne;
        private System.Windows.Forms.Button btnAddOne;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioAddMany;
        private System.Windows.Forms.RadioButton radioAddOne;
        private System.Windows.Forms.TextBox textClass;
        private System.Windows.Forms.TextBox textDept;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTeacher;
    }
}
