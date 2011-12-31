namespace OES.UControl
{
    partial class CustomPPT
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Question = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.NextProblem = new System.Windows.Forms.Button();
            this.Rquest = new System.Windows.Forms.RichTextBox();
            this.LastProblem = new System.Windows.Forms.Button();
            this.ProblemRequest = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Question);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(15, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 322);
            this.panel2.TabIndex = 20;
            // 
            // Question
            // 
            this.Question.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Question.BackColor = System.Drawing.Color.White;
            this.Question.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Question.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Question.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Question.Location = new System.Drawing.Point(6, 7);
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            this.Question.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Question.Size = new System.Drawing.Size(740, 256);
            this.Question.TabIndex = 12;
            this.Question.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(492, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "打开文档";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(616, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "重新做题";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // NextProblem
            // 
            this.NextProblem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextProblem.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NextProblem.Location = new System.Drawing.Point(549, 428);
            this.NextProblem.Name = "NextProblem";
            this.NextProblem.Size = new System.Drawing.Size(169, 42);
            this.NextProblem.TabIndex = 19;
            this.NextProblem.Text = "下一题";
            this.NextProblem.UseVisualStyleBackColor = true;
            this.NextProblem.Click += new System.EventHandler(this.nextstep_Click);
            // 
            // Rquest
            // 
            this.Rquest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Rquest.BackColor = System.Drawing.Color.White;
            this.Rquest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Rquest.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Rquest.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rquest.Location = new System.Drawing.Point(3, 33);
            this.Rquest.Name = "Rquest";
            this.Rquest.ReadOnly = true;
            this.Rquest.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Rquest.Size = new System.Drawing.Size(746, 38);
            this.Rquest.TabIndex = 1;
            this.Rquest.Text = "根据题目描述完成PowerPoint题。";
            // 
            // LastProblem
            // 
            this.LastProblem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LastProblem.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LastProblem.Location = new System.Drawing.Point(19, 428);
            this.LastProblem.Name = "LastProblem";
            this.LastProblem.Size = new System.Drawing.Size(169, 42);
            this.LastProblem.TabIndex = 18;
            this.LastProblem.Text = "上一题";
            this.LastProblem.UseVisualStyleBackColor = true;
            this.LastProblem.Click += new System.EventHandler(this.laststep_Click);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Rquest);
            this.panel1.Controls.Add(this.ProblemRequest);
            this.panel1.Location = new System.Drawing.Point(15, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 76);
            this.panel1.TabIndex = 17;
            // 
            // CustomPPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.NextProblem);
            this.Controls.Add(this.LastProblem);
            this.Controls.Add(this.panel1);
            this.Name = "CustomPPT";
            this.Size = new System.Drawing.Size(784, 489);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox Question;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button NextProblem;
        private System.Windows.Forms.RichTextBox Rquest;
        private System.Windows.Forms.Button LastProblem;
        private System.Windows.Forms.Label ProblemRequest;
        private System.Windows.Forms.Panel panel1;

    }
}
