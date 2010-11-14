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
            this.RequestTeam = new System.Windows.Forms.RichTextBox();
            this.LastProblem = new System.Windows.Forms.Button();
            this.NestProblem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Jadge_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Request);
            this.panel1.Controls.Add(this.ProblemRequest);
            this.panel1.Location = new System.Drawing.Point(18, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 76);
            this.panel1.TabIndex = 0;
            // 
            // Request
            // 
            this.Request.BackColor = System.Drawing.Color.White;
            this.Request.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Request.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Request.Location = new System.Drawing.Point(143, 3);
            this.Request.Name = "Request";
            this.Request.ReadOnly = true;
            this.Request.Size = new System.Drawing.Size(551, 68);
            this.Request.TabIndex = 1;
            this.Request.Text = "";
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
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Jadge_groupBox);
            this.panel2.Controls.Add(this.RequestTeam);
            this.panel2.Location = new System.Drawing.Point(18, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 274);
            this.panel2.TabIndex = 1;
            // 
            // Jadge_groupBox
            // 
            this.Jadge_groupBox.Controls.Add(this.TrueButton);
            this.Jadge_groupBox.Controls.Add(this.FalseButton);
            this.Jadge_groupBox.Location = new System.Drawing.Point(3, 209);
            this.Jadge_groupBox.Name = "Jadge_groupBox";
            this.Jadge_groupBox.Size = new System.Drawing.Size(687, 60);
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
            // 
            // FalseButton
            // 
            this.FalseButton.AutoSize = true;
            this.FalseButton.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FalseButton.Location = new System.Drawing.Point(489, 20);
            this.FalseButton.Name = "FalseButton";
            this.FalseButton.Size = new System.Drawing.Size(104, 28);
            this.FalseButton.TabIndex = 2;
            this.FalseButton.TabStop = true;
            this.FalseButton.Text = " 错 误";
            this.FalseButton.UseVisualStyleBackColor = true;
            // 
            // RequestTeam
            // 
            this.RequestTeam.BackColor = System.Drawing.Color.White;
            this.RequestTeam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RequestTeam.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RequestTeam.Location = new System.Drawing.Point(3, 3);
            this.RequestTeam.Name = "RequestTeam";
            this.RequestTeam.ReadOnly = true;
            this.RequestTeam.Size = new System.Drawing.Size(687, 186);
            this.RequestTeam.TabIndex = 0;
            this.RequestTeam.Text = "";
            this.RequestTeam.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide_MouseDown);
            // 
            // LastProblem
            // 
            this.LastProblem.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LastProblem.Location = new System.Drawing.Point(26, 406);
            this.LastProblem.Name = "LastProblem";
            this.LastProblem.Size = new System.Drawing.Size(154, 42);
            this.LastProblem.TabIndex = 2;
            this.LastProblem.Text = "上一题";
            this.LastProblem.UseVisualStyleBackColor = true;
            this.LastProblem.Click += new System.EventHandler(this.LastProblem_Click);
            // 
            // NestProblem
            // 
            this.NestProblem.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NestProblem.Location = new System.Drawing.Point(555, 406);
            this.NestProblem.Name = "NestProblem";
            this.NestProblem.Size = new System.Drawing.Size(154, 42);
            this.NestProblem.TabIndex = 3;
            this.NestProblem.Text = "下一题";
            this.NestProblem.UseVisualStyleBackColor = true;
            this.NestProblem.Click += new System.EventHandler(this.NestProblem_Click);
            // 
            // CustomJudge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.NestProblem);
            this.Controls.Add(this.LastProblem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CustomJudge";
            this.Size = new System.Drawing.Size(750, 466);
            this.Load += new System.EventHandler(this.MyUserControl_Load);
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
        private System.Windows.Forms.RichTextBox RequestTeam;
        private System.Windows.Forms.RadioButton FalseButton;
        private System.Windows.Forms.RadioButton TrueButton;
        private System.Windows.Forms.GroupBox Jadge_groupBox;
        private System.Windows.Forms.Button LastProblem;
        private System.Windows.Forms.Button NestProblem;
    }
}
