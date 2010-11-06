using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OES
{
    public partial class ControlBar : Form
    {

        /**初始化试题界面*/
        MainForm mainForm = new MainForm();
        Form parents;
        /**开始时间的设置*/
        int seconds = 0;
        int minute = 90;
        /**打开控制条*/
        public ControlBar(Form  par)
        {            
            InitializeComponent();
            parents = par;                        
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
            /*界面初始位置，如果想做得更用通用性，先获取当前显示屏的分便率，然后设置相应变量,*/
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);
            this.SetDesktopLocation((rect.Width - 530) / 2, 0);//这里的530如果是当前FORM实例的长度就更好了
            /**显示试题窗口的初始位置*/
            mainForm.Visible = true;
            mainForm.SetDesktopLocation((rect.Width - 530) /5, rect.Height/9);
            /**去掉整个屏幕的状态栏*/
            // ShowWindow(hTray,1);

            /**显示登录学生的信息，替换接口的地方，要求使用字符串*/
            studentID.Text = "姓名 ID";

            /**显示初始时间*/
            time.Text = " 90:00";
        }


        /**显示隐藏试题按钮*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (mainForm.Visible)
            {
                mainForm.Visible = false;
                butHideMF.Text = "显示试题";
            }
            else
            {
                mainForm.Visible = true;
                butHideMF.Text = " 隐藏试题";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ( seconds > 0)
            { seconds--; }
            else
            {
                seconds = 59;
                minute--;
            }
            if (minute < 10 && seconds >= 10)
            {
                time.Text = " " + "0" + minute.ToString() + ":" + seconds.ToString();
            }
            if (minute < 10 && seconds < 10)
            {
                time.Text = " " + "0" + minute.ToString() + ":" + "0" + seconds.ToString();
                if (minute == 0 && seconds == 0)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("考试时间已到！！\n\r 系统退出考试");
                    /*222222*/
                    /**这里要调用交卷的事件*/

                }
            }
            if (minute >= 10 && seconds < 10)
            {
                time.Text = " " + minute.ToString() + ":" + "0" + seconds.ToString();
            }
            if (seconds >= 10 && minute >= 10)
            {
                time.Text = " " + minute.ToString() + ":" + seconds.ToString();
            }
            else
            { //MessageBox.Show("时间显示出错！！请重新开始！！"); 

            }
        }

        private void butHandIn_Click(object sender, EventArgs e)
        {
            
            parents.Show();
            mainForm .Dispose();
            this.Dispose();
        }

    }
}
