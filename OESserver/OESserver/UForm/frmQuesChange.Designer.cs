namespace OES
{
    partial class frmQuesChange
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Textcombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Unitcombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Typecombo = new System.Windows.Forms.ComboBox();
            this.Diffcombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PcontentText = new System.Windows.Forms.TextBox();
            this.SearchBut = new System.Windows.Forms.Button();
            this.ProblemDGV = new System.Windows.Forms.DataGridView();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Pagecombo = new System.Windows.Forms.ComboBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.AddButton = new System.Windows.Forms.Button();
            this.UpdateBut = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.scoreBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProblemDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Textcombo
            // 
            this.Textcombo.BackColor = System.Drawing.SystemColors.Control;
            this.Textcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Textcombo.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Textcombo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Textcombo.FormattingEnabled = true;
            this.Textcombo.Location = new System.Drawing.Point(74, 38);
            this.Textcombo.Name = "Textcombo";
            this.Textcombo.Size = new System.Drawing.Size(100, 20);
            this.Textcombo.TabIndex = 22;
            this.Textcombo.SelectedIndexChanged += new System.EventHandler(this.Textcombo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(23, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 14);
            this.label5.TabIndex = 23;
            this.label5.Text = "课程:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(205, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 24;
            this.label2.Text = "章节:";
            // 
            // Unitcombo
            // 
            this.Unitcombo.BackColor = System.Drawing.SystemColors.Control;
            this.Unitcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Unitcombo.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Unitcombo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Unitcombo.FormattingEnabled = true;
            this.Unitcombo.Location = new System.Drawing.Point(256, 38);
            this.Unitcombo.MaxDropDownItems = 20;
            this.Unitcombo.Name = "Unitcombo";
            this.Unitcombo.Size = new System.Drawing.Size(100, 20);
            this.Unitcombo.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(386, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 27;
            this.label1.Text = "类型:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(555, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 28;
            this.label3.Text = "难度:";
            // 
            // Typecombo
            // 
            this.Typecombo.BackColor = System.Drawing.SystemColors.Control;
            this.Typecombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Typecombo.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Typecombo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Typecombo.FormattingEnabled = true;
            this.Typecombo.Items.AddRange(new object[] {
            "选择题",
            "填空题",
            "判断题",
            "Word题",
            "Excel题",
            "PowerPoint题",
            "C语言编程填空题",
            "C语言编程改错题",
            "C语言编程综合题",
            "C++编程填空题",
            "C++编程改错题",
            "C++编程综合题",
            "VB编程填空题",
            "VB编程改错题",
            "VB编程综合题",
            "Base编程填空题",
            "Base编程改错题",
            "Base编程综合题"});
            this.Typecombo.Location = new System.Drawing.Point(437, 38);
            this.Typecombo.MaxDropDownItems = 20;
            this.Typecombo.Name = "Typecombo";
            this.Typecombo.Size = new System.Drawing.Size(100, 20);
            this.Typecombo.TabIndex = 29;
            // 
            // Diffcombo
            // 
            this.Diffcombo.BackColor = System.Drawing.SystemColors.Control;
            this.Diffcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Diffcombo.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Diffcombo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Diffcombo.FormattingEnabled = true;
            this.Diffcombo.Items.AddRange(new object[] {
            "全部",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.Diffcombo.Location = new System.Drawing.Point(606, 38);
            this.Diffcombo.MaxDropDownItems = 20;
            this.Diffcombo.Name = "Diffcombo";
            this.Diffcombo.Size = new System.Drawing.Size(100, 20);
            this.Diffcombo.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(14, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 31;
            this.label4.Text = "关键字:";
            // 
            // PcontentText
            // 
            this.PcontentText.Location = new System.Drawing.Point(74, 83);
            this.PcontentText.Name = "PcontentText";
            this.PcontentText.Size = new System.Drawing.Size(182, 21);
            this.PcontentText.TabIndex = 32;
            // 
            // SearchBut
            // 
            this.SearchBut.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SearchBut.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchBut.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.SearchBut.Location = new System.Drawing.Point(273, 77);
            this.SearchBut.Name = "SearchBut";
            this.SearchBut.Size = new System.Drawing.Size(67, 27);
            this.SearchBut.TabIndex = 33;
            this.SearchBut.Text = "搜索";
            this.SearchBut.UseVisualStyleBackColor = false;
            this.SearchBut.Click += new System.EventHandler(this.SearchBut_Click);
            // 
            // ProblemDGV
            // 
            this.ProblemDGV.AllowUserToAddRows = false;
            this.ProblemDGV.AllowUserToResizeColumns = false;
            this.ProblemDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.ProblemDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ProblemDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProblemDGV.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ProblemDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProblemDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ProblemDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProblemDGV.Location = new System.Drawing.Point(17, 114);
            this.ProblemDGV.MultiSelect = false;
            this.ProblemDGV.Name = "ProblemDGV";
            this.ProblemDGV.ReadOnly = true;
            this.ProblemDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProblemDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ProblemDGV.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ProblemDGV.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ProblemDGV.RowTemplate.Height = 23;
            this.ProblemDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProblemDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProblemDGV.Size = new System.Drawing.Size(699, 483);
            this.ProblemDGV.TabIndex = 34;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(254, 626);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(41, 12);
            this.linkLabel1.TabIndex = 35;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "上一页";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // Pagecombo
            // 
            this.Pagecombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Pagecombo.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pagecombo.FormattingEnabled = true;
            this.Pagecombo.Location = new System.Drawing.Point(309, 618);
            this.Pagecombo.MaxDropDownItems = 20;
            this.Pagecombo.Name = "Pagecombo";
            this.Pagecombo.Size = new System.Drawing.Size(63, 20);
            this.Pagecombo.TabIndex = 36;
            this.Pagecombo.SelectedIndexChanged += new System.EventHandler(this.Pagecombo_SelectedIndexChanged);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(390, 626);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(41, 12);
            this.linkLabel2.TabIndex = 37;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "下一页";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked_1);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.AddButton.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddButton.Location = new System.Drawing.Point(550, 77);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 31);
            this.AddButton.TabIndex = 38;
            this.AddButton.Text = "替换/添加";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UpdateBut
            // 
            this.UpdateBut.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.UpdateBut.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpdateBut.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UpdateBut.Location = new System.Drawing.Point(631, 77);
            this.UpdateBut.Name = "UpdateBut";
            this.UpdateBut.Size = new System.Drawing.Size(75, 31);
            this.UpdateBut.TabIndex = 39;
            this.UpdateBut.Text = "取消";
            this.UpdateBut.UseVisualStyleBackColor = false;
            this.UpdateBut.Click += new System.EventHandler(this.UpdateBut_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(386, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 14);
            this.label7.TabIndex = 41;
            this.label7.Text = "分值：";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // scoreBox
            // 
            this.scoreBox.Location = new System.Drawing.Point(437, 82);
            this.scoreBox.Name = "scoreBox";
            this.scoreBox.Size = new System.Drawing.Size(27, 21);
            this.scoreBox.TabIndex = 42;
            this.scoreBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.scoreBox_KeyPress);
            // 
            // frmQuesChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 659);
            this.Controls.Add(this.scoreBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.UpdateBut);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.Pagecombo);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.ProblemDGV);
            this.Controls.Add(this.SearchBut);
            this.Controls.Add(this.PcontentText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Diffcombo);
            this.Controls.Add(this.Typecombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Unitcombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Textcombo);
            this.Location = new System.Drawing.Point(10, 10);
            this.Name = "frmQuesChange";
            this.Text = "试卷微调";
            this.Load += new System.EventHandler(this.frmQuesChange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProblemDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Textcombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Unitcombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Typecombo;
        private System.Windows.Forms.ComboBox Diffcombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PcontentText;
        private System.Windows.Forms.Button SearchBut;
        private System.Windows.Forms.DataGridView ProblemDGV;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox Pagecombo;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button UpdateBut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox scoreBox;
    }
}