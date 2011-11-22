namespace OES.UControl
{
    partial class CustomJudge
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Request = new System.Windows.Forms.RichTextBox();
            this.ProblemRequest = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Jadge_groupBox = new System.Windows.Forms.GroupBox();
            this.TrueButton = new System.Windows.Forms.RadioButton();
            this.FalseButton = new System.Windows.Forms.RadioButton();
            this.Question = new System.Windows.Forms.RichTextBox();
            this.LastProblem = new System.Windows.Forms.Button();
            this.NextProblem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Jadge_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Request);
            this.panel1.Controls.Add(this.ProblemRequest);
            this.panel1.Location = new System.Drawing.Point(18, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 76);
            this.panel1.TabIndex = 0;
            // 
            // Request
            // 
            this.Request.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Request.BackColor = System.Drawing.Color.White;
            this.Request.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Request.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Request.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Request.Location = new System.Drawing.Point(3, 33);
            this.Request.Name = "Request";
            this.Request.ReadOnly = true;
            this.Request.Size = new System.Drawing.Size(746, 38);
            this.Request.TabIndex = 1;
            this.Request.Text = "根据题目陈述判断对错。";
            this.Request.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide_MouseDown);
            // 
            // ProblemRequest
            // 
            this.ProblemRequest.AutoSize = true;
            this.ProblemRequest.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProblemRequest.Location = new System.Drawing.Point(3, 3);
            this.ProblemRequest.Name = "ProblemRequest";
            this.ProblemRequest.Size = new System.Drawing.Size(110, 24);
            this.ProblemRequest.TabIndex = 0;
            this.ProblemRequest.Text = "题目要求";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Jadge_groupBox);
            this.panel2.Controls.Add(this.Question);
            this.panel2.Location = new System.Drawing.Point(18, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 322);
            this.panel2.TabIndex = 1;
            // 
            // Jadge_groupBox
            // 
            this.Jadge_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Jadge_groupBox.Controls.Add(this.TrueButton);
            this.Jadge_groupBox.Controls.Add(this.FalseButton);
            this.Jadge_groupBox.Location = new System.Drawing.Point(3, 248);
            this.Jadge_groupBox.Name = "Jadge_groupBox";
            this.Jadge_groupBox.Size = new System.Drawing.Size(746, 60);
            this.Jadge_groupBox.TabIndex = 3;
            this.Jadge_groupBox.TabStop = false;
            // 
            // TrueButton
            // 
            this.TrueButton.AutoSize = true;
            this.TrueButton.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TrueButton.Location = new System.Drawing.Point(97, 20);
            this.TrueButton.Name = "TrueButton";
            this.TrueButton.Size = new System.Drawing.Size(104, 28);
            this.TrueButton.TabIndex = 1;
            this.TrueButton.TabStop = true;
            this.TrueButton.Text = " 正 确";
            this.TrueButton.UseVisualStyleBackColor = true;
            this.TrueButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrueButton_MouseClick);
            // 
            // FalseButton
            // 
            this.FalseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FalseButton.AutoSize = true;
            this.FalseButton.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FalseButton.Location = new System.Drawing.Point(512, 20);
            this.FalseButton.Name = "FalseButton";
            this.FalseButton.Size = new System.Drawing.Size(104, 28);
            this.FalseButton.TabIndex = 2;
            this.FalseButton.TabStop = true;
            this.FalseButton.Text = " 错 误";
            this.FalseButton.UseVisualStyleBackColor = true;
            this.FalseButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FalseButton_MouseClick);
            // 
            // Question
            // 
            this.Question.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Question.BackColor = System.Drawing.Color.White;
            this.Question.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Question.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Question.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Question.Location = new System.Drawing.Point(3, 3);
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            this.Question.Size = new System.Drawing.Size(746, 239);
            this.Question.TabIndex = 0;
            this.Question.Text = "";
            this.Question.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide_MouseDown);
            // 
            // LastProblem
            // 
            this.LastProblem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LastProblem.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LastProblem.Location = new System.Drawing.Point(22, 423);
            this.LastProblem.Name = "LastProblem";
            this.LastProblem.Size = new System.Drawing.Size(169, 42);
            this.LastProblem.TabIndex = 2;
            this.LastProblem.Text = "上一题";
            this.LastProblem.UseVisualStyleBackColor = true;
            this.LastProblem.Click += new System.EventHandler(this.LastProblem_Click);
            // 
            // NextProblem
            // 
            this.NextProblem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextProblem.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NextProblem.Location = new System.Drawing.Point(552, 423);
            this.NextProblem.Name = "NextProblem";
            this.NextProblem.Size = new System.Drawing.Size(169, 42);
            this.NextProblem.TabIndex = 3;
            this.NextProblem.Text = "下一题";
            this.NextProblem.UseVisualStyleBackColor = true;
            this.NextProblem.Click += new System.EventHandler(this.NestProblem_Click);
            // 
            // CustomJudge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.NextProblem);
            this.Controls.Add(this.LastProblem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CustomJudge";
            this.Size = new System.Drawing.Size(790, 496);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.Jadge_groupBox.ResumeLayout(false);
            this.Jadge_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox Request;
        private System.Windows.Forms.Label ProblemRequest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox Question;
        private System.Windows.Forms.RadioButton FalseButton;
        private System.Windows.Forms.RadioButton TrueButton;
        private System.Windows.Forms.GroupBox Jadge_groupBox;
        private System.Windows.Forms.Button LastProblem;
        private System.Windows.Forms.Button NextProblem;
    }
}
