namespace MainWindow
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.判断题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.word操作题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerPoint操作题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excel操作题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.c改错题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c填空题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c综合题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.problemsList1 = new PublicControl.ProblemsList();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开aToolStripMenuItem,
            this.toolStripMenuItem1,
            this.判断题ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.word操作题ToolStripMenuItem,
            this.powerPoint操作题ToolStripMenuItem,
            this.excel操作题ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.c改错题ToolStripMenuItem,
            this.c填空题ToolStripMenuItem,
            this.c综合题ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.文件ToolStripMenuItem.Text = "考试项目";
            // 
            // 打开aToolStripMenuItem
            // 
            this.打开aToolStripMenuItem.Name = "打开aToolStripMenuItem";
            this.打开aToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.打开aToolStripMenuItem.Text = "选择题(&a)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem1.Text = "填空题";
            // 
            // 判断题ToolStripMenuItem
            // 
            this.判断题ToolStripMenuItem.Name = "判断题ToolStripMenuItem";
            this.判断题ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.判断题ToolStripMenuItem.Text = "判断题";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(163, 6);
            // 
            // word操作题ToolStripMenuItem
            // 
            this.word操作题ToolStripMenuItem.Name = "word操作题ToolStripMenuItem";
            this.word操作题ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.word操作题ToolStripMenuItem.Text = "word操作题";
            // 
            // powerPoint操作题ToolStripMenuItem
            // 
            this.powerPoint操作题ToolStripMenuItem.Name = "powerPoint操作题ToolStripMenuItem";
            this.powerPoint操作题ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.powerPoint操作题ToolStripMenuItem.Text = "PowerPoint操作题";
            // 
            // excel操作题ToolStripMenuItem
            // 
            this.excel操作题ToolStripMenuItem.Name = "excel操作题ToolStripMenuItem";
            this.excel操作题ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.excel操作题ToolStripMenuItem.Text = "excel操作题";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(163, 6);
            // 
            // c改错题ToolStripMenuItem
            // 
            this.c改错题ToolStripMenuItem.Name = "c改错题ToolStripMenuItem";
            this.c改错题ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.c改错题ToolStripMenuItem.Text = "c++改错题";
            // 
            // c填空题ToolStripMenuItem
            // 
            this.c填空题ToolStripMenuItem.Name = "c填空题ToolStripMenuItem";
            this.c填空题ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.c填空题ToolStripMenuItem.Text = "c++填空题";
            // 
            // c综合题ToolStripMenuItem
            // 
            this.c综合题ToolStripMenuItem.Name = "c综合题ToolStripMenuItem";
            this.c综合题ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.c综合题ToolStripMenuItem.Text = "c++综合题";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(163, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.退出ToolStripMenuItem.Text = "浏览考生文件夹";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(892, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel1.Text = "考生文件夹：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabel2.Text = "路径";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl.Location = new System.Drawing.Point(3, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(792, 518);
            this.tabControl.TabIndex = 1;
            // 
            // problemsList1
            // 
            this.problemsList1.Location = new System.Drawing.Point(798, 49);
            this.problemsList1.Name = "problemsList1";
            this.problemsList1.Size = new System.Drawing.Size(74, 489);
            this.problemsList1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 566);
            this.Controls.Add(this.problemsList1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.Text = "OES";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 判断题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem word操作题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powerPoint操作题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excel操作题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem c改错题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c填空题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c综合题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TabControl tabControl;
        private PublicControl.ProblemsList problemsList1;

    }
}

