namespace OES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.xpPanelGroup1 = new UIComponents.XPPanelGroup();
            this.xpPanel3 = new UIComponents.XPPanel(127);
            this.scoreManlbl = new System.Windows.Forms.LinkLabel();
            this.techManlbl = new System.Windows.Forms.LinkLabel();
            this.classManlbl = new System.Windows.Forms.LinkLabel();
            this.stuManlbl = new System.Windows.Forms.LinkLabel();
            this.xpPanel2 = new UIComponents.XPPanel(122);
            this.llbBulkImport = new System.Windows.Forms.LinkLabel();
            this.llbProManage = new System.Windows.Forms.LinkLabel();
            this.llbNewPaper = new System.Windows.Forms.LinkLabel();
            this.paperManLbl = new System.Windows.Forms.LinkLabel();
            this.MainPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup1)).BeginInit();
            this.xpPanelGroup1.SuspendLayout();
            this.xpPanel3.SuspendLayout();
            this.xpPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpPanelGroup1
            // 
            this.xpPanelGroup1.AutoScroll = true;
            this.xpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelGroup1.Controls.Add(this.xpPanel3);
            this.xpPanelGroup1.Controls.Add(this.xpPanel2);
            this.xpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.xpPanelGroup1.Name = "xpPanelGroup1";
            this.xpPanelGroup1.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroup1.PanelGradient")));
            this.xpPanelGroup1.Size = new System.Drawing.Size(200, 680);
            this.xpPanelGroup1.TabIndex = 0;
            // 
            // xpPanel3
            // 
            this.xpPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel3.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel3.Caption = "人员管理";
            this.xpPanel3.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel3.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpPanel3.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpPanel3.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel3.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel3.Controls.Add(this.scoreManlbl);
            this.xpPanel3.Controls.Add(this.techManlbl);
            this.xpPanel3.Controls.Add(this.classManlbl);
            this.xpPanel3.Controls.Add(this.stuManlbl);
            this.xpPanel3.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel3.HorzAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel3.ImageItems.ImageSet = null;
            this.xpPanel3.Location = new System.Drawing.Point(8, 138);
            this.xpPanel3.Name = "xpPanel3";
            this.xpPanel3.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanel3.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanel3.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel3.Size = new System.Drawing.Size(184, 127);
            this.xpPanel3.TabIndex = 2;
            this.xpPanel3.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpPanel3.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpPanel3.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // scoreManlbl
            // 
            this.scoreManlbl.AutoSize = true;
            this.scoreManlbl.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold);
            this.scoreManlbl.Location = new System.Drawing.Point(7, 92);
            this.scoreManlbl.Name = "scoreManlbl";
            this.scoreManlbl.Size = new System.Drawing.Size(69, 19);
            this.scoreManlbl.TabIndex = 5;
            this.scoreManlbl.TabStop = true;
            this.scoreManlbl.Tag = "6";
            this.scoreManlbl.Text = "成绩管理";
            this.scoreManlbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // techManlbl
            // 
            this.techManlbl.AutoSize = true;
            this.techManlbl.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold);
            this.techManlbl.Location = new System.Drawing.Point(7, 73);
            this.techManlbl.Name = "techManlbl";
            this.techManlbl.Size = new System.Drawing.Size(69, 19);
            this.techManlbl.TabIndex = 4;
            this.techManlbl.TabStop = true;
            this.techManlbl.Tag = "5";
            this.techManlbl.Text = "教师管理";
            this.techManlbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // classManlbl
            // 
            this.classManlbl.AutoSize = true;
            this.classManlbl.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold);
            this.classManlbl.Location = new System.Drawing.Point(7, 54);
            this.classManlbl.Name = "classManlbl";
            this.classManlbl.Size = new System.Drawing.Size(69, 19);
            this.classManlbl.TabIndex = 3;
            this.classManlbl.TabStop = true;
            this.classManlbl.Tag = "4";
            this.classManlbl.Text = "班级管理";
            this.classManlbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // stuManlbl
            // 
            this.stuManlbl.AutoSize = true;
            this.stuManlbl.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold);
            this.stuManlbl.Location = new System.Drawing.Point(7, 35);
            this.stuManlbl.Name = "stuManlbl";
            this.stuManlbl.Size = new System.Drawing.Size(69, 19);
            this.stuManlbl.TabIndex = 2;
            this.stuManlbl.TabStop = true;
            this.stuManlbl.Tag = "3";
            this.stuManlbl.Text = "学生管理";
            this.stuManlbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // xpPanel2
            // 
            this.xpPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel2.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel2.Caption = "题库管理";
            this.xpPanel2.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel2.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpPanel2.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpPanel2.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel2.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel2.Controls.Add(this.llbBulkImport);
            this.xpPanel2.Controls.Add(this.llbProManage);
            this.xpPanel2.Controls.Add(this.llbNewPaper);
            this.xpPanel2.Controls.Add(this.paperManLbl);
            this.xpPanel2.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel2.HorzAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel2.ImageItems.ImageSet = null;
            this.xpPanel2.Location = new System.Drawing.Point(8, 8);
            this.xpPanel2.Name = "xpPanel2";
            this.xpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel2.Size = new System.Drawing.Size(184, 122);
            this.xpPanel2.TabIndex = 1;
            this.xpPanel2.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpPanel2.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpPanel2.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // llbBulkImport
            // 
            this.llbBulkImport.Location = new System.Drawing.Point(7, 96);
            this.llbBulkImport.Name = "llbBulkImport";
            this.llbBulkImport.Size = new System.Drawing.Size(69, 19);
            this.llbBulkImport.TabIndex = 4;
            this.llbBulkImport.TabStop = true;
            this.llbBulkImport.Tag = "9";
            this.llbBulkImport.Text = "批量导入";
            this.llbBulkImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // llbProManage
            // 
            this.llbProManage.AutoSize = true;
            this.llbProManage.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold);
            this.llbProManage.Location = new System.Drawing.Point(7, 39);
            this.llbProManage.Name = "llbProManage";
            this.llbProManage.Size = new System.Drawing.Size(69, 19);
            this.llbProManage.TabIndex = 3;
            this.llbProManage.TabStop = true;
            this.llbProManage.Tag = "0";
            this.llbProManage.Text = "试题管理";
            this.llbProManage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // llbNewPaper
            // 
            this.llbNewPaper.Location = new System.Drawing.Point(7, 77);
            this.llbNewPaper.Name = "llbNewPaper";
            this.llbNewPaper.Size = new System.Drawing.Size(69, 19);
            this.llbNewPaper.TabIndex = 0;
            this.llbNewPaper.TabStop = true;
            this.llbNewPaper.Tag = "2";
            this.llbNewPaper.Text = "新增试卷";
            this.llbNewPaper.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // paperManLbl
            // 
            this.paperManLbl.Location = new System.Drawing.Point(7, 58);
            this.paperManLbl.Name = "paperManLbl";
            this.paperManLbl.Size = new System.Drawing.Size(69, 19);
            this.paperManLbl.TabIndex = 1;
            this.paperManLbl.TabStop = true;
            this.paperManLbl.Tag = "1";
            this.paperManLbl.Text = "试卷管理";
            this.paperManLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(200, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(754, 680);
            this.MainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 680);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.xpPanelGroup1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(960, 705);
            this.MinimumSize = new System.Drawing.Size(960, 705);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OES服务端";
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup1)).EndInit();
            this.xpPanelGroup1.ResumeLayout(false);
            this.xpPanel3.ResumeLayout(false);
            this.xpPanel3.PerformLayout();
            this.xpPanel2.ResumeLayout(false);
            this.xpPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UIComponents.XPPanelGroup xpPanelGroup1;
        private UIComponents.XPPanel xpPanel3;
        private UIComponents.XPPanel xpPanel2;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.LinkLabel llbNewPaper;
        private System.Windows.Forms.LinkLabel paperManLbl;
        private System.Windows.Forms.LinkLabel stuManlbl;
        private System.Windows.Forms.LinkLabel classManlbl;
        private System.Windows.Forms.LinkLabel techManlbl;
        private System.Windows.Forms.LinkLabel scoreManlbl;
        private System.Windows.Forms.LinkLabel llbProManage;
        private System.Windows.Forms.LinkLabel llbBulkImport;

    }
}

