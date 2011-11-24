namespace OES.UControl
{
    partial class CFuctionEdit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.procon = new System.Windows.Forms.RichTextBox();
            this.title = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.anspath = new System.Windows.Forms.RichTextBox();
            this.propath = new System.Windows.Forms.RichTextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.in1 = new System.Windows.Forms.RichTextBox();
            this.in2 = new System.Windows.Forms.RichTextBox();
            this.in3 = new System.Windows.Forms.RichTextBox();
            this.out2 = new System.Windows.Forms.RichTextBox();
            this.out1 = new System.Windows.Forms.RichTextBox();
            this.out3 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.procon);
            this.groupBox1.Location = new System.Drawing.Point(35, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "题干";
            // 
            // procon
            // 
            this.procon.Location = new System.Drawing.Point(7, 21);
            this.procon.Name = "procon";
            this.procon.Size = new System.Drawing.Size(501, 196);
            this.procon.TabIndex = 0;
            this.procon.Text = "";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.title.Location = new System.Drawing.Point(33, 25);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(182, 39);
            this.title.TabIndex = 1;
            this.title.Text = "C程序综合题";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.75725F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.24239F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00035F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.anspath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.propath, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(42, 317);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(501, 90);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "答案路径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "原题路径";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(453, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 39);
            this.button2.TabIndex = 11;
            this.button2.Text = "浏览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 39);
            this.button1.TabIndex = 12;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // anspath
            // 
            this.anspath.Location = new System.Drawing.Point(112, 48);
            this.anspath.Name = "anspath";
            this.anspath.Size = new System.Drawing.Size(335, 39);
            this.anspath.TabIndex = 9;
            this.anspath.Text = "";
            // 
            // propath
            // 
            this.propath.Location = new System.Drawing.Point(112, 3);
            this.propath.Name = "propath";
            this.propath.Size = new System.Drawing.Size(335, 39);
            this.propath.TabIndex = 13;
            this.propath.Text = "";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(312, 566);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 60);
            this.button5.TabIndex = 5;
            this.button5.Text = "保存";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(436, 566);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(104, 60);
            this.button6.TabIndex = 6;
            this.button6.Text = "取消";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.in1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.in2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.in3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.out2, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.out1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.out3, 2, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(42, 439);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(498, 121);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(3, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 35);
            this.label5.TabIndex = 2;
            this.label5.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 35);
            this.label4.TabIndex = 1;
            this.label4.Text = "2";
            // 
            // in1
            // 
            this.in1.Location = new System.Drawing.Point(52, 3);
            this.in1.Name = "in1";
            this.in1.Size = new System.Drawing.Size(218, 34);
            this.in1.TabIndex = 3;
            this.in1.Text = "";
            // 
            // in2
            // 
            this.in2.Location = new System.Drawing.Point(52, 43);
            this.in2.Name = "in2";
            this.in2.Size = new System.Drawing.Size(218, 34);
            this.in2.TabIndex = 4;
            this.in2.Text = "";
            // 
            // in3
            // 
            this.in3.Location = new System.Drawing.Point(52, 83);
            this.in3.Name = "in3";
            this.in3.Size = new System.Drawing.Size(218, 35);
            this.in3.TabIndex = 5;
            this.in3.Text = "";
            // 
            // out2
            // 
            this.out2.Location = new System.Drawing.Point(276, 43);
            this.out2.Name = "out2";
            this.out2.Size = new System.Drawing.Size(218, 34);
            this.out2.TabIndex = 7;
            this.out2.Text = "";
            // 
            // out1
            // 
            this.out1.Location = new System.Drawing.Point(276, 3);
            this.out1.Name = "out1";
            this.out1.Size = new System.Drawing.Size(218, 34);
            this.out1.TabIndex = 6;
            this.out1.Text = "";
            // 
            // out3
            // 
            this.out3.Location = new System.Drawing.Point(276, 83);
            this.out3.Name = "out3";
            this.out3.Size = new System.Drawing.Size(218, 34);
            this.out3.TabIndex = 8;
            this.out3.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(40, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 26);
            this.label6.TabIndex = 8;
            this.label6.Text = "测试用数据";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(313, 413);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 26);
            this.label7.TabIndex = 9;
            this.label7.Text = "测试用数答案";
            // 
            // CFuctionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.groupBox1);
            this.Name = "CFuctionEdit";
            this.Size = new System.Drawing.Size(593, 666);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.RichTextBox procon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox propath;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox in1;
        private System.Windows.Forms.RichTextBox in2;
        private System.Windows.Forms.RichTextBox in3;
        private System.Windows.Forms.RichTextBox out2;
        private System.Windows.Forms.RichTextBox out1;
        private System.Windows.Forms.RichTextBox out3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox anspath;
    }
}
