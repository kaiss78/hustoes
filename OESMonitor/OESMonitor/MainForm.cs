using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESMonitor.Net;

namespace OESMonitor
{
    public partial class OESMonitor : Form
    {
        CommandLine cl = new CommandLine();
       
        public OESMonitor()
        {
            InitializeComponent();
            panel1.Controls.Add( ComputerState.getInstance());
        }
       
        public void AddComputer(Client client)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                Computer com = new Computer();
                com.CreateControl();
                com.State = 1;
                com.Client = client;
                Computer.Add(com);

                UpdateList();
            }));
        }
        private void UpdateList()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Computer c in Computer.ComputerList)
            {
                flowLayoutPanel1.Controls.Add(c);
            }
        }
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
            ServerEvt.Server.StartServer();
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
                }
            }
        }

        void Server_AcceptedClient(object sender, EventArgs e)
        {
            AddComputer((Client)sender);
        }
    }
}
