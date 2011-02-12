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
    public partial class Computer : UserControl
    {
        private static List<Computer> computerList = new List<Computer>();

        public static List<Computer> ComputerList
        {
            get { return Computer.computerList; }
            //set { Computer.computerList = value; }
        }
       
        private int state=0;

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
                        this.Invoke(new MethodInvoker(() =>
                        { 
                            ico.BackgroundImage = Properties.Resources.s0; 
                            lab.Text = "未启动";
                            
                        }));
                        break;
                    case 1:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s1;
                            lab.Text = "未登录";
                            
                        }));
                        break;
                    case 2:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s2;
                            lab.Text = "已登录";
                            
                        }));
                        break;
                    case 3:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s3;
                            lab.Text = "开始考试";
                            
                        }));
                        break;
                    case 4:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s4;
                            lab.Text = "已交卷";
                            
                        }));
                        break;
                    case 5:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s2;
                            lab.Text = "已发卷";

                        }));
                        break;
                    case 6:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s3;
                            lab.Text = "恢复考试";

                        }));
                        break;
                    case 7:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s7;
                            lab.Text = "申请重考";

                        }));
                        break;
                    case 8:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s3;
                            lab.Text = "开始重考";

                        }));
                        break;
                    default:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s0;
                            lab.Text = "未启动";
                            
                        }));
                        break;
                        

                }
                
                state = value; 
            }
        }
        private Net.Client client;

        public Net.Client Client
        {
            get 
            {
                return client; 
            }
            set 
            {
                client = value;
                client.TestStarted += new global::OESMonitor.Net.Client.StartTest(client_TestStarted);
                client.LoginValidating += new global::OESMonitor.Net.Client.ValidateLogin(client_LoginValidating);
                client.LoginSuccess += new global::OESMonitor.Net.Client.SimpleFun(client_LoginSuccess);
                client.ClientCrashed += new global::OESMonitor.Net.Client.SimpleFun(client_ClientCrashed);
                client.AnswerHanded += new global::OESMonitor.Net.Client.SimpleFun(client_AnswerHanded);
                client.PaperDelivered += new global::OESMonitor.Net.Client.SimpleFun(client_PaperDelivered);
                client.AnswerHanding += new global::OESMonitor.Net.Client.SimpleFun(client_AnswerHanding);
                client.PaperDelivering += new global::OESMonitor.Net.Client.SimpleFun(client_PaperDelivering);
                client.LogoutSuccess += new global::OESMonitor.Net.Client.SimpleFun(client_LogoutSuccess);
            }
        }

        #region 填充client事件
        void client_PaperDelivering()
        {
            //this.Client.paperPath=
        }

        void client_LogoutSuccess()
        {
            this.State = 1;
        }

        void client_AnswerHanding()
        {
            this.Client.fileName = this.Student.ID + ".rar";
        }

        void client_PaperDelivered()
        {
            this.State = 5;
        }

        void client_AnswerHanded()
        {
            this.State = 4;
        }

        void client_ClientCrashed()
        {
            if (this.State != 4)
            {
                this.State = 0;
                Computer.Del(this);
            }
        }

        void client_LoginSuccess()
        {
            this.State = 2;
        }

        bool client_LoginValidating(string name, string id, string pwd)
        {
            this.Student = new Student(name, "", id, pwd);
            //if()
                return false;
        }

        void client_TestStarted(int reason)
        {
            switch (reason)
            {
                case 0:
                    this.State = 3;
                    break;
                case 1:
                    this.State = 6;
                    break;
                case 2:
                    this.State = 7;
                    break;
                case 3:
                    this.State = 8;
                    break;
            }
        }

        #endregion

        private Student student = new Student("", "", "", "");

        public Student Student
        {
            get 
            {
                return student; 
            }
            set 
            { 
                student = value;
                StuLabel.Invoke(new MethodInvoker(() => { StuLabel.Text = student.ID; }));
                
            }
        }
        public Computer()
        {
            InitializeComponent();
            
        }

        private void Computer_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Computer c in computerList)
            {
                c.BorderStyle = BorderStyle.None;
            }
            this.BorderStyle = BorderStyle.FixedSingle;
            ComputerState.getInstance().setStudent(student);
            ComputerState.getInstance().setState(lab.Text);
            if (client.clientInfo() != "")
            {
                ComputerState.getInstance().setIpPort(client.clientInfo().Split(':')[0], Convert.ToInt32(client.clientInfo().Split(':')[1]));
            }
            else
            {
                ComputerState.getInstance().setIpPort("已离开", 0);
            }
        }
        public static void Add(Computer c)
        {
            computerList.Add(c);
        }
        public static void Del(Computer c)
        {
            computerList.Remove(c);
        }
    }
}
