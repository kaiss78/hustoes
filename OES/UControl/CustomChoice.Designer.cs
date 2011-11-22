namespace OES.UControl
{
    partial class CustomChoice
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
            this.ProblemRequest = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Rquest = new System.Windows.Forms.RichTextBox();
            this.LastProblem = new System.Windows.Forms.Button();
            this.NextProblem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonA = new System.Windows.Forms.RadioButton();
            this.OptionA = new TextBoxS.SmartTextBox();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.OptionB = new TextBoxS.SmartTextBox();
            this.radioButtonC = new System.Windows.Forms.RadioButton();
            this.OptionC = new TextBoxS.SmartTextBox();
            this.radioButtonD = new System.Windows.Forms.RadioButton();
            this.OptionD = new TextBoxS.SmartTextBox();
            this.Question = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Rquest);
            this.panel1.Controls.Add(this.ProblemRequest);
            this.panel1.Location = new System.Drawing.Point(18, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 76);
            this.panel1.TabIndex = 8;
            // 
            // Rquest
            // 
            this.Rquest.BackColor = System.Drawing.Color.White;
            this.Rquest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Rquest.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Rquest.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rquest.Location = new System.Drawing.Point(128, 2);
            this.Rquest.Name = "Rquest";
            this.Rquest.ReadOnly = true;
            this.Rquest.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Rquest.Size = new System.Drawing.Size(615, 68);
            this.Rquest.TabIndex = 1;
            this.Rquest.Text = "";
            this.Rquest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide_MouseDown);
            // 
            // LastProblem
            // 
            this.LastProblem.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LastProblem.Location = new System.Drawing.Point(22, 423);
            this.LastProblem.Name = "LastProblem";
            this.LastProblem.Size = new System.Drawing.Size(169, 42);
            this.LastProblem.TabIndex = 9;
            this.LastProblem.Text = "上一题";
            this.LastProblem.UseVisualStyleBackColor = true;
            this.LastProblem.Click += new System.EventHandler(this.laststep_Click);
            // 
            // NextProblem
            // 
            this.NextProblem.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NextProblem.Location = new System.Drawing.Point(552, 423);
            this.NextProblem.Name = "NextProblem";
            this.NextProblem.Size = new System.Drawing.Size(169, 42);
            this.NextProblem.TabIndex = 10;
            this.NextProblem.Text = "下一题";
            this.NextProblem.UseVisualStyleBackColor = true;
            this.NextProblem.Click += new System.EventHandler(this.nextstep_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.Question);
            this.panel2.Location = new System.Drawing.Point(18, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 322);
            this.panel2.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.radioButtonA);
            this.flowLayoutPanel1.Controls.Add(this.OptionA);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonB);
            this.flowLayoutPanel1.Controls.Add(this.OptionB);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonC);
            this.flowLayoutPanel1.Controls.Add(this.OptionC);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonD);
            this.flowLayoutPanel1.Controls.Add(this.OptionD);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 151);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(737, 166);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // radioButtonA
            // 
            this.radioButtonA.AutoSize = true;
            this.radioButtonA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonA.Location = new System.Drawing.Point(3, 3);
            this.radioButtonA.Name = "radioButtonA";
            this.radioButtonA.Size = new System.Drawing.Size(39, 18);
            this.radioButtonA.TabIndex = 4;
            this.radioButtonA.TabStop = true;
            this.radioButtonA.Text = "A.";
            this.radioButtonA.UseVisualStyleBackColor = true;
            this.radioButtonA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButtonA_MouseClick);
            // 
            // OptionA
            // 
            this.OptionA.BackColor = System.Drawing.Color.White;
            this.OptionA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OptionA.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.OptionA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptionA.InText = "";
            this.OptionA.LineCount = 80;
            this.OptionA.Location = new System.Drawing.Point(48, 3);
            this.OptionA.Multiline = true;
            this.OptionA.Name = "OptionA";
            this.OptionA.ReadOnly = true;
            this.OptionA.ShortcutsEnabled = false;
            this.OptionA.Size = new System.Drawing.Size(670, 29);
            this.OptionA.TabIndex = 12;
            this.OptionA.TabStop = false;
            this.OptionA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide1_MouseDown);
            // 
            // radioButtonB
            // 
            this.radioButtonB.AutoSize = true;
            this.radioButtonB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonB.Location = new System.Drawing.Point(3, 38);
            this.radioButtonB.Name = "radioButtonB";
            this.radioButtonB.Size = new System.Drawing.Size(39, 18);
            this.radioButtonB.TabIndex = 5;
            this.radioButtonB.TabStop = true;
            this.radioButtonB.Text = "B.";
            this.radioButtonB.UseVisualStyleBackColor = true;
            this.radioButtonB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButtonB_MouseClick);
            // 
            // OptionB
            // 
            this.OptionB.BackColor = System.Drawing.Color.White;
            this.OptionB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OptionB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.OptionB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptionB.InText = "";
            this.OptionB.LineCount = 80;
            this.OptionB.Location = new System.Drawing.Point(48, 38);
            this.OptionB.Multiline = true;
            this.OptionB.Name = "OptionB";
            this.OptionB.ReadOnly = true;
            this.OptionB.ShortcutsEnabled = false;
            this.OptionB.Size = new System.Drawing.Size(670, 29);
            this.OptionB.TabIndex = 13;
            this.OptionB.TabStop = false;
            this.OptionB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide1_MouseDown);
            // 
            // radioButtonC
            // 
            this.radioButtonC.AutoSize = true;
            this.radioButtonC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonC.Location = new System.Drawing.Point(3, 73);
            this.radioButtonC.Name = "radioButtonC";
            this.radioButtonC.Size = new System.Drawing.Size(39, 18);
            this.radioButtonC.TabIndex = 6;
            this.radioButtonC.TabStop = true;
            this.radioButtonC.Text = "C.";
            this.radioButtonC.UseVisualStyleBackColor = true;
            this.radioButtonC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButtonC_MouseClick);
            // 
            // OptionC
            // 
            this.OptionC.BackColor = System.Drawing.Color.White;
            this.OptionC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OptionC.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.OptionC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptionC.InText = "";
            this.OptionC.LineCount = 80;
            this.OptionC.Location = new System.Drawing.Point(48, 73);
            this.OptionC.Multiline = true;
            this.OptionC.Name = "OptionC";
            this.OptionC.ReadOnly = true;
            this.OptionC.ShortcutsEnabled = false;
            this.OptionC.Size = new System.Drawing.Size(670, 29);
            this.OptionC.TabIndex = 14;
            this.OptionC.TabStop = false;
            this.OptionC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide1_MouseDown);
            // 
            // radioButtonD
            // 
            this.radioButtonD.AutoSize = true;
            this.radioButtonD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonD.Location = new System.Drawing.Point(3, 108);
            this.radioButtonD.Name = "radioButtonD";
            this.radioButtonD.Size = new System.Drawing.Size(39, 18);
            this.radioButtonD.TabIndex = 7;
            this.radioButtonD.TabStop = true;
            this.radioButtonD.Text = "D.";
            this.radioButtonD.UseVisualStyleBackColor = true;
            this.radioButtonD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButtonD_MouseClick);
            // 
            // OptionD
            // 
            this.OptionD.BackColor = System.Drawing.Color.White;
            this.OptionD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OptionD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.OptionD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptionD.InText = "";
            this.OptionD.LineCount = 80;
            this.OptionD.Location = new System.Drawing.Point(48, 108);
            this.OptionD.Multiline = true;
            this.OptionD.Name = "OptionD";
            this.OptionD.ReadOnly = true;
            this.OptionD.ShortcutsEnabled = false;
            this.OptionD.Size = new System.Drawing.Size(670, 29);
            this.OptionD.TabIndex = 15;
            this.OptionD.TabStop = false;
            this.OptionD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide1_MouseDown);
            // 
            // Question
            // 
            this.Question.BackColor = System.Drawing.Color.White;
            this.Question.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Question.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Question.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Question.Location = new System.Drawing.Point(6, 7);
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            this.Question.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Question.Size = new System.Drawing.Size(740, 138);
            this.Question.TabIndex = 12;
            this.Question.Text = "";
            this.Question.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide_MouseDown);
            // 
            // CustomChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.NextProblem);
            this.Controls.Add(this.LastProblem);
            this.Controls.Add(this.panel1);
            this.Name = "CustomChoice";
            this.Size = new System.Drawing.Size(790, 478);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ProblemRequest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LastProblem;
        private System.Windows.Forms.Button NextProblem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox Rquest;
        private System.Windows.Forms.RichTextBox Question;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonA;
        private System.Windows.Forms.RadioButton radioButtonB;
        private System.Windows.Forms.RadioButton radioButtonC;
        private System.Windows.Forms.RadioButton radioButtonD;
        private TextBoxS.SmartTextBox OptionA;
        private TextBoxS.SmartTextBox OptionB;
        private TextBoxS.SmartTextBox OptionC;
        private TextBoxS.SmartTextBox OptionD;
    }
}
