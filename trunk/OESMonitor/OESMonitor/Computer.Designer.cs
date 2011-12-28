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
            this.components = new System.ComponentModel.Container();
            this.lab = new System.Windows.Forms.Label();
            this.StuLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.重启计算机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ico = new System.Windows.Forms.PictureBox();
            this.发送消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.试卷已收到ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ico)).BeginInit();
            this.SuspendLayout();
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发送消息ToolStripMenuItem,
            this.试卷已收到ToolStripMenuItem,
            this.重启计算机ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // 重启计算机ToolStripMenuItem
            // 
            this.重启计算机ToolStripMenuItem.Name = "重启计算机ToolStripMenuItem";
            this.重启计算机ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.重启计算机ToolStripMenuItem.Text = "重启计算机";
            this.重启计算机ToolStripMenuItem.Click += new System.EventHandler(this.重启计算机ToolStripMenuItem_Click);
            // 
            // ico
            // 
            this.ico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ico.ContextMenuStrip = this.contextMenuStrip1;
            this.ico.Location = new System.Drawing.Point(1, 1);
            this.ico.Name = "ico";
            this.ico.Size = new System.Drawing.Size(80, 70);
            this.ico.TabIndex = 0;
            this.ico.TabStop = false;
            this.ico.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Computer_MouseClick);
            // 
            // 发送消息ToolStripMenuItem
            // 
            this.发送消息ToolStripMenuItem.Name = "发送消息ToolStripMenuItem";
            this.发送消息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.发送消息ToolStripMenuItem.Text = "发送消息";
            this.发送消息ToolStripMenuItem.Click += new System.EventHandler(this.发送消息ToolStripMenuItem_Click);
            // 
            // 试卷已收到ToolStripMenuItem
            // 
            this.试卷已收到ToolStripMenuItem.Name = "试卷已收到ToolStripMenuItem";
            this.试卷已收到ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.试卷已收到ToolStripMenuItem.Text = "试卷已收到";
            this.试卷已收到ToolStripMenuItem.Click += new System.EventHandler(this.试卷已收到ToolStripMenuItem_Click);
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
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ico;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.Label StuLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 重启计算机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发送消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 试卷已收到ToolStripMenuItem;
    }
}
