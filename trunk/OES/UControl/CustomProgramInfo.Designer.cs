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
            this.SuspendLayout();
            // 
            // Question
            // 
            this.Question.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Question.Location = new System.Drawing.Point(2, 0);
            this.Question.Margin = new System.Windows.Forms.Padding(5);
            this.Question.Multiline = true;
            this.Question.Name = "Question";
            this.Question.ReadOnly = true;
            this.Question.Size = new System.Drawing.Size(780, 400);
            this.Question.TabIndex = 1;
            // 
            // butOpen
            // 
            this.butOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butOpen.Location = new System.Drawing.Point(146, 435);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(80, 30);
            this.butOpen.TabIndex = 1;
            this.butOpen.Text = "打开文档";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // butRedo
            // 
            this.butRedo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butRedo.Location = new System.Drawing.Point(470, 435);
            this.butRedo.Name = "butRedo";
            this.butRedo.Size = new System.Drawing.Size(80, 30);
            this.butRedo.TabIndex = 2;
            this.butRedo.Text = "重做题目";
            this.butRedo.UseVisualStyleBackColor = true;
            // 
            // CustomProgramInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
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

    }
}
