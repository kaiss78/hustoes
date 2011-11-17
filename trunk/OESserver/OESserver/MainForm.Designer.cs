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
            this.netState1 = new OES.NetState();
            this.xpPanel3 = new UIComponents.XPPanel(127);
            this.scoreManlbl = new System.Windows.Forms.LinkLabel();
            this.techManlbl = new System.Windows.Forms.LinkLabel();
            this.classManlbl = new System.Windows.Forms.LinkLabel();
            this.stuManlbl = new System.Windows.Forms.LinkLabel();
            this.xpPanel2 = new UIComponents.XPPanel(100);
            this.newPapLbl = new System.Windows.Forms.LinkLabel();
            this.paperManLbl = new System.Windows.Forms.LinkLabel();
            this.PMXP = new UIComponents.XPPanel(309);
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.choiceLbl = new System.Windows.Forms.LinkLabel();
            this.cfLbl = new System.Windows.Forms.LinkLabel();
            this.cmLbl = new System.Windows.Forms.LinkLabel();
            this.ccLbl = new System.Windows.Forms.LinkLabel();
            this.WordLbl = new System.Windows.Forms.LinkLabel();
            this.pptLbl = new System.Windows.Forms.LinkLabel();
            this.exlLbl = new System.Windows.Forms.LinkLabel();
            this.JudgeLbl = new System.Windows.Forms.LinkLabel();
            this.completionLbl = new System.Windows.Forms.LinkLabel();
            this.MainPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup1)).BeginInit();
            this.xpPanelGroup1.SuspendLayout();
            this.xpPanel3.SuspendLayout();
            this.xpPanel2.SuspendLayout();
            this.PMXP.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpPanelGroup1
            // 
            this.xpPanelGroup1.AutoScroll = true;
            this.xpPanelGroup1.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelGroup1.Controls.Add(this.netState1);
            this.xpPanelGroup1.Controls.Add(this.xpPanel3);
            this.xpPanelGroup1.Controls.Add(this.xpPanel2);
            this.xpPanelGroup1.Controls.Add(this.PMXP);
            this.xpPanelGroup1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xpPanelGroup1.Location = new System.Drawing.Point(0, 0);
            this.xpPanelGroup1.Name = "xpPanelGroup1";
            this.xpPanelGroup1.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroup1.PanelGradient")));
            this.xpPanelGroup1.Size = new System.Drawing.Size(200, 667);
            this.xpPanelGroup1.TabIndex = 0;
            // 
            // netState1
            // 
            this.netState1.BackColor = System.Drawing.Color.Transparent;
            this.netState1.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.netState1.Location = new System.Drawing.Point(-9, 631);
            this.netState1.Name = "netState1";
            this.netState1.Size = new System.Drawing.Size(206, 24);
            this.netState1.State = 0;
            this.netState1.TabIndex = 3;
            // 
            // xpPanel3
            // 
            this.xpPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel3.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel3.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel3.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpPanel3.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpPanel3.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel3.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel3.Controls.Add(this.scoreManlbl);
            this.xpPanel3.Controls.Add(this.techManlbl);
            this.xpPanel3.Controls.Add(this.classManlbl);
            this.xpPanel3.Controls.Add(this.stuManlbl);
            this.xpPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xpPanel3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel3.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel3.ImageItems.ImageSet = null;
            this.xpPanel3.Location = new System.Drawing.Point(8, 433);
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
            this.scoreManlbl.Tag = "17";
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
            this.techManlbl.Tag = "16";
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
            this.classManlbl.Tag = "15";
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
            this.stuManlbl.Tag = "14";
            this.stuManlbl.Text = "学生管理";
            this.stuManlbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // xpPanel2
            // 
            this.xpPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel2.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel2.Caption = "组卷管理";
            this.xpPanel2.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel2.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xpPanel2.CaptionGradient.Start = System.Drawing.Color.White;
            this.xpPanel2.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel2.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel2.Controls.Add(this.newPapLbl);
            this.xpPanel2.Controls.Add(this.paperManLbl);
            this.xpPanel2.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xpPanel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel2.HorzAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel2.ImageItems.ImageSet = null;
            this.xpPanel2.Location = new System.Drawing.Point(8, 325);
            this.xpPanel2.Name = "xpPanel2";
            this.xpPanel2.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanel2.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xpPanel2.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel2.Size = new System.Drawing.Size(184, 100);
            this.xpPanel2.TabIndex = 1;
            this.xpPanel2.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xpPanel2.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xpPanel2.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // newPapLbl
            // 
            this.newPapLbl.AutoSize = true;
            this.newPapLbl.Location = new System.Drawing.Point(6, 39);
            this.newPapLbl.Name = "newPapLbl";
            this.newPapLbl.Size = new System.Drawing.Size(59, 13);
            this.newPapLbl.TabIndex = 0;
            this.newPapLbl.TabStop = true;
            this.newPapLbl.Tag = "12";
            this.newPapLbl.Text = "新增试卷";
            this.newPapLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // paperManLbl
            // 
            this.paperManLbl.AutoSize = true;
            this.paperManLbl.Location = new System.Drawing.Point(6, 58);
            this.paperManLbl.Name = "paperManLbl";
            this.paperManLbl.Size = new System.Drawing.Size(59, 13);
            this.paperManLbl.TabIndex = 1;
            this.paperManLbl.TabStop = true;
            this.paperManLbl.Tag = "13";
            this.paperManLbl.Text = "试卷管理";
            this.paperManLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // PMXP
            // 
            this.PMXP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PMXP.BackColor = System.Drawing.Color.Transparent;
            this.PMXP.Caption = "题目管理";
            this.PMXP.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.PMXP.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.PMXP.CaptionGradient.Start = System.Drawing.Color.White;
            this.PMXP.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.PMXP.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PMXP.Controls.Add(this.linkLabel3);
            this.PMXP.Controls.Add(this.linkLabel2);
            this.PMXP.Controls.Add(this.linkLabel1);
            this.PMXP.Controls.Add(this.choiceLbl);
            this.PMXP.Controls.Add(this.cfLbl);
            this.PMXP.Controls.Add(this.cmLbl);
            this.PMXP.Controls.Add(this.ccLbl);
            this.PMXP.Controls.Add(this.WordLbl);
            this.PMXP.Controls.Add(this.pptLbl);
            this.PMXP.Controls.Add(this.exlLbl);
            this.PMXP.Controls.Add(this.JudgeLbl);
            this.PMXP.Controls.Add(this.completionLbl);
            this.PMXP.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PMXP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PMXP.HorzAlignment = System.Drawing.StringAlignment.Center;
            this.PMXP.ImageItems.ImageSet = null;
            this.PMXP.Location = new System.Drawing.Point(8, 8);
            this.PMXP.Margin = new System.Windows.Forms.Padding(2);
            this.PMXP.Name = "PMXP";
            this.PMXP.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.PMXP.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.PMXP.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.PMXP.Size = new System.Drawing.Size(184, 309);
            this.PMXP.TabIndex = 0;
            this.PMXP.Tag = "";
            this.PMXP.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.PMXP.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.PMXP.VertAlignment = System.Drawing.StringAlignment.Center;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(6, 245);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(81, 13);
            this.linkLabel3.TabIndex = 11;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Tag = "11";
            this.linkLabel3.Text = "程序C++编程";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(6, 226);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(81, 13);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Tag = "10";
            this.linkLabel2.Text = "程序C++改错";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 207);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(81, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "9";
            this.linkLabel1.Text = "程序C++填空";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // choiceLbl
            // 
            this.choiceLbl.AutoSize = true;
            this.choiceLbl.Location = new System.Drawing.Point(6, 39);
            this.choiceLbl.Name = "choiceLbl";
            this.choiceLbl.Size = new System.Drawing.Size(46, 13);
            this.choiceLbl.TabIndex = 0;
            this.choiceLbl.TabStop = true;
            this.choiceLbl.Tag = "0";
            this.choiceLbl.Text = "选择题";
            this.choiceLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // cfLbl
            // 
            this.cfLbl.AutoSize = true;
            this.cfLbl.Location = new System.Drawing.Point(6, 191);
            this.cfLbl.Name = "cfLbl";
            this.cfLbl.Size = new System.Drawing.Size(67, 13);
            this.cfLbl.TabIndex = 8;
            this.cfLbl.TabStop = true;
            this.cfLbl.Tag = "8";
            this.cfLbl.Text = "程序C编程";
            this.cfLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // cmLbl
            // 
            this.cmLbl.AutoSize = true;
            this.cmLbl.Location = new System.Drawing.Point(6, 172);
            this.cmLbl.Name = "cmLbl";
            this.cmLbl.Size = new System.Drawing.Size(67, 13);
            this.cmLbl.TabIndex = 7;
            this.cmLbl.TabStop = true;
            this.cmLbl.Tag = "7";
            this.cmLbl.Text = "程序C改错";
            this.cmLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // ccLbl
            // 
            this.ccLbl.AutoSize = true;
            this.ccLbl.Location = new System.Drawing.Point(6, 153);
            this.ccLbl.Name = "ccLbl";
            this.ccLbl.Size = new System.Drawing.Size(67, 13);
            this.ccLbl.TabIndex = 6;
            this.ccLbl.TabStop = true;
            this.ccLbl.Tag = "6";
            this.ccLbl.Text = "程序C填空";
            this.ccLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // WordLbl
            // 
            this.WordLbl.AutoSize = true;
            this.WordLbl.Location = new System.Drawing.Point(6, 134);
            this.WordLbl.Name = "WordLbl";
            this.WordLbl.Size = new System.Drawing.Size(46, 13);
            this.WordLbl.TabIndex = 5;
            this.WordLbl.TabStop = true;
            this.WordLbl.Tag = "5";
            this.WordLbl.Text = "字处理";
            this.WordLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // pptLbl
            // 
            this.pptLbl.AutoSize = true;
            this.pptLbl.Location = new System.Drawing.Point(6, 115);
            this.pptLbl.Name = "pptLbl";
            this.pptLbl.Size = new System.Drawing.Size(59, 13);
            this.pptLbl.TabIndex = 4;
            this.pptLbl.TabStop = true;
            this.pptLbl.Tag = "4";
            this.pptLbl.Text = "演示文稿";
            this.pptLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // exlLbl
            // 
            this.exlLbl.AutoSize = true;
            this.exlLbl.Location = new System.Drawing.Point(6, 96);
            this.exlLbl.Name = "exlLbl";
            this.exlLbl.Size = new System.Drawing.Size(59, 13);
            this.exlLbl.TabIndex = 3;
            this.exlLbl.TabStop = true;
            this.exlLbl.Tag = "3";
            this.exlLbl.Text = "电子表格";
            this.exlLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // JudgeLbl
            // 
            this.JudgeLbl.AutoSize = true;
            this.JudgeLbl.Location = new System.Drawing.Point(6, 77);
            this.JudgeLbl.Name = "JudgeLbl";
            this.JudgeLbl.Size = new System.Drawing.Size(46, 13);
            this.JudgeLbl.TabIndex = 2;
            this.JudgeLbl.TabStop = true;
            this.JudgeLbl.Tag = "2";
            this.JudgeLbl.Text = "判断题";
            this.JudgeLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // completionLbl
            // 
            this.completionLbl.AutoSize = true;
            this.completionLbl.Location = new System.Drawing.Point(6, 58);
            this.completionLbl.Name = "completionLbl";
            this.completionLbl.Size = new System.Drawing.Size(46, 13);
            this.completionLbl.TabIndex = 1;
            this.completionLbl.TabStop = true;
            this.completionLbl.Tag = "1";
            this.completionLbl.Text = "填空题";
            this.completionLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbl_LinkClicked);
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(200, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(744, 667);
            this.MainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 667);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.xpPanelGroup1);
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
            this.PMXP.ResumeLayout(false);
            this.PMXP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UIComponents.XPPanelGroup xpPanelGroup1;
        private UIComponents.XPPanel xpPanel3;
        private UIComponents.XPPanel xpPanel2;
        private UIComponents.XPPanel PMXP;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.LinkLabel cfLbl;
        private System.Windows.Forms.LinkLabel cmLbl;
        private System.Windows.Forms.LinkLabel ccLbl;
        private System.Windows.Forms.LinkLabel WordLbl;
        private System.Windows.Forms.LinkLabel pptLbl;
        private System.Windows.Forms.LinkLabel exlLbl;
        private System.Windows.Forms.LinkLabel JudgeLbl;
        private System.Windows.Forms.LinkLabel completionLbl;
        private System.Windows.Forms.LinkLabel choiceLbl;
        private System.Windows.Forms.LinkLabel newPapLbl;
        private System.Windows.Forms.LinkLabel paperManLbl;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel stuManlbl;
        private System.Windows.Forms.LinkLabel classManlbl;
        private System.Windows.Forms.LinkLabel techManlbl;
        private System.Windows.Forms.LinkLabel scoreManlbl;
        private NetState netState1;

    }
}

