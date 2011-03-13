namespace OES.UControl
{
    partial class OfficeWordEdit
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
            this.ansbrowse = new System.Windows.Forms.Button();
            this.probrowse = new System.Windows.Forms.Button();
            this.anspath = new System.Windows.Forms.RichTextBox();
            this.propath = new System.Windows.Forms.RichTextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.title.Size = new System.Drawing.Size(104, 39);
            this.title.TabIndex = 1;
            this.title.Text = "字处理";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.75725F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.24239F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.00035F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ansbrowse, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.probrowse, 2, 0);
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
            // ansbrowse
            // 
            this.ansbrowse.Location = new System.Drawing.Point(453, 48);
            this.ansbrowse.Name = "ansbrowse";
            this.ansbrowse.Size = new System.Drawing.Size(45, 39);
            this.ansbrowse.TabIndex = 11;
            this.ansbrowse.Text = "浏览";
            this.ansbrowse.UseVisualStyleBackColor = true;
            this.ansbrowse.Click += new System.EventHandler(this.button2_Click);
            // 
            // probrowse
            // 
            this.probrowse.Location = new System.Drawing.Point(453, 3);
            this.probrowse.Name = "probrowse";
            this.probrowse.Size = new System.Drawing.Size(45, 39);
            this.probrowse.TabIndex = 12;
            this.probrowse.Text = "浏览";
            this.probrowse.UseVisualStyleBackColor = true;
            this.probrowse.Click += new System.EventHandler(this.button1_Click);
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
            // OfficeWordEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.groupBox1);
            this.Name = "OfficeWordEdit";
            this.Size = new System.Drawing.Size(593, 666);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ansbrowse;
        private System.Windows.Forms.RichTextBox anspath;
        private System.Windows.Forms.Button probrowse;
        private System.Windows.Forms.RichTextBox propath;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}
