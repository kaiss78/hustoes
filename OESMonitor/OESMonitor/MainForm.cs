using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using OESMonitor.Net;
using OESMonitor.PaperControl;
using System.Net;

namespace OESMonitor
{
    public partial class OESMonitor : Form
    {
        CommandLine cl = new CommandLine();
        Config config = new Config();
        List<IPAddress> alternativeIp = new List<IPAddress>();
        int paperDeliverMode = 0;
        bool isStartExam = false;

        public bool IsStartExam
        {
            get { return isStartExam; }
            set 
            {
                isStartExam = value;
                if (isStartExam)
                {
                    ServerEvt.Server.IsPortAvailable = true;
                    button1.Text = "停止发卷/收卷";
                    timer_PortCounter.Start();
                }
                else
                {
                    ServerEvt.Server.IsPortAvailable = false;
                    button1.Text = "开始考试/收卷";
                    timer_PortCounter.Stop();
                }
            }
        }

        public static DataTable paperListDataTable;
        
        public OESMonitor()
        {
            InitializeComponent();

            timer_PortCounter.Interval = 1000;

            panel1.Controls.Add( ComputerState.getInstance());
            
            paperListDataTable = new DataTable("PaperList");
            paperListDataTable.Columns.Add("选中", typeof(bool));
            paperListDataTable.Columns.Add("试卷ID");
            paperListDataTable.Columns.Add("试卷名称");
            paperListDataTable.Columns.Add("组卷时间");
            paperListDataTable.Columns.Add("作者");
            PaperListDGV.DataSource = paperListDataTable;
            PaperListDGV.CellClick+=new DataGridViewCellEventHandler(PaperListDGV_CellClick);
            PaperListDGV.CellDoubleClick += new DataGridViewCellEventHandler(PaperListDGV_CellDoubleClick);
            PaperListDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            btnRemove.MouseEnter += new EventHandler(btnRemove_MouseEnter);
            btnRemove.MouseLeave += new EventHandler(radioButton1_MouseLeave);
            btnRemove.Click+=new EventHandler(btnRemove_Click);
            btnGetPaperFromDB.MouseEnter += new EventHandler(btnGetPaperFromDB_MouseEnter);
            btnGetPaperFromDB.MouseLeave += new EventHandler(radioButton1_MouseLeave);
        }

        void PaperListDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
                radioButton3.Text = radioButton3.Text.Split('-')[0] + '-' + paperListDataTable.Rows[e.RowIndex][1];
        }

        void btnGetPaperFromDB_MouseEnter(object sender, EventArgs e)
        {
            helpLabel.Text = @"打开新的窗口，到数据库里面取需要考试的试卷";
        }

        void btnRemove_MouseEnter(object sender, EventArgs e)
        {
            helpLabel.Text = @"从当前试卷列表中将选中的试卷移除";
        }

        void btnRemove_Click(object sender, System.EventArgs e)
        {
            for (int i = PaperListDGV.Rows.Count-1; i >=0 ; i--)
            {
                if ((bool)PaperListDGV.Rows[i].Cells[0].Value == true)
                {
                    paperListDataTable.Rows.RemoveAt(i);
                }
            }
        }

        private void PaperListDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                paperListDataTable.Rows[RIndex][0] = !Convert.ToBoolean(paperListDataTable.Rows[RIndex][0]);
            }

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

        //添加一个电脑
        public void AddComputer(Client client)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            flowLayoutPanel1.Controls.Add(new Computer());
        }

        private void OESMonitor_Load(object sender, EventArgs e)
        {
            cl.Show();
           
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

        }

        void Server_WrittenMsg(Client client, string msg)
        {
            cl.showMessage("Write:\t"+msg);
        }

        void Server_ReceivedMsg(Client client, string msg)
        {
            cl.showMessage("Read:\t"+msg);
        }

        void Server_SendDataReady(Client client, string msg)
        {
            foreach (Computer c in Computer.ComputerList)
            {
                if (c.Client == client)
                {
                    client.port.FilePath = "D:/EXAM001.rar";
                }
            }
        }

        

        void Server_FileSendEnd(DataPort dataPort)
        {
            foreach (Computer c in Computer.ComputerList)
            {
                if (c.Client.port == dataPort)
                {
                    c.State = 5;
                }
            }
        }

        void Server_FileReceiveEnd(DataPort dataPort)
        {
            for (int i = Computer.ComputerList.Count - 1; i >= 0;i-- )
            {
                if (Computer.ComputerList[i].Client.port == dataPort)
                {
                    Computer.ComputerList[i].State = 4;
                    Computer.CompleteList.Add(Computer.ComputerList[i]);
                    Computer.ComputerList.Remove(Computer.ComputerList[i]);
                    UpdateList();
                    UpdateCompleteList();
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                paperDeliverMode = Int32.Parse((sender as RadioButton).Tag.ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!isStartExam)
            {
                
                IsStartExam = true;
            }
            else
            {
                
                IsStartExam = false;
            }
        }

        private void timer_PortCounter_Tick(object sender, EventArgs e)
        {
            lab_DataPortCount.Text = Net.ServerEvt.Server.PortCurNum.ToString();
        }

    }
}
