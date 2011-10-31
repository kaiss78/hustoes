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
            this.radioButtonA = new System.Windows.Forms.RadioButton();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.radioButtonC = new System.Windows.Forms.RadioButton();
            this.radioButtonD = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Rquest = new System.Windows.Forms.RichTextBox();
            this.LastProblem = new System.Windows.Forms.Button();
            this.NextProblem = new System.Windows.Forms.Button();
            this.groupchoice = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OptionD = new System.Windows.Forms.TextBox();
            this.OptionC = new System.Windows.Forms.TextBox();
            this.OptionB = new System.Windows.Forms.TextBox();
            this.OptionA = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Question = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.groupchoice.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            // groupchoice
            // 
            this.groupchoice.Controls.Add(this.tableLayoutPanel1);
            this.groupchoice.Location = new System.Drawing.Point(3, 149);
            this.groupchoice.Name = "groupchoice";
            this.groupchoice.Size = new System.Drawing.Size(746, 162);
            this.groupchoice.TabIndex = 11;
            this.groupchoice.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.OptionD, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.OptionC, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.OptionB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonA, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonD, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonC, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OptionA, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(740, 142);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // OptionD
            // 
            this.OptionD.BackColor = System.Drawing.Color.White;
            this.OptionD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OptionD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.OptionD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptionD.Location = new System.Drawing.Point(58, 108);
            this.OptionD.Multiline = true;
            this.OptionD.Name = "OptionD";
            this.OptionD.ReadOnly = true;
            this.OptionD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OptionD.ShortcutsEnabled = false;
            this.OptionD.Size = new System.Drawing.Size(679, 31);
            this.OptionD.TabIndex = 11;
            this.OptionD.TabStop = false;
            this.OptionD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide1_MouseDown);
            // 
            // OptionC
            // 
            this.OptionC.BackColor = System.Drawing.Color.White;
            this.OptionC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OptionC.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.OptionC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptionC.Location = new System.Drawing.Point(58, 73);
            this.OptionC.Multiline = true;
            this.OptionC.Name = "OptionC";
            this.OptionC.ReadOnly = true;
            this.OptionC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OptionC.ShortcutsEnabled = false;
            this.OptionC.Size = new System.Drawing.Size(679, 29);
            this.OptionC.TabIndex = 10;
            this.OptionC.TabStop = false;
            this.OptionC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide1_MouseDown);
            // 
            // OptionB
            // 
            this.OptionB.BackColor = System.Drawing.Color.White;
            this.OptionB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OptionB.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.OptionB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptionB.Location = new System.Drawing.Point(58, 38);
            this.OptionB.Multiline = true;
            this.OptionB.Name = "OptionB";
            this.OptionB.ReadOnly = true;
            this.OptionB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OptionB.ShortcutsEnabled = false;
            this.OptionB.Size = new System.Drawing.Size(679, 29);
            this.OptionB.TabIndex = 9;
            this.OptionB.TabStop = false;
            this.OptionB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide1_MouseDown);
            // 
            // OptionA
            // 
            this.OptionA.BackColor = System.Drawing.Color.White;
            this.OptionA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OptionA.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.OptionA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptionA.Location = new System.Drawing.Point(58, 3);
            this.OptionA.Multiline = true;
            this.OptionA.Name = "OptionA";
            this.OptionA.ReadOnly = true;
            this.OptionA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OptionA.ShortcutsEnabled = false;
            this.OptionA.Size = new System.Drawing.Size(679, 29);
            this.OptionA.TabIndex = 8;
            this.OptionA.TabStop = false;
            this.OptionA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Question);
            this.panel2.Controls.Add(this.groupchoice);
            this.panel2.Location = new System.Drawing.Point(18, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 322);
            this.panel2.TabIndex = 12;
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
            this.groupchoice.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ProblemRequest;
        private System.Windows.Forms.RadioButton radioButtonA;
        private System.Windows.Forms.RadioButton radioButtonB;
        private System.Windows.Forms.RadioButton radioButtonC;
        private System.Windows.Forms.RadioButton radioButtonD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LastProblem;
        private System.Windows.Forms.Button NextProblem;
        private System.Windows.Forms.GroupBox groupchoice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox Rquest;
        private System.Windows.Forms.RichTextBox Question;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox OptionD;
        private System.Windows.Forms.TextBox OptionC;
        private System.Windows.Forms.TextBox OptionB;
        private System.Windows.Forms.TextBox OptionA;
    }
}
