namespace OESAnalyse
{
    partial class OESAnalyse
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ClassCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PathBut = new System.Windows.Forms.Button();
            this.ScoreDistriBut = new System.Windows.Forms.Button();
            this.CorrectBut = new System.Windows.Forms.Button();
            this.ConfigBut = new System.Windows.Forms.Button();
            this.ExcelBut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PaperCombo = new System.Windows.Forms.ComboBox();
            this.OrderCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(441, 252);
            this.dataGridView1.TabIndex = 0;
            // 
            // ClassCombo
            // 
            this.ClassCombo.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClassCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassCombo.Enabled = false;
            this.ClassCombo.FormattingEnabled = true;
            this.ClassCombo.Location = new System.Drawing.Point(247, 34);
            this.ClassCombo.Name = "ClassCombo";
            this.ClassCombo.Size = new System.Drawing.Size(89, 20);
            this.ClassCombo.TabIndex = 1;
            this.ClassCombo.SelectedIndexChanged += new System.EventHandler(this.ClassCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "班级：";
            // 
            // PathBut
            // 
            this.PathBut.Location = new System.Drawing.Point(509, 69);
            this.PathBut.Name = "PathBut";
            this.PathBut.Size = new System.Drawing.Size(75, 23);
            this.PathBut.TabIndex = 3;
            this.PathBut.Text = "选择路径";
            this.PathBut.UseVisualStyleBackColor = true;
            this.PathBut.Click += new System.EventHandler(this.PathBut_Click);
            // 
            // ScoreDistriBut
            // 
            this.ScoreDistriBut.Location = new System.Drawing.Point(509, 154);
            this.ScoreDistriBut.Name = "ScoreDistriBut";
            this.ScoreDistriBut.Size = new System.Drawing.Size(75, 23);
            this.ScoreDistriBut.TabIndex = 4;
            this.ScoreDistriBut.Text = "成绩分布";
            this.ScoreDistriBut.UseVisualStyleBackColor = true;
            // 
            // CorrectBut
            // 
            this.CorrectBut.Location = new System.Drawing.Point(509, 195);
            this.CorrectBut.Name = "CorrectBut";
            this.CorrectBut.Size = new System.Drawing.Size(75, 23);
            this.CorrectBut.TabIndex = 5;
            this.CorrectBut.Text = "题目正确率";
            this.CorrectBut.UseVisualStyleBackColor = true;
            // 
            // ConfigBut
            // 
            this.ConfigBut.Location = new System.Drawing.Point(509, 235);
            this.ConfigBut.Name = "ConfigBut";
            this.ConfigBut.Size = new System.Drawing.Size(75, 23);
            this.ConfigBut.TabIndex = 6;
            this.ConfigBut.Text = "配置";
            this.ConfigBut.UseVisualStyleBackColor = true;
            // 
            // ExcelBut
            // 
            this.ExcelBut.Location = new System.Drawing.Point(509, 280);
            this.ExcelBut.Name = "ExcelBut";
            this.ExcelBut.Size = new System.Drawing.Size(75, 23);
            this.ExcelBut.TabIndex = 7;
            this.ExcelBut.Text = "导出Excel";
            this.ExcelBut.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "查看试卷";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "试卷：";
            // 
            // PaperCombo
            // 
            this.PaperCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PaperCombo.Enabled = false;
            this.PaperCombo.FormattingEnabled = true;
            this.PaperCombo.Location = new System.Drawing.Point(389, 34);
            this.PaperCombo.Name = "PaperCombo";
            this.PaperCombo.Size = new System.Drawing.Size(83, 20);
            this.PaperCombo.TabIndex = 10;

            this.PaperCombo.SelectedIndexChanged += new System.EventHandler(this.PaperCombo_SelectedIndexChanged_1);

            // 
            // OrderCombo
            // 
            this.OrderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OrderCombo.FormattingEnabled = true;
            this.OrderCombo.Items.AddRange(new object[] {
            "先班级",
            "先试卷"});
            this.OrderCombo.Location = new System.Drawing.Point(100, 34);
            this.OrderCombo.Name = "OrderCombo";
            this.OrderCombo.Size = new System.Drawing.Size(89, 20);
            this.OrderCombo.TabIndex = 11;
            this.OrderCombo.SelectedIndexChanged += new System.EventHandler(this.OrderCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "选择顺序：";
            // 

            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(13, 13);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(593, 299);
            this.dataGridView2.TabIndex = 0;

            // 
            // OESAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 354);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OrderCombo);
            this.Controls.Add(this.PaperCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExcelBut);
            this.Controls.Add(this.ConfigBut);
            this.Controls.Add(this.CorrectBut);
            this.Controls.Add(this.ScoreDistriBut);
            this.Controls.Add(this.PathBut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClassCombo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OESAnalyse";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox ClassCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PathBut;
        private System.Windows.Forms.Button ScoreDistriBut;
        private System.Windows.Forms.Button CorrectBut;
        private System.Windows.Forms.Button ConfigBut;
        private System.Windows.Forms.Button ExcelBut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PaperCombo;
        private System.Windows.Forms.ComboBox OrderCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}

