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

        public static event Action HandInPaper;

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
                    }
                }
                else
                {
                    buttonExamStatue.Text = "开始考试/收卷";
                    if (HandInPaper != null)
                    {
                        HandInPaper();
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

        private ConfigEditor serverConfig = new ConfigEditor("ServerConfig.xml");

        private ConfigEditor clientConfig = new ConfigEditor("ClientConfig.xml");

        private ConfigEditor pathConfig = new ConfigEditor("PathConfig.xml");

        private ConfigEditor passConfig = new ConfigEditor("PwdConfig.xml");

        private ConfigEditor dbConfig = new ConfigEditor("DbConfig.xml");

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
            fileSystemWatcher.Path = PaperControl.PathConfig["StuAns"];
            fileSystemWatcher.Changed += new FileSystemEventHandler(fileSystemWatcher_Changed);
            fileSystemWatcher.Deleted += new FileSystemEventHandler(fileSystemWatcher_Changed);
            fileSystemWatcher.Renamed += new RenamedEventHandler(fileSystemWatcher_Renamed);
            fileSystemWatcher.Created += new FileSystemEventHandler(fileSystemWatcher_Changed);
            fileSystemWatcher.EnableRaisingEvents = true;
            foreach (string path in Directory.GetDirectories(PaperControl.PathConfig["StuAns"]))
            {
                StudentAnsDirectory studentAnsDirectory = new StudentAnsDirectory(path);
                studentAnsDirectory.OnView += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnView);
                studentAnsDirectory.OnDelete += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnDelete);
                flowLayoutPanelDir.Controls.Add(studentAnsDirectory);
            }
            #endregion

        }

        #region 考生文件夹操作
        void studentAnsDirectory_OnDelete(StudentAnsDirectory e)
        {
            Directory.Delete(PaperControl.PathConfig["StuAns"] + e.Text, true);
        }

        void studentAnsDirectory_OnView(StudentAnsDirectory e)
        {
            Process.Start(PaperControl.PathConfig["StuAns"] + e.Text);
        }
        #endregion

        #region 考生答案文件夹监视事件
        void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            flowLayoutPanelDir.Controls.Clear();
            foreach (string path in Directory.GetDirectories(PaperControl.PathConfig["StuAns"]))
            {
                StudentAnsDirectory studentAnsDirectory = new StudentAnsDirectory(path);
                studentAnsDirectory.OnView += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnView);
                studentAnsDirectory.OnDelete += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnDelete);
                flowLayoutPanelDir.Controls.Add(studentAnsDirectory);
            }
        }

        void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            flowLayoutPanelDir.Controls.Clear();
            foreach (string path in Directory.GetDirectories(PaperControl.PathConfig["StuAns"]))
            {
                StudentAnsDirectory studentAnsDirectory = new StudentAnsDirectory(path);
                studentAnsDirectory.OnView += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnView);
                studentAnsDirectory.OnDelete += new StudentAnsDirectory.SignalMsg(studentAnsDirectory_OnDelete);
                flowLayoutPanelDir.Controls.Add(studentAnsDirectory);
            }
        }
        #endregion

        #region 网络连接状态
        void Client_DisConnectError(object sender, ErrorEventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                netState1.State = 0;
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
        #endregion

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

        #region 添加一个电脑
        public void AddComputer(Client client)
        {
            while (!this.IsHandleCreated) ;
            this.Invoke(new MethodInvoker(() =>
            {
                Computer com = new Computer();
                com.CreateControl();
                com.State = 1;
                com.Client = client;
                com.OnErrorConnect += new System.IO.ErrorEventHandler(com_OnErrorConnect);
                Computer.Add(com);

                UpdateList();
            }));
        }
        #endregion

        void com_OnErrorConnect(object sender, System.IO.ErrorEventArgs e)
        {
            UpdateList();
            UpdateErrorList();
        }

        #region 更新界面上的电脑图标
        private void UpdateList()
        {
            this.Invoke(new MethodInvoker(() =>
                        {
                            flowLayoutPanel1.Controls.Clear();
                            foreach (Computer c in Computer.ComputerList)
                            {
                                flowLayoutPanel1.Controls.Add(c);
                            }
                        }));
        }
        private void UpdateCompleteList()
        {
            this.Invoke(new MethodInvoker(() =>
                        {
                            flowLayoutPanel2.Controls.Clear();
                            foreach (Computer c in Computer.CompleteList)
                            {
                                flowLayoutPanel2.Controls.Add(c);
                            }
                        }));
        }
        private void UpdateErrorList()
        {
            this.Invoke(new MethodInvoker(() =>
                        {
                            flowLayoutPanel3.Controls.Clear();
                            foreach (Computer c in Computer.ErrorList)
                            {
                                flowLayoutPanel3.Controls.Add(c);
                            }
                        }));
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
            foreach (DataRow dr in paperListDataTable.Rows)
            {
                if (Convert.ToBoolean(dr[0]))
                    examPaperIdList.Add(Convert.ToInt32(dr[1].ToString()));
            }
        }

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
            else if (alternativeIp.Count > 1)
            {
                ServerEvt.Server.ip = ChooseIp.CurrentForm(alternativeIp).ShowDialog(this);
                ServerEvt.Server.StartServer();
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
            foreach (Computer c in Computer.ComputerList)
            {
                if (c.Client == client)
                {
                    client.Port.FilePath = c.ExamPaper;
                }
            }
        }



        void Server_FileSendEnd(ServerNet.DataPort dataPort)
        {
            foreach (Computer c in Computer.ComputerList)
            {
                if (c.Client.Port == dataPort)
                {
                    c.State = 5;
                }
            }
        }

        /// <summary>
        /// 当考生答案文件收完后触发
        /// </summary>
        /// <param name="dataPort"></param>
        void Server_FileReceiveEnd(ServerNet.DataPort dataPort)
        {
            for (int i = Computer.ComputerList.Count - 1; i >= 0; i--)
            {
                if (Computer.ComputerList[i].Client.Port == dataPort)
                {
                    //对考生文件解密
                    if (RARHelper.Exists())
                    {
                        RARHelper.UnCompressRAR(PaperControl.PathConfig["StuAns"] + Computer.ComputerList[i].Student.ID + "\\", PaperControl.PathConfig["StuAns"], Computer.ComputerList[i].Student.ID + ".rar", true, Computer.ComputerList[i].Password);
                        while (!Directory.Exists(PaperControl.PathConfig["StuAns"] + Computer.ComputerList[i].Student.ID + "\\")) ;
                        File.WriteAllText(PaperControl.PathConfig["StuAns"] + Computer.ComputerList[i].Student.ID + "\\password.txt", Computer.ComputerList[i].Password);
                    }
                    Computer.ComputerList[i].State = 4;
                    if (File.Exists(PaperControl.PathConfig["StuAns"] + Computer.ComputerList[i].Student.ID + ".rar"))
                    {
                        File.Delete(PaperControl.PathConfig["StuAns"] + Computer.ComputerList[i].Student.ID + ".rar");
                    }
                    Computer.CompleteList.Add(Computer.ComputerList[i]);
                    Computer.ComputerList.Remove(Computer.ComputerList[i]);
                    UpdateList();
                    UpdateCompleteList();
                    break;
                }
            }
        }

        void Server_AcceptedClient(object sender, EventArgs e)
        {
            AddComputer((Client)sender);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComputerState.getInstance().InfoClear();
        }

        private void btnGetPaperFromDB_Click(object sender, EventArgs e)
        {
            PaperChooseForm pcf = new PaperChooseForm();
            pcf.Show();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                paperDeliverMode = Int32.Parse((sender as RadioButton).Tag.ToString());
            }
        }



        private void timer_PortCounter_Tick(object sender, EventArgs e)
        {
            lab_DataPortCount.Text = Net.ServerEvt.Server.PortCurNum.ToString();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 1 && netState1.State != 1)
            {
                MessageBox.Show("未连接上服务端!");
                tabControl2.SelectedIndex = 0;
            }
            else
            {
            }
        }

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
                    timer_Broadcast.Interval = 10000;
                    timer_Broadcast.Start();
                    buttonBroadcastRepeat.Text = "停止广播";
                    buttonBroadcastOnce.Enabled = false;
                }
                else
                {
                    timer_Broadcast.Stop();
                    buttonBroadcastRepeat.Text = "每10s广播一次";
                    buttonBroadcastOnce.Enabled = true;
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

        private void timer_Broadcast_Tick(object sender, EventArgs e)
        {
            ServerEvt.BroadcastHelper.Broadcast("monitor#" + UdpBroadcast.GetLongIp(textBoxStartIp.Text).ToString() + "#" + UdpBroadcast.GetLongIp(textBoxEndIp.Text).ToString() + "#" + ServerEvt.Server.ip.ToString() + "#" + ServerEvt.Server.port.ToString());
        }
        #endregion


    }
}
