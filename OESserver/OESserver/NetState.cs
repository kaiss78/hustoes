using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OES
{
    public partial class NetState : UserControl
    {
        public event EventHandler ReConnect;
        int intervalTime = 10;
        int conter = 10;
        int state = 0;

        public NetState()
        {
            InitializeComponent();
        }

        public NetState(int intervalTime)
        {
            InitializeComponent();
            this.intervalTime = intervalTime;
            conter = intervalTime;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (state == 0)
            {
                label1.Text = "未连接上,等待 " + (--conter).ToString() + " s,重新连接";
            }
            else if (state == 2)
            {
                conter--;
            }
            if (conter == 0)
            {
                if (ReConnect != null)
                {
                    ReConnect(this, null);
                }
                conter = intervalTime;
            }
        }

        public void StillWaitting()
        {
            timer.Start();
        }

        public int State
        {
            get { return state; }
            set 
            {
                state = value;
                switch (state)
                {
                    case 0:
                        label1.Text = "未连接上,等待 "+intervalTime.ToString()+" s,重新连接";
                        pictureBox1.Image = imageList.Images[0];
                        timer.Start();
                        break;
                    case 1:
                        timer.Stop();
                        label1.Text = "与服务端连接正常.";
                        pictureBox1.Image = imageList.Images[1];
                        break;
                    case 2:
                        label1.Text = "正在连接中...";
                        pictureBox1.Image = imageList.Images[2];
                        timer.Start();
                        break;
                }
            }
        }
    }
}
