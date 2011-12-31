using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Net;

namespace OES
{
    public partial class ChangeIpForm : Form
    {
        public ChangeIpForm()
        {
            InitializeComponent();
            string[] ips = ClientEvt.Client.server.Split('.');
            numericUpDown1.Value = int.Parse(ips[0]);
            numericUpDown2.Value = int.Parse(ips[1]);
            numericUpDown3.Value = int.Parse(ips[2]);
            numericUpDown4.Value = int.Parse(ips[3]);
            numericUpDown5.Value = ClientEvt.Client.portNum;
        }

        private void CancleButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            ClientEvt.Client.server = numericUpDown1.Value.ToString() + "." + numericUpDown2.Value.ToString() + "." + numericUpDown3.Value.ToString() + "." + numericUpDown4.Value.ToString() ;
            ClientEvt.Client.portNum = (int)numericUpDown5.Value;
            ClientEvt.Client.InitializeClient();
            this.Close();
        }
    }
}
