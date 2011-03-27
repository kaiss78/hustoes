using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace OESMonitor
{
    public partial class ChooseIp : Form
    {
        public IPAddress ip;
        private ChooseIp(List<IPAddress> list)
        {
            InitializeComponent();
            foreach (IPAddress i in list)
            {
                comboBox1.Items.Add(i);
            }
        }
        public static ChooseIp CurrentForm(List<IPAddress> list)
        {
            return new ChooseIp(list);
        }
        public IPAddress ShowDialog(IWin32Window handle)
        {
            base.ShowDialog(handle);
            return ip;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ip = comboBox1.SelectedItem as IPAddress;
            this.Close();
        }
    }
}
