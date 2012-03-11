using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using OES.Model;
using System.IO;
using ServerNet;
using System.Security.Cryptography;
using OES;

namespace OESMonitor
{
    public partial class Computer : UserControl
    {
        private static object syncComputerList = new object();
        private static object syncCompleteList = new object();
        private static object syncErrorList = new object();

        private static List<Computer> computerList = new List<Computer>();

        public static List<Computer> ComputerList
        {
            get 
            {
                lock (syncComputerList)
                {
                    return Computer.computerList; 
                }
            }
            //set { Computer.computerList = value; }
        }

        private static List<Computer> completeList = new List<Computer>();

        public static List<Computer> CompleteList
        {
            get
            {
                lock (syncCompleteList)
                {
                    return Computer.completeList;
                }
            }
            //set { Computer.completeList = value; }
        }
        private static List<Computer> errorList = new List<Computer>();

        public static List<Computer> ErrorList
        {
            get
            {
                lock (syncErrorList)
                {
                    return Computer.errorList;
                }
            }
            //set { Computer.errorList = value; }
        }

        public event ErrorEventHandler OnErrorConnect;

        private int state=0;

        public int State
        {
            get 
            {
                return state; 
            }
            set 
            {
                while (!this.IsHandleCreated) ;
                switch (value)
                {
                    case 0:
                        this.BeginInvoke(new MethodInvoker(() =>
                        { 
                            ico.BackgroundImage = Properties.Resources.s0; 
                            lab.Text = "未启动";
                            
                        }));
                        break;
                    case 1:
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s1;
                            lab.Text = "未登录";
                            
                        }));
                        break;
                    case 2:
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s2;
                            PaperControl.ChangeStudentState(this.Student, ExamState.Login);
                            lab.Text = "已登录";
                            
                        }));
                        break;
                    case 3:
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s3;
                            PaperControl.ChangeStudentState(this.Student, ExamState.Examing);
                            lab.Text = "开始考试";
                            
                        }));
                        break;
                    case 4:
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s4;
                            PaperControl.ChangeStudentState(this.Student, ExamState.HandIn);
                            lab.Text = "已交卷";
                            
                        }));
                        break;
                    case 5:
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s2;
                            PaperControl.ChangeStudentState(this.Student, ExamState.SendPaper);
                            lab.Text = "已发卷";

                        }));
                        break;
                    case 6:
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s3;
                            PaperControl.ChangeStudentState(this.Student, ExamState.ResumeExaming);
                            lab.Text = "恢复考试";

                        }));
                        break;
                    case 7:
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s7;
                            PaperControl.ChangeStudentState(this.Student, ExamState.ApplyRestart);
                            lab.Text = "申请重考";

                        }));
                        break;
                    case 8:
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s3;
                            PaperControl.ChangeStudentState(this.Student, ExamState.RestartExaming);
                            lab.Text = "开始重考";

                        }));
                        break;
                    default:
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s0;
                            lab.Text = "未启动";
                            
                        }));
                        break;
                        

                }
                
                state = value;
                //加入自动收卷事件
                if (state == 3 || state == 6 || state==8)
                {
                    OESMonitor.HandInPaper += this.OESMonitor_HandInPaper;
                }
                else
                {
                    OESMonitor.HandInPaper -= this.OESMonitor_HandInPaper;
                }
            }
        }

        private Client client;

        public Client Client
        {
            get 
            {
                return client; 
            }
            set 
            {
                client = value;
                client.ReceivedTxt += new ClientEventHandel(client_ReceivedTxt);
                client.DisConnect += new EventHandler(client_DisConnect);
                client.ReceiveDataReady += new ClientEventHandel(client_ReceiveDataReady);
            }
        }

        private Random random = new Random(DateTime.Now.Millisecond);

        private string password="";

        public string Password
        {
            get 
            {
                if (password == "")
                {
                    
                   byte[] byt= MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(random.Next(int.MaxValue).ToString().ToCharArray()));
                   for (int i = 0; i < byt.Length; i++)
                   {
                       password += byt[i].ToString("X");
                   }
                }
                return password;
            }
        }

        void client_ReceiveDataReady(Client client, string msg)
        {
            if (!Directory.Exists(PaperControl.PathConfig["StuAns"]))
            {
                Directory.CreateDirectory(PaperControl.PathConfig["StuAns"]);
            }
            client.Port.FilePath = PaperControl.PathConfig["StuAns"] + Student.ID + ".rar";
        }

       
        public void OESMonitor_HandInPaper()
        {
            OESMonitor.HandInCount++;
            Client.SendTxt("oes$5");
        }

        #region 填充client事件

        void client_DisConnect(object sender, EventArgs e)
        {
            if (this.State != 4)
            {
                this.State = 0;
                ErrorList.Add(this);
                Computer.ComputerList.Remove(this);
                OnErrorConnect(this, null);
            }
        }

        void client_ReceivedTxt(Client client, string msg)
        {
            string[] msgs = msg.Split('$');
            if (msgs[0] == "oes")
            {
                switch (msgs[1])
                {
                    case "0":
                        if (client_LoginValidating(msgs[2], msgs[3], msgs[4]))
                        {
                            client.SendTxt("oes$1$1$" + new FileInfo(ExamPaperPath).Name + "$" + ExamPaperName);
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
                    case "4":
                        client.SendTxt("oes$4$"+Password);
                        File.WriteAllText(PaperControl.PathConfig["StuRarKey"] + Student.ID + ".pwd", Password);
                        break;
                    default:
                        break;
                }
            }
        }


        void client_LogoutSuccess()
        {
            this.State = 1;
            this.Student = new Student("", "", "", "");
        }

        void client_LoginSuccess()
        {
            this.State = 2;
        }

        bool client_LoginValidating(string name, string id, string pwd)
        {
            if (File.Exists(PaperControl.PathConfig["StuAns"] + id+".rar")) return false;
            foreach (Computer c in ComputerList)
            {
                if (c.student.ID == id)
                {
                    return false;
                }
            }
            if (PaperControl.OesData.ValidateStudentInfo(id, name, pwd))
            {
                int myPaperId=-1;
                bool needResume=false;

                foreach(Computer c in ErrorList)
                {
                    if(c.Student.ID == id)
                    {
                        needResume=true;
                        ExamPaperPath=c.ExamPaperPath;
                        ExamPaperName = c.ExamPaperName;
                    }
                }
                
                if(!needResume)
                {
                    myPaperId=getCurrentPaper();
                    if (myPaperId == -1) return false;
                    ExamPaperPath = PaperControl.PathConfig["TmpPaper"] + OESMonitor.examPaperIdList[myPaperId].ToString() + ".rar";
                    ExamPaperName = OESMonitor.examPaperNameList[myPaperId];
                }
                
                this.Student = PaperControl.OesData.FindStudentByStudentId(id)[0];//new Student(name, "", id, pwd);
                this.Student.ip = this.Client.ClientIp;
                return true;
            }
            ExamPaperPath = "";
            return false;
        }

        int getCurrentPaper()
        {
            if (OESMonitor.examPaperIdList.Count == 0) return -1;
            switch (OESMonitor.paperDeliverMode)
            {
                case 0://顺序发试卷
                    OESMonitor.currentDeliverId = (OESMonitor.currentDeliverId + 1) % OESMonitor.examPaperIdList.Count;
                    return OESMonitor.currentDeliverId;
                case 1://随机抽取试卷
                    return OESMonitor.random.Next(OESMonitor.examPaperIdList.Count);
                case 2://单一试卷
                    return 0;
            }
            return -1;
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
            client.SendTxt("oes$6$"+PaperControl.TestTime.ToString());
        }

        bool client_ValidateTeaPass(string psw)
        {
            if (psw == PaperControl.PwdConfig["Password"])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private string examPaperPath = "";
        public string ExamPaperPath
        {
            get
            {
                return examPaperPath;
            }
            set
            {
                examPaperPath = value;
            }
        }

        private string examPaperName = "";
        public string ExamPaperName
        {
            get
            {
                return examPaperName;
            }
            set
            {
                examPaperName = value;
            }
        }

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
                StuLabel.BeginInvoke(new MethodInvoker(() => { StuLabel.Text = student.ID; }));
                
            }
        }
        public Computer()
        {
            InitializeComponent();
            
        }

        private void Computer_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Computer c in ComputerList)
            {
                c.BorderStyle = BorderStyle.None;
            }
            foreach (Computer c in CompleteList)
            {
                c.BorderStyle = BorderStyle.None;
            }
            foreach (Computer c in ErrorList)
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

        private void 发送消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.SendTxt("oes$7$" + MessageContent.DisplayDialog());
        }

        private void 重启计算机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PaperControl.AdminConfig["IsAdmin"] == "true")
            {
                client.SendTxt("oes$8");
            }
            else
            {
                MessageBox.Show("您没有该权限！");
            }
        }

        private void 试卷已收到ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.SendTxt("oes$9");
        }
    }
}
