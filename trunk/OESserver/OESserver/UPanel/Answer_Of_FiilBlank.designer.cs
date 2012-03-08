namespace OES.UPanel
{
    partial class Answer_Of_FiilBlank
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
            this.Answer = new System.Windows.Forms.TextBox();
            this.deleteThisPanel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Answer
            // 
            this.Answer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Answer.Location = new System.Drawing.Point(76, 0);
            this.Answer.Multiline = true;
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(345, 62);
            this.Answer.TabIndex = 1;
            // 
            // deleteThisPanel
            // 
            this.deleteThisPanel.Location = new System.Drawing.Point(427, 40);
            this.deleteThisPanel.Name = "deleteThisPanel";
            this.deleteThisPanel.Size = new System.Drawing.Size(74, 22);
            this.deleteThisPanel.TabIndex = 2;
            this.deleteThisPanel.Text = "删除";
            this.deleteThisPanel.UseVisualStyleBackColor = true;
            this.deleteThisPanel.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "试题答案";
            // 
            // Answer_Of_FiilBlank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteThisPanel);
            this.Controls.Add(this.Answer);
            this.Name = "Answer_Of_FiilBlank";
            this.Size = new System.Drawing.Size(581, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Answer;
        private System.Windows.Forms.Button deleteThisPanel;
        private System.Windows.Forms.Label label1;
    }
}
