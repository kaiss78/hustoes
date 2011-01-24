using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESMonitor.Model;

namespace OESMonitor
{
    public partial class ComputerState : UserControl
    {
        private static ComputerState instance=new ComputerState();
        private ComputerState()
        {
            InitializeComponent();
            instance = this;
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
    }
}
