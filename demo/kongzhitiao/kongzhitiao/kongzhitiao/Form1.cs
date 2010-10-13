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
        
        /**初始化试题界面*/
        shitichuangti shitichuang = new shitichuangti();
        /**登录学生的学号*/
        string studentinfo;
        /**开始时间的设置*/
        int second = 0;
        int minute =90;
        

        public Form1()
        {
            InitializeComponent();
            
        }

       /* [DllImport("user32.dll", EntryPoint = "FindWindowA")]
        public static extern IntPtr FindWindowA(string lp1, string lp2);
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern IntPtr ShowWindow(IntPtr hWnd, int _value);
        IntPtr hTray = Form1.FindWindowA("Shell_TrayWnd",String.Empty);
        * 获取状态栏的，如果想只显示当前窗口，可以把整个状态栏隐藏
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            /**界面初始位置，如果想做得更用通用性，先获取当前显示屏的分便率，然后设置相应变量,*/
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);
            this.SetDesktopLocation((rect.Width-530)/2, 0);//这里的530如果是当前FORM实例的长度就更好了
            /**显示试题窗口的初始位置*/
            shitichuang.Visible = true;
            shitichuang.SetDesktopLocation((rect.Width-530)/2,rect.Height/4);
            /**去掉整个屏幕的状态栏*/
           // ShowWindow(hTray,1);



/**111111*/            /**显示登录学生的信息，替换接口的地方，要求使用字符串*/
            studentinfo = " 接口" + "   考生";
            stuinfo.Text = studentinfo;

            /**显示初始时间*/
            shijian.Text = " 90:00";
           }

     
        /**显示隐藏试题按钮*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (shitichuang.Visible)
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

     
       
        /**实现倒计时*/
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
                    timer1.Enabled = false;
                    MessageBox.Show("考试时间已到！！\n\r 系统退出考试");
/*222222*/                   /**这里要调用交卷的事件*/ 
                    
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
            { //MessageBox.Show("时间显示出错！！请重新开始！！"); 
            }
        }

    }
}
