using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OESMonitor.SupportNet;

namespace OESMonitor
{
    public partial class PaperChooseForm : Form
    {
        public ClientEvt supportServer;
        public PaperChooseForm()
        {
            InitializeComponent();
            supportServer = new ClientEvt();
            supportServer.Client.ReceivedTxt += new EventHandler(Client_ReceivedTxt);
        }

        void Client_ReceivedTxt(object sender, EventArgs e)
        {
            supportServer.Client.SendTxt("monitor$2$10");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            supportServer.Client.SendTxt("monitor$0");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            supportServer.Client.Port.FilePath = "F:\\abc.rar";
            supportServer.Client.ReceiveFile();
        }
    }
}
