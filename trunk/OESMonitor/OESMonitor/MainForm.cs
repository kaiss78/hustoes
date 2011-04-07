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
        public static DataTable paperListDataTable;
        
        public OESMonitor()
        {
            InitializeComponent();
            panel1.Controls.Add( ComputerState.getInstance());
            
            paperListDataTable = new DataTable("PaperList");
            paperListDataTable.Columns.Add("选中", typeof(bool));
            paperListDataTable.Columns.Add("试卷ID");
            paperListDataTable.Columns.Add("试卷名称");
            paperListDataTable.Columns.Add("组卷时间");
            paperListDataTable.Columns.Add("作者");
            PaperListDGV.DataSource = paperListDataTable;
            PaperListDGV.CellClick+=new DataGridViewCellEventHandler(PaperListDGV_CellClick);
            PaperListDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
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
            foreach (Computer c in Computer.ComputerList)
            {
                if (c.Client.port == dataPort)
                {
                    c.State = 4;
                    Computer.CompleteList.Add(c);
                    Computer.ComputerList.Remove(c);
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

    }
}
