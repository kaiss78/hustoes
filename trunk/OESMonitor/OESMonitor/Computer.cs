using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using OESMonitor.Model;
using System.IO;

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
                client.ReceivedTxt += new global::OESMonitor.Net.ClientEventHandel(client_ReceivedTxt);
                client.DisConnect += new EventHandler(client_DisConnect);
                client.ReceiveDataReady += new global::OESMonitor.Net.ClientEventHandel(client_ReceiveDataReady);
            }
        }

        void client_ReceiveDataReady(global::OESMonitor.Net.Client client, string msg)
        {
            if (!Directory.Exists("D:/" + "EXAM001"))
            {
                Directory.CreateDirectory("D:/" + "EXAM001");
            }
            client.port.FilePath = "D:/" + "EXAM001/"+Student.ID+".rar";
        }

       


        #region 填充client事件

        void client_DisConnect(object sender, EventArgs e)
        {
            if (this.State != 4)
            {
                this.State = 0;
                Computer.Del(this);
            }
        }

        void client_ReceivedTxt(global::OESMonitor.Net.Client client, string msg)
        {
            string[] msgs = msg.Split('$');
            if (msgs[0] == "oes")
            {
                switch (msgs[1])
                {
                    case "0":
                        string paperName="";
                        if (client_LoginValidating(msgs[2], msgs[3], msgs[4], out paperName))
                        {
                            client.SendTxt("oes$1$1$" + paperName);
                            client_LoginSuccess();
                        }
                        else
                        {
                            client.SendTxt("oes$1$0");
                        }
                        break;
                    case "2":
                        switch (msgs[2])
                        {
                            case "0":
                                client_TestStarted(0);
                                break;
                            case "1":
                                client_TestStarted(1);
                                break;
                            case "2":
                                client_TestStarted(2);
                                break;
                            case "3":
                                if (client_ValidateTeaPass(msgs[3]))
                                {
                                    client.SendTxt("oes$2$4");
                                    client_TestStarted(3);
                                }
                                break;
                            default :
                                break;
                        }
                        break;
                    case "3":
                        client_LogoutSuccess();
                        break;
                    default:
                        break;
                }
            }
        }


        void client_LogoutSuccess()
        {
            this.State = 1;
        }

        void client_LoginSuccess()
        {
            this.State = 2;
        }

        bool client_LoginValidating(string name, string id, string pwd,out string paper)
        {
            this.Student = new Student(name, "", id, pwd);
            //if()
            paper = "EXAM001.rar";
                return true;
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

        bool client_ValidateTeaPass(string psw)
        {
            if (psw == "123")
            {
                return true;
            }
            else
            {
                return false;
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
            if (client.ClientIp != "")
            {
                ComputerState.getInstance().setIpPort(client.ClientIp.Split(':')[0], Convert.ToInt32(client.ClientIp.Split(':')[1]));
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
