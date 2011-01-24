using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //timer1.Stop();
        }

        public void HandInOver(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
                {
                    this.Dispose();
                    ClientControl.WaitingForm = null;
                    ClientControl.LoginForm.Show();
                }));
        }

        public void addProgress()
        {
            this.CreateControl();
            this.Invoke(new MethodInvoker(() =>
            {
                if (this.progressBar1.Value + perPackage > 1000)
                {
                    this.progressBar1.Value = 1000;
                }
                else
                {
                    this.progressBar1.Value += perPackage;
                }
            }));
        }
        private void WaitingForm_Load(object sender, EventArgs e)
        {
            //timer1.Start();
        }
    }
}
