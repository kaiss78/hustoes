using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using OESMonitor.Net;
using System.Net;
using System.IO;
using ServerNet;
using ClientNet;
using OES;
using OESNet.UdpNet;
using System.Diagnostics;
using OES.Model;
using System.Threading;

namespace OESMonitor
{
    public partial class OESMonitor : Form
    {
        CommandLine cl = new CommandLine("Client2Monitor.log");
        List<IPAddress> alternativeIp = new List<IPAddress>();
        public static int paperDeliverMode = 0;
        /// <summary>
        /// 若当前为顺序发试卷，表示已经发卷的Id，是循环变化的
        /// </summary>
        public static int currentDeliverId = 0;
        /// <summary>
        /// 若当前为随机发试卷，用于产生随机数
        /// </summary>
        public static Random random = new Random(DateTime.Now.Millisecond);
        /// <summary>
        /// 当前考试的试卷列表
        /// </summary>
        public static List<int> examPaperIdList = new List<int>();
        public static List<string> examPaperNameList = new List<string>();

        //统一收卷的事件
        public static int HandInCount = 0;
        private static event Action handInPaper;
        public static event Action HandInPaper
        {
            add
            {
                handInPaper += value;
            }
            remove
            {
                handInPaper -= value;
            }
        }

        //是否开始考试
        bool isStartExam = false;
        public bool IsStartExam
        {
            get { return isStartExam; }
            set
            {
                isStartExam = value;
                if (isStartExam)
                {
                    if (examPaperIdList.Count == 0)
                    {
                    }
                    else
                    {
                        ServerEvt.Server.IsPortAvailable = true;
                        buttonExamStatue.Text = "停止发卷/发卷";
                        timer_PortCounter.Start();
                        numericUpDown1.Enabled = false;
                        PaperControl.TestTime = (int)numericUpDown1.Value;
                    }
                }
                else
                {
                    buttonExamStatue.Text = "开始考试/收卷";
                    numericUpDown1.Enabled = true;
                    if (handInPaper != null)
                    {
                        handInPaper();
                    }
                    else
                    {
                        ServerEvt.Server.IsPortAvailable = false;
                        timer_PortCounter.Stop();
                    }
                }
            }
        }

        public static DataTable paperListDataTable;

        public static Net.ClientEvt supportServer;

        #region 配置文件-界面对象
        private ConfigEditor serverConfig = new ConfigEditor("ServerConfig.xml");

        private ConfigEditor clientConfig = new ConfigEditor("ClientConfig.xml");

        private ConfigEditor pathConfig = new ConfigEditor("PathConfig.xml");

        private ConfigEditor passConfig = new ConfigEditor("PwdConfig.xml");

        private ConfigEditor dbConfig = new ConfigEditor("DbConfig.xml");
        #endregion

        public OESMonitor()
        {
            InitializeComponent();

            #region 配置控件初始化
            groupBoxServerIp.Controls.Add(serverConfig);
            serverConfig.Dock = DockStyle.Fill;
            serverConfig.Show();

            groupBoxClientIp.Controls.Add(clientConfig);
            clientConfig.Dock = DockStyle.Fill;
            clientConfig.Show();

            groupBoxDb.Controls.Add(dbConfig);
            dbConfig.Dock = DockStyle.Fill;
            dbConfig.Show();

            groupBoxPass.Controls.Add(passConfig);
            passConfig.Dock = DockStyle.Fill;
            passConfig.Show();

            groupBoxPath.Controls.Add(pathConfig);
            pathConfig.Dock = DockStyle.Fill;
            pathConfig.Show();
            #endregion

            #region 网络连接状态初始化
            netState1.ReConnect += new EventHandler(netState1_ReConnect);
            this.netState1.State = 2;
            supportServer = new Net.ClientEvt();
            #endregion

            #region 网络通信事件加载
            supportServer.Client.FileListRecieveStart += new Action(Client_FileListRecieveStart);
            supportServer.Client.FileListRecieveEnd += new Action(Client_FileListRecieveEnd);
            supportServer.Client.FileListCount += new FileListSize(Client_FileListCount);
            supportServer.Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
            supportServer.Client.DisConnectError += new ErrorEventHandler(Client_DisConnectError);
            supportServer.Client.FileError += new ErrorEventHandler(Client_FileError);
            supportServer.Client.InitializeClient();
            supportServer.Client.Port.RecieveFileRate += new ClientNet.ReturnVal(Port_RecieveFileRate);
            #endregion

            timer_PortCounter.Interval = 1000;

            panel1.Controls.Add(ComputerState.getInstance());

            paperListDataTable = new DataTable("PaperList");
            paperListDataTable.Columns.Add("选中", typeof(bool));
            paperListDataTable.Columns.Add("试卷ID");
            paperListDataTable.Columns.Add("试卷名称");
            paperListDataTable.Columns.Add("组卷时间");
            paperListDataTable.Columns.Add("作者");
            PaperListDGV.DataSource = paperListDataTable;
            PaperListDGV.CellClick += new DataGridViewCellEventHandler(PaperListDGV_CellClick);
            PaperListDGV.CellDoubleClick += new DataGridViewCellEventHandler(PaperListDGV_CellDoubleClick);
            PaperListDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PaperListDGV.CellValueChanged += new DataGridViewCellEventHandler(PaperListDGV_CellValueChanged);
            PaperListDGV.RowsAdded += new DataGridViewRowsAddedEventHandler(PaperListDGV_RowsAdded);
            btnRemove.MouseEnter += new EventHandler(btnRemove_MouseEnter);
            btnRemove.MouseLeave += new EventHandler(radioButton1_MouseLeave);
            btnRemove.Click += new EventHandler(btnRemove_Click);
            btnGetPaperFromDB.MouseEnter += new EventHandler(btnGetPaperFromDB_MouseEnter);
            btnGetPaperFromDB.MouseLeave += new EventHandler(radioButton1_MouseLeave);
            downloadButton.MouseEnter += new EventHandler(downloadButton_MouseEnter);
            downloadButton.MouseLeave += new EventHandler(radioButton1_MouseLeave);

            #region 考试答案文件夹监视管理
            if (!Directory.Exists(PaperControl.PathConfig["StuAns"]))
            {
                Directory.CreateDirectory(PaperControl.PathConfig["StuAns"]);
            }
            fileSystemWatcher.Path = PaperControl.PathConfig["StuAns"];
            fileSystemWatcher.Changed += new FileSystemEventHandler(fileSystemWatcher_Changed);
            fileSystemWatcher.Deleted += new FileSystemEventHandler(fileSystemWatcher_Changed);
            fileSystemWatcher.Renamed += new RenamedEventHandler(fileSystemWatcher_Renamed);
            fileSystemWatcher.Created += new FileSystemEventHandler(fileSystemWatcher_Changed);
            fileSystemWatcher.EnableRaisingEvents = true;
            //foreach (string path in Directory.GetDirectories(PaperControl.PathConfig["StuAns"]))
            foreach (string path in Directory.GetFiles(PaperControl.PathConfig["StuAns"]))
            {
                StudentAnsDirectory studentAnsDirectory = new StudentAnsDirectory(path);
                studentAnsDirectory.OnView += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnView);
                studentAnsDirectory.OnDelete += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnDelete);
                flowLayoutPanelDir.Controls.Add(studentAnsDirectory);
            }
            #endregion

        }

        private void OESMonitor_Load(object sender, EventArgs e)
        {
            cl.Text = "与客户端（client）的通信命令";
            cl.Show();

            if (!Directory.Exists(PaperControl.PathConfig["StuAns"]))
            {
                try
                {
                    Directory.CreateDirectory(PaperControl.PathConfig["StuAns"]);
                }
                catch
                {
                    MessageBox.Show("无法建立考生答案文件夹");
                    return;
                }
            }
            if (!Directory.Exists(PaperControl.PathConfig["StuRarKey"]))
            {
                try
                {
                    Directory.CreateDirectory(PaperControl.PathConfig["StuRarKey"]);
                }
                catch
                {
                    MessageBox.Show("无法建立考生答案密码文件夹");
                    return;
                }
            }
            if (!Directory.Exists(PaperControl.PathConfig["TmpPaper"]))
            {
                try
                {
                    Directory.CreateDirectory(PaperControl.PathConfig["TmpPaper"]);
                }
                catch
                {
                    MessageBox.Show("无法建立临时考卷文件夹");
                    return;
                }
            }

            ServerEvt.Server.AcceptedClient += new EventHandler(Server_AcceptedClient);
            ServerEvt.Server.FileReceiveEnd += new DataPortEventHandler(Server_FileReceiveEnd);
            ServerEvt.Server.FileSendEnd += new DataPortEventHandler(Server_FileSendEnd);
            ServerEvt.Server.SendDataReady += new ClientEventHandel(Server_SendDataReady);
            ServerEvt.Server.ReceivedMsg += new ClientEventHandel(Server_ReceivedMsg);
            ServerEvt.Server.WrittenMsg += new ClientEventHandel(Server_WrittenMsg);
            RetrieveHostIpv4Address();

            if (alternativeIp.Count == 0)
            {
                MessageBox.Show("无正确的Ipv4网络连接！");
            }
            else if (alternativeIp.Count == 1)
            {
                ServerEvt.Server.ip = alternativeIp[0];
                ServerEvt.Server.StartServer();
                OESServer.Config["HostIp"] = ServerEvt.Server.ip.ToString();
            }
            else if (alternativeIp.Count > 1)
            {
                ServerEvt.Server.ip = ChooseIp.CurrentForm(alternativeIp).ShowDialog(this);
                ServerEvt.Server.StartServer();
                OESServer.Config["HostIp"] = ServerEvt.Server.ip.ToString();
            }
            else
            {
                ServerEvt.Server.StartServer();
            }
            IsStartExam = false;

            string[] ips = ServerEvt.Server.ip.ToString().Split('.');
            textBoxStartIp.Text = ips[0] + "." + ips[1] + "." + ips[2] + "." + "1";
            textBoxEndIp.Text = ips[0] + "." + ips[1] + "." + ips[2] + "." + "254";
        }

        private void RetrieveHostIpv4Address()
        {
            //获得所有的ip地址，包括ipv6和ipv4
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress tip in ips)
            {
                //ipv4的最大长度为15，ipv6为39
                if (tip.ToString().Length <= 15)
                {
                    alternativeIp.Add(tip);
                }
            }
        }

        #region 试卷文件夹管理Tab
        #region 考生文件夹操作
        void studentAnsDirectory_OnDelete(StudentAnsDirectory e)
        {
            //Directory.Delete(PaperControl.PathConfig["StuAns"] + e.Text, true);
            File.Delete(PaperControl.PathConfig["StuAns"] + e.Text + ".rar");
        }

        void studentAnsDirectory_OnView(StudentAnsDirectory e)
        {
            Process.Start(PaperControl.PathConfig["StuAns"] + e.Text + ".rar");
        }
        #endregion

        #region 考生答案文件夹监视事件
        void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            flowLayoutPanelDir.Controls.Clear();
            //foreach (string path in Directory.GetDirectories(PaperControl.PathConfig["StuAns"]))
            foreach (string path in Directory.GetFiles(PaperControl.PathConfig["StuAns"]))
            {
                StudentAnsDirectory studentAnsDirectory = new StudentAnsDirectory(path);
                studentAnsDirectory.OnView += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnView);
                studentAnsDirectory.OnDelete += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnDelete);
                flowLayoutPanelDir.Controls.Add(studentAnsDirectory);
            }
        }

        void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (tabControl2.SelectedIndex == 4)
            {
                flowLayoutPanelDir.Controls.Clear();
                //foreach (string path in Directory.GetDirectories(PaperControl.PathConfig["StuAns"]))
                foreach (string path in Directory.GetFiles(PaperControl.PathConfig["StuAns"]))
                {
                    StudentAnsDirectory studentAnsDirectory = new StudentAnsDirectory(path);
                    studentAnsDirectory.OnView += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnView);
                    studentAnsDirectory.OnDelete += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnDelete);
                    flowLayoutPanelDir.Controls.Add(studentAnsDirectory);
                }
            }
        }
        #endregion
        #endregion

        #region 考试状态Tab
        #region 网络连接状态
        void Client_DisConnectError(object sender, ErrorEventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                netState1.State = 0;
                if (FileListWaiting.Instance != null && !FileListWaiting.Instance.IsDisposed)
                {
                    FileListWaiting.Instance.Close();
                    this.Enabled = true;
                    MessageBox.Show("试卷下载出错！");
                }
            }));
        }

        void Client_ConnectedServer(object sender, EventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                netState1.State = 1;
            }));
        }

        void netState1_ReConnect(object sender, EventArgs e)
        {
            if (netState1.State == 0)
            {
                supportServer.Client.InitializeClient();
            }
            else
            {
                netState1.State = 0;
            }
        }

        void Client_FileError(object sender, ErrorEventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (FileListWaiting.Instance != null && !FileListWaiting.Instance.IsDisposed)
                {
                    FileListWaiting.Instance.Close();
                    this.Enabled = true;
                    MessageBox.Show("试卷下载出错！");
                }
            }));
        }
        #endregion
        #region 添加一个电脑
        public void AddComputer(Client client)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                Computer com = new Computer();
                com.CreateControl();
                com.State = 1;
                com.Client = client;
                com.OnErrorConnect += new System.IO.ErrorEventHandler(com_OnErrorConnect);
                lock (Computer.syncComputerList)
                {
                    Computer.ComputerList.Add(com);
                }
                AddToFlp(flp_Onexam, com);
            }));
        }
        #endregion
        #region 更新界面上的电脑图标
        private void AddToFlp(FlowLayoutPanel f, Computer c)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (tabControl2.SelectedIndex == 0)
                {
                    f.Controls.Add(c);
                }
            }));
        }
        private void RemoveFromFlp(FlowLayoutPanel f, Computer c)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (tabControl2.SelectedIndex == 0)
                {
                    f.Controls.Remove(c);
                }
            }));
        }
        private void UpdateList()
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (tabControl2.SelectedIndex == 0)
                {
                    flp_Onexam.Controls.Clear();
                    lock (Computer.syncComputerList)
                    {
                        foreach (Computer c in Computer.ComputerList)
                        {
                            flp_Onexam.Controls.Add(c);
                        }
                    }
                }
            }));
        }
        private void UpdateCompleteList()
        {

            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (tabControl2.SelectedIndex == 0)
                {
                    flp_CompleteExam.Controls.Clear();
                    lock (Computer.syncCompleteList)
                    {
                        foreach (Computer c in Computer.CompleteList)
                        {
                            flp_CompleteExam.Controls.Add(c);
                        }
                    }
                }
            }));

        }
        private void UpdateErrorList()
        {
            
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (tabControl2.SelectedIndex == 0)
                {
                    flp_Disconnect.Controls.Clear();
                    lock (Computer.syncErrorList)
                    {
                        foreach (Computer c in Computer.ErrorList)
                        {
                            flp_Disconnect.Controls.Add(c);
                        }
                    }
                }
            }));
            
        }
        #endregion
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComputerState.getInstance().InfoClear();
        }
        void com_OnErrorConnect(object sender, System.IO.ErrorEventArgs e)
        {
            UpdateList();
            UpdateErrorList();
        }
        //点击开始考试按钮
        private void buttonExamStatue_Click(object sender, EventArgs e)
        {
            if (netState1.State == 1)
            {
                if (!IsStartExam)
                {
                    bool isExistPaper = true;
                    foreach (DataRow dr in paperListDataTable.Rows)
                    {
                        string id = dr[1].ToString();
                        if (!File.Exists(PaperControl.PathConfig["TmpPaper"] + id + ".rar"))
                        {
                            isExistPaper = false;
                        }
                    }
                    if (isExistPaper && examPaperIdList.Count != 0)
                    {
                        IsStartExam = true;
                    }
                    else
                    {
                        helpLabel.Text = "您没有选择考试试卷 或者 您还有部分试卷未下载，请点击“下载试卷”";
                        MessageBox.Show(helpLabel.Text);
                        tabControl2.SelectedIndex = 1;
                    }
                }
                else
                {

                    IsStartExam = false;
                }
            }
            else
            {
                MessageBox.Show("未连接上服务器,不能开始考试!");
            }
        }
        //Timer间隔显示数据端口数量
        private void timer_PortCounter_Tick(object sender, EventArgs e)
        {
            lab_DataPortCount.Text = Net.ServerEvt.Server.PortCurNum.ToString();
        }
        #endregion

        #region 考卷选择Tab
        #region 文字功能提示
        void btnGetPaperFromDB_MouseEnter(object sender, EventArgs e)
        {
            helpLabel.Text = @"打开新的窗口，到数据库里面取需要考试的试卷";
        }

        void btnRemove_MouseEnter(object sender, EventArgs e)
        {
            helpLabel.Text = @"从当前试卷列表中将选中的试卷移除";
        }

        void downloadButton_MouseEnter(object sender, EventArgs e)
        {
            helpLabel.Text = @"从服务器下载试卷到本机";
        }

        private void radioButton1_MouseEnter(object sender, EventArgs e)
        {
            helpLabel.Text = @"顺序选取试卷";
        }

        private void radioButton2_MouseEnter(object sender, EventArgs e)
        {
            helpLabel.Text = @"随机选取试卷";
        }

        private void radioButton3_MouseEnter(object sender, EventArgs e)
        {
            helpLabel.Text = @"通过双击
选取其中一份试卷
当前选择的试卷为：";
        }

        private void radioButton1_MouseLeave(object sender, EventArgs e)
        {
            helpLabel.Text = "";
        }

        #endregion
        #region 按钮点击事件
        void btnRemove_Click(object sender, System.EventArgs e)
        {
            for (int i = PaperListDGV.Rows.Count - 1; i >= 0; i--)
            {
                if ((bool)PaperListDGV.Rows[i].Cells[0].Value == true)
                {
                    paperListDataTable.Rows.RemoveAt(i);
                }
            }
            updateExamPaperList();//当移除部分试卷后，更新当前考试的试卷列表
        }

        void PaperListDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                radioButton3.Text = radioButton3.Text.Split('-')[0] + '-' + paperListDataTable.Rows[e.RowIndex][1];
                radioButton3.Checked = true;
                foreach (DataRow dr in paperListDataTable.Rows)
                {
                    dr[0] = false;
                }
                paperListDataTable.Rows[e.RowIndex][0] = true;
                updateExamPaperList();//当点击勾选时，更新当前考试的试卷列表
            }
        }

        private void PaperListDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                paperListDataTable.Rows[RIndex][0] = !Convert.ToBoolean(paperListDataTable.Rows[RIndex][0]);
                updateExamPaperList();//当点击勾选时，更新当前考试的试卷列表
            }
        }

        void PaperListDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateExamPaperList();
        }

        void PaperListDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updateExamPaperList();
        }
        /// <summary>
        /// 更新当前考试的试卷列表
        /// </summary>
        private void updateExamPaperList()
        {
            examPaperIdList.Clear();
            examPaperNameList.Clear();
            foreach (DataRow dr in paperListDataTable.Rows)
            {
                if (Convert.ToBoolean(dr[0]))
                {
                    examPaperIdList.Add(Convert.ToInt32(dr[1].ToString()));
                    examPaperNameList.Add(dr[2].ToString());
                }
            }
        }

        public List<string> localPath = new List<string>();
        public List<string> remoteCmd = new List<string>();

        private void downloadButton_Click(object sender, EventArgs e)
        {
            bool isExistPaper = true;
            foreach (DataRow dr in paperListDataTable.Rows)
            {
                string id = dr[1].ToString();
                if (!File.Exists(PaperControl.PathConfig["TmpPaper"] + id + ".rar"))
                {
                    isExistPaper = false;
                    localPath.Add(PaperControl.PathConfig["TmpPaper"] + id + ".rar");
                    remoteCmd.Add(supportServer.LoadPaperPkg(Convert.ToInt32(id), 0));
                }
            }
            if (!isExistPaper)
            {
                supportServer.Client.ReceiveFileList(remoteCmd, localPath);
            }
        }

        void Client_FileListRecieveEnd()
        {
            while (!this.IsHandleCreated) ;
            this.Invoke(new Action(() =>
            {
                this.Enabled = true;
                FileListWaiting.Instance.Close();
            }));

        }

        void Client_FileListRecieveStart()
        {
            while (!this.IsHandleCreated) ;
            this.Invoke(new Action(() =>
            {
                this.Enabled = false;
                FileListWaiting.Instance.Show();
            }));
        }

        void Port_RecieveFileRate(double rate)
        {
            while (!this.IsHandleCreated) ;
            this.Invoke(new Action(() =>
            {
                FileListWaiting.Instance.setProcessBar((int)rate * 1000);
            }));
        }

        void Client_FileListCount(int count)
        {
            while (!this.IsHandleCreated) ;
            this.Invoke(new Action(() =>
            {
                FileListWaiting.Instance.setText(count);
            }));
        }

        #endregion
        private void btnGetPaperFromDB_Click(object sender, EventArgs e)
        {
            PaperChooseForm pcf = new PaperChooseForm();
            pcf.Show();
        }
        //发卷模式选择
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                paperDeliverMode = Int32.Parse((sender as RadioButton).Tag.ToString());
            }
        }
        //点击选择试卷标签时发生
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 1 && netState1.State != 1)
            {
                MessageBox.Show("未连接上服务端!");
                tabControl2.SelectedIndex = 0;
            }
            else if(tabControl2.SelectedIndex==0)
            {
                UpdateCompleteList();
                UpdateList();
                UpdateErrorList();
            }
            else if (tabControl2.SelectedIndex == 4)
            {
                fileSystemWatcher_Changed(null, null);
            }
        }
        #endregion

        #region 监考设置Tab
        #region 本机服务Ip端口广播
        private bool checkIp()
        {
            IPAddress temp;
            if (IPAddress.TryParse(textBoxStartIp.Text, out temp) && IPAddress.TryParse(textBoxEndIp.Text, out temp))
            {
                string[] ips = textBoxStartIp.Text.Split('.');
                ServerEvt.BroadcastHelper.DomineIp = ips[0] + "." + ips[1] + "." + ips[2] + "." + "255";
                return true;
            }
            return false;
        }
        public List<string> generateIpDomain()
        {
            IPAddress temp;
            List<string> iplist = new List<string>();
            if (IPAddress.TryParse(textBoxStartIp.Text, out temp) && IPAddress.TryParse(textBoxEndIp.Text, out temp))
            {
                string[] ips = textBoxEndIp.Text.Split('.');
                for (int i = Convert.ToInt32(textBoxStartIp.Text.Split('.')[3]); i <= Convert.ToInt32(ips[3]); i++)
                {
                    iplist.Add(ips[0] + "." + ips[1] + "." + ips[2] + "." + i.ToString());
                }
            }
            return iplist;
        }
        private void buttonBroadcastOnce_Click(object sender, EventArgs e)
        {
            if (checkIp())
            {
                ServerEvt.BroadcastHelper.Broadcast("monitor#" + UdpBroadcast.GetLongIp(textBoxStartIp.Text).ToString() + "#" + UdpBroadcast.GetLongIp(textBoxEndIp.Text).ToString() + "#" + ServerEvt.Server.ip.ToString() + "#" + ServerEvt.Server.port.ToString());
            }
            else
            {
                MessageBox.Show("您输入的Ip不合法!");
            }
        }
        //是否开始广播循环
        private bool isStartBroadcastRepeat = false;

        public bool IsStartBroadcastRepeat
        {
            get
            {
                return isStartBroadcastRepeat;
            }
            set
            {
                isStartBroadcastRepeat = value;
                if (isStartBroadcastRepeat)
                {
                    timer_Broadcast.Interval = 3000;
                    timer_Broadcast.Start();
                    buttonBroadcastRepeat.Text = "停止广播";
                    buttonBroadcastOnce.Enabled = false;
                    buttonRepeatSingle.Enabled = false;
                }
                else
                {
                    timer_Broadcast.Stop();
                    buttonBroadcastRepeat.Text = "每10s广播一次";
                    buttonBroadcastOnce.Enabled = true;
                    buttonRepeatSingle.Enabled = true;
                }
            }
        }
        //是否开始单播循环
        private bool isStartRepeatSingle = false;

        public bool IsStartRepeatSingle
        {
            get
            {
                return isStartRepeatSingle;
            }
            set
            {
                isStartRepeatSingle = value;
                if (isStartRepeatSingle)
                {
                    timer_BroadcastSingle.Interval = 3000;
                    timer_BroadcastSingle.Start();
                    buttonRepeatSingle.Text = "停止单播";
                    buttonBroadcastOnce.Enabled = false;
                    buttonBroadcastRepeat.Enabled = false;
                }
                else
                {
                    timer_BroadcastSingle.Stop();
                    buttonRepeatSingle.Text = "循环单播";
                    buttonBroadcastOnce.Enabled = true;
                    buttonBroadcastRepeat.Enabled = true;
                }
            }
        }
        private void buttonBroadcastRepeat_Click(object sender, EventArgs e)
        {
            if (checkIp())
            {
                IsStartBroadcastRepeat = !IsStartBroadcastRepeat;
            }
            else
            {
                MessageBox.Show("您输入的Ip不合法!");
            }
        }

        private void buttonRepeatSingle_Click(object sender, EventArgs e)
        {
            if (checkIp())
            {
                IsStartRepeatSingle = !IsStartRepeatSingle;
            }
            else
            {
                MessageBox.Show("您输入的Ip不合法!");
            }
        }

        private void timer_Broadcast_Tick(object sender, EventArgs e)
        {
            ServerEvt.BroadcastHelper.Broadcast("monitor#" + UdpBroadcast.GetLongIp(textBoxStartIp.Text).ToString() + "#" + UdpBroadcast.GetLongIp(textBoxEndIp.Text).ToString() + "#" + ServerEvt.Server.ip.ToString() + "#" + ServerEvt.Server.port.ToString());
        }
        private Thread t;
        private static bool isBoardCastEnd=true;
        private void timer_BroadcastSingle_Tick(object sender, EventArgs e)
        {
            if (isBoardCastEnd)
            {
                isBoardCastEnd = false;
                List<string> iplist = generateIpDomain();
                string startIp = textBoxStartIp.Text;
                string endIp = textBoxEndIp.Text;
                t = new Thread(new ThreadStart(() =>
                {
                    foreach (string ip in iplist)
                    {
                        ServerEvt.BroadcastHelper.DomineIp = ip;
                        ServerEvt.BroadcastHelper.Broadcast("monitor#" + UdpBroadcast.GetLongIp(startIp).ToString() + "#" + UdpBroadcast.GetLongIp(endIp).ToString() + "#" + ServerEvt.Server.ip.ToString() + "#" + ServerEvt.Server.port.ToString());
                    }
                    isBoardCastEnd = true;
                }));
                t.Start();
            }
        }

        #endregion
        #endregion

        #region 考生状态Tab
        //刷新考生状态，手动刷新，减少界面负担
        private void refreshButton_Click(object sender, EventArgs e)
        {
            int completeNum = 0;
            StudentDataGridView.Rows.Clear();
            foreach (Student s in PaperControl.StudentCollection.Keys)
            {
                StudentDataGridView.Rows.Add(s.ID, s.sName, s.className, s.ip, PaperControl.MapExamStateString[PaperControl.StudentCollection[s]]);
                if (PaperControl.StudentCollection[s] == ExamState.HandIn)
                {
                    completeNum++;
                }
            }
            LoginNumLabel.Text = "登录人数：" + PaperControl.StudentCollection.Keys.Count.ToString();
            CompleteNumLabel.Text = "完成人数：" + completeNum.ToString();
        }
        //将考生状态信息存成xls文件
        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder content = new StringBuilder();
                foreach (Student s in PaperControl.StudentCollection.Keys)
                {
                    content.AppendLine(s.ID + "\t" + s.sName + "\t" + s.className + "\t" + s.ip + "\t" + PaperControl.MapExamStateString[PaperControl.StudentCollection[s]]);
                }
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.Default))
                {
                    sw.Write(content);
                }
            }
        }
        #endregion

        #region 网络事件监听
        void Server_WrittenMsg(Client client, string msg)
        {
            cl.showMessage("(" + client.ClientIp + ")" + "Write:\t" + msg);
        }

        void Server_ReceivedMsg(Client client, string msg)
        {
            cl.showMessage("(" + client.ClientIp + ")" + "Read:\t" + msg);
        }

        void Server_SendDataReady(Client client, string msg)
        {
            lock (Computer.syncComputerList)
            {
                for (int i = 0; i < Computer.ComputerList.Count; i++)
                {
                    if (Computer.ComputerList[i].Client == client)
                    {
                        client.Port.FilePath = Computer.ComputerList[i].ExamPaperPath;
                    }
                }
            }
        }

        void Server_FileSendEnd(ServerNet.DataPort dataPort)
        {
            lock (Computer.syncComputerList)
            {
                for (int i = 0; i < Computer.ComputerList.Count;i++ )
                {
                    if (Computer.ComputerList[i].Client.Port == dataPort)
                    {
                        Computer.ComputerList[i].State = 5;
                    }
                }
            }
        }

        /// <summary>
        /// 当考生答案文件收完后触发
        /// </summary>
        /// <param name="dataPort"></param>
        void Server_FileReceiveEnd(ServerNet.DataPort dataPort)
        {
            lock (Computer.syncComputerList)
            {
                for (int i = Computer.ComputerList.Count - 1; i >= 0; i--)
                {
                    if (Computer.ComputerList[i].Client.Port == dataPort)
                    {
                        //对考生文件解密
                        //if (RARHelper.Exists())
                        //{
                        //    RARHelper.UnCompressRAR(PaperControl.PathConfig["StuAns"] + Computer.ComputerList[i].Student.ID + "\\", PaperControl.PathConfig["StuAns"], Computer.ComputerList[i].Student.ID + ".rar", true, Computer.ComputerList[i].Password);
                        //    while (!Directory.Exists(PaperControl.PathConfig["StuAns"] + Computer.ComputerList[i].Student.ID + "\\")) ;
                        //    File.WriteAllText(PaperControl.PathConfig["StuAns"] + Computer.ComputerList[i].Student.ID + "\\password.txt", Computer.ComputerList[i].Password);
                        //}
                        //Computer.ComputerList[i].State = 4;
                        //if (File.Exists(PaperControl.PathConfig["StuAns"] + Computer.ComputerList[i].Student.ID + ".rar"))
                        //{
                        //    File.Delete(PaperControl.PathConfig["StuAns"] + Computer.ComputerList[i].Student.ID + ".rar");
                        //}
                        Computer.ComputerList[i].State = 4;
                        AddToFlp(flp_CompleteExam, Computer.ComputerList[i]);
                        RemoveFromFlp(flp_Onexam, Computer.ComputerList[i]);
                        lock (Computer.syncCompleteList)
                        {
                            Computer.CompleteList.Add(Computer.ComputerList[i]);
                        }
                        Computer.ComputerList.Remove(Computer.ComputerList[i]);
                        HandInCount--;
                        if (HandInCount == 0)
                        {
                            ServerEvt.Server.IsPortAvailable = false;
                            timer_PortCounter.Stop();
                        }
                        break;
                    }
                }
            }
        }

        void Server_AcceptedClient(object sender, EventArgs e)
        {
            AddComputer((Client)sender);
        }
        #endregion
    }
}
