using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using OES.Model;
using System.IO;
using System.Diagnostics;

namespace OESMonitor
{
    public partial class ComputerState : UserControl
    {
        private static ComputerState instance=new ComputerState();
        public static string ansPath = "";
        private ComputerState()
        {
            InitializeComponent();
            instance = this;
            InfoClear();
        }
        public void InfoClear()
        {
            button1.Hide();
            
            this.NameLab.Text = "";
            this.IdLab.Text = "";
            this.PortLab.Text = "";
            this.IpLab.Text = "";
            this.StateLab.Text = "";
        }
        public void setIpPort(string ip, int port)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                IpLab.Text = ip;
                PortLab.Text = port.ToString();
            }));
        }
        public void setStudent(Student s)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                IdLab.Text = s.ID;
                NameLab.Text = s.sName;
            }));
        }
        public void setState(string state)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                StateLab.Text = state;
                if (state == "已交卷")
                {
                    button1.Show();
                    ansPath = PaperControl.PathConfig["StuAns"]+IdLab.Text+".rar";
                }
                else
                {
                    button1.Hide();
                }
            }));
        }
        public static ComputerState getInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                return new ComputerState();
            }
            else
            {
                return instance;
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(ansPath))
            {
                Process.Start(ansPath);
            }
            else
            {
                MessageBox.Show("路径无效");
            }
        }
    }
}
