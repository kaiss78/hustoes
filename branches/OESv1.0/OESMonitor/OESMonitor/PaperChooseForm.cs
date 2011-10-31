using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OESMonitor.Net;
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

        private void PaperChooseForm_Load(object sender, EventArgs e)
        {

            supportServer.Client.SendTxt("monitor$0");
        }
    }
}
