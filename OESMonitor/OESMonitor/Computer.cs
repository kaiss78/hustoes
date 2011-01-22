using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OESMonitor
{
    public partial class Computer : UserControl
    {
        private int state;

        public int State
        {
            get 
            {
                return state; 
            }
            set 
            {
                switch (value)
                {
                    case 0:
                        ico.BackgroundImage = Properties.Resources.s0;
                        lab.Text = "未启动";
                        break;
                    case 1:
                        ico.BackgroundImage = Properties.Resources.s1;
                        lab.Text = "未登录";
                        break;
                    case 2:
                        ico.BackgroundImage = Properties.Resources.s2;
                        lab.Text = "已登录";
                        break;
                    case 3:
                        ico.BackgroundImage = Properties.Resources.s3;
                        lab.Text = "考试中";
                        break;
                    case 4:
                        ico.BackgroundImage = Properties.Resources.s4;
                        lab.Text = "已交卷";
                        break;
                    default:
                        ico.BackgroundImage = Properties.Resources.s0;
                        lab.Text = "未启动";
                        break;


                }
                state = value; 
            }
        }
        public Net.Client client;
        public Computer()
        {
            InitializeComponent();
            State = 0;
        }
    }
}
