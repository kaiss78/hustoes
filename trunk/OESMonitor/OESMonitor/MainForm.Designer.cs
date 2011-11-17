namespace OESMonitor
{
    partial class OESMonitor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OESMonitor));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.netState1 = new OES.NetState();
            this.label5 = new System.Windows.Forms.Label();
            this.lab_DataPortCount = new System.Windows.Forms.Label();
            this.buttonExamStatue = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.downloadButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.helpLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.PaperListDGV = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnGetPaperFromDB = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRemove = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBoxServerIp = new System.Windows.Forms.GroupBox();
            this.groupBoxClientIp = new System.Windows.Forms.GroupBox();
            this.groupBoxBroadcast = new System.Windows.Forms.GroupBox();
            this.buttonBroadcastRepeat = new System.Windows.Forms.Button();
            this.buttonBroadcastOnce = new System.Windows.Forms.Button();
            this.labelRangeIp = new System.Windows.Forms.Label();
            this.textBoxEndIp = new System.Windows.Forms.TextBox();
            this.textBoxStartIp = new System.Windows.Forms.TextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.groupBoxDb = new System.Windows.Forms.GroupBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBoxPass = new System.Windows.Forms.GroupBox();
            this.timer_PortCounter = new System.Windows.Forms.Timer(this.components);
            this.timer_Broadcast = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaperListDGV)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBoxBroadcast.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 33);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(589, 398);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(652, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 385);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "考试状态";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 473);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(618, 445);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "在线考生";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(618, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "考试完成考生";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(21, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "考试状态";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(18, 33);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(589, 398);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.flowLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(618, 445);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "断开连接考生";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(21, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "考试状态";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoScroll = true;
            this.flowLayoutPanel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(18, 33);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(589, 398);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(878, 495);
            this.tabControl2.TabIndex = 5;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.netState1);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.lab_DataPortCount);
            this.tabPage4.Controls.Add(this.buttonExamStatue);
            this.tabPage4.Controls.Add(this.tabControl1);
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.Location = new System.Drawing.Point(25, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(849, 487);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "考试状态";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // netState1
            // 
            this.netState1.BackColor = System.Drawing.Color.Transparent;
            this.netState1.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.netState1.Location = new System.Drawing.Point(636, 3);
            this.netState1.Name = "netState1";
            this.netState1.Size = new System.Drawing.Size(213, 26);
            this.netState1.State = 0;
            this.netState1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(652, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "数据端口数量：";
            // 
            // lab_DataPortCount
            // 
            this.lab_DataPortCount.AutoSize = true;
            this.lab_DataPortCount.Location = new System.Drawing.Point(763, 459);
            this.lab_DataPortCount.Name = "lab_DataPortCount";
            this.lab_DataPortCount.Size = new System.Drawing.Size(35, 14);
            this.lab_DataPortCount.TabIndex = 6;
            this.lab_DataPortCount.Text = "未知";
            // 
            // buttonExamStatue
            // 
            this.buttonExamStatue.Location = new System.Drawing.Point(652, 31);
            this.buttonExamStatue.Name = "buttonExamStatue";
            this.buttonExamStatue.Size = new System.Drawing.Size(184, 30);
            this.buttonExamStatue.TabIndex = 5;
            this.buttonExamStatue.Text = "开始考试/发卷";
            this.buttonExamStatue.UseVisualStyleBackColor = true;
            this.buttonExamStatue.Click += new System.EventHandler(this.buttonExamStatue_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.downloadButton);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Controls.Add(this.PaperListDGV);
            this.tabPage5.Controls.Add(this.btnGetPaperFromDB);
            this.tabPage5.Controls.Add(this.btnRemove);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Location = new System.Drawing.Point(25, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(849, 487);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "考卷选择";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(707, 320);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(123, 50);
            this.downloadButton.TabIndex = 6;
            this.downloadButton.Values.Text = "下载试卷";
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.helpLabel);
            this.groupBox2.Location = new System.Drawing.Point(580, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 114);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "帮助";
            // 
            // helpLabel
            // 
            this.helpLabel.AutoEllipsis = true;
            this.helpLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.helpLabel.Location = new System.Drawing.Point(3, 19);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(205, 92);
            this.helpLabel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(580, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 150);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "试卷随机方式";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(41, 108);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(158, 18);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "2";
            this.radioButton3.Text = "用单一试卷-双击试卷";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.MouseLeave += new System.EventHandler(this.radioButton1_MouseLeave);
            this.radioButton3.MouseEnter += new System.EventHandler(this.radioButton3_MouseEnter);
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(41, 70);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(109, 18);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "1";
            this.radioButton2.Text = "随机选取试卷";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.MouseLeave += new System.EventHandler(this.radioButton1_MouseLeave);
            this.radioButton2.MouseEnter += new System.EventHandler(this.radioButton2_MouseEnter);
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(41, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(109, 18);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "0";
            this.radioButton1.Text = "顺序选取试卷";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.MouseLeave += new System.EventHandler(this.radioButton1_MouseLeave);
            this.radioButton1.MouseEnter += new System.EventHandler(this.radioButton1_MouseEnter);
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // PaperListDGV
            // 
            this.PaperListDGV.AllowUserToAddRows = false;
            this.PaperListDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.PaperListDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PaperListDGV.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.PaperListDGV.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonNavigatorMini;
            this.PaperListDGV.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.PaperListDGV.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.PaperListDGV.Location = new System.Drawing.Point(18, 34);
            this.PaperListDGV.Name = "PaperListDGV";
            this.PaperListDGV.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.PaperListDGV.ReadOnly = true;
            this.PaperListDGV.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PaperListDGV.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.PaperListDGV.RowTemplate.Height = 23;
            this.PaperListDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PaperListDGV.Size = new System.Drawing.Size(527, 434);
            this.PaperListDGV.TabIndex = 3;
            // 
            // btnGetPaperFromDB
            // 
            this.btnGetPaperFromDB.Location = new System.Drawing.Point(580, 400);
            this.btnGetPaperFromDB.Name = "btnGetPaperFromDB";
            this.btnGetPaperFromDB.Size = new System.Drawing.Size(250, 50);
            this.btnGetPaperFromDB.TabIndex = 2;
            this.btnGetPaperFromDB.Values.Text = "从数据库获取获取试卷>>>";
            this.btnGetPaperFromDB.Click += new System.EventHandler(this.btnGetPaperFromDB_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(580, 320);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 50);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Values.Text = "移除选中试卷";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "本场考试试卷列表";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.tabControl3);
            this.tabPage6.Location = new System.Drawing.Point(25, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(849, 487);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "监考设置";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Location = new System.Drawing.Point(16, 7);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(812, 461);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBoxServerIp);
            this.tabPage7.Controls.Add(this.groupBoxClientIp);
            this.tabPage7.Controls.Add(this.groupBoxBroadcast);
            this.tabPage7.Location = new System.Drawing.Point(4, 24);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(804, 433);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "网络设置";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBoxServerIp
            // 
            this.groupBoxServerIp.Location = new System.Drawing.Point(7, 18);
            this.groupBoxServerIp.Name = "groupBoxServerIp";
            this.groupBoxServerIp.Size = new System.Drawing.Size(383, 185);
            this.groupBoxServerIp.TabIndex = 2;
            this.groupBoxServerIp.TabStop = false;
            this.groupBoxServerIp.Text = "监考Ip端口设置";
            // 
            // groupBoxClientIp
            // 
            this.groupBoxClientIp.Location = new System.Drawing.Point(414, 18);
            this.groupBoxClientIp.Name = "groupBoxClientIp";
            this.groupBoxClientIp.Size = new System.Drawing.Size(376, 185);
            this.groupBoxClientIp.TabIndex = 1;
            this.groupBoxClientIp.TabStop = false;
            this.groupBoxClientIp.Text = "服务器Ip端口设置";
            // 
            // groupBoxBroadcast
            // 
            this.groupBoxBroadcast.Controls.Add(this.buttonBroadcastRepeat);
            this.groupBoxBroadcast.Controls.Add(this.buttonBroadcastOnce);
            this.groupBoxBroadcast.Controls.Add(this.labelRangeIp);
            this.groupBoxBroadcast.Controls.Add(this.textBoxEndIp);
            this.groupBoxBroadcast.Controls.Add(this.textBoxStartIp);
            this.groupBoxBroadcast.Location = new System.Drawing.Point(7, 219);
            this.groupBoxBroadcast.Name = "groupBoxBroadcast";
            this.groupBoxBroadcast.Size = new System.Drawing.Size(783, 187);
            this.groupBoxBroadcast.TabIndex = 0;
            this.groupBoxBroadcast.TabStop = false;
            this.groupBoxBroadcast.Text = "广播本机Ip";
            // 
            // buttonBroadcastRepeat
            // 
            this.buttonBroadcastRepeat.Location = new System.Drawing.Point(328, 120);
            this.buttonBroadcastRepeat.Name = "buttonBroadcastRepeat";
            this.buttonBroadcastRepeat.Size = new System.Drawing.Size(139, 23);
            this.buttonBroadcastRepeat.TabIndex = 4;
            this.buttonBroadcastRepeat.Text = "每10s广播一次";
            this.buttonBroadcastRepeat.UseVisualStyleBackColor = true;
            this.buttonBroadcastRepeat.Click += new System.EventHandler(this.buttonBroadcastRepeat_Click);
            // 
            // buttonBroadcastOnce
            // 
            this.buttonBroadcastOnce.Location = new System.Drawing.Point(105, 120);
            this.buttonBroadcastOnce.Name = "buttonBroadcastOnce";
            this.buttonBroadcastOnce.Size = new System.Drawing.Size(75, 23);
            this.buttonBroadcastOnce.TabIndex = 3;
            this.buttonBroadcastOnce.Text = "广播一次";
            this.buttonBroadcastOnce.UseVisualStyleBackColor = true;
            this.buttonBroadcastOnce.Click += new System.EventHandler(this.buttonBroadcastOnce_Click);
            // 
            // labelRangeIp
            // 
            this.labelRangeIp.AutoSize = true;
            this.labelRangeIp.Location = new System.Drawing.Point(41, 46);
            this.labelRangeIp.Name = "labelRangeIp";
            this.labelRangeIp.Size = new System.Drawing.Size(77, 14);
            this.labelRangeIp.TabIndex = 2;
            this.labelRangeIp.Text = "广播Ip区间";
            // 
            // textBoxEndIp
            // 
            this.textBoxEndIp.Location = new System.Drawing.Point(281, 72);
            this.textBoxEndIp.Name = "textBoxEndIp";
            this.textBoxEndIp.Size = new System.Drawing.Size(211, 23);
            this.textBoxEndIp.TabIndex = 1;
            // 
            // textBoxStartIp
            // 
            this.textBoxStartIp.Location = new System.Drawing.Point(45, 72);
            this.textBoxStartIp.Name = "textBoxStartIp";
            this.textBoxStartIp.Size = new System.Drawing.Size(211, 23);
            this.textBoxStartIp.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.groupBoxPath);
            this.tabPage8.Controls.Add(this.groupBoxDb);
            this.tabPage8.Location = new System.Drawing.Point(4, 24);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(804, 433);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "数据库和文件夹设置";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Location = new System.Drawing.Point(392, 6);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(392, 421);
            this.groupBoxPath.TabIndex = 1;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "文件夹路径设置";
            // 
            // groupBoxDb
            // 
            this.groupBoxDb.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDb.Name = "groupBoxDb";
            this.groupBoxDb.Size = new System.Drawing.Size(371, 421);
            this.groupBoxDb.TabIndex = 0;
            this.groupBoxDb.TabStop = false;
            this.groupBoxDb.Text = "数据库设置";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.groupBoxPass);
            this.tabPage9.Location = new System.Drawing.Point(4, 24);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(804, 433);
            this.tabPage9.TabIndex = 2;
            this.tabPage9.Text = "重考密码设置";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBoxPass
            // 
            this.groupBoxPass.Location = new System.Drawing.Point(206, 6);
            this.groupBoxPass.Name = "groupBoxPass";
            this.groupBoxPass.Size = new System.Drawing.Size(392, 421);
            this.groupBoxPass.TabIndex = 2;
            this.groupBoxPass.TabStop = false;
            this.groupBoxPass.Text = "重考密码设置";
            // 
            // timer_PortCounter
            // 
            this.timer_PortCounter.Tick += new System.EventHandler(this.timer_PortCounter_Tick);
            // 
            // timer_Broadcast
            // 
            this.timer_Broadcast.Tick += new System.EventHandler(this.timer_Broadcast_Tick);
            // 
            // OESMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(878, 495);
            this.Controls.Add(this.tabControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OESMonitor";
            this.Text = "OESMonitor";
            this.Load += new System.EventHandler(this.OESMonitor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaperListDGV)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.groupBoxBroadcast.ResumeLayout(false);
            this.groupBoxBroadcast.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGetPaperFromDB;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRemove;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView PaperListDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Button buttonExamStatue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lab_DataPortCount;
        private System.Windows.Forms.Timer timer_PortCounter;
        private ComponentFactory.Krypton.Toolkit.KryptonButton downloadButton;
        private OES.NetState netState1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.GroupBox groupBoxClientIp;
        private System.Windows.Forms.GroupBox groupBoxBroadcast;
        private System.Windows.Forms.GroupBox groupBoxServerIp;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.GroupBox groupBoxDb;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.GroupBox groupBoxPass;
        private System.Windows.Forms.Label labelRangeIp;
        private System.Windows.Forms.TextBox textBoxEndIp;
        private System.Windows.Forms.TextBox textBoxStartIp;
        private System.Windows.Forms.Button buttonBroadcastRepeat;
        private System.Windows.Forms.Button buttonBroadcastOnce;
        private System.Windows.Forms.Timer timer_Broadcast;

    }
}

