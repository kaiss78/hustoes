﻿namespace OES.UControl
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
            this.comboClass = new System.Windows.Forms.ComboBox();
            this.groupAddOne = new System.Windows.Forms.GroupBox();
            this.groupAddMany = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textPW = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.textPW2 = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.btnAddOne = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupAddOne.SuspendLayout();
            this.groupAddMany.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择需要添加学生的班级：";
            // 
            // radioAddOne
            // 
            this.radioAddOne.AutoSize = true;
            this.radioAddOne.Location = new System.Drawing.Point(51, 72);
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
            this.radioAddMany.Location = new System.Drawing.Point(51, 253);
            this.radioAddMany.Name = "radioAddMany";
            this.radioAddMany.Size = new System.Drawing.Size(122, 20);
            this.radioAddMany.TabIndex = 2;
            this.radioAddMany.TabStop = true;
            this.radioAddMany.Text = "批量导入学生";
            this.radioAddMany.UseVisualStyleBackColor = true;
            // 
            // comboClass
            // 
            this.comboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClass.FormattingEnabled = true;
            this.comboClass.Location = new System.Drawing.Point(268, 18);
            this.comboClass.Name = "comboClass";
            this.comboClass.Size = new System.Drawing.Size(277, 24);
            this.comboClass.TabIndex = 3;
            // 
            // groupAddOne
            // 
            this.groupAddOne.Controls.Add(this.btnAddOne);
            this.groupAddOne.Controls.Add(this.textID);
            this.groupAddOne.Controls.Add(this.textPW2);
            this.groupAddOne.Controls.Add(this.textName);
            this.groupAddOne.Controls.Add(this.textPW);
            this.groupAddOne.Controls.Add(this.label6);
            this.groupAddOne.Controls.Add(this.label5);
            this.groupAddOne.Controls.Add(this.label4);
            this.groupAddOne.Controls.Add(this.label3);
            this.groupAddOne.Controls.Add(this.label2);
            this.groupAddOne.Location = new System.Drawing.Point(62, 98);
            this.groupAddOne.Name = "groupAddOne";
            this.groupAddOne.Size = new System.Drawing.Size(557, 136);
            this.groupAddOne.TabIndex = 4;
            this.groupAddOne.TabStop = false;
            this.groupAddOne.Text = "学生信息";
            // 
            // groupAddMany
            // 
            this.groupAddMany.Controls.Add(this.button1);
            this.groupAddMany.Controls.Add(this.textBox1);
            this.groupAddMany.Controls.Add(this.label7);
            this.groupAddMany.Location = new System.Drawing.Point(62, 279);
            this.groupAddMany.Name = "groupAddMany";
            this.groupAddMany.Size = new System.Drawing.Size(557, 149);
            this.groupAddMany.TabIndex = 5;
            this.groupAddMany.TabStop = false;
            this.groupAddMany.Text = "导入文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "学生姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "学号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "新密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(280, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "（若不填密码，则新密码为该生学号）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "再输入一次：";
            // 
            // textPW
            // 
            this.textPW.Location = new System.Drawing.Point(117, 59);
            this.textPW.Name = "textPW";
            this.textPW.PasswordChar = '*';
            this.textPW.Size = new System.Drawing.Size(133, 26);
            this.textPW.TabIndex = 5;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(117, 18);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(133, 26);
            this.textName.TabIndex = 6;
            // 
            // textPW2
            // 
            this.textPW2.Location = new System.Drawing.Point(117, 99);
            this.textPW2.Name = "textPW2";
            this.textPW2.PasswordChar = '*';
            this.textPW2.Size = new System.Drawing.Size(133, 26);
            this.textPW2.TabIndex = 7;
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(339, 18);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(190, 26);
            this.textID.TabIndex = 8;
            // 
            // btnAddOne
            // 
            this.btnAddOne.Location = new System.Drawing.Point(394, 92);
            this.btnAddOne.Name = "btnAddOne";
            this.btnAddOne.Size = new System.Drawing.Size(100, 34);
            this.btnAddOne.TabIndex = 9;
            this.btnAddOne.Text = "添加学生";
            this.btnAddOne.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "要导入的文件：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(133, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(292, 26);
            this.textBox1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // StudentAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupAddMany);
            this.Controls.Add(this.groupAddOne);
            this.Controls.Add(this.comboClass);
            this.Controls.Add(this.radioAddMany);
            this.Controls.Add(this.radioAddOne);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StudentAdd";
            this.Size = new System.Drawing.Size(710, 510);
            this.groupAddOne.ResumeLayout(false);
            this.groupAddOne.PerformLayout();
            this.groupAddMany.ResumeLayout(false);
            this.groupAddMany.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioAddOne;
        private System.Windows.Forms.RadioButton radioAddMany;
        private System.Windows.Forms.ComboBox comboClass;
        private System.Windows.Forms.GroupBox groupAddOne;
        private System.Windows.Forms.GroupBox groupAddMany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.TextBox textPW2;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textPW;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAddOne;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}
