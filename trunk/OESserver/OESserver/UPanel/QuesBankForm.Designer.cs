namespace OES.UPanel
{
    partial class QuesBankForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProblemDGV = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteBut = new System.Windows.Forms.Button();
            this.Typecombo = new System.Windows.Forms.ComboBox();
            this.UpdateBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Unitcombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Diffcombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PcontentText = new System.Windows.Forms.TextBox();
            this.SearchBut = new System.Windows.Forms.Button();
            this.Pagecombo = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.Textcombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProblemDGV)).BeginInit();
            this.SuspendLayout();
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
            this.ProblemDGV.Location = new System.Drawing.Point(15, 118);
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
            this.ProblemDGV.Size = new System.Drawing.Size(699, 486);
            this.ProblemDGV.TabIndex = 1;
            this.ProblemDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProblemDGV_CellClick);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.AddButton.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddButton.Location = new System.Drawing.Point(477, 62);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 31);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "添加试题";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteBut
            // 
            this.DeleteBut.BackColor = System.Drawing.Color.Crimson;
            this.DeleteBut.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeleteBut.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.DeleteBut.Location = new System.Drawing.Point(639, 60);
            this.DeleteBut.Name = "DeleteBut";
            this.DeleteBut.Size = new System.Drawing.Size(75, 31);
            this.DeleteBut.TabIndex = 3;
            this.DeleteBut.Text = "删除试题";
            this.DeleteBut.UseVisualStyleBackColor = false;
            this.DeleteBut.Click += new System.EventHandler(this.DeleteBut_Click);
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
            "编程填空题",
            "编程改错题",
            "编程综合题",
            "Word题",
            "Excel题",
            "PowerPoint题"});
            this.Typecombo.Location = new System.Drawing.Point(432, 26);
            this.Typecombo.MaxDropDownItems = 20;
            this.Typecombo.Name = "Typecombo";
            this.Typecombo.Size = new System.Drawing.Size(100, 20);
            this.Typecombo.TabIndex = 6;
            // 
            // UpdateBut
            // 
            this.UpdateBut.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.UpdateBut.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpdateBut.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UpdateBut.Location = new System.Drawing.Point(558, 62);
            this.UpdateBut.Name = "UpdateBut";
            this.UpdateBut.Size = new System.Drawing.Size(75, 31);
            this.UpdateBut.TabIndex = 7;
            this.UpdateBut.Text = "修改/查看";
            this.UpdateBut.UseVisualStyleBackColor = false;
            this.UpdateBut.Click += new System.EventHandler(this.UpdateBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(372, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "类型:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(192, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "章节:";
            // 
            // Unitcombo
            // 
            this.Unitcombo.BackColor = System.Drawing.SystemColors.Control;
            this.Unitcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Unitcombo.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Unitcombo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Unitcombo.FormattingEnabled = true;
            this.Unitcombo.Location = new System.Drawing.Point(252, 26);
            this.Unitcombo.MaxDropDownItems = 20;
            this.Unitcombo.Name = "Unitcombo";
            this.Unitcombo.Size = new System.Drawing.Size(100, 20);
            this.Unitcombo.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(552, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "难度:";
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
            this.Diffcombo.Location = new System.Drawing.Point(612, 26);
            this.Diffcombo.MaxDropDownItems = 20;
            this.Diffcombo.Name = "Diffcombo";
            this.Diffcombo.Size = new System.Drawing.Size(100, 20);
            this.Diffcombo.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "关键字:";
            // 
            // PcontentText
            // 
            this.PcontentText.Location = new System.Drawing.Point(89, 71);
            this.PcontentText.Name = "PcontentText";
            this.PcontentText.Size = new System.Drawing.Size(250, 21);
            this.PcontentText.TabIndex = 14;
            // 
            // SearchBut
            // 
            this.SearchBut.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SearchBut.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchBut.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.SearchBut.Location = new System.Drawing.Point(362, 66);
            this.SearchBut.Name = "SearchBut";
            this.SearchBut.Size = new System.Drawing.Size(67, 27);
            this.SearchBut.TabIndex = 15;
            this.SearchBut.Text = "搜索";
            this.SearchBut.UseVisualStyleBackColor = false;
            this.SearchBut.Click += new System.EventHandler(this.SearchBut_Click);
            // 
            // Pagecombo
            // 
            this.Pagecombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Pagecombo.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pagecombo.FormattingEnabled = true;
            this.Pagecombo.Location = new System.Drawing.Point(328, 631);
            this.Pagecombo.MaxDropDownItems = 20;
            this.Pagecombo.Name = "Pagecombo";
            this.Pagecombo.Size = new System.Drawing.Size(63, 20);
            this.Pagecombo.TabIndex = 18;
            this.Pagecombo.SelectedIndexChanged += new System.EventHandler(this.Pagecombo_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(281, 634);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(41, 12);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "上一页";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(397, 634);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(41, 12);
            this.linkLabel2.TabIndex = 20;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "下一页";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Textcombo
            // 
            this.Textcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Textcombo.FormattingEnabled = true;
            this.Textcombo.Location = new System.Drawing.Point(72, 26);
            this.Textcombo.Name = "Textcombo";
            this.Textcombo.Size = new System.Drawing.Size(100, 20);
            this.Textcombo.TabIndex = 21;
  
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "课程:";
            // 
            // QuesBankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Textcombo);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Pagecombo);
            this.Controls.Add(this.SearchBut);
            this.Controls.Add(this.PcontentText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Diffcombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Unitcombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpdateBut);
            this.Controls.Add(this.Typecombo);
            this.Controls.Add(this.DeleteBut);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ProblemDGV);
            this.Name = "QuesBankForm";
            ((System.ComponentModel.ISupportInitialize)(this.ProblemDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProblemDGV;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteBut;
        private System.Windows.Forms.ComboBox Typecombo;
        private System.Windows.Forms.Button UpdateBut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Unitcombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Diffcombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PcontentText;
        private System.Windows.Forms.Button SearchBut;
        private System.Windows.Forms.ComboBox Pagecombo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ComboBox Textcombo;
        private System.Windows.Forms.Label label5;
    }
}
