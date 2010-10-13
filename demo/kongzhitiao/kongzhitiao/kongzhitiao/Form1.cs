using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace kongzhitiao
{
    public partial class Form1 : Form

    {
        shitichuangti shitichuang = new shitichuangti();
        string studentinfo;
        int second = 0;
        int minute = 90;

        public Form1()
        {
            InitializeComponent();
            
        }

       /* [DllImport("user32.dll", EntryPoint = "FindWindowA")]
        public static extern IntPtr FindWindowA(string lp1, string lp2);
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern IntPtr ShowWindow(IntPtr hWnd, int _value);
        IntPtr hTray = Form1.FindWindowA("Shell_TrayWnd",String.Empty);
        */
        private void Form1_Load(object sender, EventArgs e)
        {

            this.SetDesktopLocation(400, 0);
            /**初始化显示试题窗口*/
            shitichuang.Visible = true;
            shitichuang.SetDesktopLocation(400,200);
            /**去掉FORM1的状态栏*/
           // ShowWindow(hTray,1);
            studentinfo = " 接口" + "   考生";
            stuinfo.Text = studentinfo;
           
            
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            if (shiti.Text.Equals("  隐藏试题"))
            {
                shitichuang.Visible = false;
                shiti.Text = "  显示试题";
            }
            else
            {
                shitichuang.Visible = true;
                shiti.Text = "  隐藏试题";
            }

        }

     
       

        private void timer1_Tick(object sender, EventArgs e)
        {
           

            if (second > 0)
            { second--; }
            else
            {
                second = 59;
                minute--;
            }
            if (minute < 10 && second >= 10)
            {
                shijian.Text = " " + "0" + minute.ToString() + ":" + second.ToString();
            }
            if (minute < 10 && second < 10)
            {
                shijian.Text = " " + "0" + minute.ToString() + ":" + "0" + second.ToString();
                if (minute == 0 && second == 0)
                {
                    MessageBox.Show("考试时间已到！！\n\r 系统退出考试");
                    this.Close();
                }
            }
            if (minute >= 10 && second < 10)
            {
                shijian.Text = " " + minute.ToString() + ":" + "0" + second.ToString();
            }
            if (second >= 10 && minute >= 10)
            {
                shijian.Text = " " + minute.ToString() + ":" + second.ToString();
            }
            else
            { MessageBox.Show("时间显示出错！！请重新开始！！"); }
        }

    }
}
