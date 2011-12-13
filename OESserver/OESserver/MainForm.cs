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
        //public ProMan proMan;
        public PaperListPanel paperListPanel;
        public PaperEditPanel paperEditPanel;
        public StudentManage studentManage;
        public ClassManage classManage;
        public TeacherManage teacherManage;
        public ScoreManage scoreManage;
        public QuesBankForm quesBankForm;
        public AddQuetionPanel addQuestionPanel;
        public BulkImport bulkImport;
        //public ProManCho proManCho;
              
        public MainForm()
        {
            InitializeComponent();

            paperInfo = new PaperInfo();                 //试卷信息界面
            paperListPanel=new PaperListPanel();      //试卷管理界面
            paperEditPanel=new PaperEditPanel();     //组卷界面
            studentManage=new StudentManage();     //学生管理界面
            classManage=new ClassManage();             //班级管理界面
            teacherManage = new TeacherManage();   //教师管理界面            
            scoreManage=new ScoreManage();           //成绩管理界面
            quesBankForm = new QuesBankForm();     //试题管理界面
            addQuestionPanel = new AddQuetionPanel(); //添加试题界面
            bulkImport = new BulkImport();             //批量导入界面

            MainPanel.Controls.Add(quesBankForm);
            MainPanel.Controls.Add(paperInfo);
            MainPanel.Controls.Add(paperListPanel);            
            MainPanel.Controls.Add(studentManage);
            MainPanel.Controls.Add(classManage);
            MainPanel.Controls.Add(teacherManage);
            MainPanel.Controls.Add(paperEditPanel);
            MainPanel.Controls.Add(scoreManage);
            MainPanel.Controls.Add(addQuestionPanel);
            MainPanel.Controls.Add(bulkImport);

            PanelControl.init(this);
            PanelControl.HideAllPanel();

            PermissionControl();

            this.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);            

        }

        

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