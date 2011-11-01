using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using OES.Model;
using System.IO;
using OES.Net;
using OES.DAO;
using ClientNet;

namespace OES
{
    public partial class ExamForm : Form
    {
        
        public ExamForm()
        {
            InitializeComponent();
            ClientEvt.Client.Port.FileReceiveEnd -= Port_FileReceiveEnd;
            ClientEvt.Client.Port.RecieveFileRate -= Port_RecieveFileRate;
            ClientEvt.Client.Port.FileReceiveEnd += new EventHandler(Port_FileReceiveEnd);
            ClientEvt.Client.Port.RecieveFileRate += new ReturnVal(Port_RecieveFileRate);
            
        }

        void Port_RecieveFileRate(double rate)
        {
            ClientControl.ExamForm.progressBar1.Invoke(new MethodInvoker(() =>
            {
                this.progressBar1.Value = (int)(1000 * rate);
            }));
        }

        void Port_FileReceiveEnd(object sender, EventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.Invoke(new MethodInvoker(() =>
            {
                Start.Enabled = true;
                Restart.Enabled = true;
                Resume.Enabled = true;
            }));
            if (RARHelper.Exists())
            {
                RARHelper.UnCompressRAR(Config.paperPath, Config.PaperPath, restore, true, "123456");
            }
            else
            {
                Error.ErrorControl.ShowError(OES.Error.ErrorType.RARNotExist);
            }
        }

        private bool ExistPaper()
        {
            if (Directory.Exists(Config.paperPath ))
            {  
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            //检查是否可以开始考试
            if (!File.Exists(Config.stuPath + "k.key") || !MD5File.CheckMD5("Initial"))
            {
                Error.ErrorControl.ShowError(OES.Error.ErrorType.ExistAnsXML);
            }
            else
            {
                //读考卷内容
                ClientControl.paper.ReadPaper();

                ClientControl.isResume = false;


                ClientControl.ControlBar.Show();
                ClientControl.MainForm.Show();
                this.Dispose();
                ClientEvt.beginExam(0, "");
                MD5File.GenerateSecurityFile("Begin" + ClientControl.student.ID);
            }
         
        }
        string restore="";
        public void ExamForm_Load(object sender, EventArgs e)
        {

            progressBar1.CreateControl();
            this.CreateControl();
            progressBar1.Maximum = 1000;
            Start.Enabled = false;
            Restart.Enabled = false;
            Resume.Enabled = false;

            restore = ClientEvt.Paper;

            Config.paperPath = Config.PaperPath + ClientEvt.Paper.Replace(".rar", "")+ @"\";
            ClientEvt.Paper = Config.PaperPath + ClientEvt.Paper;
            
            if (!ExistPaper())
            {
                if (!Directory.Exists(Config.paperPath)) Directory.CreateDirectory(Config.paperPath);
                ClientEvt.Client.ReceiveFile();
            }
            else
            {
                Start.Enabled = true;
                Restart.Enabled = true;
                Resume.Enabled = true;
                this.progressBar1.Value = 1000;
            }
            
            string temp = restore.Replace(".rar", "");
            ClientControl.paper.paperName = temp;
            this.ExamNo.Text = ClientControl.paper.paperName;
            this.SName.Text = ClientControl.student.sName;
            this.ID.Text = ClientControl.student.ID;
            Config.stuPath = Config.StuPath + ClientControl.student.ID + @"\";

            if (!File.Exists(Config.PaperPath))
            {
                Directory.CreateDirectory(Config.PaperPath);
            }

            if (!File.Exists(Config.StuPath))
            {
                Directory.CreateDirectory(Config.StuPath);
            }
            if (!File.Exists(Config.stuPath))
            {
                Directory.CreateDirectory(Config.stuPath);
            }

            if (!File.Exists(Config.stuPath + "k.key"))
            {
                OES.DAO.MD5File.GenerateSecurityFile("Initial");
            }
        }

        private void Resume_Click(object sender, EventArgs e)
        {
            //检查是否可以恢复考试
            if (!File.Exists(Config.stuPath + "k.key") || !MD5File.CheckMD5("Begin"+ClientControl.student.ID))
            {
                Error.ErrorControl.ShowError(OES.Error.ErrorType.ExistAnsXML);
            }
            else
            {
                //读考卷内容
                ClientControl.paper.ReadPaper();
                ClientControl.isResume = true;
                ClientControl.ControlBar.Show();
                ClientControl.MainForm.Show();
                this.Dispose();
                ClientEvt.beginExam(1,"");
            }

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Directory.Delete(Config.paperPath, true);
            ClientControl.LoginForm.Show();
            ClientEvt.logout();
            this.Dispose();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            ClientControl.TeaPassForm.Show();
            ClientEvt.beginExam(2, "");
            this.Dispose();
        }
    }
}
