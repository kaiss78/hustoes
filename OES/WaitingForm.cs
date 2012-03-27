using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using OES.Net;
using System.IO;
using ClientNet;

namespace OES
{
    public partial class WaitingForm : Form
    {
        public int perPackage = 0;
        public WaitingForm()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            progressBar1.Maximum = 1000;
            ClientEvt.Client.Port.SendFileRate += new ReturnVal(Port_SendFileRate);
            ClientEvt.Client.Port.FileSendEnd += new EventHandler(Port_FileSendEnd);
        }

        void Port_FileSendEnd(object sender, EventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                ClientControl.WaitingForm = null;
                ClientControl.LoginForm.Show();
                ClientControl.LoginForm.SetNetState(0);
                this.Hide();
                OES.DAO.MD5File.GenerateSecurityFile("End");
                if(Directory.Exists(Config.paperPath))
                    Directory.Delete(Config.paperPath,true);
                Directory.Move(Config.stuPath, Config.HistoryPath+DateTime.Now.Ticks.ToString());
                ClientControl.State = 0;        //交卷完成设置为未启动状态
            }));
        }

        void Port_SendFileRate(double rate)
        {
            progressBar1.Value = (int)(1000 * rate);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //timer1.Stop();
        }
        private void WaitingForm_Load(object sender, EventArgs e)
        {
            //timer1.Start();
        }
    }
}
