namespace OES.UControl
{
    partial class CustomCompletion
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
            this.Rquest = new System.Windows.Forms.RichTextBox();
            this.ProblemRquest = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Answer_richbox = new System.Windows.Forms.RichTextBox();
            this.Answer = new System.Windows.Forms.Label();
            this.Question = new System.Windows.Forms.RichTextBox();
            this.lastproblem = new System.Windows.Forms.Button();
            this.nextproblem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Rquest);
            this.panel1.Controls.Add(this.ProblemRquest);
            this.panel1.Location = new System.Drawing.Point(18, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 76);
            this.panel1.TabIndex = 0;
            // 
            // Rquest
            // 
            this.Rquest.BackColor = System.Drawing.Color.White;
            this.Rquest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Rquest.CausesValidation = false;
            this.Rquest.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Rquest.DetectUrls = false;
            this.Rquest.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rquest.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Rquest.Location = new System.Drawing.Point(131, 3);
            this.Rquest.Name = "Rquest";
            this.Rquest.ReadOnly = true;
            this.Rquest.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Rquest.ShortcutsEnabled = false;
            this.Rquest.Size = new System.Drawing.Size(618, 68);
            this.Rquest.TabIndex = 1;
            this.Rquest.Text = "";
            this.Rquest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide_MouseDown);
            // 
            // ProblemRquest
            // 
            this.ProblemRquest.AutoSize = true;
            this.ProblemRquest.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProblemRquest.Location = new System.Drawing.Point(3, 3);
            this.ProblemRquest.Name = "ProblemRquest";
            this.ProblemRquest.Size = new System.Drawing.Size(110, 24);
            this.ProblemRquest.TabIndex = 0;
            this.ProblemRquest.Text = "题目要求";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Answer_richbox);
            this.panel2.Controls.Add(this.Answer);
            this.panel2.Controls.Add(this.Question);
            this.panel2.Location = new System.Drawing.Point(18, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 322);
            this.panel2.TabIndex = 1;
            // 
            // Answer_richbox
            // 
            this.Answer_richbox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Answer_richbox.Location = new System.Drawing.Point(69, 270);
            this.Answer_richbox.Name = "Answer_richbox";
            this.Answer_richbox.Size = new System.Drawing.Size(680, 31);
            this.Answer_richbox.TabIndex = 2;
            this.Answer_richbox.Text = "";
            this.Answer_richbox.TextChanged += new System.EventHandler(this.Answer_richbox_TextChanged);
            // 
            // Answer
            // 
            this.Answer.AutoSize = true;
            this.Answer.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Answer.Location = new System.Drawing.Point(3, 277);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(60, 24);
            this.Answer.TabIndex = 1;
            this.Answer.Text = "答案";
            // 
            // Question
            // 
            this.Question.BackColor = System.Drawing.Color.White;
            this.Question.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Question.CausesValidation = false;
            this.Question.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Question.DetectUrls = false;
            this.Question.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Question.Location = new System.Drawing.Point(3, 3);
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            this.Question.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Question.ShortcutsEnabled = false;
            this.Question.Size = new System.Drawing.Size(746, 249);
            this.Question.TabIndex = 0;
            this.Question.Text = "";
            this.Question.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide_MouseDown);
            // 
            // lastproblem
            // 
            this.lastproblem.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lastproblem.Location = new System.Drawing.Point(22, 423);
            this.lastproblem.Name = "lastproblem";
            this.lastproblem.Size = new System.Drawing.Size(169, 42);
            this.lastproblem.TabIndex = 2;
            this.lastproblem.Text = "上一题";
            this.lastproblem.UseVisualStyleBackColor = true;
            this.lastproblem.Click += new System.EventHandler(this.lastproblem_Click);
            // 
            // nextproblem
            // 
            this.nextproblem.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nextproblem.Location = new System.Drawing.Point(552, 423);
            this.nextproblem.Name = "nextproblem";
            this.nextproblem.Size = new System.Drawing.Size(169, 42);
            this.nextproblem.TabIndex = 3;
            this.nextproblem.Text = "下一题";
            this.nextproblem.UseVisualStyleBackColor = true;
            this.nextproblem.Click += new System.EventHandler(this.nextproblem_Click);
            // 
            // CustomCompletion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.nextproblem);
            this.Controls.Add(this.lastproblem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CustomCompletion";
            this.Size = new System.Drawing.Size(790, 496);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ProblemRquest;
        private System.Windows.Forms.RichTextBox Rquest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox Question;
        private System.Windows.Forms.Label Answer;
        private System.Windows.Forms.RichTextBox Answer_richbox;
        private System.Windows.Forms.Button lastproblem;
        private System.Windows.Forms.Button nextproblem;
    }
}
