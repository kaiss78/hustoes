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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PathBut = new System.Windows.Forms.Button();
            this.ScoreDistriBut = new System.Windows.Forms.Button();
            this.CorrectBut = new System.Windows.Forms.Button();
            this.ConfigBut = new System.Windows.Forms.Button();
            this.ExcelBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(327, 214);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(100, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "分析方式：";
            // 
            // PathBut
            // 
            this.PathBut.Location = new System.Drawing.Point(392, 45);
            this.PathBut.Name = "PathBut";
            this.PathBut.Size = new System.Drawing.Size(75, 23);
            this.PathBut.TabIndex = 3;
            this.PathBut.Text = "选择路径";
            this.PathBut.UseVisualStyleBackColor = true;
            this.PathBut.Click += new System.EventHandler(this.PathBut_Click);
            // 
            // ScoreDistriBut
            // 
            this.ScoreDistriBut.Location = new System.Drawing.Point(392, 89);
            this.ScoreDistriBut.Name = "ScoreDistriBut";
            this.ScoreDistriBut.Size = new System.Drawing.Size(75, 23);
            this.ScoreDistriBut.TabIndex = 4;
            this.ScoreDistriBut.Text = "成绩分布";
            this.ScoreDistriBut.UseVisualStyleBackColor = true;
            // 
            // CorrectBut
            // 
            this.CorrectBut.Location = new System.Drawing.Point(392, 130);
            this.CorrectBut.Name = "CorrectBut";
            this.CorrectBut.Size = new System.Drawing.Size(75, 23);
            this.CorrectBut.TabIndex = 5;
            this.CorrectBut.Text = "题目正确率";
            this.CorrectBut.UseVisualStyleBackColor = true;
            // 
            // ConfigBut
            // 
            this.ConfigBut.Location = new System.Drawing.Point(392, 172);
            this.ConfigBut.Name = "ConfigBut";
            this.ConfigBut.Size = new System.Drawing.Size(75, 23);
            this.ConfigBut.TabIndex = 6;
            this.ConfigBut.Text = "配置";
            this.ConfigBut.UseVisualStyleBackColor = true;
            // 
            // ExcelBut
            // 
            this.ExcelBut.Location = new System.Drawing.Point(392, 213);
            this.ExcelBut.Name = "ExcelBut";
            this.ExcelBut.Size = new System.Drawing.Size(75, 23);
            this.ExcelBut.TabIndex = 7;
            this.ExcelBut.Text = "导出Excel";
            this.ExcelBut.UseVisualStyleBackColor = true;
            // 
            // OESAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 337);
            this.Controls.Add(this.ExcelBut);
            this.Controls.Add(this.ConfigBut);
            this.Controls.Add(this.CorrectBut);
            this.Controls.Add(this.ScoreDistriBut);
            this.Controls.Add(this.PathBut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OESAnalyse";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PathBut;
        private System.Windows.Forms.Button ScoreDistriBut;
        private System.Windows.Forms.Button CorrectBut;
        private System.Windows.Forms.Button ConfigBut;
        private System.Windows.Forms.Button ExcelBut;
    }
}

