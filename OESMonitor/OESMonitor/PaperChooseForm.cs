using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OESMonitor.SupportNet;
using System.Threading;

namespace OESMonitor
{
    public partial class PaperChooseForm : Form
    {
        public ClientEvt supportServer=new ClientEvt();
        public PaperChooseForm()
        {
            InitializeComponent();
            paperListPanel1.parent = this;

        }

        void Client_ReceivedTxt(object sender, EventArgs e)
        {
            //supportServer.Client.SendTxt("monitor$2$1");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            supportServer.Client.SendTxt("monitor$0");
            //supportServer.Client.SendTxt("server$4$1");
            //supportServer.Client.SendTxt("server$2$1$1$2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            supportServer.Client.Port.FilePath = "F:\\abc.xml";
            supportServer.Client.ReceiveFile();
        }

        

        private void PaperChooseForm_Load(object sender, EventArgs e)
        {

            supportServer.Client.SendTxt("monitor$0");
        }
    }
}
