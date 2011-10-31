namespace OES.UControl
{
    partial class ProblemsList
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
            this.components = new System.ComponentModel.Container();
            this.panelUp = new System.Windows.Forms.Panel();
            this.panelDown = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panelUp
            // 
            this.panelUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUp.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(72, 20);
            this.panelUp.TabIndex = 0;
            this.panelUp.MouseLeave += new System.EventHandler(this.panelUp_MouseLeave);
            this.panelUp.MouseEnter += new System.EventHandler(this.panelUp_MouseEnter);
            // 
            // panelDown
            // 
            this.panelDown.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.Location = new System.Drawing.Point(0, 510);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(72, 20);
            this.panelDown.TabIndex = 1;
            this.panelDown.MouseLeave += new System.EventHandler(this.panelDown_MouseLeave);
            this.panelDown.MouseEnter += new System.EventHandler(this.panelDown_MouseEnter);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProblemsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Name = "ProblemsList";
            this.Size = new System.Drawing.Size(72, 530);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Timer timer1;
    }
}
