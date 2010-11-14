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
            this.txtProblem = new System.Windows.Forms.TextBox();
            this.butOpen = new System.Windows.Forms.Button();
            this.butRedo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtProblem
            // 
            this.txtProblem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProblem.Location = new System.Drawing.Point(3, 3);
            this.txtProblem.Multiline = true;
            this.txtProblem.Name = "txtProblem";
            this.txtProblem.ReadOnly = true;
            this.txtProblem.Size = new System.Drawing.Size(777, 400);
            this.txtProblem.TabIndex = 1;
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
            // ProgramInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.txtProblem);
            this.Controls.Add(this.butRedo);
            this.Controls.Add(this.butOpen);
            this.Name = "ProgramInfo";
            this.Size = new System.Drawing.Size(784, 489);
            this.Load += new System.EventHandler(this.ProgramInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProblem;
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.Button butRedo;

    }
}
