using System;
using System.Windows.Forms;
using OES.Model;
using OES.UPanel;
using OES.Net;

namespace OES
{
    public partial class MainForm : Form
    {
        public PaperInfo paperInfo;
        public ProMan proMan;
        public PaperListPanel paperListPanel;
        public PaperEditPanel paperEditPanel;
        public StudentManage studentManage;
        public ClassManage classManage;
        public TeacherManage teacherManage;
        public ScoreManage scoreManage;
        public ProManCho proManCho;
              
        public MainForm()
        {
            InitializeComponent();
            proMan = new ProMan();                         //题目管理界面
            paperInfo = new PaperInfo();                 //试卷信息界面
            paperListPanel=new PaperListPanel();      //试卷管理界面
            paperEditPanel=new PaperEditPanel();     //组卷界面
            studentManage=new StudentManage();     //学生管理界面
            classManage=new ClassManage();             //班级管理界面
            teacherManage = new TeacherManage();   //教师管理界面            
            scoreManage=new ScoreManage();           //成绩管理界面
            proManCho=new ProManCho();                 //题目选择界面

            MainPanel.Controls.Add(proMan);
            MainPanel.Controls.Add(paperInfo);
            MainPanel.Controls.Add(paperListPanel);            
            MainPanel.Controls.Add(studentManage);
            MainPanel.Controls.Add(classManage);
            MainPanel.Controls.Add(teacherManage);
            MainPanel.Controls.Add(paperEditPanel);
            MainPanel.Controls.Add(scoreManage);
            MainPanel.Controls.Add(proManCho);

            PanelControl.init(this);
            PanelControl.HideAllPanel();

            PermissionControl();

            this.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

            #region 网络连接状态初始化
            netState1.ReConnect += new EventHandler(netState1_ReConnect);
            netState1.State = 2;
            ClientEvt.Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
            ClientEvt.Client.DisConnectError += new System.IO.ErrorEventHandler(Client_DisConnectError);
            InfoControl.ClientObj.Init();
            #endregion

        }

        #region 网络连接状态
        void Client_DisConnectError(object sender, System.IO.ErrorEventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                netState1.State = 0;
            }));
        }

        void Client_ConnectedServer(object sender, EventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                netState1.State = 1;
            }));
        }

        void netState1_ReConnect(object sender, EventArgs e)
        {
            if (netState1.State == 0)
            {
                ClientEvt.Client.InitializeClient();
            }
            else
            {
                netState1.State = 0;
            }
        }
        #endregion

        //权限控制，根据登录用户的权限，设置不同的功能显示
        void PermissionControl()
        {
            int permission = InfoControl.User.permission;
            if (permission == 1) { return; }    //管理员拥有所有权限
            techManlbl.Visible = false;
            //以下是对普通用户的功能屏蔽
            classManage.ForbidFunction();
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {            
            InfoControl.LoginForm.Show();
        }        

        private void Lbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   
            PanelControl.ChangPanel(Convert.ToInt32(((LinkLabel)sender).Tag));         
        }
    }
}