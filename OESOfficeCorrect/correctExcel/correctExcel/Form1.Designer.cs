namespace correctExcel
{
    partial class Form1
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
            this.textOrigin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textAns = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textPoint = new System.Windows.Forms.TextBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textOrigin
            // 
            this.textOrigin.Location = new System.Drawing.Point(7, 39);
            this.textOrigin.Name = "textOrigin";
            this.textOrigin.ReadOnly = true;
            this.textOrigin.Size = new System.Drawing.Size(272, 21);
            this.textOrigin.TabIndex = 0;
            this.textOrigin.Text = "D:\\Test\\StuTest.xls";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(285, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "浏览...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(285, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "浏览...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textAns
            // 
            this.textAns.Location = new System.Drawing.Point(7, 96);
            this.textAns.Name = "textAns";
            this.textAns.ReadOnly = true;
            this.textAns.Size = new System.Drawing.Size(272, 21);
            this.textAns.TabIndex = 2;
            this.textAns.Text = "D:\\Test\\Test.xls";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(285, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "浏览...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textPoint
            // 
            this.textPoint.Location = new System.Drawing.Point(7, 150);
            this.textPoint.Name = "textPoint";
            this.textPoint.ReadOnly = true;
            this.textPoint.Size = new System.Drawing.Size(272, 21);
            this.textPoint.TabIndex = 4;
            this.textPoint.Text = "F:\\Excel\\testExcel\\testExcel\\bin\\Debug\\test.xml";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(123, 215);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(118, 38);
            this.buttonCheck.TabIndex = 6;
            this.buttonCheck.Text = "开始评分";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "请选择考生文档：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "请选择标准答案文档：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "请选择考点信息：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 293);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textPoint);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textAns);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textOrigin);
            this.Name = "Form1";
            this.Text = "Excel评分";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textOrigin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textAns;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textPoint;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

