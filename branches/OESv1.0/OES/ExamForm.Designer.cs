namespace OES
{
    partial class ExamForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Resume = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ExamNo = new System.Windows.Forms.Label();
            this.SName = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(45, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "大学生计算机基础考试";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(391, 183);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 25);
            this.Start.TabIndex = 1;
            this.Start.Text = "开始考试";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Resume
            // 
            this.Resume.Location = new System.Drawing.Point(391, 228);
            this.Resume.Name = "Resume";
            this.Resume.Size = new System.Drawing.Size(75, 25);
            this.Resume.TabIndex = 2;
            this.Resume.Text = "恢复考试";
            this.Resume.UseVisualStyleBackColor = true;
            this.Resume.Click += new System.EventHandler(this.Resume_Click);
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(391, 270);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(75, 25);
            this.Restart.TabIndex = 3;
            this.Restart.Text = "重新考试";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(90, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "考生学号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(90, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "考生姓名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(90, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "试卷代号：";
            // 
            // ExamNo
            // 
            this.ExamNo.AutoSize = true;
            this.ExamNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExamNo.Location = new System.Drawing.Point(240, 272);
            this.ExamNo.Name = "ExamNo";
            this.ExamNo.Size = new System.Drawing.Size(56, 16);
            this.ExamNo.TabIndex = 7;
            this.ExamNo.Text = "label5";
            // 
            // SName
            // 
            this.SName.AutoSize = true;
            this.SName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SName.Location = new System.Drawing.Point(240, 230);
            this.SName.Name = "SName";
            this.SName.Size = new System.Drawing.Size(56, 16);
            this.SName.TabIndex = 8;
            this.SName.Text = "label6";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ID.Location = new System.Drawing.Point(240, 185);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(56, 16);
            this.ID.TabIndex = 9;
            this.ID.Text = "label7";
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(243, 372);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 10;
            this.Exit.Text = "退出";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(45, 340);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(504, 16);
            this.progressBar1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "加载试卷";
            // 
            // ExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 420);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.SName);
            this.Controls.Add(this.ExamNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.Resume);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(585, 420);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(585, 420);
            this.Name = "ExamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExamForm";
            //this.Load += new System.EventHandler(this.ExamForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Resume;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ExamNo;
        private System.Windows.Forms.Label SName;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
    }
}