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
            this.StuLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ico)).BeginInit();
            this.SuspendLayout();
            // 
            // ico
            // 
            this.ico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ico.Location = new System.Drawing.Point(1, 1);
            this.ico.Name = "ico";
            this.ico.Size = new System.Drawing.Size(80, 70);
            this.ico.TabIndex = 0;
            this.ico.TabStop = false;
            this.ico.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Computer_MouseClick);
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Location = new System.Drawing.Point(20, 74);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(41, 12);
            this.lab.TabIndex = 1;
            this.lab.Text = "label1";
            this.lab.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Computer_MouseClick);
            // 
            // StuLabel
            // 
            this.StuLabel.AutoSize = true;
            this.StuLabel.Location = new System.Drawing.Point(5, 89);
            this.StuLabel.Name = "StuLabel";
            this.StuLabel.Size = new System.Drawing.Size(29, 12);
            this.StuLabel.TabIndex = 2;
            this.StuLabel.Text = "    ";
            this.StuLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Computer_MouseClick);
            // 
            // Computer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.StuLabel);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.ico);
            this.Name = "Computer";
            this.Size = new System.Drawing.Size(82, 102);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Computer_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.ico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ico;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.Label StuLabel;
    }
}
