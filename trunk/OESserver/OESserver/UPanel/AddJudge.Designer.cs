namespace OES
{
    partial class AddJudge
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
            this.True = new System.Windows.Forms.RadioButton();
            this.Flase = new System.Windows.Forms.RadioButton();
            this.Content = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureBox4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // True
            // 
            this.True.AutoSize = true;
            this.True.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.True.ForeColor = System.Drawing.SystemColors.Highlight;
            this.True.Location = new System.Drawing.Point(187, 216);
            this.True.Name = "True";
            this.True.Size = new System.Drawing.Size(55, 24);
            this.True.TabIndex = 3;
            this.True.TabStop = true;
            this.True.Text = "正确";
            this.True.UseVisualStyleBackColor = true;
            // 
            // Flase
            // 
            this.Flase.AutoSize = true;
            this.Flase.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Flase.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Flase.Location = new System.Drawing.Point(482, 216);
            this.Flase.Name = "Flase";
            this.Flase.Size = new System.Drawing.Size(55, 24);
            this.Flase.TabIndex = 4;
            this.Flase.TabStop = true;
            this.Flase.Text = "错误";
            this.Flase.UseVisualStyleBackColor = true;
            // 
            // Content
            // 
            this.Content.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Content.Location = new System.Drawing.Point(109, 35);
            this.Content.Multiline = true;
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(551, 129);
            this.Content.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "试题答案";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "判断题";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(162, 291);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(105, 35);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.Values.Text = "保存";
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(473, 291);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(101, 35);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.Values.Text = "返回";
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // AddJudge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Flase);
            this.Controls.Add(this.True);
            this.Controls.Add(this.Content);
            this.Name = "AddJudge";
            this.Size = new System.Drawing.Size(742, 553);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton True;
        private System.Windows.Forms.RadioButton Flase;
        private System.Windows.Forms.TextBox Content;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton pictureBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton pictureBox4;

    }
}
