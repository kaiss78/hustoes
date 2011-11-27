namespace OES.UControl
{
    partial class CustomProgramInfo
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
            this.Question = new System.Windows.Forms.TextBox();
            this.butOpen = new System.Windows.Forms.Button();
            this.butRedo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Question
            // 
            this.Question.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Question.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Question.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Question.Font = new System.Drawing.Font("宋体", 14.25F);
            this.Question.Location = new System.Drawing.Point(32, 58);
            this.Question.Margin = new System.Windows.Forms.Padding(5);
            this.Question.Multiline = true;
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            this.Question.Size = new System.Drawing.Size(711, 342);
            this.Question.TabIndex = 1;
            this.Question.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hide1_MouseDown);
            // 
            // butOpen
            // 
            this.butOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOpen.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butOpen.Location = new System.Drawing.Point(482, 434);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(107, 37);
            this.butOpen.TabIndex = 1;
            this.butOpen.Text = "打开文档";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // butRedo
            // 
            this.butRedo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butRedo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.butRedo.Location = new System.Drawing.Point(606, 434);
            this.butRedo.Name = "butRedo";
            this.butRedo.Size = new System.Drawing.Size(107, 37);
            this.butRedo.TabIndex = 2;
            this.butRedo.Text = "重做题目";
            this.butRedo.UseVisualStyleBackColor = true;
            this.butRedo.Click += new System.EventHandler(this.butRedo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "题目要求";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomProgramInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.butRedo);
            this.Controls.Add(this.butOpen);
            this.Name = "CustomProgramInfo";
            this.Size = new System.Drawing.Size(784, 489);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Question;
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.Button butRedo;
        private System.Windows.Forms.Label label1;

    }
}
