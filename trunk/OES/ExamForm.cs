using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;
using System.IO;
using OES.Net;

namespace OES
{
    public partial class ExamForm : Form
    {
        
        public ExamForm()
        {
            InitializeComponent();
            
        }

        private bool ExistPaper()
        {
            if (Directory.Exists(Config.paperPath + OESClient.fileName.Replace(".rar", "")))
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
            //读考卷内容
            ClientControl.paper.ReadPaper();

            ClientControl.isResume = false;

      
            ClientControl.ControlBar.Show();
            ClientControl.MainForm.Show();
            this.Dispose();
            Program.Client.beginExam(0);
         
        }

        public void JumpToMain(object sender,EventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
                {
                    Start.Enabled = true;
                    Restart.Enabled = true;
                    Resume.Enabled = true;
                }));
            RARHelper.UnCompressRAR(Config.paperPath, Config.paperPath, OESClient.fileName, true, "");
        }
        private void ExamForm_Load(object sender, EventArgs e)
        {

            progressBar1.CreateControl();
            this.CreateControl();
            progressBar1.Maximum = 1000;
            Start.Enabled = false;
            Restart.Enabled = false;
            Resume.Enabled = false;
            if (!ExistPaper())
            {
                Program.Client.RequestingPaper();
            }
            else
            {
                Start.Enabled = true;
                Restart.Enabled = true;
                Resume.Enabled = true;
                this.progressBar1.Value = 1000;
            }

            string temp = OESClient.fileName.Replace(".rar", "");
            Paper.pName = temp;
            this.ExamNo.Text = Paper.pName;
            this.SName.Text = ClientControl.student.sName;
            this.ID.Text = ClientControl.student.ID;
            Config.stuPath = Config.stuPath + ClientControl.student.ID + @"\";

            if (!File.Exists(Config.paperPath))
            {
                Directory.CreateDirectory(Config.paperPath);
            }

            if (!File.Exists(Config.stuPath))
            {
                Directory.CreateDirectory(Config.stuPath);
            }
        }

        private void Resume_Click(object sender, EventArgs e)
        {
            //检查是否可以恢复考试
            if (File.Exists(Config.stuPath + "studentAns.xml"))
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
                Program.Client.beginExam(1);
            }

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            ClientControl.LoginForm.Show();
            Program.Client.logout();
            this.Dispose();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            ClientControl.TeaPassForm.Show();
            Program.Client.beginExam(2);
            this.Dispose();
        }
        public int perPackage = 0;
        public void addProcessBar()
        {
            this.CreateControl();
            this.Invoke(new MethodInvoker(() =>
            {
                if (this.progressBar1.Value + perPackage > 1000)
                {
                    this.progressBar1.Value = 1000;
                }
                else
                {
                    this.progressBar1.Value += perPackage;
                }
            }));
        }
    }
}
