namespace OESMonitor
{
    partial class Computer
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
            this.ico = new System.Windows.Forms.PictureBox();
            this.lab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ico)).BeginInit();
            this.SuspendLayout();
            // 
            // ico
            // 
            this.ico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ico.Location = new System.Drawing.Point(0, 0);
            this.ico.Name = "ico";
            this.ico.Size = new System.Drawing.Size(80, 70);
            this.ico.TabIndex = 0;
            this.ico.TabStop = false;
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Location = new System.Drawing.Point(20, 73);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(41, 12);
            this.lab.TabIndex = 1;
            this.lab.Text = "label1";
            // 
            // Computer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lab);
            this.Controls.Add(this.ico);
            this.Name = "Computer";
            this.Size = new System.Drawing.Size(80, 100);
            ((System.ComponentModel.ISupportInitialize)(this.ico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ico;
        private System.Windows.Forms.Label lab;
    }
}
