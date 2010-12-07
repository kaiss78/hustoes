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
        public WaitingForm()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            ClientControl.LoginForm.Show();
            timer1.Stop();
        }

        private void WaitingForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
