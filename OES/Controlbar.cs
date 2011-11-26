using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OES.XMLFile;
using OES.Model;
using System.Threading;

namespace OES
{
    public partial class ControlBar : Form
    {
        //考试总时间
        public static int Seconds = 5400;
        /**开始时间的设置*/
        int seconds = 0;
        int minute = 90;
        /**打开控制条*/
        public ControlBar()
        {
            InitializeComponent();
        }

        public void SetTiem(int s)
        {
            Seconds = s;
            seconds = Seconds - ClientControl.paper.ResumeSecond();
            minute = seconds / 60;
            seconds = seconds % 60;
            time.Text = this.minute.ToString() + ":" + this.seconds.ToString();
        }

        public bool Init()
        {
            if (!ClientControl.isResume)
            {
                //初始化日志文件
                XMLControl.CreateLogXML(Config.stuPath);
                XMLControl.WriteLogXML(Config.stuPath, ProblemType.Start, 0, "");
                timer1.Start();
                return true;
            }
            else
            {
                if (XMLControl.LoadLogXML(Config.stuPath))
                {
                    ClientControl.paper.Resume();
                    XMLControl.WriteLogXML(Config.stuPath, ProblemType.Start, 0, "");
                    SetTiem(Seconds);
                    //恢复考试，考试时间恢复！！！！！
                    timer1.Start();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*界面初始位置，如果想做得更用通用性，先获取当前显示屏的分便率，然后设置相应变量,*/
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);
            this.SetDesktopLocation((rect.Width - 530) / 2, 0);//这里的530如果是当前FORM实例的长度就更好了
            /**显示试题窗口的初始位置*/
            ClientControl.MainForm.Show();
            ClientControl.MainForm.SetDesktopLocation((rect.Width - 530) / 5, rect.Height / 9);
            /**去掉整个屏幕的状态栏*/
            // ShowWindow(hTray,1);

            /**显示登录学生的信息，替换接口的地方，要求使用字符串*/
            studentID.Text = ClientControl.student.ID;

            /**显示初始时间*/
            time.Text = this.minute.ToString() + ":" + this.seconds.ToString();
        }


        /**显示隐藏试题按钮*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (ClientControl.MainForm.Visible)
            {
                ClientControl.MainForm.Visible = false;
                butHideMF.Text = "显示试题";
            }
            else
            {
                ClientControl.MainForm.Visible = true;
                butHideMF.Text = "隐藏试题";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds > 0)
            { seconds--; }
            else
            {
                XMLControl.WriteLogXML(Config.stuPath,ProblemType.Blank, 0, "");
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
                    /**这里要调用交卷的事件*/
                    butHandIn_Click(null, null);
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

        public void butHandIn_Click(object sender, EventArgs e)
        {
           
            //ClientControl.MainForm.Dispose();
            //this.Dispose();
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
                        {
                            //生成考生答案xml
                            XMLControl.CreateStudentAnsXML(Config.stuPath, ClientControl.student.ID,ClientControl.paper.paperID);
                            foreach (Problem p in ClientControl.paper.problemList)
                            {
                                XMLControl.studentAnsXML.AddStudentAns(p.type, new Pid_Ans(p.problemId, p.getAns()));
                            }
                            // 
                            ClientControl.WaitingForm.Show();
                            ClientControl.SendInPaper();
                            //提交试题，压缩rar
                            //

                            ClientControl.MainForm.Dispose();
                            this.Dispose();
                            ClientControl.MainForm = null;
                            ClientControl.ControlBar = null;
                        }));
            
        }

    }
}
